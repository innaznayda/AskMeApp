using Android.App;
using Android.Widget;
using Android.OS;
using Android.Runtime;

namespace TryMeApp {
    [Activity(Label = "AskMe", MainLauncher = true)]
    public class MainActivity : Activity {
        protected override void OnCreate(Bundle savedInstanceState) {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            Button myButton = FindViewById<Button>(Resource.Id.myButton);
            myButton.Click += MyButton_Click;
        }

        private void MyButton_Click(object sender, System.EventArgs e) {
            var toast = Toast.MakeText(this,"Button was clicked", ToastLength.Short);
            toast.Show();
        }
    }
}

