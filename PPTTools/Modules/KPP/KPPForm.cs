using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
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
