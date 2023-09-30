using Android.Media.TV;
using CatAppSharp.Rest;
using Refit;

namespace CatAppSharp;

[Activity(Label = "@string/app_name", MainLauncher = true)]
public class MainActivity : Activity
{
    protected override void OnCreate(Bundle? savedInstanceState)
    {
        base.OnCreate(savedInstanceState);

        // Set our view from the "main" layout resource
        SetContentView(Resource.Layout.activity_main);

        var btnGetCats = FindViewById<Button>(Resource.Id.btnGetCats);

        if (btnGetCats != null)
            btnGetCats.Click += BtnGetCats_Click;
    }

    private void BtnGetCats_Click(object? sender, EventArgs e)
    {
        Task.Run(() =>
        {
            _ = LoadCatsAsync();
        });
    }

    private async Task LoadCatsAsync()
    {
        var catsAPI = RestService.For<IApi>("https://api.thecatapi.com");
        var response = await catsAPI.GetCats();
        if(response != null)
        {

        }
    }
}
