using System;
using System.Drawing;
using System.Windows.Forms;

namespace PPTTools {
    public partial class InputsForm : Form {
        public InputsForm() {
            InitializeComponent();
        }

        private void OnChanged(int[] keys) {
            for (int i = 0; i < 7; i++)
                ((PictureBox)this.Controls[$"pictureKey{i}"]).BackgroundImage = (Image)PPTTools.Properties.Resources.ResourceManager.GetObject($"key{i}_{keys[i]}");
        }

        private void FTXForm_Load(object sender, EventArgs e) {
            GameHelper.GameState._Inputs.Changed += OnChanged;
            GameHelper.GameState._Inputs.Update();
        }
    }
}
