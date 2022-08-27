
using Super.User.Interfaces.Models;
using System.Collections.ObjectModel;

namespace Super.User.Module.Interfaces.ViewModels
{
    /// <summary>
    ///  INavigationBarUserControlViewModel mavigation bar view model
    ///  Interface for the view model of the navigation bar control
    /// </summary>
    public interface INavigationBarUserControlViewModel
    {
        #region Accessors

        /// <summary>
        /// NavigationButtons Accessor Get Set Property
        /// Collection of navigation buttons used for binding 
        /// </summary>
        /// <value> Collection of ISuperUserNavigationButtonModel references </value>
        ObservableCollection<ISuperUserNavigationButtonModel> NavigationButtons { get; set; }
  
        #endregion
    }
}
