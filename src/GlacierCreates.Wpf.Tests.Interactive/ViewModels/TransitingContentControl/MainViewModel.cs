using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlacierCrates.Wpf.Tests.Interactive.ViewModels.TransitingContentControl
{
    public class MainViewModel : Screen
    {
        public object PresentationView { get; set; }

        public MainViewModel()
        {
            this.DisplayName = "Testing TransitingContentControl";
        }

        public void GoToViewA()
        {
            this.PresentationView = new SampleAViewModel();
        }

        public void GoToViewB()
        {
            this.PresentationView = new SampleBViewModel();
        }

        public void ClearView()
        {
            this.PresentationView = null;
        }
    }
}
