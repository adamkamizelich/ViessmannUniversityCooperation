using UniversityIot.UI.Core.Controls;
using UniversityIot.UI.Droid.Renderers;
using Xamarin.Forms;

[assembly: ExportRenderer(typeof(RoundedFrame), typeof(RoundedFrameRenderer))]

namespace UniversityIot.UI.Droid.Renderers
{
    using Android.Graphics;
    using Xamarin.Forms.Platform.Android;

    internal class RoundedFrameRenderer : FrameRenderer
    {
        public override void Draw(Canvas canvas)
        {
            base.Draw(canvas);

            var frame = (RoundedFrame)this.Element;
            int width = (int)frame.Width;
            int height = (int)frame.Height;

            using (var paint = new Paint { AntiAlias = true })
            using (var path = new Path())
            using (Path.Direction direction = Path.Direction.Cw)
            using (Paint.Style style = Paint.Style.Fill)
            using (var rect = new RectF(0, 0, width, height))
            {
                float rx = Forms.Context.ToPixels(5);
                float ry = Forms.Context.ToPixels(5);
                path.AddRoundRect(rect, rx, ry, direction);

                paint.SetStyle(style);
                paint.Color = frame.BackgroundColor.ToAndroid();

                canvas.DrawPath(path, paint);
            }
        }
    }
}