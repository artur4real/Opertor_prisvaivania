using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Operator_prisvaivania
{
    public partial class Form1 : Form
    {
        private Horse horse1;
        private Horse horse2;
        private decimal money;

        public Form1()
        {
            InitializeComponent();
            horse1 = new Horse("Horse 1", 100, 100, 50);
            horse2 = new Horse("Horse 2", 150, 150, 40);
            money = 1000m;
            UpdateUI();
        }

        private void UseButton_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            if (button == horse1UseButton)
            {
                horse1.TakeDamage();
                money += new Random().Next(10, 30);
            }
            else if (button == horse2UseButton)
            {
                horse2.TakeDamage();
                money += new Random().Next(10, 30);
            }
            UpdateUI();
        }

        private void HealButton_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            decimal cost = numericUpDown1.Value;
            if (cost > money)
            {
                MessageBox.Show("Not enough money!");
                return;
            }
            if (button == horse1HealButton)
            {
                horse1.Heal((int)numericUpDown2.Value);
                money -= cost;
            }
            else if (button == horse2HealButton)
            {
                horse2.Heal((int)numericUpDown2.Value);
                money -= cost;
            }
            UpdateUI();
        }

        private void UpdateUI()
        {
            horse1HPProgressBar.Value = horse1.CurrentHP * 100 / horse1.MaxHP;
            horse2HPProgressBar.Value = horse2.CurrentHP * 100 / horse2.MaxHP;
            horse1SpeedLabel.Text = horse1.Speed.ToString();
            horse2SpeedLabel.Text = horse2.Speed.ToString();
            moneyLabel.Text = $"Money: {money.ToString("C")}";
        }

        private void maxSpeedButton_Click(object sender, EventArgs e)
        {
            int maxSpeed = Math.Max(horse1.Speed, horse2.Speed);
            MessageBox.Show($"The maximum speed is: {maxSpeed}");
        }
    }

}