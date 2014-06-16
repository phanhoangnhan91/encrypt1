using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace encrypt
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //string s=encrypt.EncryptStringAES("PhanHoangNhan");
            //string a=encrypt.DecryptStringAES(s);
            //doc file text
            try
            {
                var filestream = new FileStream(Path.GetDirectoryName(Environment.GetCommandLineArgs()[0]) + @"\code.txt",
                                   FileMode.Open,
                                   FileAccess.Read,
                                   FileShare.ReadWrite);
                var file = new StreamReader(filestream, Encoding.UTF8, true, 128);
                string line;
                // khai báo file ghi f
                StreamWriter f = null;
            
                string fn = Path.GetDirectoryName(Environment.GetCommandLineArgs()[0]) + @"\codemh.txt";

                f = File.CreateText(fn); // tao ra file moi                        
               
                while ((line = file.ReadLine()) != null)
                {
                    f.WriteLine(encrypt.EncryptStringAES(line));
                }
                if (f != null)
                    f.Close();
                if (filestream != null)
                    filestream.Close();
              
            }
            catch
            {
            }
            MessageBox.Show("Done!");
            
        }
    }
}
