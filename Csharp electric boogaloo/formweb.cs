using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Csharp_electric_boogaloo
{
    public partial class FormWeb : Form
    {
        [BindableAttribute(true)]
        public Uri Url { get; set; }

        // Navigates to the given URL if it is valid. 
        private void Navigate(String address)
        {
            if (String.IsNullOrEmpty(address))
            {
                return;
            } 
            if (address.Equals("about:blank"))
            {
                return;
            }
            if (!address.StartsWith("http://") && !address.StartsWith("https://"))
            {
                address = "http://" + address;
            }
            try
            {
                THEWEB.Navigate(new Uri(address));
                txtWebsite.Text = THEWEB.Url.ToString();
            }
            catch (System.UriFormatException)
            {
                return;
            }
        }

        // Updates the URL in TextBoxAddress upon navigation. 
        private void webBrowser1_Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {
            txtWebsite.Text = THEWEB.Url.ToString();
        }


        public FormWeb()
        {
            InitializeComponent();
        }

        private void cmdLeave_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtWebsite_Click(object sender, EventArgs e)
        {
            Navigate(txtWebsite.Text);
        }

        private void THEWEB_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            txtWebsite.Text = THEWEB.Url.ToString();
        }

        private void Fix_Click(object sender, EventArgs e)
        {
            //FormSettings.dothething();
        }

        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            saveFileDialog1.ShowDialog();
        }

        private void helpToolStripButton_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
        }

        private void printToolStripButton_Click(object sender, EventArgs e)
        {
            bananaprint.ShowDialog();
        }
    }
}
