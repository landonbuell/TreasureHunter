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
        // Represents a User Profile
        private static readonly string NULL_USERNAME = "NULL_USER";


        private string _username;
        private PlayerTier _playerTier;
        private PlayerClass _playerClass;     
        private DifficultyLevel _difficulty;

        private ulong _lifetimeExperiencePoints;
        private ulong _currentExperiencePoints;

        private uint _numberOfTotalRuns;
        private uint _numberOfSuccessfulRuns;

        private uint _maxHealthPoints;
        private uint _maxStaminaPoints;
        private uint _maxMagicPoints;

        private UserProfile()
        {
            // Constuctor (NULL USER)
            _username = NULL_USERNAME;
            _playerTier = PlayerTier.LEVEL_0;
            _playerClass = PlayerClass.NONE;
            _difficulty = DifficultyLevel.NONE;

            _lifetimeExperiencePoints = 0;
            _currentExperiencePoints = 0;

            _numberOfTotalRuns = 0;
            _numberOfSuccessfulRuns = 0;

            _maxHealthPoints = 0;
            _maxStaminaPoints = 0;
            _maxMagicPoints = 0;
        }

        private UserProfile(
            string username,
            PlayerClass playerClass,
            DifficultyLevel level)
        {
            // Constructor
            _username = username;
            _playerClass = playerClass;
            _playerTier = PlayerTier.LEVEL_0; ;
            _difficulty = level;

            _lifetimeExperiencePoints = 0;
            _currentExperiencePoints = 0;

            _maxHealthPoints = 100;
            _maxStaminaPoints = 100;
            _maxMagicPoints = 100;
        }

        #region Public Interface

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

        #endregion

        #region Private Interface

        private bool IsNullUser()
        {
            // Return T/F If this is a Null User
            return ((_username == NULL_USERNAME) &&
                    (_playerTier == PlayerTier.LEVEL_0) &&
                    (_playerClass == PlayerClass.NONE) &&
                    (_difficulty == DifficultyLevel.NONE));
        }


        #endregion

        #region Static Interface

        public static UserProfile NullUserProfile()
        {
            // Create a "DUMMY" User Profile
            UserProfile nullUser = new UserProfile();
            return nullUser;
        }

        public static UserProfile PresetUserProfileAlpha()
        {
            // Default User Profile Alpha for Developmen
            UserProfile alpha = new UserProfile(
                "Alpha", PlayerClass.WARRIOR, DifficultyLevel.MEDIUM);
            return alpha;
        }

        #endregion
    }
}
