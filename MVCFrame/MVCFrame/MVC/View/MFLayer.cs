using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MVCFrame.MVC.View
{
    class MFLayer : IComparable<MFLayer>
    {
        protected bool bVisible = false;
        protected int depth = 0;
        protected List<MFSprite> spriteList = new List<MFSprite>();

        protected static List<MFLayer> sLayerList = new List<MFLayer>();
        public static void OnInit()
        {
            //Test
            new MFMainGameLayer(0).Show();
            new MFGUILayer(1);
        }
        public static void OnLayerUpdate()
        {
            foreach (MFLayer l in sLayerList)
                if (l.bVisible) l.OnUpdate();
        }

        public static void OnLayerDraw()
        {
            foreach (MFLayer l in sLayerList)
                if (l.bVisible) l.OnDraw();
        }

        private static void OnNewLayerCreated(MFLayer layer)
        {
            if (sLayerList.Contains(layer)) return;
            foreach (MFLayer l in sLayerList)
                if (l.GetType() == layer.GetType()) return;
            sLayerList.Add(layer);
            sLayerList.Sort();
        }

        public static T GetLayer<T>() where T : class
        {
            foreach (MFLayer l in sLayerList)
                if (l is T) return l as T;
            return null;
        }

        public MFLayer(int depth)
        {
            this.depth = depth;
            OnNewLayerCreated(this);
        }

        protected virtual void OnShow()
        {

        }

        protected virtual void OnHide()
        {

        }

        protected virtual void OnUpdate()
        {
            
        }

        protected virtual void OnDraw()
        {
            if (bVisible)
                foreach (MFSprite s in spriteList)
                    s.Draw();
        }

        public void AddSprite(MFSprite sprite)
        {
            if (!spriteList.Contains(sprite))
            {
                this.spriteList.Add(sprite);
                sprite.OnAdded(this);
            }
        }

        public void RemoveSprite(MFSprite sprite)
        {
            if (spriteList.Contains(sprite))
            {
                this.spriteList.Remove(sprite);
                sprite.OnRemoved();
            }
        }

        public void Show()
        {
            if (!bVisible)
            {
                bVisible = true;
                OnShow();
            }
        }

        public void Hide()
        {
            if (bVisible)
            {
                bVisible = false;
                OnHide();
            }
        }

        public int CompareTo(MFLayer other)
        {
            if (this.depth > other.depth) return 1;
            else if (this.depth == other.depth) return 0;
            return -1;
        }
    }
}
