using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MVCFrame.MVC.View
{
    class MFBackgroundLayer : MFLayer
    {
        public MFBackgroundLayer(int depth)
            : base(depth)
        { }

        float timer = 0.0f;
        float offsetSpeed = 0.1f;
        int offset = 0;

        protected override void OnUpdate()
        {
            base.OnUpdate();
            timer += Env.deltaTime;
            offset = (int)(timer / offsetSpeed);
            offset = offset % Env.screenWidth;
        }

        protected override void OnDraw()
        {
            base.OnDraw();
            Texture2D t2d = Env.content.Load<Texture2D>("starspace");
            if (t2d != null)
            {
                Env.spriteBatch.Begin();
                Env.spriteBatch.Draw(t2d, new Microsoft.Xna.Framework.Rectangle(-offset, 0, Env.screenWidth, Env.screenHeight), Color.White);
                Env.spriteBatch.Draw(t2d, new Rectangle(Env.screenWidth - offset, 0, Env.screenWidth, Env.screenHeight), null, Color.White, 0.0f, Vector2.Zero, SpriteEffects.FlipHorizontally, 0);
                Env.spriteBatch.Draw(t2d, new Rectangle(Env.screenWidth * 2 - offset, 0, Env.screenWidth, Env.screenHeight), Color.White);
                Env.spriteBatch.End();
            }
        }
    }
}
