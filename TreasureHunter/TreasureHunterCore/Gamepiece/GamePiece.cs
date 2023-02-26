/*
 * Repository:      TreasureHunter
 * Solution:        TreatureHunter
 * Project:         TreasureHunterCore
 * Namespace:       Gamepiece
 * 
 * File:            GamePiece.cs
 * Author:          Landon Buell
 * Date:            Feb 2023 
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TreasureHunterCore.Core;

namespace TreasureHunterCore.Gamepiece
{
    internal abstract class GamePiece
    {
        // Represents a "Moveable" & "Interactive" Character
        private static uint _gamePieceCounter = 0;

        private GamePieceData _data;

        protected GamePiece(
            GamePieceData pieceData)
        {
            // Constructor
            _data = new GamePieceData(pieceData);
        }

        ~GamePiece()
        {
            // Destructor
        }

        public string Name
        {
            // Get the Name
            get { return _data.name; }   
        }

        public uint Identifier
        {
            // Get the Piece's Identifier
            get { return _data.identifier; }
        }


        public uint MaxHealth
        {
            // Get the Max Health
            get { return _data.maxHealthPoints; }
        }

        public uint MaxStamina
        {
            // Get the Max Stamina
            get { return _data.maxStaminaPoints;}
        }

        public uint MaxMagic
        {
            // Get the Max Magic 
            get { return (_data.maxMagicPoints); }  
        }

        public uint CurrentHealth
        {
            // Get or Set the Current Health
            get { return _data.currentHealthPoints; }
            protected set { _data.currentHealthPoints = value; }
        }

        public uint CurrentStamina
        {
            // Get or Set the Current Stamina
            get { return _data.currentStaminaPoints;}
            protected set { _data.currentStaminaPoints = value; }
        }

        public uint CurrentMagic
        {
            // Get or Set the CUrrent Magic
            get { return _data.currentMagicPoints; }
            protected set { _data.currentMagicPoints = value; }
        }

        #region Public Interface

 

        #endregion

    }
}
