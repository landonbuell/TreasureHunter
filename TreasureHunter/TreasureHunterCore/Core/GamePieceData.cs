using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreasureHunterCore.Core
{
    internal class GamePieceData
    {
        // Structure to store basic info related to a game peice

        internal GamePieceData(
            string pieceName)
        {
            // Constructor
            name = pieceName;
            identifier = 0;

            inventory = new List<int>();

            maxHealthPoints = 100;
            maxStaminaPoints = 100;
            maxMagicPoints = 100;

            currentHealthPoints = maxHealthPoints;
            currentStaminaPoints = maxStaminaPoints;
            currentMagicPoints = maxMagicPoints;
        }

        internal GamePieceData(
            GamePieceData pieceData)
        {
            // Copy Constructor
            name = pieceData.name;
            identifier = pieceData.identifier;

            inventory = new List<int>(pieceData.inventory);

            maxHealthPoints = pieceData.maxHealthPoints;
            maxStaminaPoints = pieceData.maxStaminaPoints;
            maxMagicPoints = pieceData.maxMagicPoints;

            currentHealthPoints = pieceData.currentHealthPoints;
            currentStaminaPoints = pieceData.currentStaminaPoints;
            currentMagicPoints = pieceData.currentMagicPoints;
        }

        public string name;
        public uint identifier;

        public List<int> inventory;   // Replace w/ Inventory Item Type

        public uint maxHealthPoints;
        public uint maxStaminaPoints;
        public uint maxMagicPoints;

        public uint currentHealthPoints;
        public uint currentStaminaPoints;
        public uint currentMagicPoints;
    }
}
