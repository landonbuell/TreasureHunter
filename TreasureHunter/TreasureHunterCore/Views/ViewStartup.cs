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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TreasureHunterCore.Administrative;

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
            string instructions = "Enter a number and press ENTER to invoke the corresponding action";

            AppendHeader(welcome);
            AppendHeader(instructions);
            return;
        }

        protected override void InitActions()
        {
            // Init the Actions for the Startup View
            RegisterTextActionPair(new TextActionPair("EXIT", ViewActionDatabase.SendExitApplicationFlag));


            return;

        }


        #endregion 

    }
}
