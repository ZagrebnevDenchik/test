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
    public partial class SignLeo : Form
    {
        //Принимаю перемённую через конструктор и в лейбл вписываю текст
        public SignLeo(string accept)
        {
            InitializeComponent();
            text.Text = accept;
        }

        private void SignLeo_Load(object sender, EventArgs e)
        {

        }
    }
}
