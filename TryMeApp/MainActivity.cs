using Android.App;
using Android.Widget;
using Android.OS;
using System.Collections.Generic;
using System;
using Com.Aigestudio.Wheelpicker;

namespace TryMeApp {
    [Activity(Label = "AskMe", MainLauncher = true)]
    public class MainActivity : Activity {
        private WheelPicker WheelPicker;

        protected override void OnCreate(Bundle savedInstanceState) {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            Button myButton = FindViewById<Button>(Resource.Id.myButton);
            myButton.Click += MyButton_Click;

            WheelPicker = FindViewById<WheelPicker>(Resource.Id.pickerWheel);
            // adding some data
            var test = new List<string>();
            for (int i = 0; i < 100; i++) {
                test.Add($"item{i}");
            }
            WheelPicker.Data = test;
            
            WheelPicker.Curved = true;
            WheelPicker.Cyclic = true;
            WheelPicker.SetIndicator(true);
            WheelPicker.SetBackgroundColor(Android.Graphics.Color.Transparent);
            WheelPicker.SetCurtain(true);
            WheelPicker.ItemSelected += (sender, e) => {                
                Console.WriteLine(e.P1);
            };
            WheelPicker.StartNestedScroll(Android.Views.ScrollAxis.Vertical);
        }

        private void MyButton_Click(object sender, System.EventArgs e) {
            var toast = Toast.MakeText(this, "Button was clicked", ToastLength.Short);
            toast.Show();
        }
    }
}

