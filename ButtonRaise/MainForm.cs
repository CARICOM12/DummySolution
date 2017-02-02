using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace ButtonRaise
{
    public partial class MainForm : Form
    {
        private static Random randomizer = new Random();
        private readonly Button[] buttons;

        public MainForm()
        {
            InitializeComponent();

            this.startButton.Click += StartButton_Click;
            this.resetButton.Click += ResetButton_Click;

            buttons = new Button[] { button1, button2, button3 };
        }

        private void ResetButton_Click(object sender, EventArgs e)
        {
            foreach (Button button in buttons)
            {
                button.Location = new Point(0, button.Location.Y);
            }
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            new Thread(MoveButtons).Start();

        }

        delegate void MoveButtonsDelegate(Button[] buttons);

        private void MoveButtons()
        {
            if (InvokeRequired)
            {
                bool raceFinished = false;
                while (!raceFinished)
                {
                    this.Invoke(new MethodInvoker(delegate
                    {
                        foreach (Button button in buttons)
                        {
                            int newX = button.Location.X + randomizer.Next(5);
                            if (newX > raisePanel.Width - button.Width)
                            {
                                newX = raisePanel.Width - button.Width;
                                raceFinished = true;
                            }
                            button.Location = new Point(newX, button.Location.Y);
                        }
                    }));
                    Thread.Sleep(100);
                }                
            }
        }
    }
}
