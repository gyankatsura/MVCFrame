using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using MVCFrame.MVC.Model;
using Microsoft.Xna.Framework;

namespace MVCFrame.MVC.View
{
    class MFMainGameLayer : MFLayer
    {
        public MFMainGameLayer(int depth)
            : base(depth) { }

        protected override void OnDraw()
        {
            base.OnDraw();
            SpriteFont font = Env.content.Load<SpriteFont>("SpriteFont1");
            int playerHP = MFScene.GetScene<MFMainGameScene>().playerHP;
            if (font != null)
            {
                Env.spriteBatch.Begin();
                Env.spriteBatch.DrawString(font, playerHP.ToString(), new Vector2(10, 10), Color.White);
                Env.spriteBatch.End();
            }
        }
    }
}
