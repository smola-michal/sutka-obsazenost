using System;
using System.Windows.Forms;

namespace SutkaObsazenostUI
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkRun.Checked)
            {
                SutkaObsazenost.Program.ConsoleWrite = s => textConsole.Text += s;
                SutkaObsazenost.Program.Run();
            }
        }
    }
}
