using System;  // Tom war hier
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.IO;

namespace InputTracker
{
    public partial class FrmMain : Form
    {
        readonly GlobalKeyboardHook keyHook = new GlobalKeyboardHook();
        readonly GlobalMouseHook mouseHook = new GlobalMouseHook();

        class MouseClickedStruct
        {
            public int XPos;
            public int YPos;
        }

        int AllKeys = 0;

        int Escape = 0, F1 = 0, F2 = 0, F3 = 0, F4 = 0, F5 = 0, F6 = 0, F7 = 0, F8 = 0, F9 = 0, F10 = 0, F11 = 0, F12 = 0,
            UpArrowHead = 0, D1 = 0, D2 = 0, D3 = 0, D4 = 0, D5 = 0, D6 = 0, D7 = 0, D8 = 0, D9 = 0, D0 = 0, ß = 0, Backquote = 0, Back = 0,
            Tab = 0, Q = 0, W = 0, E = 0, R = 0, T = 0, Z = 0, U = 0, I = 0, O = 0, P = 0, Ü = 0, DPlus = 0, Return = 0,
            Caps = 0, A = 0, S = 0, D = 0, F = 0, G = 0, H = 0, J = 0, K = 0, L = 0, Ö = 0, Ä = 0, Hashtag = 0,
            LShift = 0, LowerThen = 0, Y = 0, X = 0, C = 0, V = 0, B = 0, N = 0, M = 0, DComma = 0, Point = 0, DMinus = 0, RShift = 0,
            LControl = 0, LWin = 0, LAlt = 0, Space = 0, RAlt = 0, RWin = 0, Apps = 0, RControl = 0,
            Print = 0, Scroll = 0, Pause = 0, Insert = 0, Pos1 = 0, PageUp = 0, Delete = 0, End = 0, PageDown = 0, Up = 0, Left = 0, Down = 0, Right = 0,
            Num = 0, NDivide = 0, NMultiply = 0, NMinus = 0, NPlus = 0,
            N1 = 0, N2 = 0, N3 = 0, N4 = 0, N5 = 0, N6 = 0, N7 = 0, N8 = 0, N9 = 0, N0 = 0, NComma = 0;

        List<MouseClickedStruct> mouseClicks = new List<MouseClickedStruct>();

        public FrmMain()
        {
            InitializeComponent();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            string ExeName = Path.GetFileName(Application.ExecutablePath).Substring(0, Path.GetFileName(Application.ExecutablePath).Length - 4);
            PicScreens.Width = (Screen.AllScreens.Count() * 330);
            Width = (Screen.AllScreens.Count() * 330) + 50 + 17;

            Text = ExeName;
            NotifyIcon.Text = ExeName;

            GetDataFromDokument();
            keyHook.KeyUp += new KeyEventHandler(KeyHook_KeyUp);
            mouseHook.ButtonUp += new MouseEventHandler(MouseHook_ButtonUp);
        }

        private void FrmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            SaveDataInDokument();
        }

