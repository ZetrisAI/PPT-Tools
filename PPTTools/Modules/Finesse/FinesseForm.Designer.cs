namespace PPTTools {
    partial class FinesseForm {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FinesseForm));
            this.labelFinesse = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelFinesse
            // 
            this.labelFinesse.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFinesse.ForeColor = System.Drawing.Color.Gainsboro;
            this.labelFinesse.Location = new System.Drawing.Point(10, 11);
            this.labelFinesse.Name = "labelFinesse";
            this.labelFinesse.Size = new System.Drawing.Size(198, 26);
            this.labelFinesse.TabIndex = 2;
            this.labelFinesse.Text = "Finesse: 0";
            // 
            // FinesseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this.ClientSize = new System.Drawing.Size(218, 47);
            this.Controls.Add(this.labelFinesse);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FinesseForm";
            this.Text = "PPT Finesse";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.FinesseForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label labelFinesse;
    }
}

