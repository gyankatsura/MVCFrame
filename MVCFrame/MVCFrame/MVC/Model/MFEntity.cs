using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MVCFrame.MVC.Model
{
    struct MFVector
    {
        public float x;
        public float y;

        public MFVector(float x, float y)
        {
            this.x = x;
            this.y = y;
        }
    }

    struct MFRectangle
    {
        public float left;
        public float top;
        public float width;
        public float height;

        public MFRectangle(float l, float t, float w, float h)
        {
            left = l;
            top = t;
            width = w;
            height = h;
        }
    }

    class MFEntity
    {
        protected MFScene scene;

        public MFVector position;
        public MFVector size;

        public bool life { get; protected set; }

        public MFRectangle rectangle
        {
            get
            {
                return new MFRectangle(position.x - size.x / 2,
                                       position.y - size.y / 2,
                                       size.x,
                                       size.y);
            }
        }

        public MFEntity(MFScene scene)
        {
            this.scene = scene;
            life = false;
        }

        public void Spawn()
        {
            if (life) return;
            life = true;
            scene.EntitySpawned(this);
            OnSpawn();
        }

        protected void OnSpawn()
        {

        }

        public void Destroy()
        {
            if (!life) return;
            life = false;
            scene.EntityDestroyed(this);
            OnDestroy();
        }

        protected virtual void OnDestroy()
        {

        }
    }
}
