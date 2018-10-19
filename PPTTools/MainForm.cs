using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace PPTTools {
    public partial class MainForm : Form {
        public MainForm() {
            InitializeComponent();
        }
        
        static VAMemory PPT;

        private bool EnsurePPT() {
            if (PPT == null) {
                if (Process.GetProcessesByName("puyopuyotetris").Length != 0) {
                    PPT = new VAMemory("puyopuyotetris");
                } else {
                    return false;
                }
            } else if (Process.GetProcessesByName("puyopuyotetris").Length == 0) {
                PPT = null;
                return false;
            }

            return true;
        }

        private int FindPlayer() {
            if (GameHelper.PlayerCount(PPT) < 2) {
                return 0;
            }

            int localSteam = GameHelper.LocalSteam(PPT);

            for (int i = 0; i < 2; i++) {
                if (localSteam == GameHelper.PlayerSteam(PPT, i))
                    return i;
            }

            return 0;
        }

        private enum MatchState {
            Menu,
            Match,
            Finished
        }

        static MatchState match = MatchState.Menu;

        int[] score = new int[2] { 0, 0 };
        int[] total = new int[2] { 0, 0 };

        private void FTX() {
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
        }

        int pieces = 0;
        int state = 0;

        private void PPS() {
            int drop = GameHelper.PieceDropped(PPT);

            if (drop != state) {
                if (drop == 1) {
                    pieces++;
                }
                state = drop;
            }
        }

        int cGarbage = 0;
        int tGarbage = 0;

        private void APM() {
            int garbage = GameHelper.GarbageSent(PPT);

            if (garbage != cGarbage) {
                tGarbage += garbage;
                cGarbage = garbage;
            }
        }

        int? startingRating = null;

        private void Rating() {
            if (startingRating == null) {
                startingRating = GameHelper.Rating(PPT);
            }

            labelRating.Text = $"{startingRating.ToString()} > {GameHelper.Rating(PPT).ToString()}";
        }

        private void CalculateTimeBased() {
            int totalFrames = GameHelper.BigFrames(PPT);

            if (totalFrames < 100) {
                pieces = 0;
                tGarbage = 0;
            }

            int frames = GameHelper.SmallFrames(PPT);

            if (frames != 0) {
                Decimal pps = Decimal.Divide(pieces, frames) * 60;
                labelPPS.Text = $"{pps.ToString("0.000")} PPS";

                Decimal apm = Decimal.Divide(tGarbage, frames) * 3600;
                labelAPM.Text = $"{apm.ToString("0.000")} APM";
            }
        }

        private void ScanTimer_Tick(object sender, EventArgs e) {
            if (EnsurePPT()) {
                int playerIndex = FindPlayer();

                FTX();
                PPS();
                APM();
                Rating();
                CalculateTimeBased();
            }
        }
    }
}
