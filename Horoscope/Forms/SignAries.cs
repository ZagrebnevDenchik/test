﻿using System;
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
    public partial class SignAries : Form
    {
        //Принимаю перемённую через конструктор и в лейбл вписываю текст
        public SignAries(string accept)
        {
            InitializeComponent();
            text.Text = accept;
        }

        private void SignAries_Load(object sender, EventArgs e)
        {

        }
    }
}
