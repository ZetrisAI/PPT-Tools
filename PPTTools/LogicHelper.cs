using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace PPTTools {
    class LogicHelper {
        public static int FindPlayer() {
            if (GameHelper.PlayerCount() < 2)
                return 0;

            int localSteam = GameHelper.LocalSteam();

            for (int i = 0; i < 2; i++)
                if (localSteam == GameHelper.PlayerSteam(i))
                    return i;

            return 0;
        }

        private enum MatchState {
            Menu,
            Match,
            Finished
        }
        private static MatchState matchState = MatchState.Menu;

        public static bool EnsureMatch() {
            if (GameHelper.Game.ReadInt32(new IntPtr(0x140573A78)) != 0x0) {
                if (matchState == MatchState.Match) {
                    matchState = MatchState.Finished;
                }
            }

            int scoreAddress = GameHelper.Game.ReadInt32(new IntPtr(0x14057F048));

            if (scoreAddress == 0x0) {
                if (matchState == MatchState.Finished)
                    matchState = MatchState.Menu;

            } else if (matchState == MatchState.Menu)
                matchState = MatchState.Match;

            return matchState == MatchState.Match;
        }

        public class FTX {
            private int[] score, total;

            public delegate void FTXEventHandler(int[] Score);
            public event FTXEventHandler Changed;

            private void Raise() {
                if (Changed != null) {
                    Changed.Invoke(total);
                }
            }

            public void Reset() {
                score = new int[2] {0, 0};
                total = new int[2] {0, 0};

                Raise();
            }

            public void Update() {
                if (EnsureMatch()) {
                    for (int i = 0; i < 2; i++) {
                        int temp = GameHelper.Score(i);

                        if (temp > score[i])
                            total[i]++;

                        score[i] = temp;
                    }

                    Raise();

                } else {
                    Reset();
                }
            }

            public FTX() {
                Reset();
            }
        }

        public class PPS {
            private int pieces, state, frames;

            public delegate void PPSEventHandler(Decimal PPS);
            public event PPSEventHandler Changed;

            private void Raise() {
                if (Changed != null) {
                    if (frames == 0) {
                        Changed.Invoke(0);
                    } else {
                        Changed.Invoke(Decimal.Divide(pieces, frames) * 60);
                    }
                }
            }

            public void Reset() {
                pieces = state = 0;

                Raise();
            }

            public void Update() {
                frames = GameHelper.SmallFrames();
                int drop = GameHelper.PieceDropped(GameHelper.GameState.playerIndex);

                if (drop != state) {
                    if (drop == 1)
                        pieces++;

                    state = drop;
                }

                Raise();
            }

            public PPS() {
                Reset();
            }
        }

        public class APM {
            private int current, total, frames;

            public delegate void APMEventHandler(Decimal APM);
            public event APMEventHandler Changed;

            private void Raise() {
                if (Changed != null) {
                    if (frames == 0) {
                        Changed.Invoke(0);
                    } else {
                        Changed.Invoke(Decimal.Divide(total, frames) * 3600);
                    }
                }
            }

            public void Reset() {
                total = 0;

                Raise();
            }

            public void Update() {
                frames = GameHelper.SmallFrames();
                int garbage = GameHelper.GarbageSent(GameHelper.GameState.playerIndex);

                if (garbage != current) {
                    if (garbage > current) {
                        total += garbage - current;
                    }

                    current = garbage;
                }

                Raise();
            }

            public APM() {
                Reset();
            }
        }

        public class APC {
            private int currentSent, totalSent, currentCleared, totalCleared;

            public delegate void APCEventHandler(Decimal APC);
            public event APCEventHandler Changed;

            private void Raise() {
                if (Changed != null) {
                    if (totalCleared == 0) {
                        Changed.Invoke(0);
                    } else {
                        Changed.Invoke(Decimal.Divide(totalSent, totalCleared));
                    }
                }
            }

            public void Reset() {
                totalSent = totalCleared = 0;

                Raise();
            }

            public void Update() {
                int garbage = GameHelper.GarbageSent(GameHelper.GameState.playerIndex);

                if (garbage != currentSent) {
                    if (garbage > currentSent) {
                        totalSent += garbage - currentSent;
                    }

                    currentSent = garbage;
                }

                int lines = GameHelper.LinesCleared(GameHelper.GameState.playerIndex);

                if (lines != currentCleared) {
                    if (lines > currentCleared)
                        totalCleared += lines;

                    currentCleared = lines;
                }

                Raise();
            }

            public APC() {
                Reset();
            }
        }

        public class KPP {
            private int[] keyStates = new int[7] { 0, 0, 0, 0, 0, 0, 0 };
            private int keystrokes, state, pieces;

            public delegate void KPPEventHandler(Decimal KPP);
            public event KPPEventHandler Changed;

            private void Raise() {
                if (Changed != null) {
                    if (pieces == 0) {
                        Changed.Invoke(0);
                    } else {
                        Changed.Invoke(Decimal.Divide(keystrokes, pieces));
                    }
                }
            }

            public void Reset() {
                keystrokes = pieces = 0;

                Raise();
            }

            public void Update() {
                int drop = GameHelper.PieceDropped(GameHelper.GameState.playerIndex);

                if (drop != state) {
                    if (drop == 1)
                        pieces++;

                    state = drop;
                }

                for (int i = 0; i < 7; i++) {
                    int key = GameHelper.Keystroke(i);

                    if (key != keyStates[i]) {
                        if (key == 1 && GameHelper.BigFrames() >= 147)
                            keystrokes++;

                        keyStates[i] = key;
                    }
                }

                Raise();
            }

            public KPP() {
                Reset();
            }
        }

        public class Finesse {
            private int[] keyStates = new int[7] {0, 0, 0, 0, 0, 0, 0};
            private List<int> finesseKeys = new List<int>();
            private bool holdUsed;
            private int? cPiece, cHold;
            private int keystrokes, state, cPiecePos, cPieceRot, errors;

            public delegate void FinesseEventHandler(int Errors);
            public event FinesseEventHandler Changed;

            private void Raise() {
                if (Changed != null) {
                    Changed.Invoke(errors);
                }
            }

            public void Reset() {
                keystrokes = errors = state = 0;
                cPiece = GameHelper.NextPiece(GameHelper.GameState.playerIndex);
                cHold = null;
                holdUsed = false;

                Raise();
            }

            public void Update() {
                for (int i = 0; i < 7; i++) {
                    int key = GameHelper.Keystroke(i);

                    if (key != keyStates[i]) {
                        if (key == 1 && GameHelper.BigFrames() >= 147) {
                            if (i == 6 && !holdUsed) {
                                finesseKeys.Clear();
                                holdUsed = true;

                                if (cHold == null) {
                                    cHold = cPiece;
                                    cPiece = GameHelper.NextPiece(GameHelper.GameState.playerIndex);
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

                int drop = GameHelper.PieceDropped(GameHelper.GameState.playerIndex);

                if (drop != state) {
                    if (drop == 1) {
                        if (cPiece != null) {
                            errors += FinesseHelper.Errors(cPiece.Value, finesseKeys, cPiecePos, cPieceRot);
                        }

                        finesseKeys.Clear();
                        holdUsed = false;
                        cPiece = GameHelper.NextPiece(GameHelper.GameState.playerIndex);
                    }

                    state = drop;
                }

                cPiecePos = GameHelper.PiecePosition(GameHelper.GameState.playerIndex);
                cPieceRot = GameHelper.PieceRotation(GameHelper.GameState.playerIndex);

                Raise();
            }

            public Finesse() {
                Reset();
            }
        }

        public class Rating {
            private int start, current;

            public delegate void RatingEventHandler(int StartRating, int CurrentRating);
            public event RatingEventHandler Changed;

            private void Raise() {
                if (Changed != null) {
                    Changed.Invoke(start, current);
                }
            }

            public void Reset() {
                start = current = GameHelper.Rating();
                Raise();
            }

            public void Update() {
                int rating = GameHelper.Rating();

                if (rating != current)
                    current = rating;

                Raise();
            }

            public Rating() {
                Reset();
            }
        }

        public class Duration {
            int frames;

            public delegate void DurationEventHandler(string Time);
            public event DurationEventHandler Changed;

            private void Raise() {
                if (Changed != null) {
                    Changed.Invoke(new TimeSpan((long)(frames * 166666.6666666667)).ToString("mm':'ss'.'fff"));
                }
            }

            public void Reset() {
                frames = 0;
                Raise();
            }

            public void Update() {
                frames = GameHelper.SmallFrames();
                Raise();
            }

            public Duration() {
                Reset();
            }
        }
    }
}
