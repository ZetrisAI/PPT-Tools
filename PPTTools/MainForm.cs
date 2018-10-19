using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace PPTTools {
    public partial class MainForm : Form {
        public MainForm() {
            InitializeComponent();
        }
        
        static VAMemory PPT;
        
        private enum MatchState {
            Menu,   
            Match,  
            Finished
        }
        
        static MatchState match = MatchState.Menu;

        int[] score = new int[2] {0, 0};
        int[] total = new int[2] {0, 0};

        int pieces = 0;
        int state = 0;

        private void ScanTimer_Tick(object sender, EventArgs e) {
            if (PPT == null) {
                if (Process.GetProcessesByName("puyopuyotetris").Length != 0) {
                    PPT = new VAMemory("puyopuyotetris");
                } else {
                    return;
                }
            } else if (Process.GetProcessesByName("puyopuyotetris").Length == 0) {
                PPT = null;
                return;
            }
            
            int scoreAddress = PPT.ReadInt32(new IntPtr(0x14057F048));
            
            if (scoreAddress == 0x0) {
                if (match == MatchState.Finished) {
                    match = MatchState.Menu;
                    score[0] = score[1] = total[0] = total[1] = 0;
                }
            } else {
                if (match == MatchState.Menu) {
                    match = MatchState.Match;
                }
                scoreAddress += 0x38;
            }
            
            if (match == MatchState.Match) {
                for (int i = 0; i < 2; i++) {
                    int temp = PPT.ReadInt32(new IntPtr(scoreAddress) + i * 4);
                    if (temp > score[i]) {
                        total[i]++;
                    }
                    score[i] = temp;
                }
            }
            
            if (PPT.ReadInt32(new IntPtr(0x140573A78)) != 0x0) {
                if (match == MatchState.Match) {
                    match = MatchState.Finished;
                }
            }
            
            labelP1.Text = total[0].ToString();
            labelP2.Text = total[1].ToString();

            int drop = PPT.ReadByte(new IntPtr(
                PPT.ReadInt32(new IntPtr(
                    PPT.ReadInt32(new IntPtr(
                        PPT.ReadInt32(new IntPtr(
                            PPT.ReadInt32(new IntPtr(
                                PPT.ReadInt32(new IntPtr(
                                    0x140460C08
                                )) + 0x18
                            )) + 0x268
                        )) + 0x38
                    )) + 0x3C8
                )) + 0x1C
            ));

            if (drop != state) {
                if (drop == 1) {
                    pieces++;
                }
                state = drop;
            }

            int frames = PPT.ReadInt32(new IntPtr(
                PPT.ReadInt32(new IntPtr(
                    0x1405989F0
                )) + 0x594
            ));

            if (frames < 2) {
                pieces = 0;
            }

            if (frames != 0) {
                Decimal pps = Decimal.Divide(pieces, frames) * 60;
                labelPPS.Text = $"{pps.ToString("0.000")} PPS";
            }
        }
    }
}
