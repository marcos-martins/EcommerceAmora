
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace Amora.Droid
{
	[Activity(Label = "Amora",MainLauncher = true, NoHistory = true,Theme = "@style/Theme.Splash",Icon = "@mipmap/icon",
	          ScreenOrientation = ScreenOrientation.Portrait)]
	public class SplashActivity : Activity
	{
		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			System.Threading.Thread.Sleep(2000); //Aguarda 3 segundos
			this.StartActivity(typeof(MainActivity)); //Inicia próxima Activity 
													  // Create your application here
		}
	}
}
