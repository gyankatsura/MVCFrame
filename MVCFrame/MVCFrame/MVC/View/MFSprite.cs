using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace MVCFrame.MVC.View
{
    class MFSprite
    {
        public MFLayer layer { get; protected set; }
        public virtual void OnAdded(MFLayer layer)
        {
            this.layer = layer;
        }

        public virtual void OnRemoved()
        {

        }

        public virtual void Draw()
        {

        }
    }
}
