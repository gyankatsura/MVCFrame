using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MVCFrame.MVC.Model;
using MVCFrame.MVC.View;
using Microsoft.Xna.Framework;

namespace MVCFrame.MVC.Control
{
    class MFMainGameControl : MFControl
    {
        private static MFMainGameControl inst;
        public static MFMainGameControl getInst
        {
            get
            {
                if (inst == null) inst = new MFMainGameControl();
                return inst;
            }
        }

        protected override void OnUpdate()
        {
            base.OnUpdate();
            foreach (MFEntity e in entitySpriteDict.Keys)
            {
                MFQuadSprite s = entitySpriteDict[e] as MFQuadSprite;
                if (s != null)
                {
                    Rectangle rect = new Rectangle((int)(e.rectangle.left * 120) + Env.screenWidth / 2,
                                                   (int)(e.rectangle.top * 120) + Env.screenHeight / 2,
                                                   (int)(e.rectangle.width * 120),
                                                   (int)(e.rectangle.height * 120));
                    s.rect = rect;
                }
            }
        }

        protected override void OnInit()
        {
            base.OnInit();
            MFMainGameScene.getInst.OnEventEntitySpawned += this.OnEntitySpawned;
            MFMainGameScene.getInst.OnEventEntityDestroyed += this.OnEntityDestroyed;
            MFMainGameScene.getInst.OnEventGameState += this.OnGameState;
        }

        private void OnEntitySpawned(object sender, EntityArgs args)
        {
            MFQuadSprite sp = new MFQuadSprite();
            MFMainGameLayer layer = MFLayer.GetLayer<MFMainGameLayer>();
            if (args.entity is MFBullet) sp.texName = "bullet";
            else sp.texName = "ship";
            if (layer != null)
            {
                layer.AddSprite(sp);
            }
            this.entitySpriteDict[args.entity] = sp;
        }

        private void OnEntityDestroyed(object sender, EntityArgs args)
        {
            if (entitySpriteDict.ContainsKey(args.entity))
            {
                MFSprite sp = entitySpriteDict[args.entity];
                MFMainGameLayer layer = MFLayer.GetLayer<MFMainGameLayer>();
                if (layer != null)
                {
                    layer.RemoveSprite(sp);
                }
            }
        }

        private void OnGameState(object sender, GameStateEventArgs args)
        {
            MFGUILayer guiLayer = MFLayer.GetLayer<MFGUILayer>();
            if (guiLayer != null)
            {
                if (args.state == MainGameState.GameOver)
                {
                    guiLayer.Show();
                }
                else if(args.state == MainGameState.Running)
                {
                    guiLayer.Hide();
                }
            }
        }
    }
}
