using AnimalSoundboard.Data;
using AnimalSoundboard.Models;
using System;
using System.Collections.ObjectModel;
using Windows.ApplicationModel.Core;
using Windows.Media.Core;
using Windows.UI;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml.Controls;


// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace AnimalSoundboardUWP
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {

        public ObservableCollection<SoundItem> SoundCollection { get; set; }
        public MediaPlayerElement MediaPlayerElement = new MediaPlayerElement();
        public MainPage()
        {
            this.InitializeComponent();
            this.ExtendViewToTitleBar();
            this.InitSounds();
        }

        private void ExtendViewToTitleBar()
        {
            ApplicationViewTitleBar titleBar = ApplicationView.GetForCurrentView().TitleBar;
            titleBar.ButtonBackgroundColor = Colors.Transparent;
            titleBar.ButtonInactiveBackgroundColor = Colors.Transparent;
            CoreApplicationViewTitleBar coreTitleBar = CoreApplication.GetCurrentView().TitleBar;
            coreTitleBar.ExtendViewIntoTitleBar = true;
        }

        private void InitSounds()
        {
            this.SoundCollection = new ObservableCollection<SoundItem>(SoundDB.GetSounds());
        }

        private async void SoundView_ItemClick(object sender, ItemClickEventArgs e)
        {
            SoundItem currentSoundItem = e.ClickedItem as SoundItem;

            Windows.Storage.StorageFolder folder = await Windows.ApplicationModel.Package.Current.InstalledLocation.GetFolderAsync("AnimalSoundboard\\assets\\sounds");
            Windows.Storage.StorageFile file = await folder.GetFileAsync(currentSoundItem.AudioSource);
            this.MediaPlayerElement.Source = MediaSource.CreateFromStorageFile(file);

            this.MediaPlayerElement.MediaPlayer.Play();
        }
    }
}
