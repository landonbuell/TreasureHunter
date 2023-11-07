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
        private string _username;
        private DateTime _created;
        private int _profileSettings;

        // List of currently available peices to play as
        private List<int> _adventurers;


    }
}
