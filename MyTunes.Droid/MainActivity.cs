#region usings

using System.Linq;
using Android.App;
using Android.OS;

#endregion

namespace MyTunes
{
    [Activity(Label = "@string/app_name", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : ListActivity
    {
        #region Public methods

        protected override async void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            var songList = await SongLoader.Load();

            this.ListAdapter = new ListAdapter<Song>()
            {
                DataSource = songList.ToList(),
                TextProc = s => s.Name,
                DetailTextProc = s=> $"{s.Artist} - {s.Album}"
            };

            //this.ListAdapter = new ListAdapter<string>
            //{
            //    DataSource = new[]
            //    {
            //        "One",
            //        "Two",
            //        "Three"
            //    }
            //};
        }

        #endregion
    }
}