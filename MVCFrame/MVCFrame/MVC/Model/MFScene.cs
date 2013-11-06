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
        //Entity Events
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

        protected virtual void OnEntitySpawned(MFEntity entity)
        {

        }

        public void EntityDestroyed(MFEntity entity)
        {
            EntityArgs args = new EntityArgs();
            args.entity = entity;
            OnEventEntityDestroyed(this, args);
            OnEntityDestroyed(entity);
        }

        protected virtual void OnEntityDestroyed(MFEntity entity)
        {

        }

        //Scene Management
        private static List<MFScene> sSceneList = new List<MFScene>();
        protected MFScene() { }

        public static T GetScene<T>() where T : MFScene
        {
            foreach (MFScene s in sSceneList)
                if (s is T) return s as T;
            return null;
        }

        public static bool CreateScene<T>() where T : MFScene, new()
        {
            foreach (MFScene s in sSceneList)
                if (s is T) return false;
            T scene = new T();
            sSceneList.Add(scene);
            return true;
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
