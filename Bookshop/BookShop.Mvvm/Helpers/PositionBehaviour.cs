﻿using System.Windows;
using System.Windows.Controls.Primitives;
using Microsoft.Xaml.Behaviors;

namespace BookShop.Mvvm.Helpers
{
    /// <summary>
    /// Defines the reposition behavior of a <see cref="Popup"/> control when the window to which it is attached is moved or resized.
    /// </summary>
    /// <remarks>
    /// This solution was influenced by the answers provided by <see href="https://stackoverflow.com/users/262204/nathanaw">NathanAW</see> and
    /// <see href="https://stackoverflow.com/users/718325/jason">Jason</see> to
    /// <see href="https://stackoverflow.com/questions/1600218/how-can-i-move-a-wpf-popup-when-its-anchor-element-moves">this</see> question.
    /// </remarks>
    public class RepositionPopupBehavior : Behavior<Popup>
    {
        #region Protected Methods

        /// <summary>
        /// Called after the behavior is attached to an <see cref="Behavior.AssociatedObject"/>.
        /// </summary>
        protected override void OnAttached()
        {
            base.OnAttached();
            var window = Window.GetWindow(AssociatedObject.PlacementTarget);
            if (window == null) { return; }
            window.LocationChanged += OnLocationChanged;
            window.SizeChanged += OnSizeChanged;
            AssociatedObject.Loaded += AssociatedObject_Loaded;
        }

        void AssociatedObject_Loaded(object sender, RoutedEventArgs e)
        {
            //AssociatedObject.HorizontalOffset = 7;
            //AssociatedObject.VerticalOffset = -AssociatedObject.Height;
        }

        /// <summary>
        /// Called when the behavior is being detached from its <see cref="Behavior.AssociatedObject"/>, but before it has actually occurred.
        /// </summary>
        protected override void OnDetaching()
        {
            base.OnDetaching();
            var window = Window.GetWindow(AssociatedObject.PlacementTarget);
            if (window == null) { return; }
            window.LocationChanged -= OnLocationChanged;
            window.SizeChanged -= OnSizeChanged;
            AssociatedObject.Loaded -= AssociatedObject_Loaded;
        }

        #endregion Protected Methods

        #region Private Methods

        /// <summary>
        /// Handles the <see cref="Window.LocationChanged"/> routed event which occurs when the window's location changes.
        /// </summary>
        /// <param name="sender">
        /// The source of the event.
        /// </param>
        /// <param name="e">
        /// An object that contains the event data.
        /// </param>
        private void OnLocationChanged(object sender, EventArgs e)
        {
            var offset = AssociatedObject.HorizontalOffset;
            AssociatedObject.HorizontalOffset = offset + 1;
            AssociatedObject.HorizontalOffset = offset;
        }

        /// <summary>
        /// Handles the <see cref="Window.SizeChanged"/> routed event which occurs when either then <see cref="Window.ActualHeight"/> or the
        /// <see cref="Window.ActualWidth"/> properties change value.
        /// </summary>
        /// <param name="sender">
        /// The source of the event.
        /// </param>
        /// <param name="e">
        /// An object that contains the event data.
        /// </param>
        private void OnSizeChanged(object sender, SizeChangedEventArgs e)
        {
            var offset = AssociatedObject.HorizontalOffset;
            AssociatedObject.HorizontalOffset = offset + 1;
            AssociatedObject.HorizontalOffset = offset;
        }

        #endregion Private Methods
    }
}
