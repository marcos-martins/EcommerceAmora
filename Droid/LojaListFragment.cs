
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.Widget;
using Android.Util;
using Android.Views;
using Android.Widget;
using Square.Picasso;

namespace Amora.Droid
{
	[Activity(Label = "LojaListFragment")]
	public class LojaListFragment : Android.Support.V4.App.Fragment
	{
		public override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			// Create your fragment here
		}

		public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
		{
			var v = inflater.Inflate(
				Resource.Layout.fragment_loja_list, container, false);
			var rv = v.JavaCast<RecyclerView>();
			new System.Threading.Thread(new System.Threading.ThreadStart(() =>
			{
			Activity.RunOnUiThread(() =>
			{
					setupRecyclerView(rv);
					});
			})).Start();
			return rv;
		}

		void setupRecyclerView(RecyclerView recyclerView)
		{
			List<Produto> list = new List<Produto>();
			list.Add(new Produto { Descricao = "Blusa florida .....", Codigo="1", Valor= 60.99M });
			list.Add(new Produto { Descricao = "Calça jeans ......", Codigo = "2" , Valor = 70.99M });
			list.Add(new Produto { Descricao = "Blusa branca ...", Codigo = "3", Valor = 87.99M });
			list.Add(new Produto { Descricao = "Blusa florida .....", Codigo = "1", Valor = 60.99M });
			list.Add(new Produto { Descricao = "Calça jeans ......", Codigo = "2", Valor = 70.99M });
			list.Add(new Produto { Descricao = "Blusa branca ...", Codigo = "3", Valor = 87.99M });
			list.Add(new Produto { Descricao = "Blusa florida .....", Codigo = "1", Valor = 60.99M });
			list.Add(new Produto { Descricao = "Calça jeans ......", Codigo = "2", Valor = 70.99M });
			list.Add(new Produto { Descricao = "Blusa branca ...", Codigo = "3", Valor = 87.99M });
			list.Add(new Produto { Descricao = "Blusa florida .....", Codigo = "1", Valor = 60.99M });
			list.Add(new Produto { Descricao = "Calça jeans ......", Codigo = "2", Valor = 70.99M });
			list.Add(new Produto { Descricao = "Blusa branca ...", Codigo = "3", Valor = 87.99M });
			list.Add(new Produto { Descricao = "Blusa florida .....", Codigo = "1", Valor = 60.99M });
			list.Add(new Produto { Descricao = "Calça jeans ......", Codigo = "2", Valor = 70.99M });
			list.Add(new Produto { Descricao = "Blusa branca ...", Codigo = "3", Valor = 87.99M });
			//StaggeredGridLayoutManager grid = new StaggeredGridLayoutManager(,3,1);
			var gridLayoutManager = new GridLayoutManager(recyclerView.Context, 2);
			recyclerView.SetLayoutManager(gridLayoutManager);
			recyclerView.HasFixedSize = true;


					recyclerView.SetAdapter(new LojaRecyclerViewAdapter(Activity, list));
				



			//recyclerView.SetAdapter(adapter);
		}


		public class LojaRecyclerViewAdapter : RecyclerView.Adapter
		{
			TypedValue typedValue = new TypedValue();
			int background;
			List<Produto> values;
			Android.App.Activity parent;

			public class ViewHolderLoja : RecyclerView.ViewHolder
			{
				public string BoundString { get; set; }
				public View View { get; set; }
				public ImageView ImageView { get; set; }
				public TextView TextView { get; set; }
				public TextView TextViewValor { get; set; }
				public EventHandler ClickHandler { get; set; }

				public ViewHolderLoja(View view) : base(view)
				{
					View = view;
					ImageView = view.FindViewById<ImageView>(Resource.Id.produto_imagem);
					TextView = view.FindViewById<TextView>(Resource.Id.produto_descricao);
					TextViewValor = view.FindViewById<TextView>(Resource.Id.produto_valor);
				}

				/*public override string ToString()
				{
					return base.ToString() + " '" + TextView.Text;
				}*/
			}

			public Produto GetValueAt(int position)
			{
				return values[position];
			}

			public LojaRecyclerViewAdapter(Android.App.Activity context, List<Produto> items)
			{
				parent = context;
				//context.Theme.ResolveAttribute(Resource.Attribute.selectableItemBackground, typedValue, true);
				background = typedValue.ResourceId;
				values = items;
			}

			public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
			{
				var view = LayoutInflater.From(parent.Context)
				                         .Inflate(Resource.Layout.loja_item, parent, false);
				//view.SetBackgroundResource(background);
				return new ViewHolderLoja(view);
			}

			public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
			{
				var h = holder as ViewHolderLoja;

				h.BoundString = values[position].Codigo;
				h.TextViewValor.Text = "R$ " + values[position].Valor.ToString("F");
				h.TextView.Text = values[position].Descricao;

				if (h.ClickHandler != null)
					h.View.Click -= h.ClickHandler;

				h.ClickHandler = new EventHandler((sender, e) =>
				{
					var context = h.View.Context;
					var intent = new Intent(context, typeof(DetalheLojaActivity));
					//intent.PutExtra(MainActivity.EXTRA_NAME, h.BoundString);
					//intent.SetFlags(ActivityFlags.ReorderToFront);
					context.StartActivity(intent);
				});

				h.View.Click += h.ClickHandler;

				Picasso.With(parent)
					   .Load("http://sessaolegal.com.br/img/fotos/vestidos%20estilosos%201.jpg")
				       .Resize(250, 250)
				       .CenterInside()
	   				  .Into(h.ImageView);

				//h.ImageView.SetImageResource(Cheeses.GetRandomCheeseResource(parent));
			}

			public override int ItemCount
			{
				get { return values.Count; }
			}
		}
	}
}
