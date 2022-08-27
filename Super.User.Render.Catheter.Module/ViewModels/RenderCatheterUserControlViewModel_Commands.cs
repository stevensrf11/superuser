using Prism.Commands;
using Prism.Ioc;
using Prism.Regions;
using Super.User.Infrastructure.Utilities;
using Super.User.Render.Catheter.Module.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Super.User.Render.Catheter.Module.ViewModels
{

    /// <summary>
    /// RenderCatheterUserControlViewModel partial  class
    /// Contains the commands for  the  RenderCatheterUserControlViewModel view model  class
    /// </summary>
    public partial class RenderCatheterUserControlViewModel
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
          //  _regionManager.RequestNavigate(RegionNames.RegionRenderCatheter, "RenderCatheterUserControl", NavigationCompleted, parameters);

            var viewCathodorOne = _containerProvider.Resolve<RenderCatheterViewOne>();

            var viewCathodorTwo = _containerProvider.Resolve<RenderCatheterViewTwo>();

            IRegion regionCathodorOne = _regionManager.Regions[RegionNames.RegionRenderCatheterOne];

            IRegion regionCathodorTwo = _regionManager.Regions[RegionNames.RegionRenderCatheterTwo];

            regionCathodorOne.Add(viewCathodorOne);

            regionCathodorTwo.Add(viewCathodorTwo);

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
