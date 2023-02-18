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

using System.Text;

using TreasureHunterCore.Core;

namespace TreasureHunterCore.Views
{
    internal class BaseView
    {
        // A View is a "menu" or "window" that Accepts User Input
        private string _viewName;
        private string _viewTitle;
        private StringBuilder _viewDescription;
        private ViewAction[] _actions;


        protected BaseView(
            string viewName,
            int numActions)
        {
            // Constructor for BaseView
            _viewName = viewName;
            _viewTitle = viewName;
            _viewDescription = new StringBuilder();
            _actions = new ViewAction[numActions];
        }

        #region Getters and Setters

        public string ViewName
        {
            // Get the Name of this View
            get { return _viewName; }
        }

        #endregion

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
