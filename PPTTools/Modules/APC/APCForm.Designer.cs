namespace PPTTools {
    partial class APCForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(APCForm));
            this.labelAPC = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelAPC
            // 
            this.labelAPC.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAPC.ForeColor = System.Drawing.Color.Gainsboro;
            this.labelAPC.Location = new System.Drawing.Point(49, 11);
            this.labelAPC.Name = "labelAPC";
            this.labelAPC.Size = new System.Drawing.Size(165, 26);
            this.labelAPC.TabIndex = 2;
            this.labelAPC.Text = "0.000 APC";
            this.labelAPC.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // APCForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this.ClientSize = new System.Drawing.Size(218, 47);
            this.Controls.Add(this.labelAPC);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "APCForm";
            this.Text = "PPT APC";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.APCForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label labelAPC;
    }
}

