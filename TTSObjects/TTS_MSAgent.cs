using System;
using System.Collections.Generic;
using SpeechAgent.Items;
using SpeechAgent.Interfaces;
using SpeechAgent.Enum;
using System.IO;

namespace SpeechAgent.TTSObjects
{
    /// <summary>
    /// MSAgent
    /// </summary>
    public class TTS_MSAgent : ITTS
    {
        private AxAgentObjects.AxAgent axAgent;
        private AgentObjects.IAgentCtlCharacterEx speaker = null;
        public TTS_MSAgent(string user, string pwd)
        {
            this.axAgent = new AxAgentObjects.AxAgent();
            this.axAgent.Enabled = true;
            this.axAgent.Location = new System.Drawing.Point(50, 232);
            this.axAgent.Name = "axAgent";
            this.axAgent.Size = new System.Drawing.Size(32, 32);
            this.axAgent.TabIndex = 0;
        }
        public bool NeedLoginCredentials { get { return false; } }
        public bool CanChangeVolume { get { return false; } }
        public int Volume
        {
            get { return 50; }
            set
            {
            }
        }
        public bool CanChangeRate { get { return false; } }
        public int Rate
        {
            get { return -1; }
            set
            {
            }
        }

        public IList<TTSItem> GetInstalledVoices()
        {
            List<TTSItem> retVal = new List<TTSItem>();
            DirectoryInfo dir = new DirectoryInfo(Path.Combine(
                Environment.GetEnvironmentVariable("windir"), "MSAgent", "Chars"));
            var voices = dir.GetFiles("*.acs");
            foreach (var v in voices)
                retVal.Add(new TTSItem(Path.GetFileNameWithoutExtension(v.FullName), null));
            return retVal;
        }
        public IList<TTSItem> GetOuputs()
        {
            List<TTSItem> retVal = new List<TTSItem>();
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
        string lastVoice = null;
        public void SelectVoice(TTSItem voice)
        {
            if (lastVoice != null)
                this.axAgent.Characters.Unload(lastVoice);
            this.axAgent.Characters.Load(voice.Description, $"{voice.Description}.acs");
            this.speaker = this.axAgent.Characters[voice.Description];
            this.speaker.LanguageID = 0xC0A; //spanish
            this.speaker.Show(0);
            lastVoice = voice.Description;
        }
        public void SpeakAsync(string textToSpeak)
        {
            State = TTSState.Speaking;
            if (!string.IsNullOrEmpty(textToSpeak))
                this.speaker.Speak(textToSpeak);
        }
        public void Pause()
        {
        }
        public void Resume()
        {
        }
        public System.Windows.Forms.Control AddControl()
        {
            return axAgent;
        }
        public void Dispose()
        {
            State = TTSState.None;
            if (lastVoice != null)
                this.axAgent?.Characters.Unload(lastVoice);
            axAgent?.Dispose();
            axAgent = null;
        }

    }
}
