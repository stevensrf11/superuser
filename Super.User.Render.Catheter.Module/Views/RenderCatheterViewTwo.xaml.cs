using Super.User.Render.Catheter.Module.Interfaces.ViewModels;
using Super.User.Render.Catheter.Module.Interfaces.Views;
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
    /// Interaction logic for RenderCatheterViewTwo.xaml
    /// </summary>
    public partial class RenderCatheterViewTwo : UserControl
        , IRenderCatheterViewTwo



    {
        public RenderCatheterViewTwo(IRenderCatheterViewModel viewModel)
        {
            InitializeComponent();
            RenderCatheterViewModel = viewModel;
        }

        public IRenderCatheterViewModel RenderCatheterViewModel
        {
            get { return (IRenderCatheterViewModel)DataContext; }
            set { DataContext = value; }
        }
    }
}
/*
         public ContentAView(IContentAViewViewModel viewModel)
        {
            InitializeComponent();
            ViewModel = viewModel;
        }

        public IViewModel ViewModel
        {
            get { return (IContentAViewViewModel)DataContext; }
            set { DataContext = value; }
        } 
 * */