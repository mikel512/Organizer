using System.ComponentModel;
using Caliburn.Micro;

namespace M_ToDoList
{ 
     public abstract class ViewModelBase : PropertyChangedBase, INotifyPropertyChanging, INotifyPropertyChanged
     {
          #region INotifyPropertyChanged Members

          public override event PropertyChangedEventHandler PropertyChanged;

          #endregion

          #region Administrative Properties

          /// <summary>
          /// Whether the view model should ignore property-change events.
          /// </summary>
          public virtual bool IgnorePropertyChangeEvents { get; set; }

          #endregion

          #region Protected Methods

          /// <summary>
          /// Raises the PropertyChanged event.
          /// </summary>
          /// <param name="propertyName">The name of the changed property.</param>
		internal virtual void RaisePropertyChangedEvent(string propertyName)
          {
               // Exit if changes ignored
               if (IgnorePropertyChangeEvents) return;

               // Exit if no subscribers
               if (PropertyChanged == null) return;

               // Raise event
               var e = new PropertyChangedEventArgs(propertyName);
               PropertyChanged(this, e);
          }

          /// <summary>
          /// Raises the PropertyChanging event.
          /// </summary>
          /// <param name="propertyName">The name of the changing property.</param>
		internal virtual void RaisePropertyChangingEvent(string propertyName)
          {
               // Exit if changes ignored
               if (IgnorePropertyChangeEvents) return;

               // Exit if no subscribers
               if (PropertyChanging == null) return;

               // Raise event
               var e = new PropertyChangingEventArgs(propertyName);
               PropertyChanging(this, e);
          }

          #endregion

          #region INotifyPropertyChanging Members

          public event PropertyChangingEventHandler PropertyChanging;

          #endregion
     }
}