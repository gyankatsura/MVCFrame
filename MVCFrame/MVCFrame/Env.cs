using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace MVCFrame
{
    class Env
    {
        public static int screenWidth = 960;
        public static int screenHeight = 720;

        public static ContentManager content;
        public static SpriteBatch spriteBatch;
        public static GraphicsDeviceManager graphics;
        public static float deltaTime;
        private static KeyboardState preState;
        private static KeyboardState curState;

        public static void OnInit(ContentManager c, SpriteBatch s, GraphicsDeviceManager g)
        {
            content = c;
            spriteBatch = s;
            graphics = g;
        }
        public static void OnPreUpdate(GameTime time)
        {
            deltaTime = (float)time.ElapsedGameTime.TotalSeconds;
            curState = Keyboard.GetState();
        }
        public static void OnPostUpdate()
        {
            preState = curState;
        }

        public static bool GetKey(Keys key)
        {
            return curState.IsKeyDown(key);
        }

        public static bool GetKeyDown(Keys key)
        {
            return curState.IsKeyDown(key) && preState.IsKeyUp(key);
        }

        public static bool GetKeyUp(Keys key)
        {
            return curState.IsKeyUp(key) && preState.IsKeyDown(key);
        }
    }
}
