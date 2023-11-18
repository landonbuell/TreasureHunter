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
        private static readonly string NULL_TASK_ID = "NULL_TASK_ID";
        private static readonly int MAX_QUEUE_SIZE = 1024;

        private LinkedList<TaskBase> _taskQueue;
        private LinkedListNode<TaskBase>? _taskNode;
        private int[] _taskCounters;

        internal TaskManager(
            TreasureHunterApp app) :
            base(app, TASK_MANAGER)
        {
            // Constructor
            _taskQueue = new LinkedList<TaskBase>();
            _taskNode = null;

            _taskCounters = new int[2];
        }



        ~TaskManager()
        {
            // Destructor
            _taskQueue.Clear();
            _taskNode = null;
        }

        #region Accessors

        public bool CurrentTaskValid
        {
            // Return T/F if the current task is valid
            get { return _taskNode != null; } 
        }
   
        public int TotalTasksQueued
        {
            // Get the number of tasks queued
            get { return _taskCounters[0]; }
            private set { _taskCounters[0] = value; }
        }

        public int TotalTasksCompleted
        {
            // Get the number of tasks completed
            get { return _taskCounters[1]; }
            private set { _taskCounters[1] = value; }
        }

        #endregion

        #region Public Interface

        public bool ExecuteCurrentTask()
        {
            // Assume Current Task is valid and execute it?
            if (_taskNode == null)
            {
                // No Current task
                return false;
            }
            _taskNode.ValueRef.Run();
            return true;
        }

        public void Clear()
        {
            // Clears all Tasks from the Queue
            _taskQueue.Clear();
            _taskNode = null;
            return;
        }

        public void Enqueue(TaskBase task)
        {
            // Enqueue An Element to the Queue
            if (_taskQueue.Count >= MAX_QUEUE_SIZE)
            {
                // Queue Full, remove the oldest node
                RemoveOldest();
            }
            // Add as the LAST node
            _taskQueue.AddLast(task);
            TotalTasksQueued += 1;
            return;
        }

        public void EnqueueImmediate(TaskBase task)
        {
            // Enqueue an item Immediately after the current task
            if (_taskQueue.Count >= MAX_QUEUE_SIZE)
            {
                // Queue Full, remove the oldest node
                RemoveOldest();
            }
            if (_taskNode == null)
            {
                // If not current task: add it to front
                _taskQueue.AddFirst(task);
            }
            else
            {
                // If so, add after current task
                _taskQueue.AddAfter(_taskNode, task);
            }
            TotalTasksQueued += 1;
            return;
        }

        public TaskBase? Peek()
        {
            // Get a reference to the item at the front of the Queue
            if (_taskNode == null) { return null; }
            return _taskNode.Value;
        }

        public bool MoveToNextTask()
        {
            // Move to the next Task without executing, Return T/F if successful
            if (_taskNode == null)
            {
                // No Current Task
                MoveToNextNoCurrentTask();
            }
            else
            {
                // Valid Current Task
                MoveToNextFromCurrentTask();
            }
            return CurrentTaskValid;
        }

        public bool MoveToPrevTask(int numTasks)
        {
            // Move some number of tasks backward, Return T/F if successful
            if (_taskNode == null)
            {
                // No Current Task
                MoveToPrevFromNoCurrentTask();
            }
            else
            {
                // Valid Current Taks
                MoveToPrevFromCurrentTaks(numTasks);
            }
            return CurrentTaskValid;
        }


        #endregion

        #region Private Interface

        private void RemoveOldest()
        {
            // Remove the oldest node in the queue
            if (_taskQueue.Count == 0) { return; }
            if (_taskQueue.Count == 1) { _taskQueue.Clear(); }
            _taskQueue.RemoveFirst();
            return;
        }

        private void SetNewCurrentTask(LinkedListNode<TaskBase>? newTaskNode)
        {
            // Set the ew current task
            string prevTaskID = NULL_TASK_ID;
            string currTaskID = NULL_TASK_ID;
            if (_taskNode != null)
            {
                prevTaskID = Convert.ToString(_taskNode.Value.TaskIdentifier);
            }
            if (newTaskNode != null)
            {
                currTaskID = Convert.ToString(newTaskNode.Value.TaskIdentifier);
            }
            string message = string.Format("Setting new task: {0} -> {1}",prevTaskID,currTaskID);
            LogMessage(message, TextLogger.LogLevel.INFO);
            _taskNode = newTaskNode;
            return;

        }

        private void MoveToNextNoCurrentTask()
        {
            // Move to "Next" Task when there is no current taks
            if (_taskQueue.Count == 0) 
            {
                // No Tasks at all, nothing we can do
                return;
            }
            // There are tasks, get the latest one
            SetNewCurrentTask(_taskQueue.Last);
            return;
        }

        private void MoveToNextFromCurrentTask()
        {
            // Move to "Next" Task when there IS a current task
            if (_taskQueue.Count == 0)
            {
                // No Tasks at all, nothing we can do
                SetNewCurrentTask(null);
            }
            // There are some tasks, see if any are left to be run         
            if (_taskNode == _taskQueue.Last)
            {
                // There are NO MORE tasks to run
                SetNewCurrentTask(null);
            }
            else
            {
                // There ARE tasks to be run
                // To get here, where KNOW _taskNode is not null
                SetNewCurrentTask(_taskNode.Next);
            }
            return;            
        }

        private void MoveToPrevFromNoCurrentTask()
        {
            // Move to Previus task if invalid current task
            if (_taskQueue.Count == 0)
            {
                // No tasks at all, nothing we can do
                SetNewCurrentTask(null);
                return;
            }
            // There are tasks, just get the oldest one
            SetNewCurrentTask(_taskQueue.First);
            return;
        }

        private void MoveToPrevFromCurrentTaks(int numTasks)
        {
            // Move back "numTasks" times when there is a current task
            // NOT IMPLEMENTED
            return;
        }

        #endregion

    }


}
