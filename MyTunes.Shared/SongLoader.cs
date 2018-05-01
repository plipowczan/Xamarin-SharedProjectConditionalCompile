#region usings

using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Newtonsoft.Json;

#endregion

namespace MyTunes
{
    public static class SongLoader
    {
        #region Consts

        const string Filename = "songs.json";

        #endregion

        #region Private methods

        private async static Task<Stream> OpenData()
        {
#if __IOS__
            return File.OpenRead(Filename);
#elif __ANDROID__
            return Android.App.Application.Context.Assets.Open(Filename);
#elif WINDOWS_UWP
            var sf = await Windows.ApplicationModel.Package.Current.InstalledLocation.GetFileAsync(Filename);
            return await sf.OpenStreamForReadAsync();
#else
            return null;
#endif
        }

        #endregion

        #region Public methods

        public static async Task<IEnumerable<Song>> Load()
        {
            using (var reader = new StreamReader(await OpenData()))
            {
                return JsonConvert.DeserializeObject<List<Song>>(await reader.ReadToEndAsync());
            }
        }

        #endregion
    }
}