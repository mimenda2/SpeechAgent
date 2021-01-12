using SpeechAgent.Items;
using System.Collections.Generic;

namespace SpeechAgent
{
    public class TTSData
    {
        public bool NeedLoginCredentials { get; set; }
        public bool CanChangeVolume { get; set; }
        public int Volume { get; set; }
        public bool CanChangeRate { get; set; }
        public int Rate { get; set; }
        public IList<TTSItem> InstalledVoices { get; set; }
    }
}
