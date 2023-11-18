/*
 * Repository:      TreasureHunter
 * Solution:        TreatureHunter
 * Project:         TreasureHunterCore
 * Namespace:       Operations
 * 
 * File:            TaskBase.cs
 * Author:          Landon Buell
 * Date:            Nov 2023 
 */

using TreasureHunterCore.Administrative;
using TreasureHunterCore.Views;

namespace TreasureHunterCore.Operations
{
    internal partial class TaskBase
    {
        // A task is an operation that the application invokes to change it's state
        private static uint _taskCounter = 0;

        private readonly uint _taskId;
        private readonly TreasureHunterApp _app;
        private ViewBase _view;
        private TaskReport _report;

        protected List<Action> _preRunCallbacks;
        protected List<Action> _postRunCallbacks;

        internal TaskBase(
            TreasureHunterApp app)
        {
            // Constructor
            _taskId = TaskCounter;
            _app = app;
            _view = new PlaceholderView(app);
            _report = new TaskReport(TaskStatus.NO_ERROR);

            _preRunCallbacks = new List<Action>();
            _postRunCallbacks = new List<Action>();

            if (app.Settings.IsDebugMode == true)
            {
                RegisterDebugCallbacks();
            }

            TaskCounter += 1;
        }

        ~TaskBase()
        {
            // Destructor
        }

        #region Accessors

        public uint TaskIdentifier
        {
            // Return the Task's ID
            get { return _taskId; }
        }

        protected TreasureHunterApp App
        {
            // Return the Parent application
            get { return _app; }
        }

        protected ViewBase View
        {
            // Get or Set the current View
            get { return _view; }
            set { _view = value; }
        }

        public TaskStatus Status
        {
            // Get or set the Task's status
            get { return _report.Status; }
            protected set { _report.Status = value; }
        }

        public string GetReportMessage()
        {
            // Get the Report's Message
            return _report.GetMessage();
        }

        public DateTime TaskStartTime
        {
            // Get or set the start time
            get { return _report.TimeStart; }
            private set { _report.TimeStart = value; }
        }

        public DateTime TaskFinishTime
        {
            // Get or set the finish time
            get { return _report.TimeFinish; }
            private set { _report.TimeFinish = value; }
        }

        public static uint TaskCounter
        {
            // Get or set the task counter
            get { return _taskCounter; }
            private set { _taskCounter = value; }
        }

        #endregion

        #region Public Interface

        public void Run()
        {
            // Execute this Task
            TaskStartTime = DateTime.Now;
            ExecutePreRunCallbacks();
            RunBody();
            ExecutePostRunCallbacks();
            TaskFinishTime = DateTime.Now;
            LogReport();
            return;
        }

        public static bool IsNullTask(TaskBase task)
        {
            // Return T/F if the provided task is of NULL type
            return ((task == null) || (task.GetType() == typeof(TaskNull)));
        }

        #endregion

        #region Protected Interface

        protected virtual void RunBody()
        {
            // Body of the 'Run' method - to be overridden;
            return;
        }


        protected virtual void RegisterDebugCallbacks()
        {
            // Register any pre/post run callbacks
            return;
        }


        protected void ExecutePreRunCallbacks()
        {
            // Invoke all of the pre-run callbacks
            foreach (Action action in _preRunCallbacks)
            {
                action.Invoke();
            }
            return;
        }

        protected void ExecutePostRunCallbacks()
        {
            // Invoke all of the pre-run callbacks
            foreach (Action action in _postRunCallbacks)
            {
                action.Invoke();
            }
            return;
        }

        #endregion

        #region Private Interface

        private void LogReport()
        {
            // Log the Task Completion Report to the app Logger
            // TODO: THIS!
            return;
        }

        #endregion

    }
}
