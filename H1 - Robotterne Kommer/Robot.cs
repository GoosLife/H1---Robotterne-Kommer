using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H1___Robotterne_Kommer
{
    // This class and its constructors are an absolute mess, as per the assignment given. :)
    public enum Microchip
    {
        RX54667,
        QT8339
    }

    public enum Size
    {
        Small,
        Medium,
        Large
    }

    internal class Robot
    {
        private string color = "White";
        public string Color
        {
            get { return color; }
        }

        private Microchip microchip;
        public Microchip Microchip
        {
            get { return microchip; }
        }

        private bool wifi = false;
        public bool Wifi
        {
            get { return wifi; }
        }

        private byte batteryCapacity = 0;
        public byte BatteryCapacity
        {
            get { return batteryCapacity; }
        }

        private List<RobotComponent> components;
        public List<RobotComponent> Components
        {
            get { return components; }
        }

        private int wheels;
        public int Wheels
        {
            get { return wheels; }
        }

        private string type;
        public string Type
        {
            get { return type; }
        }

        private Size size;
        public Size Size
        {
            get { return size; }
        }

        /* THE THREE NEXT CONSTRUCTORS BELOW WILL ALWAYS BE HIT. */

        private Robot(Size size, int wheels)
        {
            this.size = size;

            this.wheels = this.size == Size.Small ? 0 : wheels; // If the size is Small, the robot always comes out with 0 wheels, regardless of input. Otherwise, give it as many wheels as indicated by the parameter.
                                                                // Not a very elegant solution, because it might ignore user-input.
                                                                // I've also arbitrarily chosen to ignore the wheels parameter. I could have chosen to ignore the size parameter, and just give the user a medium-sized
                                                                // robot with the correct amount of wheels. But either way, I'm ignoring whatever was sent in as parameters.
        }

        private Robot(string type, Size size, int wheels) : this(size, wheels)
        {
            this.type = type;
            this.components = new List<RobotComponent>();
            AddComponents();
        }

        // All constructors will end up here, meaning all robots will have a microchip, a type, a size and a number of wheels. Unless they're small, in which case they
        // won't have wheels. But we can't really check for that until we're further down the line.
        private Robot(Microchip microchip, string type, Size size, int wheels) : this(type, size, wheels)
        {
            this.microchip = microchip;
        }

        /* BELOW ARE THE 4 CONSTRUCTORS THAT CAN BE CALLED FROM OUTSIDE THE CLASS */

        // This constructor starts with a string value, implying a color is being set. Thus, the battery capacity will have the default value of 0
        // because color robots can't have batteries.
        public Robot(string color, Microchip microchip, string type, Size size, int wheels) : this(microchip, type, size, wheels)
        {
            this.color = color;
        }

        // This constructor also starts with a color, but ends with a boolean, to denote whether or not this robot needs wifi. The default value is false.
        // This calls the 
        public Robot(string color, Microchip microchip, string type, Size size, int wheels, bool wifi) : this(color, microchip, type, size, wheels)
        {
            this.wifi = wifi;
        }

        // This constructor starts with a byte value, implying a battery capacity is being set. Thus we know the color must be the default value of "White". If the constructor is also asking
        // for a cleaning robot, however, battery capacity will be reset to 0, because cleaning robots can't have batteries. Oh well. Learn to use your constructors properly, User.
        public Robot(byte batteryCapacity, Microchip microchip, string type, Size size, int wheels) : this(microchip, type, size, wheels)
        {
            this.batteryCapacity = this.type == "CleaningRobot" ? (byte)0 : batteryCapacity; // Cleaning robots can't have batteries, so if there is any battery capacity, remove it.
                                                                                             // Similar to above, this is a bad solution because it might ignore user input.
        }

        // This constructor also has a battery, but it also sets the wifi value, presumably to true, as setting it to false would only be setting it to what's
        // already the default value.
        public Robot(byte batteryCapacity, Microchip microchip, string type, Size size, int wheels, bool wifi) : this(batteryCapacity, microchip, type, size, wheels)
        {
            this.wifi = wifi;
        }

        // Add components to the robot based on its type.
        private void AddComponents()
        {
            switch (type)
            {
                case "CleaningRobot":
                    RobotComponent soapDispenser = new SoapDispenser("Soap Dispenser");
                    components.Add(soapDispenser);
                    break;
                default:
                    break;
            }
        }

        // Outputs all data about the robot
        public override string ToString()
        {
            string result = "Color: " + Color + '\n' +
                            "Size: " + Size.ToString() + '\n' +
                            "Type: " + Type + '\n' +
                            "Microchip: " + Microchip + '\n' +
                            "Wifi: " + Wifi + '\n' + 
                            "Battery capacity: " + BatteryCapacity + '\n' +
                            "Wheels: " + Wheels + '\n';

            if (Components.Count > 0)
            {
                result +=   "Components:\n";

                foreach (RobotComponent c in Components)
                {
                    result += "  " + c.Name + '\n';
                }
            }

            return result;
        }
    }
}
