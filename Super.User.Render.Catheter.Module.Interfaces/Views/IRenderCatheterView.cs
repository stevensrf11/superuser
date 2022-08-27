using Super.User.Render.Catheter.Module.Interfaces.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Super.User.Render.Catheter.Module.Interfaces.Views
{
    public  interface IRenderCatheterView
    {
        IRenderCatheterViewModel RenderCatheterViewModel { get; set; }
    }

    public interface IRenderCatheterViewOne : IRenderCatheterView
    {
    }

    public interface IRenderCatheterViewTwo : IRenderCatheterView
    {
    }
}
