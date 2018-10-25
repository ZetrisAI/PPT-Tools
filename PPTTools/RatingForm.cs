using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PPTTools {
    public partial class RatingForm : Form {
        public RatingForm() {
            InitializeComponent();
        }

        private void OnChanged(int start, int current) {
            labelStart.Text = start.ToString();
            labelCurrent.Text = current.ToString();
        }

        private void RatingForm_Load(object sender, EventArgs e) {
            GameHelper.GameState._Rating.Changed += OnChanged;
        }
    }
}
