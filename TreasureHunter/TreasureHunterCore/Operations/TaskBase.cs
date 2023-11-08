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

using TreasureHunterCore.Administrative;
using TreasureHunterCore.Views;

namespace TreasureHunterCore.Operations
{
    internal abstract class TaskBase
    {
        // A task is an operation that the application invokes to change it's state
        private static uint _taskCounter = 0;

        private readonly uint _taskId;
        private readonly TreasureHunterApp _app;
        private ViewBase _view;
        private int _status;

        protected List<Action> _preRunCallbacks;
        protected List<Action> _postRunCallbacks;

        protected TaskBase(
            TreasureHunterApp app)
        {
            // Constructor
            _taskId = TaskCounter;
            _app = app;
            _view = null;
            _status = 0;

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

        public int Status
        {
            // Get or set the Task's status
            get { return _status; }
            protected set { _status = value; }
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
            ExecutePreRunCallbacks();
            RunBody();
            ExecutePostRunCallbacks();
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



    }
}
