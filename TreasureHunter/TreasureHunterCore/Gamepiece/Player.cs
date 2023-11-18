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

using TreasureHunterCore.Core;

namespace TreasureHunterCore.Gamepiece
{
    internal class Player : GamePiece
    {
        // Represents User's GamePeice

        internal Player(
            GamePieceData pieceData) :
            base(pieceData)
        {
            // Constructor
        }

    }
}
