using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
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
        }
    }
}
