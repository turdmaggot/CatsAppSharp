using Android.Content;
using Android.Views;
using AndroidX.RecyclerView.Widget;
using CatAppSharp.Rest;
using Square.Picasso;

namespace CatAppSharp.Adapter
{
	public class CatsAdapter : RecyclerView.Adapter
	{
        #region Properties

        private List<Cat> items;
        private Context context;

        #endregion

        #region Constructor

        public CatsAdapter(Context context, List<Cat> items)
		{
            this.context = context;
            this.items = items;
		}

        #endregion

        #region Overidden Methods

        public override int ItemCount => items.Count;

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            var cat = items[position];

            if (holder is CatsViewHolder catsViewHolder)
            {
                var layoutParams = catsViewHolder.ImgCat.LayoutParameters;
                layoutParams.Width = cat.Width;
                layoutParams.Height = cat.Height;

                Picasso.Get().Load(cat.Url).Into(catsViewHolder.ImgCat);
            }
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            var view = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.cats_row, parent, false);
            return new CatsViewHolder(view);
        }

        #endregion
    }

    class CatsViewHolder : RecyclerView.ViewHolder
    {
        #region Properties

        public ImageView ImgCat { get; private set; }

        #endregion

        #region Constructor

        public CatsViewHolder(View itemView) : base(itemView)
        {
            ImgCat = itemView.FindViewById<ImageView>(Resource.Id.imgCat);
        }

        #endregion
    }
}

