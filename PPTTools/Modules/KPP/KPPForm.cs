using System;
using System.Windows.Forms;

namespace PPTTools {
    public partial class KPPForm : Form {
        public KPPForm() {
            InitializeComponent();
        }

        private void OnChanged(Decimal kpp) {
            labelKPP.Text = kpp.ToString("0.000 KPP");
        }

        private void KPPForm_Load(object sender, EventArgs e) {
            GameHelper.GameState._KPP.Changed += OnChanged;
            GameHelper.GameState._KPP.Update();
        }
    }
}
