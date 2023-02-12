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

using TreasureHunterCore.Administrative;

namespace TreasureHunterCore.Core
{

    // Callbacks run at the start of Startup, Execute, Cleanup Sequences
    internal delegate AppStatus PresequenceCallback(TreasureHunterApp app);

}
