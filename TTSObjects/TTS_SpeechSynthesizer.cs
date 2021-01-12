using SpeechAgent.Enum;
using SpeechAgent.Interfaces;
using SpeechAgent.Items;
using System;
using System.Collections.Generic;
using System.Speech.Synthesis;

namespace SpeechAgent.TTSObjects
{
    /// <summary>
    /// USO SpeechSynthesizer para el TTS
    /// </summary>
    public class TTS_SpeechSynthesizer  : ITTS
    {
        SpeechSynthesizer speechSynthesizer = null;
        public TTS_SpeechSynthesizer(string user, string pwd)
        {
            speechSynthesizer = new SpeechSynthesizer();
            speechSynthesizer.StateChanged += SpeechSynthesizer_StateChanged;
        }

        private void SpeechSynthesizer_StateChanged(object sender, StateChangedEventArgs e)
        {
            StateChanged?.Invoke(this, EventArgs.Empty);
        }

        public bool NeedLoginCredentials { get { return false; } }
        public bool CanChangeVolume { get { return true; } }
        public int Volume
        {
            get { return speechSynthesizer != null ? speechSynthesizer.Volume : -1; }
            set
            {
                if (speechSynthesizer != null)
                    speechSynthesizer.Volume = value;
            }
        }
        public bool CanChangeRate { get { return true; } }
        public int Rate
        {
            get { return speechSynthesizer != null ? speechSynthesizer.Rate : -1; }
            set
            {
                if (speechSynthesizer != null)
                    speechSynthesizer.Rate = value;
            }
        }

        public IList<TTSItem> GetInstalledVoices()
        {
            List<TTSItem> retVal = new List<TTSItem>();
            if (speechSynthesizer != null)
            {
                foreach (InstalledVoice voice in speechSynthesizer.GetInstalledVoices())
                {
                    VoiceInfo info = voice.VoiceInfo;
                    retVal.Add(new TTSItem(voice.VoiceInfo.Name, voice.VoiceInfo));
                }
            }
            return retVal;
        }
        public IList<TTSItem> GetOuputs()
        {
            return new List<TTSItem>();
        }
        public TTSState State
        {
            get
            {
                TTSState retval = TTSState.None;
                switch (speechSynthesizer?.State)
                {
                    case SynthesizerState.Ready:
                        retval = TTSState.None;
                        break;
                    case SynthesizerState.Paused:
                        retval = TTSState.Pause;
                        break;
                    case SynthesizerState.Speaking:
                        retval = TTSState.Speaking;
                        break;
                }
                return retval;
            }
        }
        public event EventHandler StateChanged;

        public void SetOutputToDefaultAudioDevice()
        {
            speechSynthesizer?.SetOutputToDefaultAudioDevice();
        }
        public void SelectVoice(TTSItem voice)
        {
            speechSynthesizer?.SelectVoice(voice.Description);
        }
        public void SpeakAsync(string textToSpeak)
        {
            speechSynthesizer?.SpeakAsync(textToSpeak);
        }
        public void Pause()
        {
            speechSynthesizer?.Pause();
        }
        public void Resume()
        {
            speechSynthesizer?.Resume();
        }
        public System.Windows.Forms.Control AddControl()
        {
            return null;
        }
        public void Dispose()
        {
            if (speechSynthesizer != null)
                speechSynthesizer.StateChanged -= SpeechSynthesizer_StateChanged;
            speechSynthesizer?.Dispose();
            speechSynthesizer = null;
        }

    }
}
