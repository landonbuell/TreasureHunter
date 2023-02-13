/*
 * Repository:      TreasureHunter
 * Solution:        TreatureHunter
 * Project:         TreasureHunterCore
 * Namespace:       Views
 * 
 * File:            BaseView.cs
 * Author:          Landon Buell
 * Date:            Feb 2023 
 */

using TreasureHunterCore.Core;

namespace TreasureHunterCore.Views
{
    internal class BaseView
    {
        // A View is a "menu" or "window" that Accepts User Input
        private string _viewName;
        private string _viewTitle;
        private string[] _viewDescription;
        private ViewAction[] _actions;


        protected BaseView(
            string viewName)
        {
            // Constructor for
            
        }

        #region Getters and Setters

        public string ViewName
        {
            // Get the Name of this View
            get { return _viewName; }
        }

        #region Public Interface

        public void ShowView()
        {
            // Print this View To Console
            return;
        }


        #endregion

        #region Protected Interface

        #endregion

        #region Private Interface

        #endregion




    }
}
