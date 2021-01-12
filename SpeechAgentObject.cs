using SpeechAgent.Enum;
using SpeechAgent.Interfaces;
using SpeechAgent.Items;
using System;
using System.Collections.Generic;

namespace SpeechAgent
{
    public class SpeechAgentObject : IDisposable
    {
        ITTS ttsObject = null;
        TTS_EnumObjects ttsObjectType;
        public SpeechAgentObject(TTS_EnumObjects ttsObjectType)
        {
            this.ttsObjectType = ttsObjectType;
        }

        #region Public methods
        public void TextToVoice(string text, string user, string password,
            TTSItem voice = null, int? volume = null, int? rate = null)
        {
            ttsObject?.Dispose();

            ttsObject = TTSObject.CreateObject(ttsObjectType, user, password);
            ttsObject.SetOutputToDefaultAudioDevice();
            ttsObject.SelectVoice(voice);
            if (volume != null && ttsObject.CanChangeVolume)
                    ttsObject.Volume = volume.Value;
            if (volume != null && ttsObject.CanChangeRate)
                ttsObject.Rate = rate.Value;
            ttsObject.StateChanged += TtsObject_StateChanged;
            ttsObject.SpeakAsync(text);
        }

        public TTSData GetTTSData()
        {
            TTSData retVal = new TTSData();
            using (var ttsObject = TTSObject.CreateObject(ttsObjectType, null, null))
            {
                List<TTSItem> voices = new List<TTSItem>();
                foreach (var v in ttsObject.GetInstalledVoices())
                    voices.Add(v);
                retVal.InstalledVoices = voices;
                retVal.NeedLoginCredentials = ttsObject.NeedLoginCredentials;
                retVal.CanChangeVolume = ttsObject.CanChangeVolume;
                retVal.Volume = ttsObject.Volume;
                retVal.CanChangeRate = ttsObject.CanChangeRate;
                retVal.Rate = ttsObject.Rate;
            }
            return retVal;
        }

        public void Resume()
        {
            if (ttsObject?.State == TTSState.Pause)
                ttsObject?.Resume();
        }
        public void Pause()
        {
            if (ttsObject?.State == TTSState.Speaking)
                ttsObject?.Pause();
        }
        public void Stop()
        {
            ttsObject?.Dispose();
            ttsObject = null;
        }
        public System.Windows.Forms.Control AddControl()
        {
            return ttsObject?.AddControl();
        }
        public void Dispose()
        {
            Stop();
        }
        #endregion
        public TTSState State
        {
            get { return ttsObject != null ? ttsObject.State : TTSState.None; }
        }
        private void TtsObject_StateChanged(object sender, EventArgs e)
        {
            StateChanged?.Invoke(this, EventArgs.Empty);
        }
        public event EventHandler StateChanged;
    }
}
