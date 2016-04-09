using AutoDependencyPropertyMarker;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace GlacierCrates.Wpf.Controls
{
    public class TransitingContentControl : ContentControl
    {

        static TransitingContentControl()
        {
            try
            {
                ContentControl.ContentProperty.OverrideMetadata(typeof(TransitingContentControl), new FrameworkPropertyMetadata(new PropertyChangedCallback(OnContentChangedCallback)));
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debugger.Break();
            }
        }

        [AutoDependencyProperty()]
        public Transition EnterTransitions { get; set; }

        [AutoDependencyProperty()]
        public Transition ExitTransitions { get; set; }

        [AutoDependencyProperty()]
        public bool IsTransitingEnabled { get; set; }


        private static void OnContentChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var control = d as TransitingContentControl;
            if (control == null) throw new Exception("Invalid object state");
            if (!control.IsTransitingEnabled) return;
        }



    }
}
