using Caliburn.Micro;

namespace GlacierCreates.Wpf.Tests.Interactive.ViewModels
{
    public class ShellViewModel : Screen, IShell
    {

        private static readonly log4net.ILog log = global::log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public ShellViewModel()
        {
            this.DisplayName = "GlacierCreates.Wpf.Tests.Interactive";
        }

    }
}