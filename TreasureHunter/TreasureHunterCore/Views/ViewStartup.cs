/*
 * Repository:      TreasureHunter
 * Solution:        TreatureHunter
 * Project:         TreasureHunterCore
 * Namespace:       Views
 * 
 * File:            ViewStartup.cs
 * Author:          Landon Buell
 * Date:            Feb 2023 
 */

using TreasureHunterCore.Administrative;
using TreasureHunterCore.Views;

namespace TreasureHunterCore.Views
{
    internal class ViewStartup : ViewBase
    {

        internal ViewStartup() :
            base("Startup Menu")
        {
            // Constructor
        }

        #region Protected Interface

        protected override void InitHeader()
        {
            // Init the View's Header
            string buildID = TreasureHunterApp.GetInstance.Settings.BuildID;
            string welcome = string.Format("Welcome to the Treasure Hunter App: {0}", buildID);
            string instructions = "On any view, enter a number and press ENTER to invoke the corresponding action";

            AppendHeader(welcome);
            AppendHeader(instructions);
            return;
        }


        #endregion

    }
}
