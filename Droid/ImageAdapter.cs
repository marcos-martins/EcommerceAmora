using System;
using System.Collections.Generic;
using Android.Content;
using Android.Support.V4.View;
using Android.Views;
using Android.Widget;
using Java.Lang;
using Square.Picasso;

namespace Amora.Droid
{
	public class ImageAdapter : PagerAdapter
	{
		Android.App.Activity context;
		private List<string>_imagePaths = new List<string>();
		public ImageAdapter(Android.App.Activity context, List<string> imagePaths)
		{
			this._imagePaths = imagePaths;
			this.context = context;
		}

		public ImageAdapter() : base()
		{
			//Teste
		}

		public override Java.Lang.Object InstantiateItem(ViewGroup container, int position)
		{
			ImageView imageView = new ImageView(context);
			//imageView.Layout();


			Picasso.With(context).Load(_imagePaths[position]).Into(imageView);

			((ViewPager)container).AddView(imageView, 0);

			return imageView;
			//return base.InstantiateItem(container, position);
		}

		public override void DestroyItem(ViewGroup container, int position, Java.Lang.Object @object)
		{
			((ViewPager)container).RemoveView(@object as ImageView);
		}

		public override int Count
		{
			get
			{
				return this._imagePaths.Count;
			}
		}

		public override bool IsViewFromObject(View view, Java.Lang.Object @object)
		{
			return view == ( @object as ImageView  ) ;
		}
	}
}
 