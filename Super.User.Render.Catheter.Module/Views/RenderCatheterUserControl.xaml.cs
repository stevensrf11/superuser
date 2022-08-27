using Prism.Regions;
using Super.User.Infrastructure.Utilities;
using Super.User.Render.Catheter.Module.Interfaces.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Super.User.Render.Catheter.Module.Views
{
    /// <summary>
    /// Interaction logic for ViewA.xaml
    /// </summary>
    public partial class RenderCatheterUserControl : UserControl
    {
        /// <summary>
        /// IRegionManager reference field
        /// Defines an interface to manage a set of regions and to attach regions to objects (typically controls).
        /// </summary>
        /// <value>IRegionManager</value>
        private readonly IRegionManager _regionManager;



        /// <summary>
        /// RenderCatheterUserControl parameterized constructor
        /// Set the region manger
        /// </summary>
        /// <param name="regionManager">Region Manager</param>
        public RenderCatheterUserControl(IRegionManager regionManager)
        {
            _regionManager = regionManager;
            InitializeComponent();
        }

        /// <summary>
        /// RenderCatheterUserControl_Loaded Loaded event handle
        /// Used to create region name content for both render cathere one and two views
        /// Thie load event handle is called befor the correspnding event handler in the view model
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void RenderCatheterUserControl_Loaded(object sender, RoutedEventArgs args)
        {
            RegionManager.SetRegionManager(ContentControlRegionRenderCatheterOne, _regionManager);
            RegionManager.SetRegionName(ContentControlRegionRenderCatheterOne, RegionNames.RegionRenderCatheterOne);

            RegionManager.SetRegionManager(ContentControlRegionRenderCatheterTwo, _regionManager);
            RegionManager.SetRegionName(ContentControlRegionRenderCatheterTwo, RegionNames.RegionRenderCatheterTwo);

        }
    }
}
