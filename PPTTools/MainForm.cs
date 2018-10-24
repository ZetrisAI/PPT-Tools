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
            FTXForm a = new FTXForm();
            a.Show();
        }
    }
}
