using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using Super.User.Infrastructure.Utilities;
using Super.User.Render.Catheter.Module.Interfaces.ViewModels;
using Super.User.Render.Catheter.Module.Interfaces.Views;
using Super.User.Render.Catheter.Module.ViewModels;
using Super.User.Render.Catheter.Module.Views;
using Super.User.Resources.Constants;

namespace Super.User.Render.Catheter.Module
{

    [Module(ModuleName = SuperUserModuleNames.ModuleRenderCatheter)]
    [ModuleDependency(SuperUserModuleNames.ModuleRender)]
    public class SuperUserRenderCatheterModule : IModule
    {
        #region Fields
        private readonly IRegionManager _regionManager;


        private readonly IContainerExtension _container;
        #endregion
        #region Constructor
        public SuperUserRenderCatheterModule(IContainerExtension container
            ,IRegionManager regionManager)
        {
            _regionManager = regionManager;
            _container= container;
        }
        #endregion


        #region IModule Implementation
        public void OnInitialized(IContainerProvider containerProvider)
        {

        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<IRenderCatheterViewModel, RenderCatheterViewModel>();
           // containerRegistry.RegisterType<RenderCatheterUserControl>();
            containerRegistry.Register<IRenderCatheterViewOne, RenderCatheterViewOne>();
           
            containerRegistry.Register<IRenderCatheterViewTwo, RenderCatheterViewTwo>();


            containerRegistry.Register<RenderCatheterUserControl>();
            containerRegistry.RegisterForNavigation<RenderCatheterUserControl>();

         

        }
        #endregion
    }
}