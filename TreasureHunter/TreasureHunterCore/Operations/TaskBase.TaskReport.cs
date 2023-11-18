/*
 * Repository:      TreasureHunter
 * Solution:        TreatureHunter
 * Project:         TreasureHunterCore
 * Namespace:       Views
 * 
 * File:            TaskBase.cs
 * Author:          Landon Buell
 * Date:            Nov 2023 
 */

using System.Text;

namespace TreasureHunterCore.Operations
{
    internal partial class TaskBase
    {
        // A task is an operation that the application invokes to change it's state

        public enum TaskStatus
        {
            NO_ERROR = 0,
            WARNING_MINOR = 1,
            WARNING_MAJOR = 2,
            ERROR   = 3,
        }

        internal struct TaskReport
        {
            // Stores Report Meta-data
            private DateTime _timeStart;
            private DateTime _timeFinish;
            private TaskStatus _status;
            private StringBuilder _message;

            internal TaskReport(TaskStatus initStatus)
            {
                // Constructor
                _timeStart = DateTime.MinValue;
                _timeFinish = DateTime.MinValue; 
                _status = initStatus;
                _message = new StringBuilder();
            }

            public DateTime TimeStart
            {
                // Get or set the start time
                get { return _timeStart; }
                set { _timeStart = value; }
            }

            public DateTime TimeFinish
            {
                // Get or set the finish time
                get { return _timeFinish; }
                set { _timeFinish = value; }
            }
            
            public TaskStatus Status
            {
                // Get or set the status
                get { return _status; }
                set { _status = value; }
            }

            public void AppendLine(string line)
            {
                // Append a string to the Report's message
                _message.AppendLine(line);
                return;
            }

            public string GetMessage()
            {
                // Get the report's message
                return _message.ToString();
            }
        }
    }
}
