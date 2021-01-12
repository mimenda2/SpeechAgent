using Amazon.Polly;
using Amazon.Polly.Model;
using NAudio.Wave;
using SpeechAgent.Enum;
using SpeechAgent.Interfaces;
using SpeechAgent.Items;
using System.Collections.Generic;
using System.IO;
using System;

namespace SpeechAgent.TTSObjects
{
    public class TTS_AmazonPolly : ITTS
    {
        VoiceId selVoice = VoiceId.Lucia;
        float volume = 1;
        WaveOut waveOutDevice;
        AudioFileReader audioFileReader;
        string user;
        string pwd;
        public TTS_AmazonPolly(string user, string pwd)
        {
            this.user = user;
            this.pwd = pwd;
        }
        public bool NeedLoginCredentials { get { return true; } }
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
            retVal.Add(new TTSItem(VoiceId.Lucia.ToString(), VoiceId.Lucia));
            retVal.Add(new TTSItem(VoiceId.Conchita.ToString(), VoiceId.Conchita));
            retVal.Add(new TTSItem(VoiceId.Enrique.ToString(), VoiceId.Enrique));
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
            selVoice = voice.ItemObj as VoiceId;
        }

        public void SpeakAsync(string textToSpeak)
        {
            string fileName = SpeechUtils.GetTempPathFileName(extension: "mp3");
            AmazonPollyClient pc = new AmazonPollyClient(user, pwd, Amazon.RegionEndpoint.EUWest3);

            SynthesizeSpeechRequest sreq = new SynthesizeSpeechRequest();
            sreq.Text = textToSpeak;
            sreq.OutputFormat = OutputFormat.Mp3;
            sreq.VoiceId = selVoice;
            SynthesizeSpeechResponse sres = pc.SynthesizeSpeech(sreq);

            using (var fileStream = File.Create(fileName))
            {
                sres.AudioStream.CopyTo(fileStream);
                fileStream.Flush();
                fileStream.Close();
            }

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
