using System;
using Windows.Media.Core;
using Windows.Media.Playback;
using Windows.UI.Xaml.Controls;

namespace AnimalSoundboard.Models
{
    public class SoundItem
    {
        public string AudioSource { get; set; }
        public string PreviewText { get; set; }

        public SoundItem(string audioSource, string previewText)
        {
            this.AudioSource = audioSource;
            this.PreviewText = previewText;
        }

    }
}
