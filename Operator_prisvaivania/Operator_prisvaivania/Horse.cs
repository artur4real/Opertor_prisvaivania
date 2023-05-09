using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Operator_prisvaivania
{
    class Horse
    {
        public string Name { get; set; }
        public int MaxHP { get; set; }
        private int currentHP;
        public int CurrentHP
        {
            get { return currentHP; }
            set { currentHP = value > MaxHP ? MaxHP : value; }
        }
        private int speed;
        public int Speed
        {
            get { return speed; }
            set { speed = (int)Math.Round((double)value * (CurrentHP / (double)MaxHP)); }
        }

        public Horse(string name, int maxHP, int startingHP, int speed)
        {
            Name = name;
            MaxHP = maxHP;
            CurrentHP = startingHP;
            this.speed = speed;
        }

        public void TakeDamage()
        {
            int damage = new Random().Next(1, CurrentHP / 2);
            CurrentHP -= damage;
            Speed = Speed; // Updates the speed based on the new CurrentHP value
        }

        public void Heal(int hpToHeal)
        {
            CurrentHP += hpToHeal;
            Speed = Speed; // Updates the speed based on the new CurrentHP value
        }
    }

}
