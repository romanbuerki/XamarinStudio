using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading;

namespace WilmaaRemote
{
	[Activity (Label = "WilmaaRemote", MainLauncher = true)]
	public class MainActivity : Activity
	{
		public Button btnUp;
		public Button btnDown;
		public Button btnVUp;
		public Button btnVDown;
		public Button btnVMute;
		public Button btnClose;
		public Button btnShutdown;

		AppHandler apphandler;

		protected override void OnCreate (Bundle bundle)
		{
			RequestWindowFeature (WindowFeatures.NoTitle);
			base.OnCreate (bundle);
			apphandler = new AppHandler ();

		

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);


			btnUp = FindViewById<Button> (Resource.Id.buttonUP);
			btnDown = FindViewById<Button> (Resource.Id.buttonDown);
			btnVUp = FindViewById<Button> (Resource.Id.buttonVUp);
			btnVDown = FindViewById<Button> (Resource.Id.buttonVDown);
			btnVMute = FindViewById<Button> (Resource.Id.buttonVMute);
			btnClose = FindViewById<Button> (Resource.Id.buttonClose);
			btnShutdown = FindViewById<Button> (Resource.Id.buttonS);



			EventHandler eventhandler = new EventHandler (this);
			//CheckConnection
			apphandler.CheckConnection (this);

			 

		}

	}

	
}




