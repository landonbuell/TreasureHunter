/*
 * Repository:      TreasureHunter
 * Solution:        TreatureHunter
 * Project:         TreasureHunterCore
 * Namespace:       Administrative
 * 
 * File:            TreasureHunterApp.cs
 * Author:          Landon Buell
 * Date:            Feb 2023 
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TreasureHunterCore.Views;

namespace TreasureHunterCore.Administrative
{
    internal class ViewManager : Manager
    {
        // Governs the Currently Active View and Accepts User Input
        private static readonly string VIEW_MANAGER = "View Manager";

        private bool _isLocked;
        private BaseView _currentView;
        

        internal ViewManager(
            TreasureHunterApp app) :
            base(app, VIEW_MANAGER)
        {
            // Constructor
            _isLocked = true;
            _currentView = new StartupView();            
        }

        ~ViewManager()
        {
            // Destructor
            
        }


        #region Getters and Setters

        public BaseView CurrentView
        {
            // Get or Set the Current View
            get { return _currentView; }
            private set { _currentView = value; }
        }

        public bool IsLocked
        {
            // Return T/F If the instance is locked
            get { return _isLocked; }
            private set { _isLocked = value; }
        }

        #endregion

        #region Public Interface

        public static void ClearConsole()
        {
            // Clear the Console
            Console.Clear();
            return;
        }

        public bool SwitchToView(BaseView view)
        {
            // Switch to a new View if it is not Null
            return SwitchToViewHelper(view);
        }

        public void ShowCurrentView()
        {
            // Show the Current View to Console
            _currentView.ShowView();
            return;
        }

        public void ExecuteAction(int actionIndex)
        {
            // Execute the Action Prescribed by the Index
            if (actionIndex < 0 || actionIndex >= _currentView.NumActions)
            {
                // Action Index is Out of Range
                string message = String.Format(
                    "Action Index {0} is out of range for view {1} w/ {2} possible actions",
                    actionIndex, _currentView.ViewName, _currentView.NumActions);
                App.LogMessage(message, TextLogger.LogLevel.WARNING);
                return;
            }
            // Execute the Action
            _currentView.InvokeAction(actionIndex);
            return;
        }

        #endregion

        #region Private Interface

        private bool SwitchToViewHelper(BaseView view)
        {
            // Helper to Change Views
            if (IsLocked == true)
            {
                string message = String.Format("ViewManager: Cannot switch view to {0} while locked",
                    view.ViewName);
                App.LogMessage(message, TextLogger.LogLevel.WARNING);
                return false;
            }
            if (view == null)
            {
                string message = "ViewManager: Not switching to null view";
                App.LogMessage(message, TextLogger.LogLevel.WARNING);
                return false;
            }
            else
            {
                string message = String.Format("ViewManager: switching to {0} view",view.ViewName);
                App.LogMessage(message, TextLogger.LogLevel.INFO);
                CurrentView = view;
                return true;
            }
        }

        #endregion
    }

}
