using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;

namespace MVCFrame.MVC.Model
{
    enum MainGameState
    {
        Running,
        GameOver,
    }

    class GameStateEventArgs : EventArgs
    {
        public MainGameState state;
    }

    class MFMainGameScene : MFScene
    {
        /*private static MFMainGameScene inst = null;
        public static MFMainGameScene getInst
        {
            get
            {
                if (inst == null) inst = new MFMainGameScene();
                return inst;
            }
        }*/
        public MFMainGameScene() { }

        public delegate void GameStateEventHandler(object sender, GameStateEventArgs args);
        public event GameStateEventHandler OnEventGameState = delegate { };

        MFEntity player;
        float timer = 0.0f;
        Random rd = new Random();
        List<MFBullet> listBullet = new List<MFBullet>();
        MainGameState state = MainGameState.Running;
        public int playerHP;

        protected override void OnInit()
        {
            base.OnInit();
            playerHP = 100;
        }

        protected override void OnUpdate()
        {
            base.OnUpdate();
            if (state == MainGameState.Running)
            {
                if (player == null)
                {
                    player = new MFEntity(this);
                    player.position = new MFVector(0.0f, 0.0f);
                    player.size = new MFVector(0.3f, 0.3f);
                    player.Spawn();
                }
                if (Env.GetKey(Keys.A))
                    player.position.x -= 1.0f * Env.deltaTime;
                if (Env.GetKey(Keys.D))
                    player.position.x += 1.0f * Env.deltaTime;
                if (Env.GetKey(Keys.W))
                    player.position.y -= 1.0f * Env.deltaTime;
                if (Env.GetKey(Keys.S))
                    player.position.y += 1.0f * Env.deltaTime;

                timer -= Env.deltaTime;
                if (timer <= 0.0f)
                {
                    RandomRefreshTime();
                    SpawnBullet();
                }
                foreach (MFBullet b in listBullet)
                    b.Move();
                CheckBullets();
                CheckHit();
            }
            else if (state == MainGameState.GameOver)
            {
                if (Env.GetKeyDown(Keys.Space)) 
                    Restart();
            }
        }

        private void RandomRefreshTime()
        {
            timer = (float)(rd.NextDouble() * 0.5 + 0.1);
        }

        private void SpawnBullet()
        {
            float ypos = (float)(rd.NextDouble() * 6.0 - 3.0);
            MFVector newpos = new MFVector(-4.0f, ypos);
            MFBullet bullet = new MFBullet(this);
            bullet.position = newpos;
            float scale = (float)(rd.NextDouble()) * 5.0f + 1.0f;
            bullet.size = new MFVector(0.1f * scale, 0.1f * scale);
            bullet.speed = new MFVector(1.0f * (float)(rd.NextDouble()) + 1.0f, 0.0f);
            bullet.Spawn();
            listBullet.Add(bullet);
        }

        private void CheckBullets()
        {
            List<MFBullet> bulletsToDestroy = new List<MFBullet>();
            foreach (MFBullet b in listBullet)
            {
                if (b.position.x > 4.0f)
                {
                    bulletsToDestroy.Add(b);
                }
            }
            foreach (MFBullet b in bulletsToDestroy)
            {
                listBullet.Remove(b);
                b.Destroy();
            }
        }

        private void CheckHit()
        {
            MFRectangle rect = player.rectangle;
            foreach (MFBullet b in listBullet)
            {
                MFRectangle rect1 = b.rectangle;
                float f1 = (rect.left - (rect1.left + rect1.width));//Simple Collision Detection
                float f2 = (rect1.left - (rect.left + rect.width));
                float f3 = (rect.top - (rect1.top + rect1.height));
                float f4 = (rect1.top - (rect.top + rect.height));
                if (f1 * f2 > 0.0f && f3 * f4 > 0.0f)
                {
                    listBullet.Remove(b);
                    b.Destroy();
                    playerHP -= 10;
                    break;
                }
            }
            if (playerHP <= 0)
            {
                playerHP = 0;
                GameOver();
            }
        }

        private void GameOver()
        {
            foreach (MFBullet b in listBullet)
            {
                b.Destroy();
            }
            listBullet.Clear();
            player.Destroy();
            state = MainGameState.GameOver;
            GameStateEventArgs args = new GameStateEventArgs();
            args.state = state;
            OnEventGameState(this, args);
        }

        private void Restart()
        {
            playerHP = 100;
            player.position = new MFVector(0.0f, 0.0f);
            player.Spawn();
            state = MainGameState.Running;
            GameStateEventArgs args = new GameStateEventArgs();
            args.state = state;
            OnEventGameState(this, args);
        }
    }
}
