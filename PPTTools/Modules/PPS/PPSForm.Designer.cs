namespace PPTTools {
    partial class PPSForm {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PPSForm));
            this.labelPPS = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelPPS
            // 
            this.labelPPS.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPPS.ForeColor = System.Drawing.Color.Gainsboro;
            this.labelPPS.Location = new System.Drawing.Point(49, 11);
            this.labelPPS.Name = "labelPPS";
            this.labelPPS.Size = new System.Drawing.Size(165, 26);
            this.labelPPS.TabIndex = 2;
            this.labelPPS.Text = "0.000 PPS";
            this.labelPPS.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // PPSForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this.ClientSize = new System.Drawing.Size(218, 47);
            this.Controls.Add(this.labelPPS);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "PPSForm";
            this.Text = "PPT PPS";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.PPSForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label labelPPS;
    }
}

