using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Events;
using Prism.Mvvm;
using Prism.Regions;
using Serilog;
using Super.User.Infrastructure.ViewModels;
using Super.User.Render.Catheter.Module.Interfaces.ViewModels;

namespace Super.User.Render.Catheter.Module.ViewModels
{
    public  class RenderCatheterViewModel : SuperUserViewModel
        , IRenderCatheterViewModel
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
        ///RenderCatheterUserControlViewModel's parameterized constructor
        ///Used to initialize the region, publication subscription, and logging references
        /// </summary>
        /// <param name="regionManager">Region collection mamanger reference</param>
        /// <param name="eventAggregator">Publication and subscription reference</param>
        /// <param name="logger">Logind reference</param>
        public RenderCatheterViewModel(ILogger logger
            , IRegionManager regionManager
            , IEventAggregator eventAggregator)
        {
            _logger = logger;
            _regionManager = regionManager;
            _eventAggregator = eventAggregator;
            _logger.ForContext<RenderCatheterViewModel>();

            _message = "RenderCatheterViewModel";
        }


        #endregion
        private string _message;
        public string Message
        {
            get { return _message; }
            set { SetProperty(ref _message, value); }
        }

    }
}
