using SpeechAgent.Enum;
using SpeechAgent.Interfaces;
using SpeechAgent.Items;
using SpeechAgent.TTSObjects;
using System;
using System.Windows.Forms;

namespace SpeechAgent
{
    public partial class TestForm : Form
    {
        SpeechAgentObject speechAgent = null;
        public TestForm()
        {
            InitializeComponent();

            foreach (TTS_EnumObjects engine in System.Enum.GetValues(typeof(TTS_EnumObjects)))
                cmbEngine.Items.Add(new TTSItem(engine.ToString(), engine));
            cmbEngine.SelectedIndex = 0;
            Disposed += delegate
            {
                DiposeSpeechAgent();
            };
        }

        void DiposeSpeechAgent()
        {
            var ctrl = speechAgent?.AddControl();
            if (ctrl != null)
                this.Controls.Remove(ctrl);
            speechAgent?.Dispose();
            speechAgent = null;
        }
        private void InitTTS(TTS_EnumObjects ttsType)
        {
            try
            {
                grpTTS.Visible = true;
                btnStop_Click(this, EventArgs.Empty);
                cmbVoices.Items.Clear();

                DiposeSpeechAgent();
                speechAgent = new SpeechAgentObject(ttsType);
                var ctrl = speechAgent.AddControl();
                if (ctrl != null)
                    this.Controls.Add(ctrl);
                var ttsData = speechAgent.GetTTSData();
                foreach (var v in ttsData.InstalledVoices)
                    cmbVoices.Items.Add(v);
                volumeTrackBar.Value = ttsData.Volume;
                label2.Visible = volumeTrackBar.Visible = ttsData.CanChangeVolume;
                lblRate.Visible = rateTrackBar.Visible = ttsData.CanChangeRate;
                rateTrackBar.Value = ttsData.Rate;
                lblUser.Visible = txtUser.Visible =
                    lblPwd.Visible = txtPwd.Visible = ttsData.NeedLoginCredentials;
                if (cmbVoices.Items.Count > 0)
                    cmbVoices.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"InitTTS Error: {ex.Message}");
            }
        }

        private void btnSpeak_Click(object sender, EventArgs e)
        {
            if (richTextBox1.Text != "")
            {
                try
                {
                    speechAgent.TextToVoice(richTextBox1.Text,
                        txtUser.Text, txtPwd.Text,
                        cmbVoices.SelectedItem as TTSItem, volumeTrackBar.Value,
                        rateTrackBar.Visible ? (int?)rateTrackBar.Value : null);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"btnSpeak_Click Error: {ex.Message}");
                }
                btnPause.Enabled = true;
                btnStop.Enabled = true;
            }
        }

        private void btnPause_Click(object sender, EventArgs e)
        {
            speechAgent?.Pause();
            btnResume.Enabled = true;
            btnSpeak.Enabled = false;
        }

        private void btnResume_Click(object sender, EventArgs e)
        {
            speechAgent?.Resume();
            btnResume.Enabled = false;
            btnSpeak.Enabled = true;
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            speechAgent?.Stop();
            btnSpeak.Enabled = true;
            btnResume.Enabled = false;
            btnPause.Enabled = false;
            btnStop.Enabled = false;
        }

        private void volumeTrackBar_Scroll(object sender, EventArgs e)
        {
            btnStop_Click(this, EventArgs.Empty);
        }

        private void rateTrackBar_Scroll(object sender, EventArgs e)
        {
            btnStop_Click(this, EventArgs.Empty);
        }

        private void cmbEngine_SelectedIndexChanged(object sender, EventArgs e)
        {
            TTSItem item = cmbEngine.SelectedItem as TTSItem;
            if (item != null)
                InitTTS((TTS_EnumObjects)item.ItemObj);
        }
    }
}
