/*
 * Repository:      TreasureHunter
 * Solution:        TreatureHunter
 * Project:         TreasureHunterCore
 * Namespace:       Administrative
 * 
 * File:            TreasureHunterApp.cs
 * Author:          Landon Buell
 * Date:            Feb 2023 
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreasureHunterCore.Administrative
{
    internal class QueryManager : Manager
    {
        // Governs all user Input
        private static readonly string QUERY_MANAGER = "QueryManager";

        private string _rawUserInput;

        internal QueryManager(
            TreasureHunterApp app) :
            base(app, QUERY_MANAGER)
        {
            // Constructor
            _rawUserInput = "";
        }

        ~QueryManager()
        {
            // Destructor
        }

        #region Public Interface

        public List<string> RequestAndParseUserInput()
        {
            // Request keyboard input and return it as a list of strings
            List<string> result = new List<string>();
        }


        #endregion

        #region Private Interface

        private string GetUserInput()
        {
            // Get + Return Raw User Input
            string? rawUserInput = null;
            try
            {
                rawUserInput = Console.ReadLine();
            }
            catch (IOException err) { LogReadlineException(err); }
            catch (OutOfMemoryException err) { LogReadlineException(err); }
            catch (ArgumentOutOfRangeException err) { LogReadlineException(err); }

             
            
        }

        private void LogReadlineException(Exception err)
        {
            // Log an Console.Readline Error 
            StringBuilder message = new StringBuilder();
            message.Append("An exception occured when trying to read console input: ");
            message.Append(err.Message);
            // Log it
            LogMessage(message.ToString(), TextLogger.LogLevel.ERROR);
            return;
        }

        #endregion

    }
}
