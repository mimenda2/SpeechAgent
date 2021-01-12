using SpeechLib;
using System;
using System.Collections.Generic;
using SpeechAgent.Items;
using SpeechAgent.Interfaces;
using SpeechAgent.Enum;

namespace SpeechAgent.TTSObjects
{
    /// <summary>
    /// Interop.SpeechLib
    /// Agregar referencia al proyecto, COM, Microsoft Speech Object Library
    /// </summary>
    public class TTS_SpVoice : ITTS
    {
        SpVoice speech = null;
        public TTS_SpVoice(string user, string pwd)
        {
            speech = new SpVoice();
            speech.EndStream += delegate
            {
                State = TTSState.None;
            };
        }
        public bool NeedLoginCredentials { get { return false; } }
        public bool CanChangeVolume { get { return true; } }
        public int Volume
        {
            get { return speech != null ? speech.Volume : -1; }
            set
            {
                if (speech != null)
                    speech.Volume = value;
            }
        }
        public bool CanChangeRate { get { return true; } }
        public int Rate
        {
            get { return speech != null ? speech.Rate : -1; }
            set
            {
                if (speech != null)
                    speech.Rate = value;
            }
        }

        public IList<TTSItem> GetInstalledVoices()
        {
            List<TTSItem> retVal = new List<TTSItem>();
            if (speech != null)
            {
                foreach (ISpeechObjectToken token in speech.GetVoices(string.Empty, string.Empty))
                {
                    // Populate the ComboBox Entries ..
                    retVal.Add(new TTSItem(token.GetDescription(49), token));
                }
            }
            return retVal;
        }
        public IList<TTSItem> GetOuputs()
        {
            List<TTSItem> retVal = new List<TTSItem>();
            if (speech != null)
            {
                foreach (ISpeechObjectToken token in speech.GetAudioOutputs())
                {
                    // Populate the ComboBox Entries ..
                    retVal.Add(new TTSItem(token.GetDescription(49), token));
                }
            }
            return retVal;
        }
        public TTSState State
        {
            get { return curState; }
            set
            {
                curState = value;
                StateChanged?.Invoke(this, EventArgs.Empty);
            }
        }

        TTSState curState = TTSState.None;
        public event EventHandler StateChanged;
        public void SetOutputToDefaultAudioDevice()
        {
        }
        public void SelectVoice(TTSItem voice)
        {
            speech.Voice = (SpObjectToken)voice.ItemObj;
        }
        public void SpeakAsync(string textToSpeak)
        {
            State = TTSState.Speaking;
            speech?.Speak(textToSpeak, SpeechVoiceSpeakFlags.SVSFlagsAsync);
        }
        public void Pause()
        {
            State = TTSState.Pause;
            speech?.Pause();
        }
        public void Resume()
        {
            State = TTSState.Speaking;
            speech?.Resume();
        }
        public System.Windows.Forms.Control AddControl()
        {
            return null;
        }
        public void Dispose()
        {
            State = TTSState.None;
            IDisposable idisposable = speech as IDisposable;
            idisposable?.Dispose();
            speech = null;
        }
        
    }
}
