using System.ComponentModel;
using System.Linq;
using Prism.Ioc;
using System.Windows;
using Prism.Modularity;
using Prism.Regions;
using System;
using System.Threading.Tasks;
using System.IO;
using System.Threading;
using Super.User.Infrastructure.Utilities;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;

using Serilog;
using Serilog.Core;
using Super.User.Module;
using Super.User.App.Views;
using Super.User.Interfaces;
using System.Diagnostics;
//using Super.User.Log.Module;

namespace Super.User.App
{
    
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class SuperUserApp
    {
        #region Fields



        /// <summary>
        /// _confirguation field
        ///  Microsoft Extension Configuration interface used to obtain set of key/value application configuration properties
        /// </summary>
        /// <value>Microsoft Extension IConfigruation nullable intefdace</value>
        private IConfiguration? _configuration;

        #endregion

        #region Constructor
        /// <summary>
        /// Default Constructor
        /// </summary>
        public SuperUserApp()
        {

            SetupExceptionHandling();
        }
        #endregion

        #region PrismApplicationBase Implementation
        /// <summary>
        /// OnStartup event handler
        /// Application startup event handler
        /// </summary>
        /// <param name="e"> System.Windows.StartupEventArgs that contains the event data.</param>
        protected override Window CreateShell()
        {

            return Container.Resolve<MainWindow>();
        }

        /// <summary>
        /// RegisterTypes method
        /// Used to register objects for DI
        /// </summary>
        /// <param name="containerRegistry">Confiner extension used for registration</param>
        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            // Register Microsoft Extension Configuration as a single tone
            containerRegistry.RegisterSingleton<IConfiguration>(() => _configuration);
            containerRegistry.RegisterInstance<ILogger>(Serilog.Log.Logger);
        }

        protected override void OnStartup(StartupEventArgs e)
        {
             // Get current runtime environment
            var envDev = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            if (!string.IsNullOrEmpty(envDev)
                && string.Compare(envDev, "Development", StringComparison.InvariantCultureIgnoreCase) == 0)
            {
                //  Attach a console window for logging display
                ConsoleAllocator.ShowConsoleWindow();
            }

            // Create the configuration 
            var builder = new ConfigurationBuilder();
            _configuration = BuildConfig(builder);

   

            // Register use of Serilog
            var host = Host.CreateDefaultBuilder()
                   .ConfigureServices((context, services) =>
                   {
                       services.AddTransient<ILogger, Logger>();
                       services.AddSingleton<MainWindow>();
                   })
                   .UseSerilog()
                   .Build();

            // Create logger
            Log.Logger = new LoggerConfiguration()
              .ReadFrom.Configuration(_configuration)
              .Enrich.FromLogContext()
              .CreateLogger();

            // Flush out serilog stream when exit

            // Flush out serilog stream when exit
            // Free console window
            this.Exit += (s, e) =>
            {
                if (ConsoleAllocator.HasConsole)
                {
                    ConsoleAllocator.HideConsoleWindow();

                }
                Log.CloseAndFlush();
            };

            base.OnStartup(e);
        }

     

        /// <summary>
        /// ConfigureModuleCatalog method
        /// Used to register modules with the ModuleCatalog
        /// </summary>
        /// <param name="moduleCatalog">ModuleCatalog reference</param>
        /// <remarks>
        /// Might want to move the loading to directory loading and create a
        /// create a custom AggregateModuleCatalog to handle both directory and direct loading
        /// </remarks>
        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            Type xpubEntAppModule = typeof(SuperUserModule);
            moduleCatalog.AddModule(new ModuleInfo(xpubEntAppModule.Name, xpubEntAppModule.AssemblyQualifiedName));

            //Type xpubEntAppLogModule = typeof(SuperUserLogModule);
            //moduleCatalog.AddModule(new ModuleInfo(xpubEntAppLogModule.Name, xpubEntAppLogModule.AssemblyQualifiedName));



