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
            lvProcesses.Items.Clear();
            foreach (var item in list)
            {
                lvProcesses.Items.Add(new ListViewItem(new[] {item.FriendlyName, item.Id.ToString()}));
            }
            lvProcesses.EndUpdate();
        }

        private void lvProcesses_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnStartStop_Click(object sender, EventArgs e)
        {

        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            ProcessManager.I.OnProcessUpdate += UpdateViewList;
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            ProcessManager.I.OnProcessUpdate -= UpdateViewList;
        }

        private void lvProcesses_DoubleClick(object sender, EventArgs e)
        {

        }
    }
}
