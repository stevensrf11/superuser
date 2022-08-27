using Prism.Ioc;
using Prism.Modularity;
using Super.User.Render.Module.Views;
using Super.User.Resources.Constants;

namespace Super.User.Render.Module
{
    [Module(ModuleName = SuperUserModuleNames.ModuleRender)]
    public class SuperUserRenderModule : IModule
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

            containerRegistry.Register<RenderUserControl>();
            containerRegistry.RegisterForNavigation<RenderUserControl>();


        }
        #endregion

    }
}