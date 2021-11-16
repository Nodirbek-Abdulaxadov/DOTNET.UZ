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

namespace File_Properties
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void browse_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if(ofd.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = ofd.FileName;

                FileInfo file = new FileInfo(ofd.FileName);

                name.Text = file.Name;
                type.Text = file.Extension;
                dir.Text = file.DirectoryName;
                size.Text = file.Length.ToString()+" bytes";
                dc.Text = file.CreationTime.ToString();
                dm.Text = file.LastWriteTime.ToString();
                da.Text = file.LastAccessTime.ToString();
                att.Text = file.Attributes.ToString();
            }
        }
    }
}
