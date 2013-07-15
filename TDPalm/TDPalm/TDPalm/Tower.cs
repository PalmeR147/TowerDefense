using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using System.Diagnostics;

namespace TDPalm
{
    public class Tower : Tile
    {
        public int range;
        public int id;
        public int damage;
        Stopwatch shootTimer = new Stopwatch();

        public Tower(int id, int xPos, int yPos, ContentManager content, int range) :
            base(id, xPos, yPos, content)
        {
            isOccupied = true;

            this.range = range * 32;
            this.id = id;

            damage = GetDamage(id);
            shootTimer.Start();
        }

        public void Update()
        {
            if (Vector2.Distance(new Vector2(Game1.e.xPos, Game1.e.yPos), new Vector2(xPos, yPos)) < range)
            {
                if (shootTimer.ElapsedMilliseconds > 1000)
                {
                    Shoot(Game1.e);
                    shootTimer.Restart();
                }
            }
        }

        public int GetDamage(int id)
        {
            switch (id)
            {
                case 5:
                    return 10;

                default:
                    return 1;
            }
        }

        public void Shoot(Enemy e)
        {
            e.health -= damage;
        }
    }
}
