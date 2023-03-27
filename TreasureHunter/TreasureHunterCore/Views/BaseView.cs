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
        private List<string> _viewHeaderText;
        private List<string> _viewFooterText;
        private List<TextActionPair> _actions;

        protected BaseView(
            string viewName)
        {
            // Constructor for BaseView
            _viewName = viewName;

            _viewHeaderText = new List<string>();
            _viewFooterText = new List<string>();

            _actions = new List<TextActionPair>();

            InitHeader();
            InitFooter();
            InitActions();
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
            get { return _actions.Count; }
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

        public static bool ChangeView(BaseView view)
        {
            // Access the View Manager + Request to Change view
            if( TreasureHunterApp.GetInstance == null)
            {
                // Instance is null
                //string message = "TreasureHunterApp instancs is null. Cannot change view";
                return false;
            }
            bool success = TreasureHunterApp.GetInstance.ViewManager.SwitchToView(view);
            return success;
        }

        public void InvokeAction(int actionIndex)
        {
            // Invoke the action specified by the index
            if (actionIndex < 0 || actionIndex >= _actions.Count)
            {
                // Action Index is Out of Range
                // Should Already be handled by Caller
                return;
            }
            _actions[actionIndex].InvokeAction(this);
            return;
        }

        #endregion

        #region Protected Interface
        protected virtual void InitHeader()
        {
            // Initialize the Header Text
            return;
        }

        protected virtual void InitFooter()
        {
            // Initialize the Header Text
            return;
        }

        protected virtual void InitActions()
        {
            // Register all possible actions with this view
            return;
        }

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

        protected void AppendHeader(string text)
        {
            // Append a line to the header
            _viewHeaderText.Add(text);
            return;
        }

        protected void AppendFooter(string text)
        {
            // Append a line to the Footer
            _viewFooterText.Append(text);
            return;
        }

        protected void RegisterTextActionPair(TextActionPair textActionPair)
        {
            // Register a Text-Action Pair for this View
            _actions.Add(textActionPair);
            return;
        }

        #endregion

        #region Private Interface

        private void DisplayViewHeader()
        {
            // Show the Header for this View
            string[] defaultLines = new string[2];
            defaultLines[0] = new string('=', 64);
            defaultLines[1] = String.Format("{0:<8}{1}", "", _viewName);
            foreach(string line in defaultLines)
            {
                Console.WriteLine(line);
            }
            foreach(string line in _viewHeaderText)
            {
                Console.WriteLine(line);
            }
            return;
        }

        private void DisplayActionText()
        {
            // Show the List of Actions for this View
            for (int ii = 0; ii < _actions.Count; ii++)
            {
                string text = String.Format("{0:<16}{1}", "", _actions[ii].Text);
                Console.WriteLine(text);
            }
            return;
        }

        private void DisplayViewFooter()
        {
            // Show the Footer for this View
            string[] defaultLines = new string[2];
            defaultLines[0] = String.Format("{0:<8}{1}", "", _viewName);
            defaultLines[1] = new string('=', 64);
            foreach (string line in _viewFooterText)
            {
                Console.WriteLine(line);
            }
            foreach (string line in defaultLines)
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
            // Confirm that the chosen action is valid
            return false;
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

        #endregion




    }
}
