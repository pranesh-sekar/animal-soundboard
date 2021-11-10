using AnimalSoundboard.Models;
using System.Collections.Generic;

namespace AnimalSoundboard.Data
{
    public class SoundDB
    {
        public static List<SoundItem> GetSounds()
        {
            return new List<SoundItem>()
            {
                new SoundItem("Cow.wav", "🐄"),
                new SoundItem("Chicken.wav", "🐔"),
                new SoundItem("Elephant.wav", "🐘"),
                new SoundItem("Owl.wav", "🦉")
            };
        }
    }
}
