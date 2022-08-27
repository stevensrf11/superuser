using Prism.Events;
using Prism.Regions;
using Serilog;
using Super.User.Infrastructure.Utilities;
using Super.User.Infrastructure.ViewModels;
using Super.User.Infrastructure.Prism.Commands;
using Super.User.Interfaces.Models;
using Super.User.Interfaces.ViewModels;

namespace Super.User.App.ViewModels
{
    /// <summary>
    /// MainWindowViewModel derived from the <see cref="SuperUserViewModel"/> object
    /// , and the interface <seealso cref="IMainWindowViewModel"/>
    /// Used as the view model for application main view window
    /// </summary>
    public class MainWindowViewModel : SuperUserViewModel
        , IMainWindowViewModel
    {
        #region Fields

        /// <summary>
        /// IRegionManager reference field
        /// Defines an interface to manage a set of regions and to attach regions to objects (typically controls).
        /// </summary>
        /// <value>IRegionManager</value>
        private readonly IRegionManager _regionManager;


        /// <summary>
        /// _eventAggregator Field
        /// Reference to PRISM's EventAggregator object and used to subscribe and publish PRISM Events
        /// </summary>
        /// <value>IEventAggregator</value>
        private readonly IEventAggregator _eventAggregator;



        /// <summary>
        /// _logger Field
        /// Used to log messages
        /// </summary>
        /// <value>Serilog ILogger method</value>
        private readonly ILogger _logger;

        /// <summary>
        /// NavigateCommand delegate command used for navigation to a view 
        /// </summary>
        /// <value> PRISM DelegateCommand typedef string </value>
        /// <remarks> Note there is no CanExecute event handler</remarks> 
        public Prism.Commands.DelegateCommand<object> NavigateCommand => new Prism.Commands.DelegateCommand<object>(ExecuteNavigateCommand);

        #endregion


        #region Constructor



        /// <summary>
        ///MainWindowViewModel's parameterized constructor
        /// </summary>
        /// <param name="regionManager">Region Manager</param>
        /// <param name="eventAggregator">EventAggregator</param>
        /// <param name="logger">Logger</param>
        public MainWindowViewModel(IRegionManager regionManager
            , IEventAggregator eventAggregator
            , ILogger logger)
        {
            _regionManager = regionManager;
            _eventAggregator = eventAggregator;
            _logger = logger;
            _logger.ForContext<MainWindowViewModel>();
           
            // Register the Composite Naviation Command to the MainWindowViewModel's NavigateCommand
            CompositeCommands.NavigateCommand.RegisterCommand(NavigateCommand);

        }

        #endregion

        #region Commands


        #endregion  


        #region PRISM Delegate Commands Implementation
        /// <summary>
        /// Navigate execute event handler
        /// </summary>
        /// <param name="navigationPath">Navigation path</param>
        private void ExecuteNavigateCommand(object navigationObject)
        {
            if (navigationObject == null)
                return;
            // Verify the object is correct type
            var navigationPath = navigationObject as ISuperUserNavigationButtonModel;
            if (navigationPath!= null)
            {
                
                // Navigation parameters
                var parameters = new NavigationParameters();
                // Navigate to the following view as specified by the NavigationUrl to application region as speified in the main view window 
                _regionManager.RequestNavigate(RegionNames.ApplicationRegion, navigationPath.NavigationUrl, NavigationCompleted, parameters);
            }
        }

        /// <summary>
        /// NavigateToToolbar Method
        /// Used to automatically navigataed to the navigation view to the navigation ber region as speified in the main view window
        /// </summary>
        public void NavigateToToolbar()
        {
            _regionManager.RequestNavigate(RegionNames.NavigationBarRegion, "ToolbarWindow", NavigationCompleted);
        }


        /// <summary>
        /// NavigationCompleted method 
        /// This is the callback is the method  that will be invoked when navigation is complete.
        /// The navigation result input parameter provides information about the navigation operation, such as the result indicating whether or not the navigation succeeded
        /// </summary>
        /// <param name="result">Provides information about the navigation operation, such as the result indicating whether or not the navigation succeeded</param>
        private void NavigationCompleted(NavigationResult result)
        {
           if(result.Result== false)
            {
                _logger.Error($"Navigatoion Failed {result.Context.Uri}, Error= {result.Error.Message}");
            }
        }

        #endregion

        #region PRISM Sub/Pub Implementation

        #endregion

    }
}
