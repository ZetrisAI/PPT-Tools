using System;
using System.Windows.Forms;

namespace PPTTools {
    public partial class FTXForm : Form {
        public FTXForm() {
            InitializeComponent();
        }

        private void OnChanged(int[] score) {
            labelP1.Text = score[0].ToString();
            labelP2.Text = score[1].ToString();
        }

        private void FTXForm_Load(object sender, EventArgs e) {
            GameHelper.GameState._FTX.Changed += OnChanged;
            GameHelper.GameState._FTX.Update();
        }
    }
}
