using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using Super.User.Infrastructure.Utilities;
using Super.User.Log.Module.Views;
using Super.User.Resources;
using Super.User.Resources.Constants;

namespace Super.User.Log.Module
{
    /// <summary>
    /// SuperUserLogModule module class
    /// Module object for the log module which is loaded on demande
    /// </summary>
    /// <remarks>
    /// Initialize modules as soon as possible, known as "when available," 
    /// Initialize modules when the application needs them, known as "on-demand.
    /// </remarks>
    // [Module(ModuleName = " Super.User.Log.Module.SuperUserLogModule")]
 // [Module(ModuleName = "SuperUserLogModule")]
   [Module(ModuleName = SuperUserModuleNames.ModuleLog)]
   //  [Module(ModuleName = SuperUserModuleNames.ModuleLog, OnDemand = true)]



    public class SuperUserLogModule : IModule
    {
        #region IModule Implementation
        /// <summary>
        /// OnInitialized method
        /// Called when  the module that  has been initialized.
        /// Used to do things like view registrations or any other module initialization code should be performed.
        /// </summary>
        /// <param name="containerProvider">Reference to the  container </param>
        public void OnInitialized(IContainerProvider containerProvider)
        {
   
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

            containerRegistry.Register<LogUserControl>();
            containerRegistry.RegisterForNavigation<LogUserControl>();


        }
        #endregion

    }
}