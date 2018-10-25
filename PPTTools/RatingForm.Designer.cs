namespace PPTTools {
    partial class RatingForm {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RatingForm));
            this.labelStart = new System.Windows.Forms.Label();
            this.labelCurrent = new System.Windows.Forms.Label();
            this.labelDelimiter = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelStart
            // 
            this.labelStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelStart.ForeColor = System.Drawing.Color.Gainsboro;
            this.labelStart.Location = new System.Drawing.Point(4, 11);
            this.labelStart.Name = "labelStart";
            this.labelStart.Size = new System.Drawing.Size(100, 26);
            this.labelStart.TabIndex = 0;
            this.labelStart.Text = "0";
            this.labelStart.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // labelCurrent
            // 
            this.labelCurrent.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCurrent.ForeColor = System.Drawing.Color.Gainsboro;
            this.labelCurrent.Location = new System.Drawing.Point(117, 11);
            this.labelCurrent.Name = "labelCurrent";
            this.labelCurrent.Size = new System.Drawing.Size(96, 26);
            this.labelCurrent.TabIndex = 0;
            this.labelCurrent.Text = "0";
            // 
            // labelDelimiter
            // 
            this.labelDelimiter.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDelimiter.ForeColor = System.Drawing.Color.Gainsboro;
            this.labelDelimiter.Location = new System.Drawing.Point(81, 11);
            this.labelDelimiter.Name = "labelDelimiter";
            this.labelDelimiter.Size = new System.Drawing.Size(59, 26);
            this.labelDelimiter.TabIndex = 0;
            this.labelDelimiter.Text = ">";
            this.labelDelimiter.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // RatingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this.ClientSize = new System.Drawing.Size(218, 47);
            this.Controls.Add(this.labelCurrent);
            this.Controls.Add(this.labelStart);
            this.Controls.Add(this.labelDelimiter);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "RatingForm";
            this.Text = "PPT Rating";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.RatingForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label labelStart;
        private System.Windows.Forms.Label labelCurrent;
        private System.Windows.Forms.Label labelDelimiter;
    }
}

