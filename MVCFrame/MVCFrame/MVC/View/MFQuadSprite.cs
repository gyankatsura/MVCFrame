using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MVCFrame.MVC.View
{
    class MFQuadSprite : MFSprite
    {
        public Rectangle rect;
        public string texName = "white";

        public override void Draw()
        {
            base.Draw();
            Texture2D t2d = Env.content.Load<Texture2D>(texName);
            Env.spriteBatch.Begin();
            Env.spriteBatch.Draw(t2d, rect, Color.White);
            Env.spriteBatch.End();
        }

        public override void OnRemoved()
        {
            base.OnRemoved();
            Console.WriteLine("Removed");
        }
    }
}
