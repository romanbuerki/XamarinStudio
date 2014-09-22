using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;


namespace WilmaaRemote
{
	public class EventHandler
	{

		public EventHandler (MainActivity main)
		{
			AppHandler apphandler = new AppHandler();

			// Get our button from the layout resource,
			// and attach an event to it


			main.btnUp.Click += delegate {
				apphandler.SendRequest ("U");
			};

			main.btnDown.Click += delegate {		
				apphandler.SendRequest ("D");
			};

			main.btnVUp.Click += delegate {		
				apphandler.SendRequest ("Y");
			};

			main.btnVDown.Click += delegate {		
				apphandler.SendRequest ("X");
			};

			main.btnVMute.Click += delegate {		
				apphandler.SendRequest ("M");
			};

			main.btnClose.Click += delegate {		
				new AlertDialog.Builder (main)
					.SetPositiveButton ("Yes", (sender, EventArgs) => {
						apphandler.SendRequest ("C");
					})
					.SetNegativeButton ("No", (sender, EventArgs) => {

					})
					.SetMessage ("Close Wilmaa?")
					.Show ();
			};
			main.btnShutdown.Click += delegate {	
				new AlertDialog.Builder (main)
					.SetPositiveButton ("Yes", (sender, EventArgs) => {
						apphandler.SendRequest ("S");
					})
					.SetNegativeButton ("No", (sender, EventArgs) => {

					})
					.SetMessage ("Computer shutdown?")
					.Show ();
			};
		}
	}
}

