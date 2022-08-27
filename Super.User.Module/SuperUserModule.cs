using Prism.Events;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using Super.User.Infrastructure.Utilities;
using Super.User.Module.Views;

namespace Super.User.Module
{
    /// <summary>
    /// SuperUserModule object derived from the <see cref="IModule"/ interface>
    /// Used as the application module for registering navigation bar, toolbar, and status bar
    /// view for use and navigation in prison
    /// </summary>
    public class SuperUserModule : IModule
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

        #endregion

        #region Constructor
        /// <summary>
        /// SuperUserModule parameterized constructor
        /// Intializes both the region manager and the event aggregator
        /// </summary>
        /// <param name="regionManager">Reference used for managinf region and navigation</param>
        /// <param name="eventAggregator">Reference used for publication and subscription for events</param>
        public SuperUserModule(IRegionManager regionManager
        , IEventAggregator eventAggregator)
        {
            _regionManager = regionManager;
            _eventAggregator = eventAggregator;
        }
        #endregion

        #region IModule Implementation
        /// <summary>
        /// OnInitialized method
        /// Called when  the module that  has been initialized.
        /// Used to do things like view registrations or any other module initialization code should be performed.
        /// </summary>
        /// <param name="containerProvider">Reference to the  container </param>
        public void OnInitialized(IContainerProvider containerProvider)
        {
            var vmNav = containerProvider.Resolve<NavigationBarUserControl>();
            IRegion region = _regionManager.Regions[RegionNames.NavigationBarRegion];
            region.Add(vmNav);
        }

        /// <summary>
        ///  RegisterTypes Methos
        /// Used to register types with the container that will be used by the application.
        /// RegisterTypes is called before the OnInitialized method and should be used to
        /// register any services or functionality that the module implements.
        /// </summary>
        /// <param name="containerRegistry">Reference to the  container </param>
        public void RegisterTypes(IContainerRegistry containerRegistry)
        {

            //   containerRegistry.Register<NavigationBarWindowx>();

            containerRegistry.Register<NavigationBarUserControl>();

            containerRegistry.RegisterForNavigation<NavigationBarUserControl>();


        }
        #endregion
    }
}