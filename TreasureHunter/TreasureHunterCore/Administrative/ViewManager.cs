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

using TreasureHunterCore.Views;

namespace TreasureHunterCore.Administrative
{
    internal class ViewManager : Manager
    {
        // Governs the Currently Active View and Accepts User Input
        private static readonly string VIEW_MANAGER = "ViewManager";
        private static readonly int MAX_QUEUE_SIZE = 1024;

        private LinkedList<ViewBase> _queue;
        private LinkedListNode<ViewBase> _current;

        private int[] _viewCounters;
        
        internal ViewManager(
            TreasureHunterApp app) :
            base(app, VIEW_MANAGER)
        {
            // Constructor
            _queue = new LinkedList<ViewBase>();
            _current = null;
            _viewCounters = new int[2];

            AddView(new PlaceholderView(App));
        }

        ~ViewManager()
        {
            // Destructor
            _queue.Clear();
        }

        #region Getters and Setters

        public ViewBase CurrentView
        {
            // Get the Current View
            get { return _current.ValueRef; }
        }

        public int NumViewsShown
        {
            // Get the number of views shown
            get { return _viewCounters[0]; }
            private set { _viewCounters[0] = value; }
        }

        public int NumViewsQueued
        {
            // Get the number of views queued
            get { return _viewCounters[1]; }
            private set { _viewCounters[1] = value; }
        }

        private int QueueSize
        {
            // Get the number of items currently in the queue
            get { return _queue.Count; }
        }

        #endregion

        #region Public Interface

        public static void ClearConsole()
        {
            // Clear the Console
            Console.Clear();
            return;
        }

        public void DrawCurrentView()
        {
            // Show the Current View to Console
            if (App.Settings.ClearConsole == true)
            {
                ClearConsole();
            }
            if (CurrentView == null)
            {
                // Can't draw a NULL view!
                // TODO - Handle this!
                return;
            }
            CurrentView.Draw();
            NumViewsShown += 1;
            return;
        }



        #endregion

        #region Private Interface

        

        #endregion
    }

}
