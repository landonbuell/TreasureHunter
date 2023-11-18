/*
 * Repository:      TreasureHunter
 * Solution:        TreatureHunter
 * Project:         TreasureHunterCore
 * Namespace:       Views
 * 
 * File:            ViewBase.cs
 * Author:          Landon Buell
 * Date:            Feb 2023 
 */

using System.Text;

using TreasureHunterCore.Core;
using TreasureHunterCore.Administrative;

namespace TreasureHunterCore.Views
{
    internal class ViewBase
    {
        // A View is a "menu" or "window" that Accepts User Input
        // and can perform an action based on that input
        protected static readonly string SPACE_04_CHARS = new(' ', 4);
        protected static readonly string SPACE_08_CHARS = new(' ', 8);
        protected static readonly string SPACE_16_CHARS = new(' ', 16);

        private readonly string _viewName;
        private readonly TreasureHunterApp _app; 
        private List<string> _viewHeaderText;
        private List<string> _viewFooterText;
        private List<TextActionPair> _actions;

        protected ViewBase(         
            string viewName,
            TreasureHunterApp app)
        {
            // Constructor for BaseView
            _viewName = viewName;
            _app = app;

            _viewHeaderText = new List<string>();
            _viewFooterText = new List<string>();

            _actions = new List<TextActionPair>();

            InitHeader();
            InitFooter();
            InitActions();
        }

        ~ViewBase()
        {
            // Destructor
        }

        #region Getters and Setters

        public string ViewName
        {
            // Get the Name of this View
            get { return _viewName; }
        }

        protected TreasureHunterApp App
        {
            // Get a reference to the parent App
            get { return _app; }
        }

        public int NumActions
        {
            // Get the Numbe of Actions for this View
            get { return _actions.Count; }
        }


        #endregion

        #region Public Interface

        public void Draw()
        {
            // Print this View To Console
            DisplayViewHeader();
            DisplayActionText();
            DisplayViewFooter();
            return;
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
            _actions[actionIndex].InvokeAction();
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

            public void InvokeAction()
            {
                // Get the Action Delegate
                _action.Invoke();
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

        #region Actions

        protected bool SendExitFlagToApplication()
        {
            // Raise the exit flag on the Main Application
            App.ExitFlag = true;
            return true;
        }

        #endregion

        #region Private Interface

        private void DisplayViewHeader()
        {
            // Show the Header for this View
            DisplayTopBorder();
            foreach (string line in _viewHeaderText)
            {
                Console.Write(SPACE_08_CHARS);
                Console.WriteLine(line);
            }
            return;
        }

        private void DisplayActionText()
        {
            // Show the List of Actions for this View
            for (int ii = 0; ii < _actions.Count; ii++)
            {
                string text = string.Format("{0,-8}{1}",ii, _actions[ii].Text);
                Console.Write(SPACE_16_CHARS);
                Console.WriteLine(text);
            }
            return;
        }

        private void DisplayViewFooter()
        {
            // Show the Footer for this View
            foreach (string line in _viewFooterText)
            {
                Console.Write(SPACE_08_CHARS);
                Console.WriteLine(line);
            }
            DisplayBottomBorder();
            return;
        }

        private void DisplayTopBorder()
        {
            // Print out a border for the top of the view
            string[] topBorder = new string[2];
            topBorder[0] = new string('=', 64);
            if (App.Settings.IsDebugMode == true)
            {
                topBorder[1] = string.Format("{0}{1}", "Debug: ", _viewName);
            }
            // Print Out
            foreach (string line in topBorder)
            {
                Console.WriteLine(line);
            }
            return;
        }

        private void DisplayBottomBorder()
        {
            // Print out a border for the bottom of the view
            string[] bottomBorder = new string[2];
            if (App.Settings.IsDebugMode == true)
            {
                bottomBorder[0] = string.Format("{0}{1}", "Debug: ", _viewName);
            }
            bottomBorder[1] = new string('=', 64);
            // Print Out
            foreach (string line in bottomBorder)
            {
                Console.WriteLine(line);
            }
            return;
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

        private void LogUserInputSpawnedErrorMessage(
            string? userInput, string errorMessage)
        {
            // Log a Falure Message caused by the user Input
            string message = String.Format("User input: {0}, spawned error: {1}",
                userInput, errorMessage);
            App.LogMessage(message, TextLogger.LogLevel.ERROR);
            return;
        }

        #endregion

        #region Static Interface

        public static bool NullAction()
        {
            // View action that dows nothing
            return true;
        }

        #endregion


    }
}
