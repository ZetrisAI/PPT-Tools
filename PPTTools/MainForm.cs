using System;
using System.Collections.Generic;
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

        int playerIndex = 0;

        private void FindPlayer() {
            if (GameHelper.PlayerCount(PPT) < 2) {
                playerIndex = 0;
                return;
            }

            int localSteam = GameHelper.LocalSteam(PPT);

            for (int i = 0; i < 2; i++) {
                if (localSteam == GameHelper.PlayerSteam(PPT, i)) {
                    playerIndex = i;
                    return;
                }
            }

            playerIndex = 0;
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
            int drop = GameHelper.PieceDropped(PPT, playerIndex);

            if (drop != state) {
                if (drop == 1) {
                    pieces++;
                    Finesse();
                }
                
                state = drop;
            }
        }

        int cGarbage = 0;
        int tGarbage = 0;

        private void APM() {
            int garbage = GameHelper.GarbageSent(PPT, playerIndex);

            if (garbage != cGarbage) {
                if (garbage > cGarbage) {
                    tGarbage += garbage - cGarbage;
                }

                cGarbage = garbage;
            }
        }

        int[] keyStates = new int[7] {0, 0, 0, 0, 0, 0, 0};
        int keystrokes = 0;

        private void KPP() {
            for (int i = 0; i < 7; i++) {
                int key = GameHelper.Keystroke(PPT, i);

                if (key != keyStates[i]) {
                    if (key == 1 && totalFrames >= 147) {
                        keystrokes++;

                        if (i == 6 && !holdUsed) {
                            finesseKeys.Clear();
                            holdUsed = true;

                            if (cHold == null) {
                                cHold = cPiece;
                                cPiece = GameHelper.NextPiece(PPT, playerIndex);
                            } else {
                                int temp = cHold.Value;
                                cHold = cPiece;
                                cPiece = temp;
                            }
                        }

                        if (i != 2 && i != 3 && i != 6) {
                            finesseKeys.Add(i);
                        }
                    }

                    keyStates[i] = key;
                }
            }
        }

        int? cPiece = null;
        int cPiecePos = 0;
        int cPieceRot = 0;
        bool holdUsed = false;
        int? cHold = null;
        int errors = 0;
        List<int> finesseKeys = new List<int>();

        private void Finesse() {
            cPiecePos = GameHelper.PiecePosition(PPT, playerIndex);
            cPieceRot = GameHelper.PieceRotation(PPT, playerIndex);
            
            if (cPiece != null) {
                errors += FinesseHelper.Errors(cPiece.Value, finesseKeys, cPiecePos, cPieceRot);
            }

            finesseKeys.Clear();
            holdUsed = false;
            cPiece = GameHelper.NextPiece(PPT, playerIndex);
        }
        
        int? startingRating = null;

        private void Rating() {
            if (startingRating == null) {
                startingRating = GameHelper.Rating(PPT);
            }

            labelRating.Text = $"{startingRating.ToString()} > {GameHelper.Rating(PPT).ToString()}";
        }

        int totalFrames;

        private void CalculateTimeBased() {
            totalFrames = GameHelper.BigFrames(PPT);

            if (totalFrames < 148) {
                pieces = 0;
                tGarbage = 0;
                keystrokes = 0;
                finesseKeys.Clear();
                holdUsed = false;
                cHold = null;
                errors = 0;
                cPiece = GameHelper.NextPiece(PPT, playerIndex);
            }

            int frames = GameHelper.SmallFrames(PPT);

            if (frames != 0) {
                labelDuration.Text = new TimeSpan((long)(frames * 166666.6666666667)).ToString("mm':'ss'.'fff");

                Decimal pps = Decimal.Divide(pieces, frames) * 60;
                labelPPS.Text = $"{pps.ToString("0.000")} PPS";

                Decimal apm = Decimal.Divide(tGarbage, frames) * 3600;
                labelAPM.Text = $"{apm.ToString("0.000")} APM";

                Decimal kpp;
                if (pieces == 0)
                    kpp = 0;
                else 
                    kpp = decimal.Divide(keystrokes, pieces);
                labelKPP.Text = $"{kpp.ToString("0.000")} KPP";

                labelFinesse.Text = $"Finesse: {errors.ToString()}";
            }
        }

        private void ScanTimer_Tick(object sender, EventArgs e) {
            if (EnsurePPT()) {
                FindPlayer();
                FTX();
                PPS();
                APM();
                KPP();
                Rating();
                CalculateTimeBased();
            }
        }
    }
}
