/*
 * Repository:      TreasureHunter
 * Solution:        TreatureHunter
 * Project:         TreasureHunterCore
 * Namespace:       Views
 * 
 * File:            BaseView.cs
 * Author:          Landon Buell
 * Date:            Feb 2023 
 */

using System.Text;

using TreasureHunterCore.Core;
using TreasureHunterCore.Administrative;

namespace TreasureHunterCore.Views
{
    internal class BaseView
    {
        // A View is a "menu" or "window" that Accepts User Input
        private string _viewName;
        private string _viewTitle;
        private StringBuilder _viewDescription;
        private TextActionPair[] _actions;


        protected BaseView(
            string viewName,
            uint numActions)
        {
            // Constructor for BaseView
            _viewName = viewName;
            _viewTitle = viewName;
            _viewDescription = new StringBuilder();
            _actions = new TextActionPair[numActions];
        }

        ~BaseView()
        {
            // Destructor
        }

        #region Getters and Setters

        public string ViewName
        {
            // Get the Name of this View
            get { return _viewName; }
        }

        public int NumActions
        {
            // Get the Numbe of Actions for this View
            get { return _actions.Length; }
        }

        public void InvokeAction(int actionIndex)
        {
            // Invoke the action specified by the index
            if (actionIndex < 0 || actionIndex >= _actions.Length)
            {
                // Action Index is Out of Range
                // Should Already be handled by Caller
                return;
            }
            _actions[actionIndex].InvokeAction(this);
            return;
        }

        #endregion

        #region Public Interface

        public void ShowView()
        {
            // Print this View To Console
            DisplayViewHeader();
            DisplayActionText();
            DisplayViewFooter();
            return;
        }


        #endregion

        #region Protected Interface

        protected struct TextActionPair
        {
            // Text Description paired w/ an Action Delegate
            private string _text;
            private ViewAction _action;

            internal TextActionPair(
                string text,
                ViewAction action)
            {
                // Constructor
                _text = text;
                _action = action;
            }

            public string Text
            {
                // Get the Text for this Action
                get { return _text;}
            }

            public void InvokeAction(
                BaseView view)
            {
                // Get the Action Delegate
                _action.Invoke(view);
                return;
            }

        }
            

        #endregion

        #region Private Interface

        private void ClearConsole()
        {
            // Clear the Console
            Console.Clear();
            return;
        }

        private void DisplayViewHeader()
        {
            // Show the Header for this View
            string[] lines = new string[2];
            lines[0] = new string('=', 64);
            lines[1] = String.Format("{0:<8}{1}", "", _viewTitle);

            foreach (string line in lines)
            {
                Console.WriteLine(line);
            }
            return;
        }

        private void DisplayActionText()
        {
            // Show the List of Actions for this View
            for (int ii = 0; ii < _actions.Length; ii++)
            {
                string text = String.Format("{0:<16}{1}", "", _actions[ii].Text);
                Console.WriteLine(text);
            }
            return;
        }

        private void DisplayViewFooter()
        {
            // Show the Footer for this View
            string[] lines = new string[2];
            lines[0] = String.Format("{0:<8}{1}", "",_viewTitle);
            lines[1] = new string('=', 64);

            foreach (string line in lines)
            {
                Console.WriteLine(line);
            }
            return;
        }

        private void AcceptUserInput()
        {
            // Accept + Parse User Input
            bool acceptInput = true;
            bool validUserInput = true;
            string consoleMessage = String.Format("{0:<4}{1}: ", "", "Action"); 
            string? userInput = null;

            int actionIndex = -1;
            while (acceptInput == true)
            {
                validUserInput = true;
                actionIndex = -1;

                Console.Write(consoleMessage);            
                validUserInput = ReadConsoleInput(ref userInput);

                if (validUserInput == false)
                {
                    // Skip this Input because it spawned an error
                    continue;
                }

                // Parse the String for the action Index
                actionIndex = DetermineActionIndex(ref userInput);
                


            }
        }

        private bool ReadConsoleInput(ref string? userInput)
        {
            // Read User Input From Console
            try
            {
                userInput = Console.ReadLine();
            }
            catch (IOException err)
            {
                LogUserInputSpawnedErrorMessage(userInput, err.Message);
                return false;
            }
            catch (OutOfMemoryException err)
            {
                LogUserInputSpawnedErrorMessage(userInput, err.Message);
                return false;
            }
            catch (ArgumentOutOfRangeException err)
            {
                LogUserInputSpawnedErrorMessage(userInput, err.Message);
                return false;
            }
            // Check if NULL or EMPTY or WHITESPACE and TRIM it
            if (IsNullOrEmpty(ref userInput) == true)
            {
                return false;
            }
            return true;
        }

        private bool IsNullOrEmpty(ref string? userInput)
        {
            // Return T/F If string is usable
            if (String.IsNullOrWhiteSpace(userInput))
            {
                return false;
            }
            userInput = userInput.Trim();
            return true;
        }

        private int DetermineActionIndex(ref string userInput)
        {
            // Cast to UINT32 and check if it's in bounds
            int actionIndex = -1;
            try
            {
                actionIndex = Convert.ToInt32(userInput);
            }
            catch (FormatException err)
            {
                LogUserInputSpawnedErrorMessage(userInput, err.Message);
                actionIndex = -1;
            }
            catch(OverflowException err)
            {
                LogUserInputSpawnedErrorMessage(userInput, err.Message);
                actionIndex = -1;
            }
            return actionIndex;
        }

        private bool ValidateActionIndex(int actionIndex)
        {

        }

        private void LogUserInputSpawnedErrorMessage(
            string? userInput, string errorMessage)
        {
            // Log a Falure Message caused by the user Input
            TreasureHunterApp? app = TreasureHunterApp.GetInstance;
            if (app != null)
            {
                string message = String.Format("User input: {0}, spawned error: {1}",
                    userInput, errorMessage);
                app.LogMessage(message, TextLogger.LogLevel.ERROR);
            }
            return;
        }

        private void LogInvalidUser

        #endregion




    }
}
