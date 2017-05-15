using System;
using System.Windows.Forms;

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
        private DateTime paymentDateTime, removeDateTime;
        private void Form1_Load(object sender, EventArgs e)
        {

            rchContent.Rtf = @"{\rtf1\ansi{\b\fs30 What Happened to My Computer?}"
            + @"\line {\b Y}our important files are encrypted."
            + @"\line Many of your documents, photos, videos, databases and other files are no longer accessible because they have been encrypted. Maybe you are busy looking for a way to recover your files, but do not waste your time. Nobody can recover your files without our decryption engine. "
            + @"\line \line {\b\fs30 Can I Recover My Files?} "
            + @"\line {\b S}ure. We guarantee that you can recover all your files safely and easily. But you have not so enough time."
            + @"\line You can decrypt some of your for free. Try now by clicking <Decrypt>."
            + @"\line But if you want to decrypt all your files, you need to pay."
            + @"\line You only have 3 days to submit the payment. After that the price will be doubled."
            + @"\line Also, if you don’t pay in 7 days, you won’t be able to recover your files forever."
            + @"\line We will have free events for users who are so poor that they couldn't pay in 6 months."
            + @"\line \line {\b\fs30 How Do I Pay?} "
            + @"\line {\b P}ayment is accepted in Bitcoin only. For more information, click <About bitcoin>."
            + @"\line Please check the current price of Bitcoin and buy some bitcoins. For more information click <How to buy bitcoins>."
            + @"\line And send the correct amount to the address specified in this window."
            + @"\line After your payment, click <Check Payment>. Best time to check: 9:00am – 11:00am GMT."
            + "}";

            cmbLanguage.SelectedIndex = 0;  
            
            paymentDateTime = DateTime.Now.AddDays(3);
            removeDateTime = DateTime.Now.AddDays(7);
     
            lblDatePayment.Text = paymentDateTime.ToString("M'/'d'/'yyyy hh:mm:ss");
            lblDateRemove.Text = removeDateTime.ToString("M'/'d'/'yyyy hh:mm:ss");

            timeSpanMethod();
            tmrTime.Start();
        }

        public void timeSpanMethod()
        {
            TimeSpan tsPayment = paymentDateTime - DateTime.Now;
            lblPayment.Text = tsPayment.Days.ToString("D2") + ":" + tsPayment.Hours.ToString("D2") + ":" + tsPayment.Minutes.ToString("D2") + ":" + tsPayment.Seconds.ToString("D2");

            TimeSpan tsRemove = removeDateTime - DateTime.Now;
            lblRemove.Text = tsRemove.Days.ToString("D2") + ":" + tsRemove.Hours.ToString("D2") + ":" + tsRemove.Minutes.ToString("D2") + ":" + tsRemove.Seconds.ToString("D2");
        }

        private void tmrTime_Tick(object sender, EventArgs e)
        {
            paymentDateTime.AddSeconds(-1);
            removeDateTime.AddSeconds(-1);
            timeSpanMethod();
        }
        private void button1_Click(object sender, EventArgs e)
        {
           Clipboard.SetText(txtBtc.Text);
           MessageBox.Show("Copied","Success");
        }


        public void showError()
        {
            MessageBox.Show("You have a connection problem. Please fix and try again later.", "Connection Problem",MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void linkLabelAbout_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            showError();
        }


        private void btnDecrypt_Click(object sender, EventArgs e)
        {
            showError();
        }

    }
}
