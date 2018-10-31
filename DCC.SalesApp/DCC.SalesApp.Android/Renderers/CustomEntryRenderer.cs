
using Xamarin.Forms.Platform.Android;
using Xamarin.Forms;
using DCC.SalesApp.Droid.Renderers;
using DCC.SalesApp;
using Android.Graphics.Drawables;
using Android.Content;

[assembly: ExportRenderer(typeof(CustomEntry), typeof(CustomEntryRenderer))]
namespace DCC.SalesApp.Droid.Renderers
{
    class CustomEntryRenderer : EntryRenderer
    {
        public CustomEntryRenderer(Context context) : base(context)
        {
            AutoPackage = false;
        }
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if (Control != null)
            {
                Control.Background = this.Resources.GetDrawable(Resource.Drawable.RoundedCornerEntry);
                Control.SetTextColor(Android.Graphics.Color.Rgb(3, 104, 144));
                Control.SetTextSize(Android.Util.ComplexUnitType.FractionParent,11);
              //  Control.SetBackgroundColor(global::Android.Graphics.Color.LightGreen);
            }

        }
    }
}
 