using UniversityIot.UI.Core.Controls;
using UniversityIot.UI.UWP.Renderers;
using Xamarin.Forms.Platform.UWP;

[assembly: ExportRenderer(typeof(RoundedFrame), typeof(RoundedFrameRenderer))]

namespace UniversityIot.UI.UWP.Renderers
{
    using System.Linq;
    using Windows.UI.Xaml.Controls;
    using Xamarin.Forms.Platform.UWP;
    using Frame = Xamarin.Forms.Frame;

    internal class RoundedFrameRenderer : FrameRenderer
    {
        private Canvas m_Canvas;

        protected override void OnElementChanged(ElementChangedEventArgs<Frame> e)
        {
            base.OnElementChanged(e);

            var element = e.NewElement as RoundedFrame;

            if (element == null || this.Control == null)
            {
                return;
            }

            var border = this.Children.FirstOrDefault() as Border;

            /*   ArrangeNativeChildren = true;
               
                           if (m_Canvas != null)
                               Children.Remove(m_Canvas);
               
                           m_Canvas = new Canvas
                           {
                               Width = 50, // this.Control.Width/2,
                               Height = 50, //this.Control.Height,
                               Background = new SolidColorBrush(Windows.UI.Color.FromArgb(0, 0, 255, 255)),
                               IsHitTestVisible = false
                           };
               
                           Children.Add(m_Canvas);
               
                           Rectangle rectangle = new Rectangle
                           {
                               Width = m_Canvas.Width,
                               Height = m_Canvas.Height/2,
                               Fill = new SolidColorBrush(Windows.UI.Color.FromArgb(0, 255, 0,255)),// m_Canvas.Background,
                               RadiusY = element.CornerRadius,
                               RadiusX = element.CornerRadius
                           };
                           Canvas.SetLeft(rectangle, 0);
                           Canvas.SetTop(rectangle, 0);
                           m_Canvas.Children.Add(rectangle);
               */
        }
    }
}