using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace GlacierCrates.Wpf
{
    /// <summary>
    /// Basic implementation for INotifyPropertyChanged.
    /// Used by GlacierCrates.Wpf and you if you do not use any other MVVM framework.
    /// </summary>
    public abstract class PropertyChangedBase : INotifyPropertyChanged
    {
        /// <summary>
        /// Occurs when a property notifies that it has changed.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Toggles if change notifications should fire the event or not (default=true).
        /// </summary>
        public bool IsNotifying { get; set; } = true;

        /// <summary>
        /// Notifies that a property was changed. Normally called by the property setter.
        /// </summary>
        /// <param name="propertyName"></param>
        protected void NotifyOfPropertyChange([CallerMemberName] string propertyName = null)
        {
            if (!this.IsNotifying) return;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
