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
        private LinkedListNode<TaskBase>? _front;

        private int[] _taskCounters;

        internal TaskManager(
            TreasureHunterApp app) :
            base(app, TASK_MANAGER)
        {
            // Constructor
            _queue = new LinkedList<TaskBase>();
            _front = new LinkedListNode<TaskBase>(new TaskNull(app));
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
            get 
            { 
                if (FrontIsValid == false) { return null; }
                return _front.ValueRef;
            }
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

        public bool FrontIsValid
        {
            // Return T/F if the front of the queue is not null
            get { return !TaskBase.IsNullTask(_front.ValueRef); }
        }

        #endregion

        #region Public Interface

        public void Enqueue( TaskBase newTask)
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
                _front = _queue.First;
            }
            return;
        }

        public void EnqueueImmediate(TaskBase newTask)
        {
            // Enque an new task IMMEDIATELY after the current task
            if (_queue.Count == 0)
            {
                // is empty, just add to the front of the DLL
                _queue.AddFirst(newTask);
                return;
            }
            if (_front == null)
            {
                // No front? Just add to the end of the DLL
                _queue.AddLast(newTask);
                return;
            }
            // Otherwise, add after current
            _queue.AddAfter(_front, newTask);
            return;
        }

        public bool MoveToNext()
        {
            // Move to the next task
            if (_queue.Count == 0)
            {
                // Empty Queue - cannot move
                return false;
            }
            if (_front == null)
            {
                // No front? Just move to first item
                _front = _queue.First;
            }
            else
            {
                // Front set, move to next
                _front = _front.Next;
                return (_front != null);
            }
            return true;
        }

        public int ExecuteCurrentTask()
        {
            return ExecuteCurrentTask(_front);
        }

        public int ExecuteCurrentTask(LinkedListNode<TaskBase>? _front)
        {
            if ( FrontIsValid == false)
            {
                // Not task set
                return -1;
            }

            _front.Value.Run();
            return (int)_front.Value.Status;
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
                _front = null;
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
                _front = null;
            }
            return;
        }

        #endregion


    }


}
