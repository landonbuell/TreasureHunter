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

using TreasureHunterCore.Views;

namespace TreasureHunterCore.Administrative
{
    internal class ViewManager : Manager
    {
        // Governs the Currently Active View and Accepts User Input
        private static readonly string VIEW_MANAGER = "ViewManager";

        private ViewBase _view;
        private bool _locked;

        internal ViewManager(
            TreasureHunterApp app) :
            base(app, VIEW_MANAGER)
        {
            // Constructor
            _view = new PlaceholderView(App);
            _locked = false;    
        }

        ~ViewManager()
        {
            // Destructor
            _locked = false;
        }

        #region Getters and Setters

        public ViewBase CurrentView
        {
            // Get the current View
            get { return _view; }
            private set { _view = value; } 
        }

        public bool IsLocked
        {
            // Return T/F if the current view is locked
            get { return _locked; }
            private set { _locked = value; }
        }

        #endregion

        #region Public Interface

        public static void ClearConsole()
        {
            // Clear the Console
            Console.Clear();
            return;
        }

        public void DrawCurrentView()
        {
            // Show the Current View to Console
            if (App.Settings.ClearConsole == true)
            {
                ClearConsole();
            }
            // TODO; Implement this
            return;
        }



        #endregion

        #region Private Interface

        

        #endregion
    }

}
