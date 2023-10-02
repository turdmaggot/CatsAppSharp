using AndroidX.RecyclerView.Widget;
using CatAppSharp.Adapter;
using CatAppSharp.Rest;
using Refit;

namespace CatAppSharp
{
    [Activity]
    public class CatsListActivity : Activity
    {
        RecyclerView rcvCats;

        protected override async void OnCreate(Bundle? savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_cats_list);

            rcvCats = FindViewById<RecyclerView>(Resource.Id.rcvCats);
            var layoutMngr = new LinearLayoutManager(this, LinearLayoutManager.Vertical, false);

            var catsList = await LoadCatsAsync();
            var adapter = new CatsAdapter(this, catsList);
            rcvCats.SetLayoutManager(layoutMngr);
            rcvCats.SetAdapter(adapter);
        }

        private async Task<List<Cat>> LoadCatsAsync()
        {
            var catsAPI = RestService.For<IApi>("https://api.thecatapi.com");
            var response = await catsAPI.GetCats();
            return response;
        }
    }
}

