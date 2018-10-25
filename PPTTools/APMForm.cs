using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PPTTools {
    public partial class APMForm : Form {
        public APMForm() {
            InitializeComponent();
        }

        private void OnChanged(Decimal apm) {
            labelAPM.Text = apm.ToString("0.000 APM");
        }

        private void APMForm_Load(object sender, EventArgs e) {
            GameHelper.GameState._APM.Changed += OnChanged;
        }
    }
}
