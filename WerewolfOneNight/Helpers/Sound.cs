using System;
using WerewolfOneNight.Enums;
using Windows.Storage;
using Windows.UI.Xaml.Controls;

namespace WerewolfOneNight.Helpers
{
    public class Sound
    {
        private const string soundFolder = "Sounds";
        private const string roleWake = "{0}_wake.mp3";
        private const string roleSleep = "{0}_end.mp3";
        private const string startGameFile = "OnGameStart.mp3";
        private const string prepareForEndFile = "PrepareForEnd.mp3";
        private const string endFile = "End.mp3";
        private static MediaElement media;
        private static StorageFolder folder;

        public Sound()
        {
            MediaInitialize();
        }

        public void StartGame()
        {
            PlaySound(startGameFile);
        }

        public void PrepareForEnd()
        {
            PlaySound(prepareForEndFile);
        }

        public void EndGame()
        {
            PlaySound(endFile);
        }

        public void WakeUp(RoleEnum role)
        {
            PlaySound(string.Format(roleWake, role.ToString()));
        }

        public void Sleep(RoleEnum role)
        {
            PlaySound(string.Format(roleSleep, role.ToString()));
        }

        private async void PlaySound(string soundName)
        {
            var file = await folder.GetFileAsync(soundName);
            var stream = await file.OpenAsync(Windows.Storage.FileAccessMode.Read);
            media.SetSource(stream, "");
            media.Play();
        }

        private async void MediaInitialize()
        {
            if (media == null)
            {
                media = new MediaElement();
                folder = await Windows.ApplicationModel.Package.Current.InstalledLocation.GetFolderAsync(soundFolder);
            }
        }
    }
}