              var directoryCatalog = new DirectoryModuleCatalog() { ModulePath = @".\DirectoryModules" };     
             ((AggregateModuleCatalog)moduleCatalog).AddCatalog(directoryCatalog);
            directoryCatalog.Load();

            //var directoryCatalog = new DirectoryModuleCatalog() { ModulePath = @"C:\accu3\SuperUserPOC\SuperUser\Super.User.App\bin\Debug\net6.0-windows" };

        }


        /// <summary>
        /// ConfigureRegionAdapterMappings method
        /// Used to register custom region adapter for use
        /// </summary>
        /// <param name="regionAdapterMappings">Used to register custom region adapters</param>
        protected override void ConfigureRegionAdapterMappings(RegionAdapterMappings regionAdapterMappings)
        {
            base.ConfigureRegionAdapterMappings(regionAdapterMappings);
           


        }

           /// <summary>
           ///CreateModuleCatalog methos
           // Used tto create  the module catalog that will be used to initialize the modules.
           /// </summary>
           /// <returns>
           /// An instance of <see cref="AggregateModuleCatalog"/> that will be used to initialize the modules.
           /// </returns>
        protected override IModuleCatalog CreateModuleCatalog()
        {
           return  new AggregateModuleCatalog();
            // return base.CreateModuleCatalog();
        }
        #endregion

        #region Utility Methods
        /// <summary>
        /// SetupExceptionHandling Utility method
        /// Register for the applications unhandled exceptions, the dispatchers unhandled exceptions,
        /// and the task scheduler unobserver exceptions.. 
        /// </summary>
        private void SetupExceptionHandling()
        {
            //Occurs when an exception is not caught.
            AppDomain.CurrentDomain.UnhandledException += (s, e) =>

            LogUnhandledException((Exception)e.ExceptionObject, "AppDomain.CurrentDomain.UnhandledException");

            //Occurs when an exception is thrown by an application but not handled.
            DispatcherUnhandledException += (s, e) =>
            {
                LogUnhandledException(e.Exception, "Application.Current.DispatcherUnhandledException");
                e.Handled = true;
            };

            //Occurs when a faulted task's unobserved exception is about to trigger exception escalation policy, which, by default, would terminate the process.
            TaskScheduler.UnobservedTaskException += (s, e) =>
            {
                LogUnhandledException(e.Exception, "TaskScheduler.UnobservedTaskException");

                e.SetObserved();
            };
        }

        /// <summary>
        /// LogUnhandledException Utility Method
        /// Exception handle for the application UnhandledException event, the application dispatcher' UnhandledException event
        /// and the scheduler's UnobservedTaskException event.
        /// </summary>
        /// <param name="exception">Exception that occurred</param>
        /// <param name="source">Source of exception</param>
        private void LogUnhandledException(Exception exception, string source)
        {

            string message = $"Unhandled exception ({source})";
            try
            {
                System.Reflection.AssemblyName assemblyName = System.Reflection.Assembly.GetExecutingAssembly().GetName();
                message = string.Format("Unhandled exception in {0} v{1}", assemblyName.Name, assemblyName.Version);
                Log.Logger.Fatal(exception, message);
            }
            catch (Exception ex)
            {

                Log.Logger.Error(ex, "Exception in LogUnhandledException");
            }
            finally
            {
                    Log.Logger.Error(exception, message);
            }
        }


        /// <summary>
        /// BuildConfig method
        /// Used to build configuration while returning the configuration build
        /// </summary>
        /// <param name="builder">Represents a type used to build application configuration.</param>
        ///<returns> Configuration reference, IConfigurationRoot interface reference </returns>
        static IConfigurationRoot BuildConfig(IConfigurationBuilder builder)
        {
            // Load  appsettings josn, plus correct environment appsettings json file 
            var a = $"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production"}.json";
            return builder.SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile(a, optional: true)
                .AddEnvironmentVariables().Build();
        }
        #endregion
    }
}
