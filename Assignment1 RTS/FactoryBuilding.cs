using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1_RTS
{
    class FactoryBuilding : Building
    {
        int unitType;
        int productionSpeed;
        int[] spawnUnit = new int[2];
       
        int xpos;
        int ypos;
        string factSpawn;

        public int ProductionSpeed
        {
            get { return productionSpeed; }
        }
        public override string ToString()
        {
            string type;
            if (unitType == 0)
            {
                type = "Barbarien";
            }
            else
            {
                type = "Scout";
            }
            return Symbol + "  " + name + Symbol + "\nTeam: " + team + "\nPosition:  X:" + posX + ", Y:" + posY + "\nHP: " + health + "\nFactory stats \nUnit Type: " + type + "\nActive Production : " + productionSpeed + "\nFactory Gate: " + factSpawn;
        }

        public FactoryBuilding(string name, int xPos, int yPos, int health, int team, string symbol, int unitType, int speed) : base(xPos, yPos, team, 110, name, "O")
        {
            maxHealth = health;
            this.name = name;
            this.posX = xPos;
            this.posY = yPos;
            this.health = health;
            this.team = team;
            this.symbol = symbol;
            this.unitType = unitType;
            this.productionSpeed = speed;
            if (yPos == 20)
            {
                spawnUnit[0] = xPos;
                spawnUnit[1] = yPos - 1;
                factSpawn = "Top";
            }
            else
            {
                spawnUnit[0] = xPos;
                spawnUnit[1] = yPos + 1;
                factSpawn = "Bottom";
            }



        }

        public override void Destruction()
        {
            throw new NotImplementedException();
        }
        Random random = new Random();
        public Unit SpawnUnit()
        {
            int newX = spawnUnit[0];
            int newY = spawnUnit[1];
            int tempAttack = 0;

            // randomly assigns units damage values
            switch (random.Next(0, 4))
            {
                case 0: tempAttack = 5; break;
                case 1: tempAttack = 10; break;
                case 2: tempAttack = 15; break;
                case 3: tempAttack = 20; break;
            }

            // randomly gives unit type
            switch (unitType)
            {
                default: return new MeleeUnit(newX, newY, 100, 1, tempAttack, 1, team, "0");
                case 0: return new MeleeUnit(newX, newY, 100, 1, tempAttack, 1, team, "0");
                case 1: return new RangedUnit(newX, newY, 70, 2, tempAttack, 4, team, "8");

            }

        }


    }
}
