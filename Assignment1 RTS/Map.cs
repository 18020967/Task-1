using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1_RTS
{
    class Map
    {
        public Unit[] units = new Unit[10];
        public Building[] building;

        public Map()
        {
            Random r = new Random();
            for(int i = 0;i < 10; i++)
            {
                int newX = r.Next(0, 20);
                int newY = r.Next(0, 20);
                int team = i % 2;
                int tempAttack = 0;
                switch (r.Next(0, 4))
                {
                    case 0: tempAttack = 5; break;
                    case 1: tempAttack = 10; break;
                    case 2: tempAttack = 15; break;
                    case 3: tempAttack = 20; break;
                }
                switch (r.Next(0, 2))
                {
                    case 0: units[i] = new MeleeUnit(newX, newY, 100, 1, tempAttack, 1, team, "0"); break;
                    case 1: units[i] = new RangedUnit(newX, newY, 100, 1, tempAttack, 4, team, "8"); break;
                   
                }
               
            }
           

            for (int i2 = 0; i2 < 5; i2++)
            {
                int newX = r.Next(0, 20);
                int newY = r.Next(0, 20);
                int team = i2 % 2;

                switch (r.Next(0, 2))
                {
                    /*
                     * case 0: building[i2] = new ResourceBuilding("Extractor", newX, newY, 300, team, "+", "ore"); break;
                     * case 1: building[i2] = new FactoryBuilding("Factory", newX, newY, 200, team, "-", r.Next(0, 2), r.Next(5, 10)); break;
                    */

                }
            }
        }

        public void SaveToFile()
        {
            string[] toFile = new string[units.Length];

            for (int i = 0; i < units.Length; i++)
            {
                toFile[i] = units[i].X + "-" + units[i].Y + "-" +
                            units[i].Name + "-" + units[i].Symbol + "-" +
                            units[i].GetType() + "-" + units[i].Team    ;
            }

            StreamWriter myFile = new StreamWriter(@"MapInformation.txt", false);

            if (!File.Exists(@"MapInformation.txt"))
            {
                File.WriteAllLines(@"MapInformation.txt", toFile);
            }
            else
            {
                for (int j = 0; j < toFile.Length; j++)
                {
                    myFile.WriteLineAsync(toFile[j]);
                }
            }

            myFile.Close();
        }

        public void ReadFromFile()
        {
            if (!File.Exists(@"MapInformation.txt")) 
            {
                return;
            }
            StreamReader myFile = new StreamReader(@"MapInformation.txt");

            myFile.Close();
        }
    }
}
