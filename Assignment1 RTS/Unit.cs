using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1_RTS
{
    abstract class Unit   //declairing vairables
    {
       protected int x;
       protected int y;
       protected int health;
       protected int speed;
       protected int attack;
       protected int range;
       protected int team;
       protected string symbol;
       protected string name;

       

        public Unit(int _x, int _y, int _health, int _speed, int _attack, int _range, int _team, string _symbol)
        {       //setting variables
            x = _x;
            y = _y;
            health = _health;
            speed = _speed;
            attack = _attack;
            range = _range;
            team = _team;
            symbol = _symbol;
          //  name = _Name;

        }
        //methods to override
        public abstract void Move(ref Unit closestUnit);
      
        public string Name { get { return name; } }

        public abstract void Combat(ref Unit attacker);

        public abstract bool InRange();

        public abstract Unit Closest(ref Unit[] map);

        public abstract void Death();
      
     
        public int Attack //overriding attack from Unit class
        {
            get { return attack; }
            set { Attack = value; }
        }

        public int X
        {
            get { return x; }
            set { x = value; }
        }

        public int Y
        {
            get { return y; }
            set { y = value; }
        }

        public string Symbol
        {
            get { return symbol; }
            set { symbol = value; }
        }

        public int Team
        {
            get { return team; }
            
        }



    }
    
}
