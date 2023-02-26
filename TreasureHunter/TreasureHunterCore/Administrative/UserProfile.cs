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

        private GamePieceData _gamePieceData;

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

            _gamePieceData = new GamePieceData(_username);
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

            _gamePieceData = new GamePieceData(_username);

        }

        #region Getters and Setters

        public string Username
        {
            // Get the Username
            get { return _username; }
        }

        public PlayerTier PlayerTierLevel
        {
            // Get the Player's Tier Level
            get { return _playerTier; }
            protected set { _playerTier = value; }
        }

        public PlayerClass PlayerClass
        {
            // Get the Players's Class
            get { return _playerClass; }
        }

        public DifficultyLevel DifficultyLevel
        {
            // Get the Difficulty Level
            get { return _difficulty; }
        }

        public ulong LifetimeExperience
        {
            // Get the Total Lifetime Experiene Points
            get { return _lifetimeExperiencePoints; }
            protected set { _lifetimeExperiencePoints = value; }
        }

        public ulong CurrentExperiencePoints
        {
            // Get the Current Experience Points
            get { return _currentExperiencePoints; }
            protected set { _currentExperiencePoints = value; }
        }

        public GamePieceData GamePieceData
        {
            get { return _gamePieceData; }
        }

        #endregion

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
