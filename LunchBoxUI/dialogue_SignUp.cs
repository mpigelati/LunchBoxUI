using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace LunchBoxUI
{
    class onSignUpEventArgs : EventArgs
    {
        private string mFirstName;
        private string mEmail;
        private string mPwd;

        public string FirstName {
            get { return mFirstName; }
            set { mFirstName = value; }
        }

        public string Email
        {
            get { return mEmail; }
            set { mEmail = value; }
        }

        public string Password
        {
            get { return mPwd; }
            set { mPwd = value; }
        }

        public onSignUpEventArgs(string firstName, string email, string pwd)
        {
            mFirstName = firstName;
            mEmail = email;
            mPwd = pwd;
        }
    }
    class dialogue_SignUp : DialogFragment
    {
        private EditText mEditFirstName;
        private EditText mEditEmail;
        private EditText mEditPwd;
        private Button mbtnSignUp;

        public event EventHandler<onSignUpEventArgs> monSignupEvent;

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);

            var view = inflater.Inflate(Resource.Layout.dialog_sign_up, container);

            mEditFirstName = view.FindViewById<EditText>(Resource.Id.txtFirstName);
            mEditEmail = view.FindViewById<EditText>(Resource.Id.txtEmail);
            mEditPwd = view.FindViewById<EditText>(Resource.Id.txtPassword);
            mbtnSignUp = view.FindViewById<Button>(Resource.Id.btnDialogEmail);

            mbtnSignUp.Click += MbtnSignUp_Click;            

            return view;
        }

        private void MbtnSignUp_Click(object sender, EventArgs e)
        {
            //
            monSignupEvent.Invoke(this, new onSignUpEventArgs(mEditFirstName.Text,
                mEditEmail.Text,
                mEditPwd.Text));

            this.Dismiss();
        }

        public override void OnActivityCreated(Bundle savedInstanceState)
        {
            Dialog.Window.RequestFeature(WindowFeatures.NoTitle);
            base.OnActivityCreated(savedInstanceState);
            Dialog.Window.Attributes.WindowAnimations = Resource.Style.dialog_animate;
        }
    }
}