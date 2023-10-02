using Android.Content;

namespace CatAppSharp;

[Activity(Label = "@string/app_name", MainLauncher = true)]
public class MainActivity : Activity
{
    Button btnGetCats;

    protected override void OnCreate(Bundle? savedInstanceState)
    {
        base.OnCreate(savedInstanceState);

        // Set our view from the "main" layout resource
        SetContentView(Resource.Layout.activity_main);

        btnGetCats = FindViewById<Button>(Resource.Id.btnGetCats);
        btnGetCats.Click += BtnGetCats_Click;
    }

    private void BtnGetCats_Click(object? sender, EventArgs e)
    {
        var i = new Intent(this, typeof(CatsListActivity));
        StartActivity(i);
    }
}
