using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Horoscope.Forms
{
    public partial class SignMaid : Form
    {
        //Принимаю перемённую через конструктор и в лейбл вписываю текст
        public SignMaid(string accept)
        {
            InitializeComponent();
            text.Text = accept;
        }

        private void SignMaid_Load(object sender, EventArgs e)
        {

        }
    }
}
