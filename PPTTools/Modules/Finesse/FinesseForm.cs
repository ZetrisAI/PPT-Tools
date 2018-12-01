using System;
using System.Windows.Forms;

namespace PPTTools {
    public partial class FinesseForm : Form {
        public FinesseForm() {
            InitializeComponent();
        }

        private void OnChanged(int errors) {
            labelFinesse.Text = $"Finesse: {errors.ToString()}";
        }

        private void FinesseForm_Load(object sender, EventArgs e) {
            GameHelper.GameState._Finesse.Changed += OnChanged;
            GameHelper.GameState._Finesse.Update();
        }
    }
}
