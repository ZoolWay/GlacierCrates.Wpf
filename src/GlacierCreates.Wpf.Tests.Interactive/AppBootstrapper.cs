namespace GlacierCrates.Wpf.Tests.Interactive
{
    using System;
    using System.Collections.Generic;
    using Caliburn.Micro;
    using ViewModels;
    using System.Windows;
    using System.Windows.Controls;
    public class AppBootstrapper : BootstrapperBase
    {

        private static readonly log4net.ILog log;

        static AppBootstrapper()
        {
            log4net.Config.XmlConfigurator.Configure();
            log = global::log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        }

        private SimpleContainer container;

        public AppBootstrapper()
        {
            log.Debug("Creating bootstrapper");
            Initialize();
        }

        protected override void Configure()
        {
            container = new SimpleContainer();

            container.Singleton<IWindowManager, WindowManager>();
            container.Singleton<IEventAggregator, EventAggregator>();
            container.PerRequest<IShell, ShellViewModel>();

            //BindingScope.AddChildResolver<Controls.TransContentControl>(e => new[] { e.Content as System.Windows.DependencyObject });
            /*ConventionManager.AddElementConvention<Controls.TransContentControl>((Controls.TransContentControl.ContentProperty, null, null).ApplyBinding =
                (viewModelType, path, property, element, convention) =>
                {

                };*/

            ConventionManager.AddElementConvention<Controls.TransContentControl>(Controls.TransContentControl.ContentProperty, "DataContext", "Loaded").GetBindableProperty =
            delegate (DependencyObject foundControl) {
                var element = (Controls.TransContentControl)foundControl;
                return element.ContentTemplate == null && element.ContentTemplateSelector == null && !(element.Content is DependencyObject)
                    ? View.ModelProperty
                    : Controls.TransContentControl.ContentProperty;
            };
        }

        protected override object GetInstance(Type service, string key)
        {
            var instance = container.GetInstance(service, key);
            if (instance != null)
                return instance;

            throw new InvalidOperationException("Could not locate any instances.");
        }

        protected override IEnumerable<object> GetAllInstances(Type service)
        {
            return container.GetAllInstances(service);
        }

        protected override void BuildUp(object instance)
        {
            container.BuildUp(instance);
        }

        protected override void OnStartup(object sender, System.Windows.StartupEventArgs e)
        {
            DisplayRootViewFor<IShell>();
        }
    }
}