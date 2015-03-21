using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NetCryptography
{
    partial class AboutProgramBox : Form
    {
        public AboutProgramBox()
        {
            InitializeComponent();
            this.Text = @"Про .Net Cryptography"; // String.Format("About {0}", AssemblyTitle);
            //this.labelProductName.Text = AssemblyProduct;
            linkLabel1.Text = "Автор: Семенюк Олександр, 2014\n" +
                              @"E-mail: sovist9@mail.ru";
            linkLabel1.Links.Add(39, 15, "mailto:sovist9@mail.ru");
            //this.labelVersion.Text = String.Format("Version {0}", AssemblyVersion);
            //this.labelCopyright.Text = AssemblyCopyright;
            //this.labelCompanyName.Text = AssemblyCompany;
            linkLabelAboutAlg.Text =
                "Програма використовує симетрічні алгоритми шифрування вбудовані в .net framework:\n\n" +
                "AES\n" +
                "Rijndael\n" +
                "DES\n" +
                "TripleDES\n" +
                "RC2";

            linkLabelAboutAlg.Links.Add(83, 3,
                "www.msdn.microsoft.com/ru-ru/library/system.security.cryptography.aes%28v=vs.110%29.aspx");
            linkLabelAboutAlg.Links.Add(87, 8,
                "www.msdn.microsoft.com/ru-ru/library/system.security.cryptography.rijndael%28v=vs.110%29.aspx");
            linkLabelAboutAlg.Links.Add(96, 3,
                "www.msdn.microsoft.com/ru-ru/library/system.security.cryptography.des%28v=vs.110%29.aspx");
            linkLabelAboutAlg.Links.Add(100, 9,
                "www.msdn.microsoft.com/ru-ru/library/system.security.cryptography.tripledes%28v=vs.110%29.aspx");
            linkLabelAboutAlg.Links.Add(110, 3,
                "www.msdn.microsoft.com/ru-ru/library/system.security.cryptography.rc2%28v=vs.110%29.aspx");
        }

        #region Assembly Attribute Accessors

        public string AssemblyTitle
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyTitleAttribute), false);
                if (attributes.Length > 0)
                {
                    AssemblyTitleAttribute titleAttribute = (AssemblyTitleAttribute)attributes[0];
                    if (titleAttribute.Title != "")
                    {
                        return titleAttribute.Title;
                    }
                }
                return System.IO.Path.GetFileNameWithoutExtension(Assembly.GetExecutingAssembly().CodeBase);
            }
        }

        public string AssemblyVersion
        {
            get
            {
                return Assembly.GetExecutingAssembly().GetName().Version.ToString();
            }
        }

        public string AssemblyDescription
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyDescriptionAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyDescriptionAttribute)attributes[0]).Description;
            }
        }

        public string AssemblyProduct
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyProductAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyProductAttribute)attributes[0]).Product;
            }
        }

        public string AssemblyCopyright
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyCopyrightAttribute)attributes[0]).Copyright;
            }
        }

        public string AssemblyCompany
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCompanyAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyCompanyAttribute)attributes[0]).Company;
            }
        }
        #endregion

        private void okButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LinkClicked(linkLabel1, e);
        }

        private void linkLabelAboutAlg_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LinkClicked(linkLabelAboutAlg, e);
        }

        private void LinkClicked(LinkLabel linkLabel, LinkLabelLinkClickedEventArgs e)
        {
            linkLabel.Links[linkLabel.Links.IndexOf(e.Link)].Visited = true;

            string target = (string)e.Link.LinkData;

            if (null != target)
                Process.Start(target);
        }
    }
}
