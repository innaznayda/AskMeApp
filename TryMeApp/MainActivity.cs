using System;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;
using System.Collections.Generic;
using Android.Views;

namespace TryMeApp {
    [Activity(Label = "AskMe", MainLauncher = true)]
    public class MainActivity : Activity {
        public static string Question;
        public static List<string> Choices = new List<string>();
        private Button DecideButton;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            DecideButton = FindViewById<Button>(Resource.Id.decideButton);
            DecideButton.Click += DecideButton_Click;
        }

        private void DecideButton_Click(object sender, System.EventArgs e)
        {
            FillInInfo();
            Intent intent = new Intent(this, typeof(DecideActivity));
            StartActivity(intent);
        }

        private void FillInInfo()
        {
            var question = FindViewById<TextView>(Resource.Id.questionText);
            Question = question.Text;

            var l = FindViewById<LinearLayout>(Resource.Id.main);
            
            var viewGroup = (ViewGroup)l;           

            for (int i = 0; i < viewGroup.ChildCount; i++)
            {
                var childView = viewGroup.GetChildAt(i);

                var child = childView as TextView;

                if (child!=null && (child.Id == 2131165193|| child.Id == 2131165194 || child.Id == 2131165195))
                {
                    if (!string.IsNullOrEmpty(child.Text))
                    {
                        Choices.Add(child.Text);
                    }
                }
            }

        }
    }
}

