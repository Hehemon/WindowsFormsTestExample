using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace WindowsFormsTestApplication
{
    /// <summary>
    /// Managing process data class
    /// </summary>
    public class ProcessManager
    {
        /// <summary>
        /// Previous process data
        /// </summary>
        protected IEnumerable<Process> Processes { get; set; }

        /// <summary>
        /// Timer for updating in different thread
        /// </summary>
        protected Timer UpdatingTimer { get; set; }

        /// <summary>
        /// Constructor 
        /// </summary>
        /// <param name="startUpdating">if start updating process at the begging</param>
        /// <param name="interval">update interval</param>
        public ProcessManager(bool startUpdating = true, int interval = 1000)
        {
            Processes = new List<Process>(0);
            UpdatingTimer = new Timer();
            UpdatingTimer.Elapsed += OnTimedEvent;
            UpdatingTimer.Interval = interval;

            if (startUpdating)
            {
                UpdatingTimer.Enabled = true;
            }
        }

        /// <summary>
        /// Asynchronouos way
        /// </summary>
        protected void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            var newProcesses = GetCurrentProcessesData();
            LogClosedProcesses(newProcesses);
            LogNewProcesses(newProcesses);
            lock (this)
            {
                Processes = newProcesses.ToList();
            }
        }

        /// <summary>
        /// Log information about new processes
        /// </summary>
        /// <param name="data">Current state of processes</param>
        protected void LogNewProcesses(IEnumerable<Process> data)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Log information about closed processes
        /// </summary>
        /// <param name="data">Current state of processes</param>
        protected void LogClosedProcesses(IEnumerable<Process> data)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets current processes in system
        /// </summary>
        /// <returns>Collection of processes</returns>
        protected static IEnumerable<Process> GetCurrentProcessesData()
        {
            return Process.GetProcesses();
        }
    }
}
