using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.ComponentModel.Composition;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Windows;
using System.Windows.Markup;
using System.Windows.Threading;

namespace TwitterClient
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            //FrameworkElement.LanguageProperty.OverrideMetadata(typeof(FrameworkElement), new FrameworkPropertyMetadata(XmlLanguage.GetLanguage(CultureInfo.CurrentCulture.IetfLanguageTag)));
            //SetupTraceListener();
            
            RunInCorrectMode();
            SetShutdownMethod();
        }

        private void RunBootstrapper()
        {
            var bootstrapper = new TwitterClientBootstrapper();
            bootstrapper.Run();
        }

        private void SetShutdownMethod()
        {
            ShutdownMode = ShutdownMode.OnMainWindowClose;
        }

        private void RunInCorrectMode()
        {
#if (DEBUG)
            RunInDebugMode();
#else
            RunInReleaseMode();
#endif
        }

        private void RunInDebugMode()
        {
            RunBootstrapper();
        }

        private void RunInReleaseMode()
        {
            SetupExceptionHandling();
            try
            {
                RunBootstrapper();
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
        }

        private void SetupExceptionHandling()
        {
            AppDomain.CurrentDomain.UnhandledException += AppDomainUnhandledException;
            Current.DispatcherUnhandledException += Current_DispatcherUnhandledException;
        }

        private void AppDomainUnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            HandleException(e.ExceptionObject as Exception);
        }

        private void Current_DispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
        {
            HandleException(e.Exception);
        }

        private void HandleException(Exception ex)
        {
            if (ex == null)
                return;
            Trace.TraceError(ex.ToString());
            Environment.Exit(1);
        }

    }
}
