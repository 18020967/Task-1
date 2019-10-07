using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1_RTS
{
    class MeleeUnit : Unit
    {
      

        public MeleeUnit(int x, int y, int health, int speed, int attack, int range, int team, string symbol) : base(x, y, 110, 1, attack, 1, team, "O")
        {
            this.x = x;
            this.y = y;
            this.health = health;
            this.speed = speed;
            this.attack = attack;
            this.range = range;
            this.team = team;
            this.symbol = symbol;
            
        }

        public override bool InRange()
        {
            throw new NotImplementedException();
        }

        public override void Move(ref Unit closestUnit) //moving the unit
        {
            if (this == closestUnit)
            {
                return;
            }

            if (closestUnit.Team != team)//moving unit towordsunit that is not a team unit
            {
                if (health < 25)
                {
                    Random r = new Random();

                    switch (r.Next(0, 2))
                    {
                        case 0: x += (1 * speed); break;
                        case 1: x -= (1 * speed); break;//randomise x position around current position

                    }
                    switch (r.Next(0, 2))
                    {
                        case 0: y += (1 * speed); break;
                        case 1: y -= (1 * speed); break;//randomise y position around current position

                    }

                    if (x <= 0)
                    {
                        x = 0;
                    }
                    else if (x >= 20)
                    {
                        x = 20;
                    }

                    if (y <= 0)
                    {
                        y = 0;
                    }
                    else if (y >= 20)
                    {
                        y = 20;
                    }
                }
                //else if ((Math.Abs(x - closestUnit.X)) <= && (Math.Abs(y - closestUnit.Y) <= speed))
               // {
                //    Combat(ref closestUnit);
               // }
                else
                {
                    if (x > closestUnit.X)
                    {
                        x -= speed;
                    }
                    else if (x < closestUnit.X)
                    {
                        x = +speed;
                    }

                    if (y > closestUnit.Y)
                    {
                        y -= speed;
                    }
                    else if (y < closestUnit.Y)
                    {
                        y = +speed;
                    }
                }
            }
        }

        public  int Attack //overriding attack from Unit class
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

        public override void Combat(ref Unit attacker)  //overriding combat from unit class
        {
            this.health = this.health - attacker.Attack;  //taking damage from being attack , health - attackers damage
            if(health <= 0)
            {
                Death();
            }
        }

        public  bool InRange(ref Unit attacker)
        {
            if (DistanceTo(attacker) == range)  //attacking the target unit if it is in range
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private int DistanceTo(Unit unit)
        {
            int dx = Math.Abs(unit.X - x);
            int dy = Math.Abs(unit.Y - y);
            double part = Convert.ToDouble((dx * dx) + (dy * dy));
            return Convert.ToInt32(Math.Sqrt(part));
        }

        public override Unit Closest(ref Unit[] map)
        {
            Unit closest = this;
            int smallestRange = 100;
            foreach ( Unit u in map)
            {
                if (u.Team != team)
                {
                    if (smallestRange > DistanceTo(u) && u != this)
                    {
                        smallestRange = DistanceTo(u);
                        closest = u;
                    }
                }
            }
            return closest;
        }

        public override void Death()
        {
          //  throw new DeathException(this.ToString() + " IS DEAD");
        }

        public override string ToString()
        {
            return Symbol + "  " + "Melee unit" + Symbol + "\nTeam: " + team + "\nPosition:  X:" + X + ", Y:" + Y + "\nHP: " + health + "\nAttack: " + Attack;
        }
    }




}
