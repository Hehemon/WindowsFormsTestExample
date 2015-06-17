using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NLog;

namespace WindowsFormsTestApplication
{
    public partial class ProcessesMainForm : Form
    {
        public ProcessesMainForm()
        {
            InitializeComponent();
            _updater = UpdateViewListInUiThread;
        }

        private delegate void UpdateListViewDelegate(IEnumerable<ProcessInfo> current);
        private readonly UpdateListViewDelegate _updater;

        /// <summary>
        /// Get event from ProcessManager
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void UpdateViewList(object sender, ProcessUpdateEventArgs e)
        {
            this.Invoke(_updater, e.ProcessData); 
        }

        /// <summary>
        /// Update ListView data
        /// </summary>
        /// <param name="list">Current processes</param>
        private void UpdateViewListInUiThread(IEnumerable<ProcessInfo> list)
        {
            lvProcesses.BeginUpdate();
            try
            {
                lvProcesses.Clear();
                foreach (var item in list)
                {
                    lvProcesses.Items.Add(new ListViewItem(new[] {item.FriendlyName, item.Id.ToString()}));
                }
                btnDetails.Enabled = lvProcesses.SelectedItems.Count > 0;
            }
            catch (Exception e)
            {
                LogManager.GetCurrentClassLogger().Error("Updating ListView error: {0}, {1}", e.Message, e.StackTrace);
            }
            finally
            {
                lvProcesses.EndUpdate();
            }
        }

        /// <summary>
        /// Enable/Disable details button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lvProcesses_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnDetails.Enabled = lvProcesses.SelectedItems.Count > 0;
        }

        /// <summary>
        /// Start/stop updating list view
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStartStop_Click(object sender, EventArgs e)
        {
            ProcessManager.I.ChangeState();
            btnStartStop.Text = ProcessManager.I.CurrentState ? "Stop" : "Start";
        }

        /// <summary>
        /// Set startup form state
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_Load(object sender, EventArgs e)
        {
            ProcessManager.I.OnProcessUpdate += UpdateViewList;
            btnStartStop.Text = ProcessManager.I.CurrentState ? "Stop" : "Start";
            btnDetails.Enabled = lvProcesses.SelectedItems.Count > 0;
        }

        /// <summary>
        /// Unsubscribe from messages
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            ProcessManager.I.OnProcessUpdate -= UpdateViewList;
        }

        private void lvProcesses_DoubleClick(object sender, EventArgs e)
        {

        }
    }
}
