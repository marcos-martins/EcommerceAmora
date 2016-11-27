﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V4.View;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using V7Toolbar = Android.Support.V7.Widget.Toolbar;

namespace Amora.Droid
{
	[Activity(Label = "Detalhe",Theme = "@style/Theme.DesignDemo",ParentActivity = typeof(MainActivity))]
	public class DetalheLojaActivity : AppCompatActivity
	{
		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);
			SetContentView(Resource.Layout.loja_detalhe);

			var toolbar = FindViewById<V7Toolbar>(Resource.Id.toolbar);
			SetSupportActionBar(toolbar);

			ViewPager viewPager = (ViewPager)FindViewById(Resource.Id.view_pager);
			List<string> imagens = new List<string>();
			imagens.Add("http://ph-cdn2.ecosweb.com.br/Web/posthaus/foto/moda-feminina/blusa-manga-curta/blusa-com-recorte-em-renda-no-decote-preta_215780_301_1.jpg");
			imagens.Add("http://ph-cdn2.ecosweb.com.br/Web/posthaus/foto/moda-feminina/blusa-manga-curta/blusa-com-recorte-em-renda-no-decote-preta_215780_301_2.jpg");
			imagens.Add("http://ph-cdn2.ecosweb.com.br/Web/posthaus/foto/moda-feminina/blusa-manga-curta/blusa-com-recorte-em-renda-no-decote-preta_215780_301_3.jpg");
			imagens.Add("http://ph-cdn2.ecosweb.com.br/Web/posthaus/foto/moda-feminina/blusa-manga-curta/blusa-com-recorte-em-renda-no-decote-preta_215780_301_4.jpg");
			imagens.Add("http://ph-cdn2.ecosweb.com.br/Web/posthaus/foto/moda-feminina/blusa-manga-curta/blusa-com-recorte-em-renda-no-decote-preta_215780_301_5.jpg");

			ImageAdapter adapter = new ImageAdapter(this,imagens);
			viewPager.Adapter = adapter;
			// Create your application here
		}
	}
}