        private void FrmMain_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                ShowInTaskbar = false;
                NotifyIcon.Visible = true;
            }
            else
            {
                if (((Width - 17) - 10) < PicTastatur.Width)
                    Width = 17 + 10 + PicTastatur.Width;
                PicTastatur.Left = ((Width - 17) - PicTastatur.Width) / 2;
                PicScreens.Left = ((Width - 17) - PicScreens.Width) / 2;
                PnlAllNumbers.Left = ((Width - 17) - PnlAllNumbers.Width) / 2;
            }
        }

        private void NotifyIcon_MouseClick(object sender, MouseEventArgs e)
        {
            ShowInTaskbar = true;
            NotifyIcon.Visible = false;
            WindowState = FormWindowState.Normal;
        }

        private void GetDataFromDokument()
        {
            if (!Directory.Exists("Data"))
            {
                Directory.CreateDirectory("Data");
            }
            if (!File.Exists(@"Data\Keys.txt"))
            {
                FileStream file = File.Create(@"Data\Keys.txt");
                file.Close();
            }
            else
            {
                string[] lines = File.ReadAllLines(@"Data\Keys.txt");
                foreach (string line in lines)
                {
                    string[] splitted = line.Split(':');
                    switch (splitted[0])
                    {
                        case "AllKeys":
                            AllKeys = Convert.ToInt32(splitted[1]);
                            break;
                        case "Escape":
                            Escape = Convert.ToInt32(splitted[1]);
                            break;
                        case "F1":
                            F1 = Convert.ToInt32(splitted[1]);
                            break;
                        case "F2":
                            F2 = Convert.ToInt32(splitted[1]);
                            break;
                        case "F3":
                            F3 = Convert.ToInt32(splitted[1]);
                            break;
                        case "F4":
                            F4 = Convert.ToInt32(splitted[1]);
                            break;
                        case "F5":
                            F5 = Convert.ToInt32(splitted[1]);
                            break;
                        case "F6":
                            F6 = Convert.ToInt32(splitted[1]);
                            break;
                        case "F7":
                            F7 = Convert.ToInt32(splitted[1]);
                            break;
                        case "F8":
                            F8 = Convert.ToInt32(splitted[1]);
                            break;
                        case "F9":
                            F9 = Convert.ToInt32(splitted[1]);
                            break;
                        case "F10":
                            F10 = Convert.ToInt32(splitted[1]);
                            break;
                        case "F11":
                            F11 = Convert.ToInt32(splitted[1]);
                            break;
                        case "F12":
                            F12 = Convert.ToInt32(splitted[1]);
                            break;
                        case "UpArrowHead":
                            UpArrowHead = Convert.ToInt32(splitted[1]);
                            break;
                        case "D1":
                            D1 = Convert.ToInt32(splitted[1]);
                            break;
                        case "D2":
                            D2 = Convert.ToInt32(splitted[1]);
                            break;
                        case "D3":
                            D3 = Convert.ToInt32(splitted[1]);
                            break;
                        case "D4":
                            D4 = Convert.ToInt32(splitted[1]);
                            break;
                        case "D5":
                            D5 = Convert.ToInt32(splitted[1]);
                            break;
                        case "D6":
                            D6 = Convert.ToInt32(splitted[1]);
                            break;
                        case "D7":
                            D7 = Convert.ToInt32(splitted[1]);
                            break;
                        case "D8":
                            D8 = Convert.ToInt32(splitted[1]);
                            break;
                        case "D9":
                            D9 = Convert.ToInt32(splitted[1]);
                            break;
                        case "D0":
                            D0 = Convert.ToInt32(splitted[1]);
                            break;
                        case "ß":
                            ß = Convert.ToInt32(splitted[1]);
                            break;
                        case "Backquote":
                            Backquote = Convert.ToInt32(splitted[1]);
                            break;
                        case "Back":
                            Back = Convert.ToInt32(splitted[1]);
                            break;
                        case "Tab":
                            Tab = Convert.ToInt32(splitted[1]);
                            break;
                        case "Q":
                            Q = Convert.ToInt32(splitted[1]);
                            break;
                        case "W":
                            W = Convert.ToInt32(splitted[1]);
                            break;
                        case "E":
                            E = Convert.ToInt32(splitted[1]);
                            break;
                        case "R":
                            R = Convert.ToInt32(splitted[1]);
                            break;
                        case "T":
                            T = Convert.ToInt32(splitted[1]);
                            break;
                        case "Z":
                            Z = Convert.ToInt32(splitted[1]);
                            break;
                        case "U":
                            U = Convert.ToInt32(splitted[1]);
                            break;
                        case "I":
                            I = Convert.ToInt32(splitted[1]);
                            break;
                        case "O":
                            O = Convert.ToInt32(splitted[1]);
                            break;
                        case "P":
                            P = Convert.ToInt32(splitted[1]);
                            break;
                        case "Ü":
                            Ü = Convert.ToInt32(splitted[1]);
                            break;
                        case "DPlus":
                            DPlus = Convert.ToInt32(splitted[1]);
                            break;
                        case "Return":
                            Return = Convert.ToInt32(splitted[1]);
                            break;
                        case "Caps":
                            Caps = Convert.ToInt32(splitted[1]);
                            break;
                        case "A":
                            A = Convert.ToInt32(splitted[1]);
                            break;
                        case "S":
                            S = Convert.ToInt32(splitted[1]);
                            break;
                        case "D":
                            D = Convert.ToInt32(splitted[1]);
                            break;
                        case "F":
                            F = Convert.ToInt32(splitted[1]);
                            break;
                        case "G":
                            G = Convert.ToInt32(splitted[1]);
                            break;
                        case "H":
                            H = Convert.ToInt32(splitted[1]);
                            break;
                        case "J":
                            J = Convert.ToInt32(splitted[1]);
                            break;
                        case "K":
                            K = Convert.ToInt32(splitted[1]);
                            break;
                        case "L":
                            L = Convert.ToInt32(splitted[1]);
                            break;
                        case "Ö":
                            Ö = Convert.ToInt32(splitted[1]);
                            break;
                        case "Ä":
                            Ä = Convert.ToInt32(splitted[1]);
                            break;
                        case "Hashtag":
                            Hashtag = Convert.ToInt32(splitted[1]);
                            break;
                        case "LShift":
                            LShift = Convert.ToInt32(splitted[1]);
                            break;
                        case "LowerThen":
                            LowerThen = Convert.ToInt32(splitted[1]);
                            break;
                        case "Y":
                            Y = Convert.ToInt32(splitted[1]);
                            break;
                        case "X":
                            X = Convert.ToInt32(splitted[1]);
                            break;
                        case "C":
                            C = Convert.ToInt32(splitted[1]);
                            break;
                        case "V":
                            V = Convert.ToInt32(splitted[1]);
                            break;
                        case "B":
                            B = Convert.ToInt32(splitted[1]);
                            break;
                        case "N":
                            N = Convert.ToInt32(splitted[1]);
                            break;
                        case "M":
                            M = Convert.ToInt32(splitted[1]);
                            break;
                        case "DComma":
                            DComma = Convert.ToInt32(splitted[1]);
                            break;
                        case "Point":
                            Point = Convert.ToInt32(splitted[1]);
                            break;
                        case "DMinus":
                            DMinus = Convert.ToInt32(splitted[1]);
                            break;
                        case "RShift":
                            RShift = Convert.ToInt32(splitted[1]);
                            break;
                        case "LControl":
                            LControl = Convert.ToInt32(splitted[1]);
                            break;
                        case "LWin":
                            LWin = Convert.ToInt32(splitted[1]);
                            break;
                        case "LAlt":
                            LAlt = Convert.ToInt32(splitted[1]);
                            break;
                        case "Space":
                            Space = Convert.ToInt32(splitted[1]);
                            break;
                        case "RAlt":
                            RAlt = Convert.ToInt32(splitted[1]);
                            break;
                        case "RWin":
                            RWin = Convert.ToInt32(splitted[1]);
                            break;
                        case "Apps":
                            Apps = Convert.ToInt32(splitted[1]);
                            break;
                        case "RControl":
                            RControl = Convert.ToInt32(splitted[1]);
                            break;
                        case "Print":
                            Print = Convert.ToInt32(splitted[1]);
                            break;
                        case "Scroll":
                            Scroll = Convert.ToInt32(splitted[1]);
                            break;
                        case "Pause":
                            Pause = Convert.ToInt32(splitted[1]);
                            break;
                        case "Insert":
                            Insert = Convert.ToInt32(splitted[1]);
                            break;
                        case "Pos1":
                            Pos1 = Convert.ToInt32(splitted[1]);
                            break;
                        case "PageUp":
                            PageUp = Convert.ToInt32(splitted[1]);
                            break;
                        case "Delete":
                            Delete = Convert.ToInt32(splitted[1]);
                            break;
                        case "End":
                            End = Convert.ToInt32(splitted[1]);
                            break;
                        case "PageDown":
                            PageDown = Convert.ToInt32(splitted[1]);
                            break;
                        case "Up":
                            Up = Convert.ToInt32(splitted[1]);
                            break;
                        case "Left":
                            Left = Convert.ToInt32(splitted[1]);
                            break;
                        case "Down":
                            Down = Convert.ToInt32(splitted[1]);
                            break;
                        case "Right":
                            Right = Convert.ToInt32(splitted[1]);
                            break;
                        case "Num":
                            Num = Convert.ToInt32(splitted[1]);
                            break;
                        case "NDivide":
                            NDivide = Convert.ToInt32(splitted[1]);
                            break;
                        case "NMultiply":
                            NMultiply = Convert.ToInt32(splitted[1]);
                            break;
                        case "NMinus":
                            NMinus = Convert.ToInt32(splitted[1]);
                            break;
                        case "NPlus":
                            NPlus = Convert.ToInt32(splitted[1]);
                            break;
                        case "N1":
                            N1 = Convert.ToInt32(splitted[1]);
                            break;
                        case "N2":
                            N2 = Convert.ToInt32(splitted[1]);
                            break;
                        case "N3":
                            N3 = Convert.ToInt32(splitted[1]);
                            break;
                        case "N4":
                            N4 = Convert.ToInt32(splitted[1]);
                            break;
                        case "N5":
                            N5 = Convert.ToInt32(splitted[1]);
                            break;
                        case "N6":
                            N6 = Convert.ToInt32(splitted[1]);
                            break;
                        case "N7":
                            N7 = Convert.ToInt32(splitted[1]);
                            break;
                        case "N8":
                            N8 = Convert.ToInt32(splitted[1]);
                            break;
                        case "N9":
                            N9 = Convert.ToInt32(splitted[1]);
                            break;
                        case "N0":
                            N0 = Convert.ToInt32(splitted[1]);
                            break;
                        case "NComma":
                            NComma = Convert.ToInt32(splitted[1]);
                            break;
                        default:
                            break;
                    }
                }
            }
            if (!File.Exists(@"Data\Mouse.txt"))
            {
                FileStream file = File.Create(@"Data\Mouse.txt");
                file.Close();
            }
            else
            {
                string[] lines = File.ReadAllLines(@"Data\Mouse.txt");
                foreach (string line in lines)
                {
                    string[] splitted = line.Split(';');
                    mouseClicks.Add(new MouseClickedStruct
                    {
                        XPos = Convert.ToInt32(splitted[0].Remove(0, 2)),
                        YPos = Convert.ToInt32(splitted[1].Remove(0, 2))
                    });
                }
            }


        }

        private void SaveDataInDokument()
        {
            if (!Directory.Exists("Data"))
            {
                Directory.CreateDirectory("Data");
            }
            if (!File.Exists(@"Data\Keys.txt"))
            {
                FileStream file = File.Create(@"Data\Keys.txt");
                file.Close();
            }
            if (!File.Exists(@"Data\Mouse.txt"))
            {
                FileStream file = File.Create(@"Data\Mouse.txt");
                file.Close();
            }

            List<string> lines = new List<string>();
            #region FillList
            lines.Add("AllKeys:" + AllKeys.ToString());
            lines.Add("Escape:" + Escape.ToString());
            lines.Add("F1:" + F1.ToString());
            lines.Add("F2:" + F2.ToString());
            lines.Add("F3:" + F3.ToString());
            lines.Add("F4:" + F4.ToString());
            lines.Add("F5:" + F5.ToString());
            lines.Add("F6:" + F6.ToString());
            lines.Add("F7:" + F7.ToString());
            lines.Add("F8:" + F8.ToString());
            lines.Add("F9:" + F9.ToString());
            lines.Add("F10:" + F10.ToString());
            lines.Add("F11:" + F11.ToString());
            lines.Add("F12:" + F12.ToString());
            lines.Add("UpArrowHead:" + UpArrowHead.ToString());
            lines.Add("D1:" + D1.ToString());
            lines.Add("D2:" + D2.ToString());
            lines.Add("D3:" + D3.ToString());
            lines.Add("D4:" + D4.ToString());
            lines.Add("D5:" + D5.ToString());
            lines.Add("D6:" + D6.ToString());
            lines.Add("D7:" + D7.ToString());
            lines.Add("D8:" + D8.ToString());
            lines.Add("D9:" + D9.ToString());
            lines.Add("D0:" + D0.ToString());
            lines.Add("ß:" + ß.ToString());
            lines.Add("Backquote:" + Backquote.ToString());
            lines.Add("Back:" + Back.ToString());
            lines.Add("Tab:" + Tab.ToString());
            lines.Add("Q:" + Q.ToString());
            lines.Add("W:" + W.ToString());
            lines.Add("E:" + E.ToString());
            lines.Add("R:" + R.ToString());
            lines.Add("T:" + T.ToString());
            lines.Add("Z:" + Z.ToString());
            lines.Add("U:" + U.ToString());
            lines.Add("I:" + I.ToString());
            lines.Add("O:" + O.ToString());
            lines.Add("P:" + P.ToString());
            lines.Add("Ü:" + Ü.ToString());
            lines.Add("DPlus:" + DPlus.ToString());
            lines.Add("Return:" + Return.ToString());
            lines.Add("Caps:" + Caps.ToString());
            lines.Add("A:" + A.ToString());
            lines.Add("S:" + S.ToString());
            lines.Add("D:" + D.ToString());
            lines.Add("F:" + F.ToString());
            lines.Add("G:" + G.ToString());
            lines.Add("H:" + H.ToString());
            lines.Add("J:" + J.ToString());
            lines.Add("K:" + K.ToString());
            lines.Add("L:" + L.ToString());
            lines.Add("Ö:" + Ö.ToString());
            lines.Add("Ä:" + Ä.ToString());
            lines.Add("Hashtag:" + Hashtag.ToString());
            lines.Add("LShift:" + LShift.ToString());
            lines.Add("LowerThen:" + LowerThen.ToString());
            lines.Add("Y:" + Y.ToString());
            lines.Add("X:" + X.ToString());
            lines.Add("C:" + C.ToString());
            lines.Add("V:" + V.ToString());
            lines.Add("B:" + B.ToString());
            lines.Add("N:" + N.ToString());
            lines.Add("M:" + M.ToString());
            lines.Add("DComma:" + DComma.ToString());
            lines.Add("Point:" + Point.ToString());
            lines.Add("DMinus:" + DMinus.ToString());
            lines.Add("RShift:" + RShift.ToString());
            lines.Add("LControl:" + LControl.ToString());
            lines.Add("LWin:" + LWin.ToString());
            lines.Add("LAlt:" + LAlt.ToString());
            lines.Add("Space:" + Space.ToString());
            lines.Add("RAlt:" + RAlt.ToString());
            lines.Add("RWin:" + RWin.ToString());
            lines.Add("Apps:" + Apps.ToString());
            lines.Add("RControl:" + RControl.ToString());
            lines.Add("Print:" + Print.ToString());
            lines.Add("Scroll:" + Scroll.ToString());
            lines.Add("Pause:" + Pause.ToString());
            lines.Add("Insert:" + Insert.ToString());
            lines.Add("Pos1:" + Pos1.ToString());
            lines.Add("PageUp:" + PageUp.ToString());
            lines.Add("Delete:" + Delete.ToString());
            lines.Add("End:" + End.ToString());
            lines.Add("PageDown:" + PageDown.ToString());
            lines.Add("Up:" + Up.ToString());
            lines.Add("Left:" + Left.ToString());
            lines.Add("Down:" + Down.ToString());
            lines.Add("Right:" + Right.ToString());
            lines.Add("Num:" + Num.ToString());
            lines.Add("NDivide:" + NDivide.ToString());
            lines.Add("NMultiply:" + NMultiply.ToString());
            lines.Add("NMinus:" + NMinus.ToString());
            lines.Add("NPlus:" + NPlus.ToString());
            lines.Add("N1:" + N1.ToString());
            lines.Add("N2:" + N2.ToString());
            lines.Add("N3:" + N3.ToString());
            lines.Add("N4:" + N4.ToString());
            lines.Add("N5:" + N5.ToString());
            lines.Add("N6:" + N6.ToString());
            lines.Add("N7:" + N7.ToString());
            lines.Add("N8:" + N8.ToString());
            lines.Add("N9:" + N9.ToString());
            lines.Add("N0:" + N0.ToString());
            lines.Add("NComma:" + NComma.ToString());
            #endregion FillList
            File.WriteAllLines(@"Data\Keys.txt", lines);

            lines = new List<string>();
            foreach (MouseClickedStruct mouseClick in mouseClicks)
            {
                lines.Add("X:" + mouseClick.XPos.ToString() + ";Y:" + mouseClick.YPos.ToString());
            }
            File.WriteAllLines(@"Data\Mouse.txt", lines);
        }

        private void KeyHook_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                #region TastutrLine1                
                case Keys.Escape:
                    Escape++;
                    break;
                case Keys.F1:
                    F1++;
                    break;
                case Keys.F2:
                    F2++;
                    break;
                case Keys.F3:
                    F3++;
                    break;
                case Keys.F4:
                    F4++;
                    break;
                case Keys.F5:
                    F5++;
                    break;
                case Keys.F6:
                    F6++;
                    break;
                case Keys.F7:
                    F7++;
                    break;
                case Keys.F8:
                    F8++;
                    break;
                case Keys.F9:
                    F9++;
                    break;
                case Keys.F10:
                    F10++;
                    break;
                case Keys.F11:
                    F11++;
                    break;
                case Keys.F12:
                    F12++;
                    break;
                #endregion TastutrLine1                

                #region TastutrLine2                
                case Keys.OemPipe:
                    UpArrowHead++;
                    break;
                case Keys.D1:
                    D1++;
                    break;
                case Keys.D2:
                    D2++;
                    break;
                case Keys.D3:
                    D3++;
                    break;
                case Keys.D4:
                    D4++;
                    break;
                case Keys.D5:
                    D5++;
                    break;
                case Keys.D6:
                    D6++;
                    break;
                case Keys.D7:
                    D7++;
                    break;
                case Keys.D8:
                    D8++;
                    break;
                case Keys.D9:
                    D9++;
                    break;
                case Keys.D0:
                    D0++;
                    break;
                case Keys.OemOpenBrackets:
                    ß++;
                    break;
                case Keys.OemCloseBrackets:
                    Backquote++;
                    break;
                case Keys.Back:
                    Back++;
                    break;
                #endregion TastutrLine2                

                #region TastutrLine3                
                case Keys.Tab:
                    Tab++;
                    break;
                case Keys.Q:
                    Q++;
                    break;
                case Keys.W:
                    W++;
                    break;
                case Keys.E:
                    E++;
                    break;
                case Keys.R:
                    R++;
                    break;
                case Keys.T:
                    T++;
                    break;
                case Keys.Z:
                    Z++;
                    break;
                case Keys.U:
                    U++;
                    break;
                case Keys.I:
                    I++;
                    break;
                case Keys.O:
                    O++;
                    break;
                case Keys.P:
                    P++;
                    break;
                case Keys.OemSemicolon:
                    Ü++;
                    break;
                case Keys.Oemplus:
                    DPlus++;
                    break;
                case Keys.Return:
                    Return++;
                    break;
                #endregion TastutrLine3

                #region TastutrLine4                
                case Keys.CapsLock:
                    Caps++;
                    break;
                case Keys.A:
                    A++;
                    break;
                case Keys.S:
                    S++;
                    break;
                case Keys.D:
                    D++;
                    break;
                case Keys.F:
                    F++;
                    break;
                case Keys.G:
                    G++;
                    break;
                case Keys.H:
                    H++;
                    break;
                case Keys.J:
                    J++;
                    break;
                case Keys.K:
                    K++;
                    break;
                case Keys.L:
                    L++;
                    break;
                case Keys.Oemtilde:
                    Ö++;
                    break;
                case Keys.OemQuotes:
                    Ä++;
                    break;
                case Keys.OemQuestion:
                    Hashtag++;
                    break;
                #endregion TastutrLine4                

                #region TastutrLine5                
                case Keys.LShiftKey:
                    LShift++;
                    break;
                case Keys.OemBackslash:
                    LowerThen++;
                    break;
                case Keys.Y:
                    Y++;
                    break;
                case Keys.X:
                    X++;
                    break;
                case Keys.C:
                    C++;
                    break;
                case Keys.V:
                    V++;
                    break;
                case Keys.B:
                    B++;
                    break;
                case Keys.N:
                    N++;
                    break;
                case Keys.M:
                    M++;
                    break;
                case Keys.Oemcomma:
                    DComma++;
                    break;
                case Keys.OemPeriod:
                    Point++;
                    break;
                case Keys.OemMinus:
                    DMinus++;
                    break;
                case Keys.RShiftKey:
                    RShift++;
                    break;
                #endregion TastutrLine5

                #region TastutrLine6                
                case Keys.LControlKey:
                    LControl++;
                    break;
                case Keys.LWin:
                    LWin++;
                    break;
                case Keys.LMenu:
                    LAlt++;
                    break;
                case Keys.Space:
                    Space++;
                    break;
                case Keys.RMenu:
                    RAlt++;
                    break;
                case Keys.RWin:
                    RWin++;
                    break;
                case Keys.Apps:
                    Apps++;
                    break;
                case Keys.RControlKey:
                    RControl++;
                    break;
                #endregion TastutrLine6                

                #region Middle
                case Keys.Snapshot:
                    Print++;
                    break;
                case Keys.Scroll:
                    Scroll++;
                    break;
                case Keys.Pause:
                    Pause++;
                    break;
                case Keys.Insert:
                    Insert++;
                    break;
                case Keys.Home:
                    Pos1++;
                    break;
                case Keys.PageUp:
                    PageUp++;
                    break;
                case Keys.Delete:
                    Delete++;
                    break;
                case Keys.End:
                    End++;
                    break;
                case Keys.PageDown:
                    PageDown++;
                    break;
                case Keys.Up:
                    Up++;
                    break;
                case Keys.Left:
                    Left++;
                    break;
                case Keys.Down:
                    Down++;
                    break;
                case Keys.Right:
                    Right++;
                    break;
                #endregion Middle

                #region NumBlock
                case Keys.NumLock:
                    Num++;
                    break;
                case Keys.Divide:
                    NDivide++;
                    break;
                case Keys.Multiply:
                    NMultiply++;
                    break;
                case Keys.Subtract:
                    NMinus++;
                    break;
                case Keys.Add:
                    NPlus++;
                    break;
                case Keys.NumPad1:
                    N1++;
                    break;
                case Keys.NumPad2:
                    N2++;
                    break;
                case Keys.NumPad3:
                    N3++;
                    break;
                case Keys.NumPad4:
                    N4++;
                    break;
                case Keys.NumPad5:
                    N5++;
                    break;
                case Keys.NumPad6:
                    N6++;
                    break;
                case Keys.NumPad7:
                    N7++;
                    break;
                case Keys.NumPad8:
                    N8++;
                    break;
                case Keys.NumPad9:
                    N9++;
                    break;
                case Keys.NumPad0:
                    N0++;
                    break;
                case Keys.Decimal:
                    NComma++;
                    break;
                #endregion NumBlock

                default:
                    // MessageBox.Show("Unbehandelter Keycode: " + e.KeyCode.ToString());
                    break;
            }
            AllKeys++;
        }

        private void MouseHook_ButtonUp(object sender, MouseEventArgs e)
        {
            mouseClicks.Add(new MouseClickedStruct
            {
                XPos = e.X,
                YPos = e.Y
            });
        }

        private void PicScreens_Paint(object sender, PaintEventArgs e)
        {
            int count = 0;
            foreach (Screen screen in Screen.AllScreens)
            {
                e.Graphics.FillRectangle(Brushes.LightBlue, 15 + (330 * count), 10, 300, 175);
                e.Graphics.DrawRectangle(new Pen(Color.Black, 2), 15 + (330 * count), 10, 300, 175);
                e.Graphics.DrawLine(new Pen(Color.Black, 5), 15 + 150 + (330 * count), 185, 15 + 150 + (330 * count), 210);
                e.Graphics.FillEllipse(Brushes.Black, 15 + 75 + (330 * count), 195, 150, 15);

                count++;
            }

            foreach (MouseClickedStruct mouseClick in mouseClicks)
            {
                count = 0;
                foreach (Screen screen in Screen.AllScreens)
                {
                    if ((mouseClick.XPos >= screen.Bounds.Left) && (mouseClick.XPos <= screen.Bounds.Right))
                    {
                        float X = (float)(15 + (3 * (Convert.ToDouble(mouseClick.XPos - screen.Bounds.Left) / (Convert.ToDouble(screen.Bounds.Width) / 100))) + (330 * count));
                        float Y = (float)(10 + (1.75 * (Convert.ToDouble(mouseClick.YPos) / (Convert.ToDouble(screen.Bounds.Height) / 100))));
                        e.Graphics.DrawLine(new Pen(Color.Black, 2), X - 2, Y - 2, X + 2, Y + 2);
                        e.Graphics.DrawLine(new Pen(Color.Black, 2), X - 2, Y + 2, X + 2, Y - 2);
                    }
                    count++;
                }

            }

            LblNumberKlicks.Text = mouseClicks.Count.ToString();
        }

        private void PicTastatur_Paint(object sender, PaintEventArgs e)
        {
            void PaintCircle(int KeyPresses, int xPos, int yPos)
            {
                if ((KeyPresses != 0) && (AllKeys != 0))
                {
                    double sizeProzent = Convert.ToDouble(KeyPresses) / (Convert.ToDouble(AllKeys) / 100);
                    int size = Convert.ToInt32(sizeProzent * (3 / (0.15 * sizeProzent + 0.75)));
                    e.Graphics.FillEllipse(new SolidBrush(Color.FromArgb(200, 10, 170, 244)), xPos - (size / 2), yPos - (size / 2), size, size);
                }
            }

            #region CicrlesMalen

            #region Line1 
            PaintCircle(Escape, 16, 16);
            PaintCircle(F1, 66, 16);
            PaintCircle(F2, 91, 16);
            PaintCircle(F3, 116, 16);
            PaintCircle(F4, 141, 16);
            PaintCircle(F5, 179, 16);
            PaintCircle(F6, 204, 16);
            PaintCircle(F7, 229, 16);
            PaintCircle(F8, 254, 16);
            PaintCircle(F9, 291, 16);
            PaintCircle(F10, 316, 16);
            PaintCircle(F11, 341, 16);
            PaintCircle(F12, 366, 16);
            #endregion

            #region Line2
            PaintCircle(UpArrowHead, 16, 53);
            PaintCircle(D1, 41, 53);
            PaintCircle(D2, 66, 53);
            PaintCircle(D3, 91, 53);
            PaintCircle(D4, 116, 53);
            PaintCircle(D5, 141, 53);
            PaintCircle(D6, 166, 53);
            PaintCircle(D7, 191, 53);
            PaintCircle(D8, 216, 53);
            PaintCircle(D9, 241, 53);
            PaintCircle(D0, 266, 53);
            PaintCircle(ß, 291, 53);
            PaintCircle(Backquote, 316, 53);
            PaintCircle(Back, 351, 53);
            #endregion

            #region Line 3
            PaintCircle(Tab, 23, 78);
            PaintCircle(Q, 54, 78);
            PaintCircle(W, 79, 78);
            PaintCircle(E, 104, 78);
            PaintCircle(R, 129, 78);
            PaintCircle(T, 154, 78);
            PaintCircle(Z, 179, 78);
            PaintCircle(U, 204, 78);
            PaintCircle(I, 229, 78);
            PaintCircle(O, 254, 78);
            PaintCircle(P, 279, 78);
            PaintCircle(Ü, 304, 78);
            PaintCircle(DPlus, 329, 78);
            PaintCircle(Return, 363, 85);
            #endregion

            #region Line 4
            PaintCircle(Caps, 23, 103);
            PaintCircle(A, 60, 103);
            PaintCircle(S, 85, 103);
            PaintCircle(D, 110, 103);
            PaintCircle(F, 135, 103);
            PaintCircle(G, 160, 103);
            PaintCircle(H, 185, 103);
            PaintCircle(J, 210, 103);
            PaintCircle(K, 235, 103);
            PaintCircle(L, 260, 103);
            PaintCircle(Ö, 285, 103);
            PaintCircle(Ä, 310, 103);
            PaintCircle(Hashtag, 335, 103);
            #endregion

            #region Line 5
            PaintCircle(LShift, 19, 128);
            PaintCircle(LowerThen, 47, 128);
            PaintCircle(Y, 72, 128);
            PaintCircle(X, 97, 128);
            PaintCircle(C, 122, 128);
            PaintCircle(V, 147, 128);
            PaintCircle(B, 172, 128);
            PaintCircle(N, 197, 128);
            PaintCircle(M, 222, 128);
            PaintCircle(DComma, 247, 128);
            PaintCircle(Point, 272, 128);
            PaintCircle(DMinus, 297, 128);
            PaintCircle(RShift, 340, 128);
            #endregion

            #region Linie 6
            PaintCircle(LControl, 23, 153);
            PaintCircle(LWin, 58, 153);
            PaintCircle(LAlt, 88, 153);
            PaintCircle(Space, 180, 153);
            PaintCircle(RAlt, 263, 153);
            PaintCircle(RWin, 295, 153);
            PaintCircle(Apps, 327, 153);
            PaintCircle(RControl, 360, 153);
            #endregion

            #region Middle
            PaintCircle(Print, 403, 16);
            PaintCircle(Scroll, 428, 16);
            PaintCircle(Pause, 453, 16);
            PaintCircle(Insert, 403, 53);
            PaintCircle(Pos1, 428, 53);
            PaintCircle(PageUp, 453, 53);
            PaintCircle(Delete, 403, 78);
            PaintCircle(End, 428, 78);
            PaintCircle(PageDown, 453, 78);
            PaintCircle(Up, 428, 128);
            PaintCircle(Left, 403, 153);
            PaintCircle(Down, 428, 153);
            PaintCircle(Right, 453, 153);
            #endregion

            #region NumBlock
            PaintCircle(Num, 491, 53);
            PaintCircle(NDivide, 517, 53);
            PaintCircle(NMultiply, 542, 53);
            PaintCircle(NMinus, 568, 53);
            PaintCircle(NPlus, 568, 91);
            PaintCircle(N1, 491, 128);
            PaintCircle(N2, 517, 128);
            PaintCircle(N3, 542, 128);
            PaintCircle(N4, 491, 103);
            PaintCircle(N5, 517, 103);
            PaintCircle(N6, 542, 103);
            PaintCircle(N7, 491, 78);
            PaintCircle(N8, 517, 78);
            PaintCircle(N9, 542, 78);
            PaintCircle(N0, 504, 153);
            PaintCircle(NComma, 542, 153);
            PaintCircle(Return, 568, 141);
            #endregion

            #endregion CicrlesMalen

            LblNumberKeys.Text = AllKeys.ToString();
        }

        private void RepaintTimer_Tick(object sender, EventArgs e)
        {
            PicScreens.Refresh();
            PicTastatur.Refresh();
        }
        
        private void BtnReset_Click(object sender, EventArgs e)
        {
            #region Keys

            AllKeys = 0;

            #region Line 1
            Escape = 0;
            F1 = 0;
            F2 = 0;
            F3 = 0;
            F4 = 0;
            F5 = 0;
            F6 = 0;
            F7 = 0;
            F8 = 0;
            F9 = 0;
            F10 = 0;
            F11 = 0;
            F12 = 0;
            #endregion

            #region Line 2
            UpArrowHead = 0;
            D1 = 0;
            D2 = 0;
            D3 = 0;
            D4 = 0;
            D5 = 0;
            D6 = 0;
            D7 = 0;
            D8 = 0;
            D9 = 0;
            D0 = 0;
            ß = 0;
            Backquote = 0;
            Back = 0;
            #endregion

            #region Line 3
            Tab = 0;
            Q = 0;
            W = 0;
            E = 0;
            R = 0;
            T = 0;
            Z = 0;
            U = 0;
            I = 0;
            O = 0;
            P = 0;
            Ü = 0;
            DPlus = 0;
            Return = 0;
            #endregion

            #region Line 4
            Caps = 0;
            A = 0;
            S = 0;
            D = 0;
            F = 0;
            G = 0;
            H = 0;
            J = 0;
            K = 0;
            L = 0;
            Ö = 0;
            Ä = 0;
            Hashtag = 0;
            #endregion

            #region Line 5
            LShift = 0;
            LowerThen = 0;
            Y = 0;
            X = 0;
            C = 0;
            V = 0;
            B = 0;
            N = 0;
            M = 0;
            DComma = 0;
            Point = 0;
            DMinus = 0;
            RShift = 0;
            #endregion

            #region Line 6
            LControl = 0;
            LWin = 0;
            LAlt = 0;
            Space = 0;
            RAlt = 0;
            RWin = 0;
            Apps = 0;
            RControl = 0;
            #endregion

            #region Middle
            Print = 0;
            Scroll = 0;
            Pause = 0;
            Insert = 0;
            Pos1 = 0;
            PageUp = 0;
            Delete = 0;
            End = 0;
            PageDown = 0;
            Up = 0;
            Left = 0;
            Down = 0;
            Right = 0;
            #endregion

            #region NumBlock
            Num = 0; 
            NDivide = 0; 
            NMultiply = 0; 
            NMinus = 0; 
            NPlus = 0;
            N1 = 0; 
            N2 = 0;
            N3 = 0;
            N4 = 0;
            N5 = 0;
            N6 = 0;
            N7 = 0;
            N8 = 0;
            N9 = 0;
            N0 = 0;
            NComma = 0;
            #endregion

            #endregion

            mouseClicks.Clear();

            SaveDataInDokument();
            PicScreens.Refresh();
            PicTastatur.Refresh();
        }
    }
}
