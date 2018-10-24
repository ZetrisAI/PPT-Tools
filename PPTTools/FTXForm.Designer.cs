namespace PPTTools {
    partial class FTXForm {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FTXForm));
            this.labelP1 = new System.Windows.Forms.Label();
            this.labelP2 = new System.Windows.Forms.Label();
            this.labelDelimiter = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelP1
            // 
            this.labelP1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelP1.ForeColor = System.Drawing.Color.Gainsboro;
            this.labelP1.Location = new System.Drawing.Point(26, 11);
            this.labelP1.Name = "labelP1";
            this.labelP1.Size = new System.Drawing.Size(78, 26);
            this.labelP1.TabIndex = 0;
            this.labelP1.Text = "0";
            this.labelP1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // labelP2
            // 
            this.labelP2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelP2.ForeColor = System.Drawing.Color.Gainsboro;
            this.labelP2.Location = new System.Drawing.Point(117, 11);
            this.labelP2.Name = "labelP2";
            this.labelP2.Size = new System.Drawing.Size(76, 26);
            this.labelP2.TabIndex = 0;
            this.labelP2.Text = "0";
            // 
            // labelDelimiter
            // 
            this.labelDelimiter.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDelimiter.ForeColor = System.Drawing.Color.Gainsboro;
            this.labelDelimiter.Location = new System.Drawing.Point(81, 11);
            this.labelDelimiter.Name = "labelDelimiter";
            this.labelDelimiter.Size = new System.Drawing.Size(59, 26);
            this.labelDelimiter.TabIndex = 0;
            this.labelDelimiter.Text = "-";
            this.labelDelimiter.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // FTXForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this.ClientSize = new System.Drawing.Size(218, 47);
            this.Controls.Add(this.labelP2);
            this.Controls.Add(this.labelP1);
            this.Controls.Add(this.labelDelimiter);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FTXForm";
            this.Text = "PPT Score";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.FTXForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label labelP1;
        private System.Windows.Forms.Label labelP2;
        private System.Windows.Forms.Label labelDelimiter;
    }
}

