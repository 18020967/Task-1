using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1_RTS
{
    class ResourceBuilding : Building
    {
        string rType;
        int rGenerated = 0;
        int rGenPerRound = 10;
        int rPoolRemaining = 10000;

        public ResourceBuilding(string name, int PosX, int PosY, int health, int team, string symbol, string node) : base(PosX, PosY, health, team, symbol, name)
        {
            //maximumHealth = health;
            this.name = name;
            this.PosX = PosX;
            this.PosY = PosY;
            this.health = health;
            this.team = team;
            this.symbol = symbol;

            rType = node.Split(',')[0];
          //  rPoolRemaining = Int32.Parse(node.Split(',')[1]);

           // rGenPerRound = Int32.Parse(node.Split(',')[2]);



        }

        public void Generating()
        {
            if (rPoolRemaining - rGenPerRound>=0)
            rGenerated = rGenerated + rGenPerRound;
            rPoolRemaining = rPoolRemaining - rGenPerRound;
        }
        public override void Destruction()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return Symbol + "  " + name + Symbol + "\nTeam: " + team + "\nPosition:  X:" + PosX + ", Y:" + PosY + "\nHP: " + health + "\nCollector stats\nType: " + rType + "\nStockpile: " + rGenerated + "\nEfficiency: " + rGenPerRound;
        }


    }

   
}
