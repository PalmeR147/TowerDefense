using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;

namespace TDPalm
{
    public class Tile
    {

        //Stone, Dirt, Grass, 1,2,3

        public Texture2D tileTex;
        public int xPos;
        public int yPos;
        public bool isOccupied = false;
        public bool isStartTile;

        public Tile(int id, int xPos, int yPos, ContentManager content)
        {
            tileTex = content.Load<Texture2D>(id.ToString());
            this.xPos = xPos * 32;
            this.yPos = yPos * 32;

            if (id == 4)
            {
                isStartTile = true;
            }
        }

        public void Update(GameTime gameTime)
        {
        
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(tileTex, new Rectangle(xPos, yPos, 32, 32), Color.White);
        }
    }
}
