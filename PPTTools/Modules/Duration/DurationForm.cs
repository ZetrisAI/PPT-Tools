using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PPTTools {
    public partial class DurationForm : Form {
        public DurationForm() {
            InitializeComponent();
        }

        private void OnChanged(string time) {
            labelDuration.Text = time;
        }

        private void DurationForm_Load(object sender, EventArgs e) {
            GameHelper.GameState._Duration.Changed += OnChanged;
            GameHelper.GameState._Duration.Update();
        }
    }
}
