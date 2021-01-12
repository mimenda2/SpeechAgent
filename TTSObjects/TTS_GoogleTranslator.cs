using NAudio.Wave;
using SpeechAgent.Enum;
using SpeechAgent.Interfaces;
using SpeechAgent.Items;
using System.Collections.Generic;
using System.IO;
using System;
using System.Text;
using System.Web;
using System.Net;

namespace SpeechAgent.TTSObjects
{
    public class TTS_GoogleTranslator : ITTS
    {
        float volume = 1;
        WaveOut waveOutDevice;
        AudioFileReader audioFileReader;
        public TTS_GoogleTranslator(string user, string pwd)
        {
        }
        public bool NeedLoginCredentials { get { return false; } }
        public bool CanChangeVolume { get { return true; } }
        public int Volume
        {
            get
            {
                return (int)(volume * 100);
            }
            set
            {
                volume = (float)((float)value / 100);
                if (waveOutDevice != null)
                    waveOutDevice.Volume = volume;
            }
        }
        public bool CanChangeRate { get { return false; } }

        public int Rate
        {
            get { return 1; }
            set
            {
            }
        }

        public IList<TTSItem> GetInstalledVoices()
        {
            List<TTSItem> retVal = new List<TTSItem>();
            retVal.Add(new TTSItem("Default", null));
            return retVal;
        }
        public IList<TTSItem> GetOuputs()
        {
            return new List<TTSItem>();
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
        }
        void DownloadMp3(string text, string fileName)
        {
            //http://translate.google.com/translate_tts?ie=UTF-8&total=1&idx=0&textlen=32&client=tw-ob&q=Esto+es+una+prueba&tl=es
            string url = $"http://translate.google.com/translate_tts?ie=UTF-8&total=1&idx=0&textlen={text.Length + 12}&client=tw-ob&q=";
            url += HttpUtility.UrlEncode(text, Encoding.GetEncoding("utf-8"));
            url += "&tl=es";
            using (var client = new WebClient())
            {
                client.Headers[HttpRequestHeader.UserAgent] = "Mozilla/5.0 (Windows NT 6.1; WOW64; rv:7.0.1) Gecko/20100101 Firefox/7.0.1";
                client.DownloadFile(url, fileName);
            }
        }

        public void SpeakAsync(string textToSpeak)
        {
            string fileName = SpeechUtils.GetTempPathFileName(extension: "mp3");
            DownloadMp3(textToSpeak, fileName);

            waveOutDevice = new WaveOut();
            audioFileReader = new AudioFileReader(fileName);
            waveOutDevice.Init(audioFileReader);
            waveOutDevice.Volume = volume;
            waveOutDevice.Play();
            State = TTSState.Speaking;
            waveOutDevice.PlaybackStopped += WaveOutDevice_PlaybackStopped;
        }

        private void WaveOutDevice_PlaybackStopped(object sender, StoppedEventArgs e)
        {
            if (waveOutDevice != null)
                waveOutDevice.PlaybackStopped -= WaveOutDevice_PlaybackStopped;
            waveOutDevice?.Stop();
            audioFileReader?.Dispose();
            waveOutDevice?.Dispose();
            waveOutDevice = null;
            audioFileReader = null;
            waveOutDevice = null;
            State = TTSState.None;
        }

        public void Pause()
        {
            State = TTSState.Pause;
            waveOutDevice?.Pause();
        }
        public void Resume()
        {
            State = TTSState.Speaking;
            waveOutDevice?.Play();
        }
        public System.Windows.Forms.Control AddControl()
        {
            return null;
        }

        public void Dispose()
        {
            WaveOutDevice_PlaybackStopped(this, null);
        }
    }
}
