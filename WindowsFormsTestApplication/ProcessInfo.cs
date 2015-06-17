using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsTestApplication
{
    /// <summary>
    /// Class for storing default info of process
    /// </summary>
    public class ProcessInfo : IEquatable<ProcessInfo>, ICloneable
    {
        public readonly int Id;
        public readonly string FriendlyName;
        public bool Removed { get; protected set; }

        public ProcessInfo(int id, string friendlyName)
        {
            Id = id;
            FriendlyName = friendlyName;
        }

        /// <summary>
        /// Remove this process from list
        /// </summary>
        public void Remove()
        {
            Removed = true;
        }

        public bool Equals(ProcessInfo other)
        {
            if (other == null) return false;
            return Id == other.Id &&
                   FriendlyName == other.FriendlyName;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as ProcessInfo);
        }

        public override int GetHashCode()
        {
            // It's unique for each process
            return Id;
        }

        public override string ToString()
        {
            return string.Format("{0}, {1}", FriendlyName, Id);
        }

        public object Clone()
        {
            return MemberwiseClone();
        }
    }
}
