/*
 * Repository:      TreasureHunter
 * Solution:        TreatureHunter
 * Project:         TreasureHunterCore
 * Namespace:       Administrative
 * 
 * File:            UserProfile.cs
 * Author:          Landon Buell
 * Date:            Feb 2023 
 */

using TreasureHunterCore.Core;

namespace TreasureHunterCore.Administrative
{
    internal class UserProfile
    {
        private string _username;
        private PlayerClass _playerClass;
        private DifficultyLevel _playerLevel;

        private ulong _lifetimeExperiencePoints;
        private ulong _currentExperiencePoints;

        private uint _maxHealthPoints;
        private uint _maxStaminaPoints;
        private uint _maxMagicPoints;

        public static UserProfile LoadUserProfile(string localPath)
        {
            // Load a User Profile from a specified path
            return new UserProfile();
        }

        public bool SaveUserProfile(string localPath)
        {
            // Save the current user profile to specified path
            return false;
        }

    }
}
