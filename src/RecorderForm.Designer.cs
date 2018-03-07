namespace VncRecorder
{
    partial class RecorderForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.textBoxVncIp = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonStartRecord = new System.Windows.Forms.Button();
            this.buttonStop = new System.Windows.Forms.Button();
            this.rd = new VncSharp.RemoteDesktop();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBoxVncIp
            // 
            this.textBoxVncIp.Location = new System.Drawing.Point(97, 506);
            this.textBoxVncIp.Name = "textBoxVncIp";
            this.textBoxVncIp.Size = new System.Drawing.Size(152, 21);
            this.textBoxVncIp.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 510);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "IP Address";
            // 
            // buttonStartRecord
            // 
            this.buttonStartRecord.Location = new System.Drawing.Point(577, 510);
            this.buttonStartRecord.Name = "buttonStartRecord";
            this.buttonStartRecord.Size = new System.Drawing.Size(75, 21);
            this.buttonStartRecord.TabIndex = 7;
            this.buttonStartRecord.Text = "Start Record";
            this.buttonStartRecord.UseVisualStyleBackColor = true;
            this.buttonStartRecord.Click += new System.EventHandler(this.buttonStartRecord_Click);
            // 
            // buttonStop
            // 
            this.buttonStop.Enabled = false;
            this.buttonStop.Location = new System.Drawing.Point(667, 510);
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.Size = new System.Drawing.Size(75, 21);
            this.buttonStop.TabIndex = 8;
            this.buttonStop.Text = "Stop Record";
            this.buttonStop.UseVisualStyleBackColor = true;
            this.buttonStop.Click += new System.EventHandler(this.buttonStop_Click);
            // 
            // rd
            // 
            this.rd.AutoScroll = true;
            this.rd.AutoScrollMinSize = new System.Drawing.Size(608, 427);
            this.rd.Location = new System.Drawing.Point(42, 5);
            this.rd.Name = "rd";
            this.rd.Size = new System.Drawing.Size(700, 485);
            this.rd.TabIndex = 0;
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Location = new System.Drawing.Point(348, 506);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.Size = new System.Drawing.Size(161, 21);
            this.textBoxPassword.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(277, 510);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 10;
            this.label2.Text = "Password";
            // 
            // RecorderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 610);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxPassword);
            this.Controls.Add(this.buttonStop);
            this.Controls.Add(this.buttonStartRecord);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxVncIp);
            this.Controls.Add(this.rd);
            this.Name = "RecorderForm";
            this.Text = "VNC recorder";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private VncSharp.RemoteDesktop rd;
        private System.Windows.Forms.TextBox textBoxVncIp;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonStartRecord;
        private System.Windows.Forms.Button buttonStop;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.Label label2;
    }
}

