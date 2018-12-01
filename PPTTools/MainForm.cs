using System;
using System.IO;
using System.Windows.Forms;

namespace PPTTools {
    public partial class MainForm: Form {
        public MainForm() {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e) {
            GameHelper.GameState.Reset();
        }

        private void fileSelect(Modules.Module module) {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Text Files|*.txt";
            sfd.FileName = module.filename;

            if (sfd.ShowDialog() == DialogResult.OK) {
                if (!sfd.CheckFileExists) {
                    FileStream fs = File.Create(sfd.FileName);
                    fs.Close();
                }
                module.filename = sfd.FileName;
            }

            sfd.Dispose();
        }

        private void buttonFTX_Click(object sender, EventArgs e) {
            new FTXForm().Show();
        }

        private void buttonFTX_RightClick(object sender, MouseEventArgs e) {
            if (e.Button == MouseButtons.Right && ((Button)sender).ClientRectangle.Contains(e.Location)) {
                fileSelect(GameHelper.GameState._FTX);
            }
        }

        private void buttonPPS_Click(object sender, EventArgs e) {
            new PPSForm().Show();
        }

        private void buttonPPS_RightClick(object sender, MouseEventArgs e) {
            if (e.Button == MouseButtons.Right && ((Button)sender).ClientRectangle.Contains(e.Location)) {
                fileSelect(GameHelper.GameState._PPS);
            }
        }

        private void buttonKPP_Click(object sender, EventArgs e) {
            new KPPForm().Show();
        }

        private void buttonKPP_RightClick(object sender, MouseEventArgs e) {
            if (e.Button == MouseButtons.Right && ((Button)sender).ClientRectangle.Contains(e.Location)) {
                fileSelect(GameHelper.GameState._KPP);
            }
        }

        private void buttonAPM_Click(object sender, EventArgs e) {
            new APMForm().Show();
        }

        private void buttonAPM_RightClick(object sender, MouseEventArgs e) {
            if (e.Button == MouseButtons.Right && ((Button)sender).ClientRectangle.Contains(e.Location)) {
                fileSelect(GameHelper.GameState._APM);
            }
        }

        private void buttonAPC_Click(object sender, EventArgs e) {
            new APCForm().Show();
        }

        private void buttonAPC_RightClick(object sender, MouseEventArgs e) {
            if (e.Button == MouseButtons.Right && ((Button)sender).ClientRectangle.Contains(e.Location)) {
                fileSelect(GameHelper.GameState._APC);
            }
        }

        private void buttonFinesse_Click(object sender, EventArgs e) {
            new FinesseForm().Show();
        }

        private void buttonFinesse_RightClick(object sender, MouseEventArgs e) {
            if (e.Button == MouseButtons.Right && ((Button)sender).ClientRectangle.Contains(e.Location)) {
                fileSelect(GameHelper.GameState._Finesse);
            }
        }

        private void buttonDuration_Click(object sender, EventArgs e) {
            new DurationForm().Show();
        }

        private void buttonDuration_RightClick(object sender, MouseEventArgs e) {
            if (e.Button == MouseButtons.Right && ((Button)sender).ClientRectangle.Contains(e.Location)) {
                fileSelect(GameHelper.GameState._Duration);
            }
        }

        private void buttonRating_Click(object sender, EventArgs e) {
            new RatingForm().Show();
        }

        private void buttonRating_RightClick(object sender, MouseEventArgs e) {
            if (e.Button == MouseButtons.Right && ((Button)sender).ClientRectangle.Contains(e.Location)) {
                fileSelect(GameHelper.GameState._Rating);
            }
        }

        private void buttonInputs_Click(object sender, EventArgs e) {
            new InputsForm().Show();
        }
    }
}
