using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwitterClient.Views;
using System.ComponentModel.Composition;
using Prism.Logging;
using Prism.Mef;
using System.ComponentModel.Composition.Hosting;
using System.Windows;


namespace TwitterClient
{
    class TwitterClientBootstrapper : MefBootstrapper
    {
        protected override void ConfigureAggregateCatalog()
        {
            base.ConfigureAggregateCatalog();
            AggregateCatalog.Catalogs.Add(new AssemblyCatalog(typeof(TwitterClientBootstrapper).Assembly));
        }

        protected override void ConfigureContainer()
        {
            base.ConfigureContainer();
        }

        protected override void InitializeShell()
        {
            base.InitializeShell();
            Application.Current.MainWindow = (MainView)Shell;
            Application.Current.MainWindow.Show();
        }

        protected override DependencyObject CreateShell()
        {
            return Container.GetExportedValue<MainView>();
        }

        protected override CompositionContainer CreateContainer()
        {
            CompositionContainer container = (CompositionContainer)base.CreateContainer();
            return container;
        }
    }
}