
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
using System.Net;
using System.Net.Sockets;

namespace WilmaaRemote
{

	public class AppHandler
	{
		public void SendRequest (String letter)
		{
			var address = IPAddress.Parse ("192.168.192.46");
			using (TcpClient client = new TcpClient ()) {

				client.Connect (address, 444);
				NetworkStream netStream = client.GetStream ();
				if (netStream.CanWrite) {
					Byte[] sendBytes = Encoding.ASCII.GetBytes (letter);
					netStream.Write (sendBytes, 0, sendBytes.Length);
				}
				netStream.Close ();

			}
		}

		public void CheckConnection (MainActivity main)
		{
			var address = IPAddress.Parse ("192.168.192.46");

			using (TcpClient client = new TcpClient ()) {
				IAsyncResult ar = client.BeginConnect (address, 444, null, null);
				System.Threading.WaitHandle wh = ar.AsyncWaitHandle;
				if (!ar.AsyncWaitHandle.WaitOne (TimeSpan.FromSeconds (2), false)) {
					new AlertDialog.Builder (main)
						.SetNeutralButton ("Close", (sender, EventArgs) => {
						main.btnClose.Clickable = false;
						main.btnDown.Clickable = false;
						main.btnShutdown.Clickable = false;
						main.btnUp.Clickable = false;
						main.btnVDown.Clickable = false;
						main.btnVMute.Clickable = false;
						main.btnVUp.Clickable = false;

					})
						.SetMessage ("No Connection")
						.Show ();
				} else {
					main.btnClose.Clickable = true;
					main.btnDown.Clickable = true;
					main.btnShutdown.Clickable = true;
					main.btnUp.Clickable = true;
					main.btnVDown.Clickable = true;
					main.btnVMute.Clickable = true;
					main.btnVUp.Clickable = true;
				}
			}

		}


	}
}

