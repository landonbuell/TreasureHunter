/*
 * Repository:      TreasureHunter
 * Solution:        TreatureHunter
 * Project:         TreasureHunterCore
 * Namespace:       Views
 * 
 * File:            ViewActionDatabase.cs
 * Author:          Landon Buell
 * Date:            arch 2023 
 */

using System;

using TreasureHunterCore.Administrative;

namespace TreasureHunterCore.Views
{
    internal static class ViewActionDatabase
    {

        public static bool SendExitApplicationFlag(BaseView view)
        {
            // Send Flag to Exit Application
            if (TreasureHunterApp.GetInstance = null )
            {
                
            }
            return true;
           
        }

        public static bool ChangeToPlaceholderView(BaseView currentView)
        {
            // Change to Placeholder view
            PlaceholderView placeholder = new PlaceholderView();
            bool success = BaseView.ChangeView(placeholder);
            return success;
        }

    }
}
