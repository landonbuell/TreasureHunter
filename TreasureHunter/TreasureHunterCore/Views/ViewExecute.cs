/*
 * Repository:      TreasureHunter
 * Solution:        TreatureHunter
 * Project:         TreasureHunterCore
 * Namespace:       Views
 * 
 * File:            ViewExecute.cs
 * Author:          Landon Buell
 * Date:            October 2023 
 */

using TreasureHunterCore.Administrative;
using TreasureHunterCore.Views;

namespace TreasureHunterCore.Views
{
    internal class ViewExecute : ViewBase
    {

        internal ViewExecute(TreasureHunterApp app) :
            base("Execute Menu",app)
        {
            // Constructor
        }

        #region Protected Interface

        protected override void InitActions()
        {
            // Init the Actions for the Startup View

            // Option 0 - Send a safe-exit flag
            RegisterTextActionPair(new TextActionPair("EXIT",       SendExitFlagToApplication));
            RegisterTextActionPair(new TextActionPair("PROFILES",   SelectProfileToLoad));
            RegisterTextActionPair(new TextActionPair("SETTINGS",   ModifySettings));
            RegisterTextActionPair(new TextActionPair("CREDITS",    ShowCredits));
            return;
        }

        #region Actions

        protected bool SelectProfileToLoad()
        {
            // Load in User profiles, and ask a user to select one

            // 1. Get list of possible profiles
            // 2. Create view that allows user to select a profile
            // 3. Enqueue the load profile view 

            return true;
        }

        protected bool ModifySettings()
        {
            // Allow User to Modify Settings
            return true;
        }

        protected bool ShowCredits()
        {
            // Show Credits to console
            return true;
        }

        #endregion



        #endregion

    }
}
