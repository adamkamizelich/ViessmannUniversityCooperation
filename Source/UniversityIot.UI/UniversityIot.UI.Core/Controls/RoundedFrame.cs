using Xamarin.Forms;

namespace UniversityIot.UI.Core.Controls
{
    public class RoundedFrame : Frame
    {
        public static readonly BindableProperty CornerRadiusProperty =
            BindableProperty.Create(nameof(CornerRadius), typeof(double), typeof(RoundedFrame), 0d);

        public double CornerRadius
        {
            get { return (double) GetValue(CornerRadiusProperty); }
            set { SetValue(CornerRadiusProperty, value); }
        }
    }
}