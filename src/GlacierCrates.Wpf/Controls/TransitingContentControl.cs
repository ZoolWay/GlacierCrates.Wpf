using AutoDependencyPropertyMarker;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

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

            var oldElement = e.OldValue as FrameworkElement;
            var newElement = e.NewValue as FrameworkElement;

            if (oldElement != null)
            {
                var bitmap = RenderBitmap(oldElement);
            }

        }

        private static RenderTargetBitmap RenderBitmap(FrameworkElement element)
        {
            double x = 0.0;
            double y = 0.0;
            int width = (int)element.ActualWidth;
            int height = (int)element.ActualHeight;
            double dpiX = 96;
            double dpiY = 96;

            PixelFormat pixelFormat = PixelFormats.Default;
            VisualBrush elementBrush = new VisualBrush(element);
            DrawingVisual visual = new DrawingVisual();
            DrawingContext dc = visual.RenderOpen();

            dc.DrawRectangle(elementBrush, null, new Rect(x, y, width, height));
            dc.Close();

            RenderTargetBitmap bitmap = new RenderTargetBitmap(width, height, dpiX, dpiY, pixelFormat);

            bitmap.Render(visual);
            return bitmap;
        }

    }
}
