using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MVCFrame.MVC.Model;
using MVCFrame.MVC.View;

namespace MVCFrame.MVC.Control
{
    class MFControl
    {
        protected Dictionary<MFEntity, MFSprite> entitySpriteDict = new Dictionary<MFEntity, MFSprite>();

        protected virtual void OnUpdate()
        { }

        public void Update()
        {
            OnUpdate();
        }

        public void Init()
        {
            OnInit();
        }

        protected virtual void OnInit()
        {

        }
    }
}
