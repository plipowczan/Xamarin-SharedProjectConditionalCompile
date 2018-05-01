#region usings

using System.Linq;
using UIKit;

#endregion

namespace MyTunes
{
    public class MyTunesViewController : UITableViewController
    {
        #region Public methods

        public override void ViewDidLayoutSubviews()
        {
            base.ViewDidLayoutSubviews();

            this.TableView.ContentInset = new UIEdgeInsets(20, 0, 0, 0);
        }

        public override async void ViewDidLoad()
        {
            base.ViewDidLoad();

            var data = await SongLoader.Load();

            //this.TableView.Source = new ViewControllerSource<string>(this.TableView)
            //{
            //    DataSource = new[]
            //    {
            //        "One",
            //        "Two",
            //        "Three"
            //    }
            //};
            this.TableView.Source = new ViewControllerSource<Song>(this.TableView)
            {
                DataSource = data.ToList(),
                TextProc = s=> s.Name,
                DetailTextProc = s=> $"{s.Artist} - {s.Album}"
            };
        }

        #endregion
    }
}