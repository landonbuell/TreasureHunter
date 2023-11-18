/*
 * Repository:      TreasureHunter
 * Solution:        TreatureHunter
 * Project:         TreasureHunterCore
 * Namespace:       Views
 * 
 * File:            TaskNull.cs
 * Author:          Landon Buell
 * Date:            Nov 2023 
 */

using TreasureHunterCore.Administrative;

namespace TreasureHunterCore.Operations
{
    internal class TaskNull : TaskBase
    {
        // Represents a null TASK that does nothing

        internal TaskNull(
            TreasureHunterApp app) :
            base(app)
        {
            // Constructor
        }

        ~TaskNull()
        {
            // Destructor
        }
    }
}
