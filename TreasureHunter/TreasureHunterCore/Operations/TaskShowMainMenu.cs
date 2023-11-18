/*
 * Repository:      TreasureHunter
 * Solution:        TreatureHunter
 * Project:         TreasureHunterCore
 * Namespace:       Operations
 * 
 * File:            ShowMainMenu.cs
 * Author:          Landon Buell
 * Date:            Nov 2023 
 */

using TreasureHunterCore.Administrative;
using TreasureHunterCore.Views;
namespace TreasureHunterCore.Operations
{
    internal class TaskShowMainMenu : TaskBase
    {
        // Shows the Main Menu

        internal TaskShowMainMenu(
            TreasureHunterApp app) :
            base(app)
        {
            // Constructor
            View = new ViewMainMenu(App);

        }

        ~TaskShowMainMenu()
        {
            // Destructor
        }

        #region Protected Interface

        protected override void RunBody()
        {
            // Show the Main Menu View
            View.Draw();

        }

        #endregion

    }
}
