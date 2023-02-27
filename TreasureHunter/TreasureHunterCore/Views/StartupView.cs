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

namespace TreasureHunterCore.Views
{
    internal class StartupView : BaseView
    {
        private static readonly uint NUM_ACTIONS = 8;


        internal StartupView() :
            base("Startup",NUM_ACTIONS)
        {

        }

    }
}
