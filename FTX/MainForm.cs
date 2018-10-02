using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace FTX {
    public partial class MainForm : Form {
        public MainForm() {
            InitializeComponent();
        }

        // Memory reader - addresses and pointer traversing was done with Cheat Engine's scanner and debugger
        static VAMemory PPT;

        // 3 states are needed because the loading screen between games dereferences the score
        // pointer which we use in Solo Arcade to determine when the match ends much easier.
        // In Free Play we must also check an additional value which is non-null only in a menu.
        private enum MatchState {
            Menu,     // Sitting in menu
            Match,    // Match currently ongoing
            Finished  // Match (not set) finished - going back to menu
        }

        // Assume MatchState is in menu when starting. Easily transitions into a match
        static MatchState match = MatchState.Menu;

        int[] score = new int[2] {0, 0}; // Set score
        int[] total = new int[2] {0, 0}; // Total score

        private void ScanTimer_Tick(object sender, EventArgs e) {
            // Process exists and hooked properly
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

            // ppt.exe+57F048 -> + 0x38 = address of P1 current score
            int scoreAddress = PPT.ReadInt32(new IntPtr(0x14057F048));

            // This pointer is null if we're not in the match
            if (scoreAddress == 0x0) {
                // Match ended, confirm we're back to a menu
                if (match == MatchState.Finished) {
                    match = MatchState.Menu;
                    score[0] = score[1] = total[0] = total[1] = 0; // Reset score
                }
            } else {
                // Match started from the menu
                if (match == MatchState.Menu) {
                    match = MatchState.Match;
                }
                scoreAddress += 0x38;
            }

            // Only track scores when there's a match going on
            // This prevents potentially reading junk data
            if (match == MatchState.Match) {
                // For each player, check for an incremental change in the set score
                for (int i = 0; i < 2; i++) {
                    int temp = PPT.ReadInt32(new IntPtr(scoreAddress) + i * 4);
                    if (temp > score[i]) {
                        total[i]++;
                    }
                    score[i] = temp; // Save set score for change checking later
                }
            }

            // Menu loaded after end of set - match ends.
            if (PPT.ReadInt32(new IntPtr(0x140573A78)) != 0x0) {
                if (match == MatchState.Match) {
                    match = MatchState.Finished;
                }
            }

            // Update scores on UI
            labelP1.Text = total[0].ToString();
            labelP2.Text = total[1].ToString();
        }
    }
}
