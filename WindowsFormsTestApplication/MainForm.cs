using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NLog;

namespace WindowsFormsTestApplication
{
    public partial class MainForm : Form
    {

        public MainForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Get event from ProcessManager
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void UpdateViewList(object sender, ProcessUpdateEventArgs e)
        {
            LogManager.GetCurrentClassLogger().Info("Updating List View");
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
    }
}
