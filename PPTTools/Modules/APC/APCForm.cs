using System;
using System.Windows.Forms;

namespace PPTTools {
    public partial class APCForm : Form {
        public APCForm() {
            InitializeComponent();
        }

        private void OnChanged(Decimal apc) {
            labelAPC.Text = apc.ToString("0.000 APC");
        }

        private void APCForm_Load(object sender, EventArgs e) {
            GameHelper.GameState._APC.Changed += OnChanged;
            GameHelper.GameState._APC.Update();
        }
    }
}
