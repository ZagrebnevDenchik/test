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
    public partial class SignTwins : Form
    {
        //Принимаю перемённую через конструктор и в лейбл вписываю текст
        public SignTwins(string accept)
        {
            InitializeComponent();
            text.Text = accept;
        }

        private void SignTwins_Load(object sender, EventArgs e)
        {

        }
    }
}
