using System;
using System.Drawing;
using System.Windows.Forms;

namespace SAPER
{
    public partial class GRA : Form
    {
        private int boardSize;
        private int numBombs;
        int countB;


        private Button[,] buttons;
        private bool[,] bombs;
        private System.Windows.Forms.Timer timer;
        private int elapsedTime;

        public GRA(int size, int bombs)
        {
            InitializeComponent();
            boardSize = size;
            numBombs = bombs;
            InitializeBoard();
            InitializeTimer();
        }

        private void InitializeBoard()
        {
            // Inicjalizacja tablic
            buttons = new Button[boardSize, boardSize];
            bombs = new bool[boardSize, boardSize];

            for (int row = 0; row < boardSize; row++)
            {
                for (int col = 0; col < boardSize; col++)
                {
                    Button button = new Button();
                    button.Size = new Size(30, 30);
                    button.Location = new Point(30 * col, 30 * row);
                    button.Tag = new Tuple<int, int>(row, col);
                    button.MouseUp += Button_MouseUp;
                    Controls.Add(button);
                    buttons[row, col] = button;
                }
            }

            Random random = new Random();
            int bombCount = 0;
            while (bombCount < numBombs)
            {
                int row = random.Next(boardSize);
                int col = random.Next(boardSize);
                if (!bombs[row, col])
                {
                    bombs[row, col] = true;
                    bombCount++;
                }
            }
        }

        private void InitializeTimer()
        {
            timer = new System.Windows.Forms.Timer();
            timer.Interval = 1000;
            timer.Tick += Timer_Tick;
            elapsedTime = 0;
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            elapsedTime++;
            if (elapsedTime >= Form1.d*Form1.d*3)
            {
                timer.Stop();
                MessageBox.Show("Przegrałeś! Upłynął limit czasu.");
                DisableButtons();
            }
        }

        private void Button_MouseUp(object sender, MouseEventArgs e)
        {
            Button button = (Button)sender;
            Tuple<int, int> position = (Tuple<int, int>)button.Tag;
            int row = position.Item1;
            int col = position.Item2;

            if (e.Button == MouseButtons.Left)
            {
                if (bombs[row, col])
                {
                    button.BackColor = Color.Green;
                    countB++;
                    if (countB == numBombs)
                    {
                        timer.Stop();
                        MessageBox.Show("Wygrałeś! Odkryłeś wszystkie elementy.");
                        DisableButtons();
                    }
                    
                }
                else
                {
                    button.Enabled = false;
                    button.BackColor = Color.Red;
                   
                }
            }
        }

        private bool CheckForWin()
        {
            foreach (Button button in buttons)
            {
                Tuple<int, int> position = (Tuple<int, int>)button.Tag;
                int row = position.Item1;
                int col = position.Item2;

                if (!bombs[row, col] && button.BackColor != Color.LightGreen)
                {
                    return false;
                }
            }

            return true;
        }

        private void DisableButtons()
        {
            foreach (Button button in buttons)
            {
                button.Enabled = false;
            }
        }

        private void GRA_Load(object sender, EventArgs e)
        {

        }
    }
}
