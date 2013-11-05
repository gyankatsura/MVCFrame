using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MVCFrame.MVC.Model
{
    class EntityArgs : EventArgs
    {
        public MFEntity entity;
    }

    class MFScene
    {
        public delegate void EntityEventHandler(object sender, EntityArgs args);
        public event EntityEventHandler OnEventEntitySpawned = delegate { };

        public delegate void EntityDestroyHandler(object sender, EntityArgs args);
        public event EntityEventHandler OnEventEntityDestroyed = delegate { };

        public void EntitySpawned(MFEntity entity)
        {
            EntityArgs args = new EntityArgs();
            args.entity = entity;
            OnEventEntitySpawned(this, args);
            OnEntitySpawned(entity);
        }

        protected void OnEntitySpawned(MFEntity entity)
        {

        }

        public void EntityDestroyed(MFEntity entity)
        {
            EntityArgs args = new EntityArgs();
            args.entity = entity;
            OnEventEntityDestroyed(this, args);
            OnEntityDestroyed(entity);
        }

        protected void OnEntityDestroyed(MFEntity entity)
        {

        }

        public void Init()
        {
            OnInit();
        }

        protected virtual void OnInit()
        {

        }

        public void Update()
        {
            OnUpdate();
        }

        protected virtual void OnUpdate()
        {

        }
    }
}
