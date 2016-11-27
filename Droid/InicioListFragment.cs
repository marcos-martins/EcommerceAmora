
using System;
using System.Collections.Generic;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V4.App;
using Android.Support.V7.Widget;
using Android.Util;
using Android.Views;
using Android.Widget;
using Square.Picasso;

namespace Amora.Droid
{
	public class InicioListFragment : Fragment
	{
		SimpleStringRecyclerViewAdapter adapter;
		public override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			// Create your fragment here
		}

		public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
		{
			
			var v = inflater.Inflate(
				Resource.Layout.fragment_inicio_list, container, false);
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
			List<Categoria> list = new List<Categoria>();
			list.Add(new Categoria {Descricao="Teste",Imagem="Tipo1" });
			list.Add(new Categoria { Descricao = "Teste", Imagem = "Tipo2" });
			list.Add(new Categoria { Descricao = "Teste", Imagem = "Tipo3" });
			recyclerView.SetLayoutManager(new LinearLayoutManager(recyclerView.Context));
			adapter = new SimpleStringRecyclerViewAdapter(this.Activity, list);

			recyclerView.SetAdapter(adapter);
		}

		public class SimpleStringRecyclerViewAdapter : RecyclerView.Adapter
		{
			TypedValue typedValue = new TypedValue();
			int background;
			List<Categoria> values;
			FragmentActivity parent;

			public class ViewHolder : RecyclerView.ViewHolder
			{
				public string BoundString { get; set; }
				public View View { get; set; }
				public ImageView ImageView { get; set; }
				//public TextView TextView { get; set; }
				public EventHandler ClickHandler { get; set; }

				public ViewHolder(View view) : base(view)
				{
					View = view;
					ImageView = view.FindViewById<ImageView>(Resource.Id.avatar);
					//TextView = view.FindViewById<TextView>(Android.Resource.Id.Text1);
				}

				/*public override string ToString()
				{
					return base.ToString() + " '" + TextView.Text;
				}*/
			}

			public Categoria GetValueAt(int position)
			{
				return values[position];
			}

			public SimpleStringRecyclerViewAdapter(FragmentActivity context, List<Categoria> items)
			{
				parent = context;
				context.Theme.ResolveAttribute(Resource.Attribute.selectableItemBackground, typedValue, true);
				background = typedValue.ResourceId;
				values = items;
			}

			public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
			{
				var view = LayoutInflater.From(parent.Context)
				                         .Inflate(Resource.Layout.inicio_item, parent, false);
				view.SetBackgroundResource(background);
				return new ViewHolder(view);
			}

			public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
			{
				var h = holder as ViewHolder;

				//h.BoundString = values[position].Descricao;
				//h.TextView.Text = values[position].Descricao;

				if (h.ClickHandler != null)
					h.View.Click -= h.ClickHandler;

				h.ClickHandler = new EventHandler((sender, e) =>
				{
					Android.Support.V4.App.Fragment d = new LojaListFragment();
					parent.SupportFragmentManager.BeginTransaction().Replace(Resource.Id.mainFrame, d).Commit();

				});

				h.View.Click += h.ClickHandler;
				int img = 0;
				switch (values[position].Imagem)
				{
					case "Tipo1":
						img = Resource.Drawable.tipo1;
					break;
					case "Tipo2":
						img = Resource.Drawable.tipo2;
					break;
					case "Tipo3":
						img = Resource.Drawable.tipo3;
					break;
					default:
						break;
				}

				Picasso.With(parent)
				       .Load(img)
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
