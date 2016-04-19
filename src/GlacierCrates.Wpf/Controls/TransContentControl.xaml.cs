using AutoDependencyPropertyMarker;
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
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GlacierCrates.Wpf.Controls
{
    /// <summary>
    /// Interaction logic for TransContentControl.xaml
    /// </summary>
    [ContentProperty("Content")]
    public partial class TransContentControl : UserControl
    {

        public static DependencyProperty ContentProperty = DependencyProperty.Register("Content", typeof(object), typeof(TransContentControl), new PropertyMetadata(new PropertyChangedCallback(ContentChanged)));

        [AutoDependencyProperty()]
        public object Content { get; set; }

        [AutoDependencyProperty()]
        public Transition EnterTransitions { get; set; }

        [AutoDependencyProperty()]
        public Transition ExitTransitions { get; set; }

        [AutoDependencyProperty()]
        public bool IsTransitingEnabled { get; set; }

        public TransContentControl()
        {
            InitializeComponent();
        }

        private void ContentChanged(object oldContent, object newContent)
        {
            bool performTransitions = IsTransitingEnabled;
            if ( (oldContent != null) && (oldContent is UIElement) && (performTransitions) )
            {
                this.PrevImage.Source = UiElementRenderer.ConvertToBitmapSource(oldContent as UIElement);
                DoExitTransition();
            }
            this.PrevImage.Visibility = Visibility.Collapsed;
            if ( (newContent != null) && (newContent is UIElement) && (performTransitions) )
            {
                this.NextImage.Source = UiElementRenderer.ConvertToBitmapSource(newContent as UIElement);
                DoEnterTransition();
            }
            this.CurrentContent.Content = newContent;
            this.CurrentContent.Visibility = Visibility.Visible;
            this.NextImage.Visibility = Visibility.Collapsed;
        }

        private void DoEnterTransition()
        {
            if (this.EnterTransitions.HasFlag(Transition.Slide) || true)
            {
                var movedTransform = new TranslateTransform(-this.ActualWidth, 0);
                this.NextImage.LayoutTransform = movedTransform;
                Storyboard sbEnter = new Storyboard();
                DoubleAnimation a = new DoubleAnimation(0, new Duration(TimeSpan.FromSeconds(2.6)));
                Storyboard.SetTargetProperty(a, new PropertyPath("RenderTransform.(TranslateTransform.X)"));
                sbEnter.Children.Add(a);
                sbEnter.Begin(this.NextImage);
            }
            //throw new NotImplementedException();
        }

        private void DoExitTransition()
        {
            if (this.ExitTransitions.HasFlag(Transition.Slide) || true)
            {
                var movedTransform = new TranslateTransform(0, 0);
                this.PrevImage.LayoutTransform = movedTransform;
                Storyboard sbExit = new Storyboard();
                DoubleAnimation a = new DoubleAnimation(this.ActualWidth, new Duration(TimeSpan.FromSeconds(2.6)));
                Storyboard.SetTargetProperty(a, new PropertyPath("RenderTransform.(TranslateTransform.X)"));
                sbExit.Children.Add(a);
                sbExit.Begin(this.PrevImage);
            }
            //throw new NotImplementedException();
        }

        private static void ContentChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var target = d as TransContentControl;
            target.ContentChanged(e.OldValue, e.NewValue);
        }
    }

}
