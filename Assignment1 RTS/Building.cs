using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1_RTS
{
        
    abstract class Building
    {
        //declaring the protected variables
        protected string name;
        protected int posX;
        protected int posY;
        protected int health;
        protected int maxHealth;
        protected int team;
        protected string symbol;

        public abstract void Destruction();
        public abstract string ToString();
        //constructor
        public Building(int posx,int posy,int health,int team,string symbol,string name)
        {
            //this. to refer to the instance of the variable in this class
            
            this.posX = posx;
            this.posY = posy;
            this.health = health;

            this.team = team;
            this.symbol = symbol;
            this.name = name;
        }

        public int PosX { get { return posX; } set { posX = value; } }
        public int PosY { get { return posY; } set { posY = value; } }
        public int maximumHealth { get { return health; } }
        public int HP { get { return health; } }

        public int Team { get { return team; } set { team = value; } }
        public string Symbol { get { return symbol; } }
        public string Name { get { return name; } set { name = value; } }


    }
}
