using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H1___Robotterne_Kommer
{
    // A robot component class, so that all robots can have a list of components that are relevant to the robot,
    // meaning that only cleaning robots will have soap dispensers, for example...
    internal class RobotComponent
    {
        private string name;
        public string Name 
        {
            get { return name; }
        }

        public RobotComponent(string name)
        {
            this.name = name;
        }
    }
}
