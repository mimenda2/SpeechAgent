using SpeechAgent.Enum;
using SpeechAgent.Items;
using System;
using System.Collections.Generic;

namespace SpeechAgent.Interfaces
{
    public interface ITTS : IDisposable
    {
        bool NeedLoginCredentials { get; }
        bool CanChangeVolume { get; }
        int Volume { get; set; }
        bool CanChangeRate { get; }
        int Rate { get; set; }
        TTSState State { get; }
        event EventHandler StateChanged;
        IList<TTSItem> GetInstalledVoices();
        IList<TTSItem> GetOuputs();
        void SetOutputToDefaultAudioDevice();
        void SelectVoice(TTSItem voice);
        void SpeakAsync(string textToSpeak);
        void Pause();
        void Resume();
        System.Windows.Forms.Control AddControl();
    }
}
