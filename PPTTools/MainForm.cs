using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace PPTTools {
    public partial class MainForm: Form {
        public MainForm() {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e) {
            GameHelper.GameState.Reset();
        }

        private void buttonFTX_Click(object sender, EventArgs e) {
            new FTXForm().Show();
        }

        private void buttonPPS_Click(object sender, EventArgs e) {
            new PPSForm().Show();
        }

        private void buttonKPP_Click(object sender, EventArgs e) {
            new KPPForm().Show();
        }

        private void buttonAPM_Click(object sender, EventArgs e) {
            new APMForm().Show();
        }

        private void buttonAPC_Click(object sender, EventArgs e) {
            new APCForm().Show();
        }

        private void buttonFinesse_Click(object sender, EventArgs e) {
            new FinesseForm().Show();
        }

        private void buttonDuration_Click(object sender, EventArgs e) {
            new DurationForm().Show();
        }

        private void buttonRating_Click(object sender, EventArgs e) {
            new RatingForm().Show();
        }

        private void buttonReset_Click(object sender, EventArgs e) {
            GameHelper.GameState.Reset();
        }
    }
}
