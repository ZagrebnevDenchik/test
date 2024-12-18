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
    public partial class SignSagittarius : Form
    {
        //Принимаю перемённую через конструктор и в лейбл вписываю текст
        public SignSagittarius(string accept)
        {
            InitializeComponent();
            text.Text = accept;
        }

        private void SignSagittarius_Load(object sender, EventArgs e)
        {

        }
    }
}
