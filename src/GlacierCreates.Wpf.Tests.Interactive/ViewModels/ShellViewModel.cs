using Caliburn.Micro;

namespace GlacierCrates.Wpf.Tests.Interactive.ViewModels
{
    public class ShellViewModel : Screen, IShell
    {

        private static readonly log4net.ILog log = global::log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private readonly IWindowManager windowManager;

        public ShellViewModel()
        {
            this.DisplayName = "GlacierCrates.Wpf - Interactive Test Suite";
            this.windowManager = IoC.Get<IWindowManager>();
        }

        public void TestTransitingContentControl()
        {
            this.windowManager.ShowDialog(new GlacierCrates.Wpf.Tests.Interactive.ViewModels.TransitingContentControl.MainViewModel());
        }

    }
}