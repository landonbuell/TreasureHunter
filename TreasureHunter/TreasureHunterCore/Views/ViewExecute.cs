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

        internal ViewExecute() :
            base("Execute Menu")
        {
            // Constructor
        }

        #region Protected Interface

        protected override void InitActions()
        {
            // Init the Actions for the Startup View

            // Option 0 - Send a safe-exit flag
            RegisterTextActionPair(new TextActionPair("EXIT", ViewActionDatabase.SendExitApplicationFlag));
            RegisterTextActionPair(new TextActionPair("PROFILES", ViewActionDatabase.ChangeToPlaceholderView));
            RegisterTextActionPair(new TextActionPair("SETTINGS", ViewActionDatabase.ChangeToPlaceholderView));
            RegisterTextActionPair(new TextActionPair("CREDITS", ViewActionDatabase.ChangeToPlaceholderView));
            return;

        }



        #endregion

    }
}
