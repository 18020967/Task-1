using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assignment1_RTS
{
    public partial class Form1 : Form
    {
        GameEngine engine;
        int count = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            engine = new GameEngine(this, this.groupBox1);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            engine.UpdateMap();
            engine.UpdateDisplay();
            lblUnitInfo.Text = (++count).ToString();
        }

        public void displayInfo(string message)
        {
            reInfo.Text = "";
            reInfo.AppendText(message);
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            engine.UpdateMap();
            engine.UpdateDisplay();
            lblUnitInfo.Text = (++count).ToString();

        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;

     
        }

        private void btnPause_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
        }

        private void BtnWrite_Click(object sender, EventArgs e)
        {
            engine.mymap.SaveToFile();
        }
    }
}
