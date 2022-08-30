using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H1___Robotterne_Kommer
{
    // A soap dispenser component to add to cleaning robots.
    internal class SoapDispenser : RobotComponent
    {
        private float capacity;
        public float Capacity 
        {
            get { return capacity; }
        }

        public SoapDispenser(string name) : base(name)
        {
            this.capacity = 2.3f;
        }
    }
}
