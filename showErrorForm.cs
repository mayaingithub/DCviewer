using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DCviewer
{
    public partial class showErrorForm : Form
    {
        public showErrorForm()
        {
            InitializeComponent();
        }

        public void setErrorTextToRich(string errorText)
        {
            richTextBox1.Clear();
            richTextBox1.AppendText(errorText);
        }
     
    }
}
