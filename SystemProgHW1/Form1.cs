using System.Runtime.InteropServices;

//Howdy :)
//This is an attemp to combine all of the assignments into one semi-coherent application
//I really liked working on this one :)
//Although most of the 'work' was figuring out win32.dll
//Anyway it was fun





namespace SystemProgHW1
{


    public partial class Form1 : Form
    {
        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        public static extern int MessageBox(IntPtr hWnd, String text, String caption, uint type);

        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        static extern uint RegisterWindowMessage(string lpString);

        [DllImport("User32.dll")]
        static extern Boolean MessageBeep(UInt32 beepType);




        private uint _messageId = RegisterWindowMessage("BreakAccessLock");
        private Random _rand = new Random();

        

        bool _accessLock = true;
        public Form1()
        {
            InitializeComponent();
        }

        public void btn_Message(object sender, EventArgs e)
        {
            if (_accessLock)
            {
                MessageBox(IntPtr.Zero, "SUBJECT NAME: Yaroslav\nSUBJECT APPEARENCE: Humanoid\nDANGER LEVEL: Unknown", "REPORT 12B-L3-PEAR", 0);
                MessageBox(IntPtr.Zero, "FOUND: \nSubject was found inside of an appartment building on ☐☐☐☐☐☐ avn. 126 ☐☐☐☐☐, ☐☐☐☐☐☐☐☐. During the opertion to capture the subject, 12B-L3 was consuming an unkown liquid(later specified to be \"tea\".) ", "REPORT 12B-L3-PEAR: FOUND", 0);
                MessageBox(IntPtr.Zero, "DESCRIPTION: \n12B-L3 is a 16 year-old male, who has an appearance of a typical homo sapiens teen. There is nothing unusual in the subjects appearance.\n12B-L3 prefers to be adressed as 'Yaroslav' and has a mental capacity of a human teen. It was observed that 12B-L3 feels uncomforable when observed 24/7.", "REPORT 12B-L3-PEAR: DESCRIPTION", 0);
            }
            else
            {
                MessageBox(IntPtr.Zero, "SUBJECT NAME: Yaroslav\nSUBJECT APPEARENCE: Huanmoid\nDANGER LEVEL: Unknown", "REPORT 12B-L3-PEAR: YOU AR", 0);
                MessageBox(IntPtr.Zero, "FOUND: \nBtcesju aws dofnu idsnei fo na trnapempta ugiibndl no ☐☐☐☐☐☐ nva. 126 ☐☐☐☐☐, ☐☐☐☐☐☐☐☐. Uirndg hte opoirtne ot eutracp teh cusbtje, 12B-L3 aws ominngcus na oknwun ldiqiu(tealr espfeidci ot eb eta.) ", "REPORT 12B-L3-PEAR: WHY I", 0);
                MessageBox(IntPtr.Zero, "DESCRIPTION: \n12B-L3 si a 16 reya-dol eaml, ohw ash na aenpaarcep fo a paltcyi moho saenspi etne. Ereth si nithngo uansuul ni het ejbcstsu ecappaanre.\n12B-L3 ersrpfe ot eb ersdsead sa 'Rsyovaal' dan sha a tnamle cpicayat fo a auhnm ente. Ti wsa bsevorde ttah 12B-L3 elsef cfraoleounmb wenh eedrbvos 24/7.", "REPORT 12B-L3-PEAR: RNSICTOEPID", 0);
            }
        }


        protected override void WndProc(ref Message m)
        {
            if (m.Msg == _messageId)
            {
                _accessLock = false;
                pictureBox1.Image = SystemProgHW1.Properties.Resources._12B_L3_Brocken;
                label2.Text = "CONTAINMENT: Breached containment";
                label3.Text = "ACESS LEVEL: Level 4 Professor";
                timer1.Enabled = true;
                this.BackColor = Color.Black;
                label1.ForeColor = Color.WhiteSmoke;
                label2.ForeColor = Color.WhiteSmoke;
                label3.ForeColor = Color.WhiteSmoke;
            }
            base.WndProc(ref m);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            MessageBeep(0);
            timer1.Interval = _rand.Next(700, 1500);
        }
    }
}