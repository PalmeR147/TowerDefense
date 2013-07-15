using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace TDPalm
{
    public static class Tiles
    {
        public static List<Tile> Tiless = new List<Tile>();
        public static Tower[,] Towers = 
        {
            {null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null},
            {null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null},
            {null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null},
            {null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null},
            {null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null},
            {null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null},
            {null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null},
            {null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null},
            {null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null},
            {null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null},
            {null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null},
            {null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null},
            {null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null},
            {null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null},
            {null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null},
        };
        //public static List<Tower> Towers = new List<Tower>();
        public static ContentManager content;

        public static void CreateMap()
        {

            for (int x = 0; x < Map.Map1.GetLength(1); x++)
            {
                for (int y = 0; y < Map.Map1.GetLength(0); y++)
                {
                    Tiless.Add(new Tile(Map.Map1[y, x], x, y, content));
                }
            }
        }

        public static int GetTowerPrice(int id)
        {
            switch (id)
            {
                case 5:
                    return 500;

                default:
                    return 1;
            }
        }

        public static void AddTower(int xTile, int yTile, int id, int range)
        {
            if (Game1.money >= GetTowerPrice(id))
            {
                Towers[yTile, xTile] = new Tower(id, xTile, yTile, content, range);
                Game1.money -= GetTowerPrice(id);
            }
        }
        public static void RemoveTower(int xTile, int yTile)
        {
            int id = Towers[yTile, xTile].id;
            Game1.money += (int)(GetTowerPrice(id) * 0.75);
            Towers[yTile, xTile] = null;
        }

        public static void Update(GameTime gameTime)
        {
            foreach (Tile t in Tiless)
            {
                t.Update(gameTime);
            }

            for (int x = 0; x < Towers.GetLength(1); x++)
            {
                for (int y = 0; y < Towers.GetLength(0); y++)
                {
                    if (Towers[y, x] != null)
                    {
                        Towers[y, x].Update();
                    }
                }
            }

        }

        public static void DrawTiles(SpriteBatch spriteBatch)
        {
            foreach (Tile t in Tiless)
            {
                t.Draw(spriteBatch);
            }
        }
        public static void DrawTowers(SpriteBatch spriteBatch)
        {
            for (int x = 0; x < Towers.GetLength(1); x++)
            {
                for (int y = 0; y < Towers.GetLength(0); y++)
                {
                    if (Towers[y, x] != null)
                    {
                        Towers[y, x].Draw(spriteBatch);
                    }
                }
            }
        }
    }
}
