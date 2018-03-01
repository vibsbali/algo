using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Algorithms.PriorityQueue
{
    public class Data
        : IComparable<Data>
    {
        readonly DateTime _creationTime;
        public Data(string message, int priority = 0)
        {
            _creationTime = DateTime.UtcNow;
            Message = message;
            Priority = priority;
        }

        public string Message { get; }

        public int Priority { get; }

        public TimeSpan Age => DateTime.UtcNow.Subtract(_creationTime);

        public int CompareTo(Data other)
        {
            if (other == null)
            {
                throw new NullReferenceException("other object passed in is null");
            }
            var pri = Priority.CompareTo(other.Priority);
            if (pri == 0)
            {
                pri = Age.CompareTo(other.Age);
            }

            return pri;
        }

        public override string ToString()
        {
            return string.Format("[{0} : {1}] {2}", Priority, Age.Milliseconds, Message);
        }
    }
}
