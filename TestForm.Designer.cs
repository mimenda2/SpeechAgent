namespace SpeechAgent
{
    partial class TestForm
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.grpTTS = new System.Windows.Forms.GroupBox();
            this.txtPwd = new System.Windows.Forms.TextBox();
            this.lblPwd = new System.Windows.Forms.Label();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.lblUser = new System.Windows.Forms.Label();
            this.rateTrackBar = new System.Windows.Forms.TrackBar();
            this.lblRate = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.volumeTrackBar = new System.Windows.Forms.TrackBar();
            this.cmbVoices = new System.Windows.Forms.ComboBox();
            this.richTextBox1 = new System.Windows.Forms.TextBox();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnPause = new System.Windows.Forms.Button();
            this.btnResume = new System.Windows.Forms.Button();
            this.btnSpeak = new System.Windows.Forms.Button();
            this.lblEngine = new System.Windows.Forms.Label();
            this.cmbEngine = new System.Windows.Forms.ComboBox();
            this.grpTTS.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rateTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.volumeTrackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // grpTTS
            // 
            this.grpTTS.Controls.Add(this.txtPwd);
            this.grpTTS.Controls.Add(this.lblPwd);
            this.grpTTS.Controls.Add(this.txtUser);
            this.grpTTS.Controls.Add(this.lblUser);
            this.grpTTS.Controls.Add(this.rateTrackBar);
            this.grpTTS.Controls.Add(this.lblRate);
            this.grpTTS.Controls.Add(this.label2);
            this.grpTTS.Controls.Add(this.label1);
            this.grpTTS.Controls.Add(this.volumeTrackBar);
            this.grpTTS.Controls.Add(this.cmbVoices);
            this.grpTTS.Controls.Add(this.richTextBox1);
            this.grpTTS.Controls.Add(this.btnStop);
            this.grpTTS.Controls.Add(this.btnPause);
            this.grpTTS.Controls.Add(this.btnResume);
            this.grpTTS.Controls.Add(this.btnSpeak);
            this.grpTTS.Location = new System.Drawing.Point(12, 50);
            this.grpTTS.Name = "grpTTS";
            this.grpTTS.Size = new System.Drawing.Size(481, 328);
            this.grpTTS.TabIndex = 11;
            this.grpTTS.TabStop = false;
            this.grpTTS.Text = "Controles";
            this.grpTTS.Visible = false;
            // 
            // txtPwd
            // 
            this.txtPwd.Location = new System.Drawing.Point(291, 262);
            this.txtPwd.Name = "txtPwd";
            this.txtPwd.Size = new System.Drawing.Size(184, 20);
            this.txtPwd.TabIndex = 25;
            // 
            // lblPwd
            // 
            this.lblPwd.AutoSize = true;
            this.lblPwd.Location = new System.Drawing.Point(257, 265);
            this.lblPwd.Name = "lblPwd";
            this.lblPwd.Size = new System.Drawing.Size(28, 13);
            this.lblPwd.TabIndex = 24;
            this.lblPwd.Text = "Pwd";
            // 
            // txtUser
            // 
            this.txtUser.Location = new System.Drawing.Point(291, 236);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(184, 20);
            this.txtUser.TabIndex = 23;
            // 
            // lblUser
            // 
            this.lblUser.AutoSize = true;
            this.lblUser.Location = new System.Drawing.Point(257, 239);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(29, 13);
            this.lblUser.TabIndex = 22;
            this.lblUser.Text = "User";
            // 
            // rateTrackBar
            // 
            this.rateTrackBar.LargeChange = 2;
            this.rateTrackBar.Location = new System.Drawing.Point(66, 231);
            this.rateTrackBar.Minimum = -10;
            this.rateTrackBar.Name = "rateTrackBar";
            this.rateTrackBar.Size = new System.Drawing.Size(174, 45);
            this.rateTrackBar.TabIndex = 21;
            // 
            // lblRate
            // 
            this.lblRate.AutoSize = true;
            this.lblRate.Location = new System.Drawing.Point(6, 247);
            this.lblRate.Name = "lblRate";
            this.lblRate.Size = new System.Drawing.Size(32, 13);
            this.lblRate.TabIndex = 20;
            this.lblRate.Text = "Ratio";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 208);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 13);
            this.label2.TabIndex = 19;
            this.label2.Text = "Volumen";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(257, 210);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(25, 13);
            this.label1.TabIndex = 18;
            this.label1.Text = "Voz";
            // 
            // volumeTrackBar
            // 
            this.volumeTrackBar.Location = new System.Drawing.Point(66, 198);
            this.volumeTrackBar.Maximum = 100;
            this.volumeTrackBar.Name = "volumeTrackBar";
            this.volumeTrackBar.Size = new System.Drawing.Size(174, 45);
            this.volumeTrackBar.TabIndex = 17;
            // 
            // cmbVoices
            // 
            this.cmbVoices.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbVoices.FormattingEnabled = true;
            this.cmbVoices.Location = new System.Drawing.Point(291, 205);
            this.cmbVoices.Name = "cmbVoices";
            this.cmbVoices.Size = new System.Drawing.Size(184, 21);
            this.cmbVoices.TabIndex = 16;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(6, 19);
            this.richTextBox1.Multiline = true;
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(469, 173);
            this.richTextBox1.TabIndex = 15;
            this.richTextBox1.Text = "Hola mundo";
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(400, 296);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(75, 23);
            this.btnStop.TabIndex = 14;
            this.btnStop.Text = "STOP";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnPause
            // 
            this.btnPause.Location = new System.Drawing.Point(319, 296);
            this.btnPause.Name = "btnPause";
            this.btnPause.Size = new System.Drawing.Size(75, 23);
            this.btnPause.TabIndex = 13;
            this.btnPause.Text = "PAUSE";
            this.btnPause.UseVisualStyleBackColor = true;
            this.btnPause.Click += new System.EventHandler(this.btnPause_Click);
            // 
            // btnResume
            // 
            this.btnResume.Location = new System.Drawing.Point(238, 296);
            this.btnResume.Name = "btnResume";
            this.btnResume.Size = new System.Drawing.Size(75, 23);
            this.btnResume.TabIndex = 12;
            this.btnResume.Text = "RESUME";
            this.btnResume.UseVisualStyleBackColor = true;
            this.btnResume.Click += new System.EventHandler(this.btnResume_Click);
            // 
            // btnSpeak
            // 
            this.btnSpeak.Location = new System.Drawing.Point(157, 296);
            this.btnSpeak.Name = "btnSpeak";
            this.btnSpeak.Size = new System.Drawing.Size(75, 23);
            this.btnSpeak.TabIndex = 11;
            this.btnSpeak.Text = "SPEAK";
            this.btnSpeak.UseVisualStyleBackColor = true;
            this.btnSpeak.Click += new System.EventHandler(this.btnSpeak_Click);
            // 
            // lblEngine
            // 
            this.lblEngine.AutoSize = true;
            this.lblEngine.Location = new System.Drawing.Point(15, 17);
            this.lblEngine.Name = "lblEngine";
            this.lblEngine.Size = new System.Drawing.Size(34, 13);
            this.lblEngine.TabIndex = 20;
            this.lblEngine.Text = "Motor";
            // 
            // cmbEngine
            // 
            this.cmbEngine.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEngine.FormattingEnabled = true;
            this.cmbEngine.Location = new System.Drawing.Point(51, 12);
            this.cmbEngine.Name = "cmbEngine";
            this.cmbEngine.Size = new System.Drawing.Size(436, 21);
            this.cmbEngine.TabIndex = 19;
            this.cmbEngine.SelectedIndexChanged += new System.EventHandler(this.cmbEngine_SelectedIndexChanged);
            // 
            // TestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(505, 390);
            this.Controls.Add(this.lblEngine);
            this.Controls.Add(this.cmbEngine);
            this.Controls.Add(this.grpTTS);
            this.Name = "TestForm";
            this.Text = "Pruebas TTS";
            this.grpTTS.ResumeLayout(false);
            this.grpTTS.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rateTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.volumeTrackBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grpTTS;
        private System.Windows.Forms.TrackBar rateTrackBar;
        private System.Windows.Forms.Label lblRate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TrackBar volumeTrackBar;
        private System.Windows.Forms.ComboBox cmbVoices;
        private System.Windows.Forms.TextBox richTextBox1;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnPause;
        private System.Windows.Forms.Button btnResume;
        private System.Windows.Forms.Button btnSpeak;
        private System.Windows.Forms.TextBox txtUser;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.TextBox txtPwd;
        private System.Windows.Forms.Label lblPwd;
        private System.Windows.Forms.Label lblEngine;
        private System.Windows.Forms.ComboBox cmbEngine;
    }
}

