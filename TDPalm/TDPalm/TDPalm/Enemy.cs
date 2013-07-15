using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;

namespace TDPalm
{
    public class Enemy
    {
        public int xPos;
        public int yPos;
        Texture2D mobTex;
        SpriteFont hp;
        public bool isAlive = true;
        public int health;

        public Enemy(int damage, int id, ContentManager content)
        {
            foreach (Tile t in Tiles.Tiless)
            {
                if (t.isStartTile)
                {
                    xPos = t.xPos;
                    yPos = t.yPos;
                }
            }

            health = 100;

            mobTex = content.Load<Texture2D>("MobTex");
            hp = content.Load<SpriteFont>("Health");
        }

        public void SpawnWave(int typeOfWave)
        {

        }

        public void Update()
        {
            xPos += 1;
            if (health <= 0)
                isAlive = false;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (isAlive)
            {
                spriteBatch.Draw(mobTex, new Rectangle(xPos, yPos, 32, 32), Color.White);
                spriteBatch.End();

                spriteBatch.Begin(SpriteSortMode.BackToFront, BlendState.AlphaBlend);
                spriteBatch.DrawString(hp, health.ToString(), new Vector2(xPos, yPos), Color.Black);
            }
        }

    }
}
