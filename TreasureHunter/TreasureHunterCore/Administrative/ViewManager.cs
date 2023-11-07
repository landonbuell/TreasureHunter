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

        public void AddView(ViewBase view)
        {
            // Add a new view to the tail end of the Queue
            if (QueueSize >= MAX_QUEUE_SIZE)
            {
                RemoveOldest();
            }
            _queue.AddLast(view);
            NumViewsQueued += 1;
            if (QueueSize == 1)
            {
                _current = _queue.First;
            }
            return;
        }

        public void NextView()
        {
            // Move to the next view
            _current = _current.Next;
            return;
        }

        public void PrevView()
        {
            // Moce to the prev view
            _current = _current.Previous;
            return;
        }

        #endregion

        #region Private Interface

        public void RemoveOldest()
        {
            // Remove the oldest view in the chain
            if (QueueSize > 0)
            {
                _queue.RemoveFirst();
            }
            if (QueueSize == 0)
            {
                _current = null;
            }
            return;
        }

        public void RemoveNewest()
        {
            // Remove the latest view in the chain
            if (QueueSize > 0)
            {
                _queue.RemoveLast();
            }
            if (QueueSize == 0)
            {
                _current = null;
            }
            return;
        }

        #endregion
    }

}
