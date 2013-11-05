using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace MVCFrame.MVC.View
{
    class MFGUILayer : MFLayer
    {
        public MFGUILayer(int depth)
            : base(depth)
        { }

        protected override void OnDraw()
        {
            base.OnDraw();
            SpriteFont font = Env.content.Load<SpriteFont>("SpriteFont1");
            if (font != null)
            {
                Env.spriteBatch.Begin();
                Env.spriteBatch.DrawString(font, "GAME OVER", new Microsoft.Xna.Framework.Vector2(Env.screenWidth / 2 - 10, Env.screenHeight / 2 - 10), Color.White);
                Env.spriteBatch.End();
            }
        }
    }
}
