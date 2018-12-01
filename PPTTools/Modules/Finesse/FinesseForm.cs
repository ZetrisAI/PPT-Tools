using System;
using System.Windows.Forms;

namespace PPTTools {
    public partial class FinesseForm : Form {
        public FinesseForm() {
            InitializeComponent();
        }

        private void OnChanged(int errors, int? piece, int? hold, int pos, int rot, bool holdused, int holdptr) {
            labelFinesse.Text = $"Finesse: {errors.ToString()}";
            label1.Text = piece.ToString();
            label2.Text = hold.ToString();
            label3.Text = holdused.ToString();
            label4.Text = pos.ToString();
            label5.Text = rot.ToString();
            label6.Text = holdptr.ToString("X8");
        }

        private void FinesseForm_Load(object sender, EventArgs e) {
            GameHelper.GameState._Finesse.Changed += OnChanged;
            GameHelper.GameState._Finesse.Update();
        }
    }
}
