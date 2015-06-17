using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsTestApplication
{
    /// <summary>
    /// Managing process data class
    /// </summary>
    public class ProcessManager
    {
        protected IEnumerable<Process> Processes { get; set; } 

        public ProcessManager()
        {
            Processes = new List<Process>(0);
        }

        /// <summary>
        /// Asynchronuos
        /// </summary>
        public void Tick()
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
