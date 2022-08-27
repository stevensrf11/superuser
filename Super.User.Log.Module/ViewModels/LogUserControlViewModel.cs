using Prism.Events;
using Prism.Regions;
using Serilog;
using Super.User.Infrastructure.ViewModels;
using Super.User.Log.Module.Interfaces.ViewModels;


namespace Super.User.Log.Module.ViewModels
{
    /// <summary>
    /// LogUserControlViewModel view model object derived from the <see cref="SuperUserViewModel" object
    /// , and the <seealso cref="ILogUserControlViewModel"/>
    /// Used as the view model for the LogUserControl view which the the view which is nagivated to for the 
    /// log module
    /// </summary>
    public partial class LogUserControlViewModel : SuperUserViewModel
        , ILogUserControlViewModel
    {
        #region Fields
        /// <summary>
        /// _logger field
        /// Serilog logger interface used for loging information
        /// </summary>
        /// <value> Serilog ILogger interface</value>
        private ILogger _logger;


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


        #endregion

        #region Constructor
        /// <summary>
        ///LogUserControlViewModel's parameterized constructor
        ///Used to initialize the region, publication subscription, and loggind references
        /// </summary>
        /// <param name="regionManager">Region collection mamanger reference</param>
        /// <param name="eventAggregator">Publication and subscription reference</param>
        /// <param name="logger">Logind reference</param>
        public LogUserControlViewModel(ILogger logger
            , IRegionManager regionManager
            , IEventAggregator eventAggregator)
        {
            _logger = logger;
            _regionManager = regionManager;
            _eventAggregator = eventAggregator;
            _logger.ForContext<LogUserControlViewModel>();

         
        }

        #endregion

        #region Accessors

        #endregion

        #region Utitlity Methods

    
        #endregion
    }
}
