using Prism.Commands;
using Prism.Events;
using Prism.Ioc;
using Prism.Mvvm;
using Prism.Regions;
using Serilog;
using Super.User.Infrastructure.Utilities;
using Super.User.Infrastructure.ViewModels;
using Super.User.Render.Catheter.Module.Interfaces.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Super.User.Render.Catheter.Module.ViewModels
{
    public partial class RenderCatheterUserControlViewModel : SuperUserViewModel
        , IRenderCatheterUserControlViewModel
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

        private readonly IContainerExtension  _container;

        private readonly IContainerProvider _containerProvider;


        #endregion


        #region Constructor
        /// <summary>
        ///RenderCatheterUserControlViewModel's parameterized constructor
        ///Used to initialize the region, publication subscription, and logging references
        /// </summary>
        /// <param name="regionManager">Region collection mamanger reference</param>
        /// <param name="eventAggregator">Publication and subscription reference</param>
        /// <param name="logger">Logind reference</param>
        public RenderCatheterUserControlViewModel(ILogger logger
            , IRegionManager regionManager
            , IEventAggregator eventAggregator
            , IContainerExtension container
            , IContainerProvider containerProvider)
        {
            _logger = logger;
            _regionManager = regionManager;
            _eventAggregator = eventAggregator;
            _container = container;
             _containerProvider = containerProvider;
            LoadedCommand = new DelegateCommand(Loaded, CanLoaded);

            _logger.ForContext<RenderCatheterUserControlViewModel>();


        }


        #endregion
    }
}
