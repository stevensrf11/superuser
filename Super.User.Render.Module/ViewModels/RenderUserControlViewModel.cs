using Prism.Commands;
using Prism.Events;
using Prism.Regions;
using Serilog;
using Super.User.Infrastructure.ViewModels;
using Super.User.Render.Module.Interfaces.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Super.User.Render.Module.ViewModels
{ 

    /// <summary>
    /// RenderUserControlViewModel view model object derived from the <see cref="SuperUserViewModel" object
    /// , and the <seealso cref="IRecordingUserControlViewModel"/>
    /// Used as the view model for the RenderUserControl view which the the view which is nagivated to for the 
    /// resister module
    /// </summary>
    public partial class RenderUserControlViewModel : SuperUserViewModel
        , IRenderUserControlViewModel
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
    ///RenderUserControlViewModel's parameterized constructor
    ///Used to initialize the region, publication subscription, and logging references
    /// </summary>
    /// <param name="regionManager">Region collection mamanger reference</param>
    /// <param name="eventAggregator">Publication and subscription reference</param>
    /// <param name="logger">Logind reference</param>
    public RenderUserControlViewModel(ILogger logger
            , IRegionManager regionManager
            , IEventAggregator eventAggregator)
        {
            _logger = logger;
            _regionManager = regionManager;
            _eventAggregator = eventAggregator;
            _logger.ForContext<RenderUserControlViewModel>();

            LoadedCommand = new DelegateCommand(Loaded, CanLoaded);


        }

        #endregion

        #region Accessors

        #endregion

        #region Utitlity Methods


        #endregion
    }
}
