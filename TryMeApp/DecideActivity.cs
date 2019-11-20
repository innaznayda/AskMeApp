using System.Collections.Generic;
using Com.Aigestudio.Wheelpicker;
using Android.App;
using Android.OS;
using Android.Widget;
using System.Drawing;
using Android.Views;
using Android.Graphics.Drawables;

namespace TryMeApp {
    [Activity/*(Label = "DecideActivity")*/]
    public class DecideActivity : Activity {
        private WheelPicker WheelPicker;
        private LinearLayout DecideView;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.DecideLayout);
            
            WheelPicker = FindViewById<WheelPicker>(Resource.Id.pickerWheel);
            DecideView = FindViewById<LinearLayout>(Resource.Id.decide);
            SetWheelView();
        }

        public override void OnAttachedToWindow()
        {
            base.OnAttachedToWindow();
            Window.SetTitle(string.IsNullOrEmpty(MainActivity.Question)?"???": MainActivity.Question);
        }

        private void SetWheelView()
        {
            if (MainActivity.Choices.Count == 0)
            {
                var toast = Toast.MakeText(this, "Really no choices? I don't believe you ! Go back and fill in them! ", ToastLength.Long);
                toast.SetGravity(GravityFlags.Top,0,250);
                WheelPicker.Visibility = ViewStates.Invisible;

               
                DecideView.SetBackgroundDrawable(Resources.GetDrawable(Resource.Drawable.CantDecide));
                toast.Show();
                return;
            }

            WheelPicker.Data = MainActivity.Choices;
            WheelPicker.Curved = true;
            WheelPicker.Cyclic = true;
            WheelPicker.SetIndicator(true);
            WheelPicker.ItemTextColor = Color.LightBlue.ToArgb();
            WheelPicker.CurtainColor = Color.Transparent.ToArgb();
            WheelPicker.SelectedItemTextColor = Color.DarkOrchid.ToArgb();
            WheelPicker.SetBackgroundColor(Android.Graphics.Color.Honeydew);
            WheelPicker.SetCurtain(true);
            WheelPicker.ItemSelected += WheelPicker_ItemSelected;
        }

        private void WheelPicker_ItemSelected(object sender, WheelPicker.ItemSelectedEventArgs e)
        {
            var toast = Toast.MakeText(this, $"Congratulations! Decision is taken : {e.P1}", ToastLength.Short);
            toast.Show();
            DecideView.SetBackgroundDrawable(Resources.GetDrawable(Resource.Drawable.deal));


        }
    }
}