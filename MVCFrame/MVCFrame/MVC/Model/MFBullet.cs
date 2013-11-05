using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MVCFrame.MVC.Model
{
    class MFBullet : MFEntity
    {
        public MFBullet(MFScene scene)
            : base(scene)
        { }

        public MFVector speed;

        public void Move()
        {
            this.position.x += speed.x * Env.deltaTime;
            this.position.y += speed.y * Env.deltaTime;
        }
    }
}
