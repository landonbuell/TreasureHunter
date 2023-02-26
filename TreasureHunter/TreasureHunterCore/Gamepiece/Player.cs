/*
 * Repository:      TreasureHunter
 * Solution:        TreatureHunter
 * Project:         TreasureHunterCore
 * Namespace:       Gamepiece
 * 
 * File:            Player.cs
 * Author:          Landon Buell
 * Date:            Feb 2023 
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TreasureHunterCore.Administrative;

namespace TreasureHunterCore.Gamepiece
{
    internal class Player : GamePiece
    {
        // Represents User's GamePeice

        internal Player( UserProfile profile) :
            base(profile.GamePieceData)
        {
            // Constructor
        }



    }
}
