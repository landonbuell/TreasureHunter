/*
 * Repository:      TreasureHunter
 * Solution:        TreatureHunter
 * Project:         TreasureHunterCore
 * Namespace:       Views
 * 
 * File:            ViewShutdown.cs
 * Author:          Landon Buell
 * Date:            October 2023 
 */

using TreasureHunterCore.Administrative;
using TreasureHunterCore.Views;

namespace TreasureHunterCore.Views
{
    internal class ViewShutdown : ViewBase
    {

        internal ViewShutdown(TreasureHunterApp app) :
            base("Startup View",app)
        {
            // Constructor
        }
    }
}
