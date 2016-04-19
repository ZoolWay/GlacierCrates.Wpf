using Caliburn.Micro;
using System;

namespace GlacierCrates.Wpf.Tests.Interactive.ViewModels.TransitingContentControl
{
    public class MainViewModel : Screen
    {
        public object PresentationView { get; set; }

        public object PresentationDefView { get; set; }

        public bool IsDoingEffects { get; set; }

        public MainViewModel()
        {
            this.DisplayName = "Testing TransitingContentControl";
            this.IsDoingEffects = true;
        }

        public void GoToViewA()
        {
            this.PresentationView = new SampleAViewModel();
            this.PresentationDefView = new SampleAViewModel();
        }

        public void GoToViewB()
        {
            this.PresentationView = new SampleBViewModel();
            this.PresentationDefView = new SampleBViewModel();
        }

        public void ClearView()
        {
            this.PresentationView = null;
            this.PresentationDefView = null;
        }
    }
}
