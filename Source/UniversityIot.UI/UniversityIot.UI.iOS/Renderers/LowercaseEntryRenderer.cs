using UIKit;
using UniversityIot.UI.iOS.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(Entry), typeof(LowercaseEntryRenderer))]

namespace UniversityIot.UI.iOS.Renderers
{
    internal class LowercaseEntryRenderer : EntryRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if (Control != null)
            {
                Control.AutocapitalizationType = UITextAutocapitalizationType.None;
            }
        }
    }
}