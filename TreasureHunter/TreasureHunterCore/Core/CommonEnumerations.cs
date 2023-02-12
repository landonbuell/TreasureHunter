/*
 * Repository:      TreasureHunter
 * Solution:        TreatureHunter
 * Project:         TreasureHunterCore
 * Namespace:       Core
 * 
 * File:            CommonEnumerations.cs
 * Author:          Landon Buell
 * Date:            Feb 2023 
 */

namespace TreasureHunterCore.Core
{

    public enum AppStatus
    {
        UNKNOWN = 0,
        SUCCESS = 1,
        WARNING = 2,
        FAILURE = 3
    }

    public enum DifficultyLevel
    {
        NONE        = 0,  
        EASY        = 1,
        MEDIUM      = 2,
        HARD        = 3,
        HARDCORE    = 4
    }

    public enum PlayerTier
    {
        LEVEL_0 = 0,
        LEVEL_1 = 1,
        LEVEL_2 = 2,
        LEVEL_3 = 3,         
        LEVEL_4 = 4,
        LEVEL_5 = 5,
        LEVEL_6 = 6,
        LEVEL_7 = 7,
        LEVEL_8 = 8,
        LEVEL_9 = 9,
    }

    public enum PlayerClass
    {
        NONE    = 0,
        WARRIOR = 1,
        THEIF   = 2,
        MAGE    = 3
    }


}
