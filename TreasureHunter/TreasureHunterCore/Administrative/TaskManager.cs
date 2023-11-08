/*
 * Repository:      TreasureHunter
 * Solution:        TreatureHunter
 * Project:         TreasureHunterCore
 * Namespace:       Administrative
 * 
 * File:            TaskManager.cs
 * Author:          Landon Buell
 * Date:            November 2023 
 */

using TreasureHunterCore.Operations;

namespace TreasureHunterCore.Administrative
{
    internal class TaskManager : Manager
    {
        // Organizes Tasks that the application is currently running
        private static readonly string TASK_MANAGER = "TaskManager";
        private static readonly int MAX_QUEUE_SIZE = 1024;

        private LinkedList<TaskBase> _queue;
        private LinkedListNode<TaskBase> _currentTask;

        private int[] _taskCounters;

        internal TaskManager(
            TreasureHunterApp app) :
            base(app, TASK_MANAGER)
        {
            // Constructor
            _queue = new LinkedList<TaskBase>();
            _currentTask = null;
            _taskCounters = new int[2];
        }

        ~TaskManager()
        {
            // Destructor
            _queue.Clear();
        }

        #region Accessors

        public TaskBase CurrentTask
        {
            // Get or set the current task
            get { return _currentTask.ValueRef; }
        }

        public int TasksQueued
        {
            // Get the number of tasks queued
            get { return _taskCounters[0]; }
            private set { _taskCounters[0] = value; }
        }

        public int TasksCompleted
        {
            // Get the number of tasks completed
            get { return _taskCounters[1]; }
            private set { _taskCounters[1] = value; }
        }

        public int QueueSize
        {
            // Get the number of items currently in the Queue
            get { return _queue.Count; }
        }



        #endregion

        #region Public Interface

        public void EnqueueTask( TaskBase newTask)
        {
            // Enqueue a new task to the Task Manager
            if (QueueSize >= MAX_QUEUE_SIZE)
            {
                RemoveOldest();
            }
            _queue.AddLast(newTask);
            TasksQueued += 1;
            if (QueueSize == 1)
            {
                _currentTask = _queue.First;
            }
            return;
        }

        public void NextTask()
        {
            // Move to the next task
        }

        public int ExecuteCurrentTask()
        {
            if (_currentTask == null)
            {
                // Not task set
                return -1;
            }
            // Otherwise ...
            _currentTask.Value.Run();
            return _currentTask.Value.Status;
        }

        public bool IsEmpty()
        {
            // Get T/F if the queue is empty
            return (_queue.Count == 0);
        }

        public bool IsFull()
        {
            // Get T/F if the queue is empty
            return (_queue.Count >= MAX_QUEUE_SIZE);
        }

        #endregion

        #region Private Interface

        public void RemoveOldest()
        {
            // Remove the oldest view in the chain
            if (QueueSize > 0)
            {
                _queue.RemoveFirst();
            }
            if (QueueSize == 0)
            {
                _currentTask = null;
            }
            return;
        }

        public void RemoveNewest()
        {
            // Remove the latest view in the chain
            if (QueueSize > 0)
            {
                _queue.RemoveLast();
            }
            if (QueueSize == 0)
            {
                _currentTask = null;
            }
            return;
        }

        #endregion


    }


}
