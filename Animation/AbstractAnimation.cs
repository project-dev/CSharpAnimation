using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Animation
{
    abstract class AbstractAnimation
    {
        public AbstractAnimation(System.Windows.Forms.Form owner, String name)
        {
            this.Owner = owner;
            this.Name = name;
        }

        public System.Windows.Forms.Form Owner
        {
            get;
            private set;
        }

        public string Name { get; protected set; }

        public abstract void Initalize();


        public abstract void OnDraw(Graphics g);

        public override string ToString()
        {
            return this.Name;
        }
    }
}
