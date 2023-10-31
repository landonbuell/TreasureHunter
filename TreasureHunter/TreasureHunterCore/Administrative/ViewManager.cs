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
        private static readonly string VIEW_MANAGER = "View Manager";
        private static readonly int QUEUE_CAPACITY = 16;

        private Queue<ViewBase> _viewQueue;
        private int[] _viewCounters;
        
        internal ViewManager(
            TreasureHunterApp app) :
            base(app, VIEW_MANAGER)
        {
            // Constructor
            _viewQueue = new Queue<ViewBase>(QUEUE_CAPACITY);
            _viewCounters = new int[2];
        }

        ~ViewManager()
        {
            // Destructor
            _viewQueue.Clear();
        }

        #region Getters and Setters

        public ViewBase CurrentView
        {
            // Get or Set the Current View
            get{ return _viewQueue.Peek(); }
        }

        public int ViewsShown
        {
            // Get the number of views shown
            get { return _viewCounters[0]; }
            private set { _viewCounters[0] = value; }
        }

        public int ViewsQueued
        {
            // Get the number of views queued
            get { return _viewCounters[1]; }
            private set { _viewCounters[1] = value; }
        }

        #endregion

        #region Public Interface

        public static void ClearConsole()
        {
            // Clear the Console
            Console.Clear();
            return;
        }

        public void ShowCurrentView()
        {
            // Show the Current View to Console
            if (App.Settings.ClearConsole == true)
            {
                ClearConsole();
            }
            CurrentView.Show();
            ViewsShown += 1;
            return;
        }

        public bool EnqueueView(ViewBase nextView)
        {
            // Add a non-null view to the view queue
            if (nextView == null)
            {
                // Cannot enqueue a null view
                return false;
            }
            _viewQueue.Enqueue(nextView);
            ViewsQueued += 1;
            return true;
        }

        public void DequeueView()
        {
            // Remove View from the View Queue
            if (_viewQueue.Count > 0)
            {
                // Dequeue the view if there is something
                _viewQueue.Dequeue();
            }
            if (_viewQueue.Count == 0)
            {
                // Queue is Empty, just add a placeholder
                _viewQueue.Enqueue(new PlaceholderView(App));
            }
            return;
        }


        #endregion

        #region Private Interface

        #endregion
    }

}
