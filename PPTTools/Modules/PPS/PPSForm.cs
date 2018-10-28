using System;
using System.Windows.Forms;

namespace PPTTools {
    public partial class PPSForm : Form {
        public PPSForm() {
            InitializeComponent();
        }

        private void OnChanged(Decimal pps) {
            labelPPS.Text = pps.ToString("0.000 PPS");
        }

        private void PPSForm_Load(object sender, EventArgs e) {
            GameHelper.GameState._PPS.Changed += OnChanged;
            GameHelper.GameState._PPS.Update();
        }
    }
}
