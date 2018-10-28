using System;
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
