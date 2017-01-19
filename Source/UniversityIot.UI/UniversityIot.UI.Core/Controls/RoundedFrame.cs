namespace UniversityIot.UI.Core.Controls
{
    using Xamarin.Forms;

    public class RoundedFrame : Frame
    {
        public static readonly BindableProperty CornerRadiusProperty =
            BindableProperty.Create(nameof(CornerRadius), typeof(double), typeof(RoundedFrame), 0d);

        public double CornerRadius
        {
            get
            {
                return (double)this.GetValue(CornerRadiusProperty);
            }
            set
            {
                this.SetValue(CornerRadiusProperty, value);
            }
        }
    }
}