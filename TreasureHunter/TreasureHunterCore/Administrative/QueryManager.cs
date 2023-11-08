/*
 * Repository:      TreasureHunter
 * Solution:        TreatureHunter
 * Project:         TreasureHunterCore
 * Namespace:       Administrative
 * 
 * File:            TreasureHunterApp.cs
 * Author:          Landon Buell
 * Date:            Feb 2023 
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreasureHunterCore.Administrative
{
    internal class QueryManager : Manager
    {
        // Governs all user Input
        private static readonly string QUERY_MANAGER = "QueryManager";

        private string? _userInput;

        internal QueryManager(
            TreasureHunterApp app) :
            base(app, QUERY_MANAGER)
        {
            // Constructor
            _userInput = null;
        }



    }
}
