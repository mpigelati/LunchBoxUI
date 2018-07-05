using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.Threading;

namespace LunchBoxUI
{
    [Activity(Label = "LunchBoxUI", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        Button mbtnSignUp;
        ProgressBar mprogressbr;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            mbtnSignUp = FindViewById<Button>(Resource.Id.btnSignUp);
            mprogressbr = FindViewById<ProgressBar>(Resource.Id.progressBar1);

            mbtnSignUp.Click += (object sender, EventArgs e) =>
            {
                FragmentTransaction frgmentTranc = FragmentManager.BeginTransaction();

                dialogue_SignUp signUpDialog = new dialogue_SignUp();
                signUpDialog.Show(frgmentTranc, "dialog frament");

                signUpDialog.monSignupEvent += SignUpDialog_monSignupEvent;

            };
        }

        private void SignUpDialog_monSignupEvent(object sender, onSignUpEventArgs e)
        {
            mprogressbr.Visibility = ViewStates.Visible;
            Thread thrd = new Thread(ActLikeReq);
            thrd.Start();
        }

        private void ActLikeReq()
        {
            Thread.Sleep(3000);
            RunOnUiThread(() => { mprogressbr.Visibility = ViewStates.Invisible; });
        }
    }
}


