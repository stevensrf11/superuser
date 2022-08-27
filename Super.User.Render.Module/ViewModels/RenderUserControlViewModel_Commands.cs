using Prism.Commands;
using Prism.Regions;
using Super.User.Infrastructure.Utilities;
using Super.User.Infrastructure.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Super.User.Render.Module.ViewModels
{
    /// <summary>
    /// RenderUserControlViewModel partial  class
    /// Contains the commands for   the  RenderUserControlViewModel view model 
    /// </summary>
    public partial class RenderUserControlViewModel 
   {

        public DelegateCommand LoadedCommand { get; private set; }


        /// <summary>
        /// Loaded execute command handler for the Loaded event
        /// </summary>
        void Loaded()
        {

            NavigationToRenderCatheterControl();

        }

        /// <summary>
        /// CanLoaded can execute event command handler for the Loaded event
        /// Returns true is the execute event can be called
        /// Returns false is the execute event can not ne  called
        /// </summary>
        /// <returns> Ture</returns>
        bool CanLoaded()
        {
            return true;
        }


        #region Utitlity Methods

        /// <summary>
        /// NavigationToRenderCatheterControl method
        /// Used to perform navigation to the RendernCatheter Control
        /// </summary>
        void NavigationToRenderCatheterControl()
        {
            var parameters = new NavigationParameters();
            _regionManager.RequestNavigate(RegionNames.RegionRenderCatheter, "RenderCatheterUserControl", NavigationCompleted, parameters);


        }

        /// <summary>
        /// NavigationCompleted method 
        /// This is the callback is the method  that will be invoked when navigation is complete.
        /// Veriying to navigation of the StatusCollectionUserControl to RegionStatusCollection region located in the StatusUserControl in Super User Status Module projec
        /// The navigation result input parameter provides information about the navigation operation, such as the result indicating whether or not the navigation succeeded
        /// </summary>
        /// <param name="result">Provides information about the navigation operation, such as the result indicating whether or not the navigation succeeded</param>
        private void NavigationCompleted(NavigationResult result)
        {
            if (result.Result == false)
            {
                _logger.Error($"Super User Render Catheter Control Navigatoion: Failed to navigate  to Render Catheter Control region  {result.Context.Uri}, Error= {result.Error.Message}");
            }
        }

        #endregion

    }
}
