/*
 * Repository:      TreasureHunter
 * Solution:        TreatureHunter
 * Project:         TreasureHunterCore
 * Namespace:       Core
 * 
 * File:            Program.cs
 * Author:          Landon Buell
 * Date:            Feb 2023 
 */

namespace TreasureHunterCore.Administrative
{
    internal class TreasureHunterApp
    {
        // Represents Main Treasure Hunter Game
        private bool[] _statusFlags;


        internal TreasureHunterApp()
        {
            // Constructor
            _statusFlags = new bool[6];
        }

        ~TreasureHunterApp()
        {
            // Destructor
        }


        #region Getters and Setters

        public bool BegunStartup
        {
            // Get or set if startup sequnece has begun
            get { return _statusFlags[0]; }
            private set { _statusFlags[0] = value; }  
        }

        public bool FinishedStartup
        {
            // Get or Set if startup sequence has finished
            get {  return _statusFlags[1]; }
            private set { _statusFlags[1] = value; }
        }

        public bool BegunExecution
        {
            // Get or set if execution sequnece has begun
            get { return _statusFlags[2]; }
            private set { _statusFlags[2] = value; }
        }

        public bool FinishedExecution
        {
            // Get or set if execution sequnece has finished
            get { return _statusFlags[3]; }
            private set { _statusFlags[3] = value; }
        }

        public bool BegunCleanup
        {
            // Get or set if cleanup sequnece has begun
            get { return _statusFlags[4]; }
            private set { _statusFlags[4] = value; }
        }

        public bool FinishedCleanup
        {
            // Get or set if cleanup sequnece has begun
            get { return _statusFlags[5]; }
            private set { _statusFlags[5] = value; }
        }

        #endregion

        #region Public Interface

        public void Startup()
        {
            // Run App Startup Sequence
            return;
        }

        public void Execute()
        {
            // Run App Execution Squence
            return;
        }

        public void Cleanup()
        {
            // Run App Cleanup Sequence
            return;
        }

        #endregion

        #region Private Interface

        #endregion

    }
}
