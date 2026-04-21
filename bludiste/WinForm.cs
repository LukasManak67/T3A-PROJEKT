using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace bludiste
{
    public partial class WinForm : Form
    {
        public WinForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();

            Form1 game = new Form1();
            game.ShowDialog();

            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();

            MenuForm menu = new MenuForm();
            menu.ShowDialog();

            this.Close();
        }
    }
}
