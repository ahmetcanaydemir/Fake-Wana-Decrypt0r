using System;
using System.Drawing;
using System.Drawing.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace Fake_Wana_Decrypt0r
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        /*
         Name        : Fake Wana Decrypt0r 2.0
         Description : Harmless version of Wana Decrypt0r 2.0. Just for fun.
         Coder       : Ahmet Can Aydemir 
         Date Time   : 15.05.2017 06:30
         */

        [DllImport("gdi32.dll")] //For adding LCD style time font.
        private static extern IntPtr AddFontMemResourceEx(IntPtr pbfont, uint cbfont
            , IntPtr pdv, [In] ref uint pcFonts);

        private FontFamily _fontFamily;
        private Font _font;

        private DateTime _paymentDateTime, _removeDateTime;
        private void Form1_Load(object sender, EventArgs e)
        {
            rchContent.Rtf = @"{\rtf1\ansi{\b\fs30 What Happened to My Computer?}"
            + @"\line {\b Y}our important files are encrypted."
            + @"\line Many of your documents, photos, videos, databases and other files are no longer accessible because they have been encrypted. Maybe you are busy looking for a way to recover your files, but do not waste your time. Nobody can recover your files without our decryption engine."
            + @"\line \line {\b\fs30 Can I Recover My Files?}"
            + @"\line {\b S}ure. We guarantee that you can recover all your files safely and easily. But you have not so enough time."
            + @"\line You can decrypt some of your for free. Try now by clicking <Decrypt>."
            + @"\line But if you want to decrypt all your files, you need to pay."
            + @"\line You only have 3 days to submit the payment. After that the price will be doubled."
            + @"\line Also, if you don’t pay in 7 days, you won’t be able to recover your files forever."
            + @"\line We will have free events for users who are so poor that they couldn't pay in 6 months."
            + @"\line \line {\b\fs30 How Do I Pay?}"
            + @"\line {\b P}ayment is accepted in Bitcoin only. For more information, click <About bitcoin>."
            + @"\line Please check the current price of Bitcoin and buy some bitcoins. For more information click <How to buy bitcoins>."
            + @"\line And send the correct amount to the address specified in this window."
            + @"\line After your payment, click <Check Payment>. Best time to check: 9:00am – 11:00am GMT."
            + "}";
            
            LoadFont(); //Load to Memory LCD type font named Bazaronite
            AllocFont(_font,lblPayment,18); //Apply font from memory
            AllocFont(_font, lblRemove, 18); //Apply font from memory

            cmbLanguage.SelectedIndex = 0;  
            
            _paymentDateTime = DateTime.Now.AddDays(3);
            _removeDateTime = DateTime.Now.AddDays(7);
     
            lblDatePayment.Text = _paymentDateTime.ToString("M'/'d'/'yyyy hh:mm:ss");
            lblDateRemove.Text = _removeDateTime.ToString("M'/'d'/'yyyy hh:mm:ss");

            TimeSpanMethod();
            tmrTime.Start();
        }

        private void TimeSpanMethod()
        {
            TimeSpan tsPayment = _paymentDateTime - DateTime.Now;
            lblPayment.Text = tsPayment.Days.ToString("D2") + ":" + tsPayment.Hours.ToString("D2") + ":" + tsPayment.Minutes.ToString("D2") + ":" + tsPayment.Seconds.ToString("D2");

            TimeSpan tsRemove = _removeDateTime - DateTime.Now;
            lblRemove.Text = tsRemove.Days.ToString("D2") + ":" + tsRemove.Hours.ToString("D2") + ":" + tsRemove.Minutes.ToString("D2") + ":" + tsRemove.Seconds.ToString("D2");
        }

        private void tmrTime_Tick(object sender, EventArgs e)
        {
            _paymentDateTime= _paymentDateTime.AddSeconds(-1);
            _removeDateTime= _removeDateTime.AddSeconds(-1);
            TimeSpanMethod();
        }
        private void button1_Click(object sender, EventArgs e)
        {
           Clipboard.SetText(txtBtc.Text);
           MessageBox.Show("Copied","Success");
        }


        private void ShowError()
        {
            MessageBox.Show("You have a connection problem. Please fix and try again later.", "Connection Problem",MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void linkLabelAbout_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ShowError();
        }


        private void btnDecrypt_Click(object sender, EventArgs e)
        {
            ShowError();
        }

        private void LoadFont() //This is loading font from resources to Memory
        {
            byte[] fontArray = Fake_Wana_Decrypt0r.Properties.Resources.Bazaronite;
            int dataLenght = Fake_Wana_Decrypt0r.Properties.Resources.Bazaronite.Length;

            IntPtr ptrData = Marshal.AllocCoTaskMem(dataLenght);
            Marshal.Copy(fontArray, 0, ptrData, dataLenght);
            uint cFonts = 0;
            AddFontMemResourceEx(ptrData, (uint)fontArray.Length, IntPtr.Zero, ref cFonts);

            PrivateFontCollection pfc = new PrivateFontCollection();

            pfc.AddMemoryFont(ptrData, dataLenght);

            Marshal.FreeCoTaskMem(ptrData);

            _fontFamily = pfc.Families[0];
            _font = new Font(_fontFamily, 18f);
        }

        private void AllocFont(Font f, Control c, float size) //This is loading font from Memory to control
        {
            FontStyle fontStyle = FontStyle.Regular;
            c.Font = new Font(_fontFamily, size, fontStyle);
        }


    }
}
