using UniversityIot.UI.iOS.Renderers;
using Xamarin.Forms;

[assembly: ExportRenderer(typeof(Entry), typeof(LowercaseEntryRenderer))]

namespace UniversityIot.UI.iOS.Renderers
{
    using UIKit;
    using Xamarin.Forms;
    using Xamarin.Forms.Platform.iOS;

    internal class LowercaseEntryRenderer : EntryRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if (this.Control != null)
            {
                this.Control.AutocapitalizationType = UITextAutocapitalizationType.None;
            }
        }
    }
}