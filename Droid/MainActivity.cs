using Android.App;
using Android.Widget;
using Android.OS;
using Android.Support.V4.Widget;
using Android.Support.Design.Widget;
using V7Toolbar = Android.Support.V7.Widget.Toolbar;
using Android.Support.V7.App;
using Android.Views;
using System;
using Android.Content.PM;

namespace Amora.Droid
{
	
	[Activity(Label = "Amora", Theme = "@style/Theme.DesignDemo", MainLauncher = false, Icon = "@mipmap/icon",
	ScreenOrientation = ScreenOrientation.Portrait)]
	public class MainActivity : AppCompatActivity
	{
		DrawerLayout drawerLayout;
		//NavigationView navigationView;
		protected override void OnCreate(Bundle bundle)
		{
			base.OnCreate(bundle);
			SetContentView(Resource.Layout.Main);
			var toolbar = FindViewById<V7Toolbar>(Resource.Id.toolbar);
			SetSupportActionBar(toolbar);

			SupportActionBar.SetHomeAsUpIndicator(Resource.Drawable.ic_menu);
			SupportActionBar.SetDisplayHomeAsUpEnabled(true);

			drawerLayout = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);

			var navigationView = FindViewById<NavigationView>(Resource.Id.nav_view);

			if (navigationView != null)
				setupDrawerContent(navigationView);


			SupportActionBar.SetDisplayShowTitleEnabled(false);
			SupportActionBar.SetHomeButtonEnabled(true);


			/*var fab = FindViewById<FloatingActionButton>(Resource.Id.fab);
			fab.Click += (sender, e) =>
			{
				// Show a snackbar
				Snackbar.Make(fab, "Here's a snackbar!", Snackbar.LengthLong).SetAction("Action",
					v => Console.WriteLine("Action handler")).Show();
			};*/


			//navigationView = FindViewById<NavigationView>(Resource.Id.nav_view);

		}


        void setupDrawerContent(NavigationView navigationView)
		{
			navigationView.NavigationItemSelected += (sender, e) =>
			{
				e.MenuItem.SetChecked(true);
				Android.Support.V4.App.Fragment fragment = null;
				switch (e.MenuItem.ItemId)
				{
					case Resource.Id.nav_home:
						fragment = new InicioListFragment();
						break;
					case Resource.Id.nav_shop:
						fragment = new LojaListFragment();
						break;
					default:
						fragment = new InicioListFragment();
						break;
				}

				SupportFragmentManager.BeginTransaction().Replace(Resource.Id.mainFrame, fragment).Commit();

				drawerLayout.CloseDrawers();
			};
		}

		public override bool OnOptionsItemSelected(IMenuItem item)
		{
			switch (item.ItemId)
			{
				case Android.Resource.Id.Home:
					drawerLayout.OpenDrawer(Android.Support.V4.View.GravityCompat.Start);
					return true;
			}
			return base.OnOptionsItemSelected(item);
		}

	}
}

