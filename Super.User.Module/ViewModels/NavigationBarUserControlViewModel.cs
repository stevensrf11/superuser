using Super.User.Infrastructure.ViewModels;
using Super.User.Module.Interfaces.ViewModels;
using Serilog;
using System.Collections.Generic;
using System.Linq;
using Prism.Regions;
using Prism.Events;
using Microsoft.Extensions.Configuration;
using Super.User.Interfaces.Models;
using Super.User.Models;
using System.Collections.ObjectModel;

namespace Super.User.Module.ViewModels
{
    /// <summary>
    /// 
    ///  NavigationBarUserControlViewModel navigation bar view model object derived from the <see cref="SuperUserViewModel"/>
    ///  object, and the <seealso cref="INavigationBarUserControlViewModel"/> interface
    /// Used as the view model object for the navigation bar control
    /// </summary>
    public partial class NavigationBarUserControlViewModel : SuperUserViewModel
        , INavigationBarUserControlViewModel
    {
        #region Fields
        /// <summary>
        /// _logger field
        /// Serilog logger interface used for loging information
        /// </summary>
        /// <value> Serilog ILogger interface</value>
        private ILogger _logger;

        /// <summary>
        /// _confirguation field
        ///  Microsoft Extension Configuration interface used to obtain set of key/value application configuration properties
        /// Used to load navigation bar button information from the appsetting json file
        /// </summary>
        /// <value>Microsoft Extension IConfigruation intefdace</value>
        private IConfiguration _configuration;

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
        /// _navigationButtons Fiels
        /// Collection of navigation buttons used for binding to the navigation bar.
        /// </summary>
        /// <value>ObservableCollection of INavigationButtonModel references</value>
        ObservableCollection<ISuperUserNavigationButtonModel> _navigationButtons = new ObservableCollection<ISuperUserNavigationButtonModel>();

        #endregion

        #region Constructor
        /// <summary>
        ///NavigationBarUserControlViewModel's parameterized constructor
        ///Used to initialize the region, configuration, publication subscription, and loggind references
        /// </summary>
        /// <param name="regionManager">Region collection mamanger reference</param>
        /// <param name="configuration">Configuration reference</param>
        /// <param name="eventAggregator">Publication and subscription reference</param>
        /// <param name="logger">Logind reference</param>
        public NavigationBarUserControlViewModel(ILogger logger
            , IConfiguration configuration
            , IRegionManager regionManager
            , IEventAggregator eventAggregator)
        {
            _logger = logger;
            _configuration = configuration;
            _regionManager = regionManager;
            _eventAggregator = eventAggregator;
            _logger.ForContext<NavigationBarUserControlViewModel>();

            // Load navigation bar button item from the appsetting json file
            var navResults = NavigationBarButtons(configuration);
            if(string.IsNullOrEmpty(navResults.Item1))
            {
                _navigationButtons = new ObservableCollection<ISuperUserNavigationButtonModel>(navResults.Item2);

               
            }
        }

        #endregion

        #region Accessors

        /// <summary>
        /// NavigationButtons Accessor Get Set Property
        /// Collection of navigation buttons used for binding 
        /// </summary>
        /// <value> Collection of ISuperUserNavigationButtonModel references </value>
        public ObservableCollection<ISuperUserNavigationButtonModel> NavigationButtons
        {
            get { return _navigationButtons; }
            set { SetProperty(ref _navigationButtons, value); }
        }
        #endregion

        #region Utitlity Methods

        /// <summary>
        /// NavigationBarButtons Utility Methods
        /// Used to load navigation bar button information.
        /// </summary>
        /// <param name="configuration">Configureation reference to load navigation  bar button information</param>
        /// <returns>
        /// An error string , and a collection of navigation bar buttons objects
        /// The error string contains any error that may have occurred duing the operation.
        /// If the error string's value is null or empty then the operation was successfull.
        /// 
        /// </returns>
        /// <exception cref=""></exception>
        protected virtual (string,IList<ISuperUserNavigationButtonModel> )NavigationBarButtons(IConfiguration configuration)
        {
            var error = string.Empty;
            var navButtons = new List<ISuperUserNavigationButtonModel>();
            // Load navigation bar button information from appsetting file
            var navigationButtons = configuration.GetSection("NavigationButtons")
                    .GetChildren()
                    .ToList()
                    .Select(x => new 
                    {
                        Name = x.GetValue<string>("Name"),
                        DisplayText = x.GetValue<string>("DisplayText"),
                        NavigationUrl = x.GetValue<string>("NavigationUrl"),
                        IsEnabled = x.GetValue<bool?>("IsEnabled"),
                        IsVisible = x.GetValue<bool?>("IsVisible"),
                        ToolTip = x.GetValue<string>("ToolTip")
                    });

            foreach(var navigationButton in navigationButtons)
            {
                navButtons.Add(new SuperUserNavigationButtonModel
                    (
                    navigationButton.DisplayText
                    , navigationButton.Name
                    , navigationButton.NavigationUrl
                    , navigationButton.IsEnabled.HasValue ? navigationButton.IsEnabled.Value : false
                    , navigationButton.IsVisible.HasValue ? navigationButton.IsVisible.Value : false
                    , navigationButton.ToolTip
                    ));
            }
            if(navButtons.Any())
            {
                return (error, navButtons);
            }
            error = $"No navigiation bar button information found.";
            _logger.Error($"{error} from appsetting json file");
            return (error, new List<ISuperUserNavigationButtonModel>());
        }

        private object _selectedNavigationItem;


        public object SelectedNavigationItem
        {
            get => _selectedNavigationItem;
            set { 
                SetProperty(ref _selectedNavigationItem, value); 
            }
        }
        #endregion
    }
}
