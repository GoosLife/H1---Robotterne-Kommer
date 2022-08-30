using System;
using System.Collections.Generic;

namespace H1___Robotterne_Kommer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Robot r1 = new Robot(100, Microchip.RX54667, "CleaningRobot", Size.Small, 4); // This robot will lose its charge and its wheels, on account of
                                                                                          // being too small for wheels, and cleaning robots not being able
                                                                                          // to have batteries.

            Robot r2 = new Robot(255, Microchip.QT8339, "TireChangingRobot", Size.Medium, 4, true); // This robot will have all the values described in its
                                                                                                    // parameters, and will have the default white color.
                                                                                                    // It also has wifi.

            Robot r3 = new Robot("Red", Microchip.RX54667, "CleaningRobot", Size.Small, 8); // This robot will lose its wheels because it's too small to have
                                                                                            // wheels, but the default battery capacity of 0 is consistent with
                                                                                            // its type.

            Robot r4 = new Robot("Blue", Microchip.QT8339, "TireChangingRobot", Size.Large, 2147483647, false); // This robot uses the wifi parameter, but sets
                                                                                                                // it to false, which is also the default value.
                                                                                                                // So that's pretty pointless.

            // Save all these robots to array and output to console to see if everything is as expected.
            Robot[] robots = new Robot[4]
            {
                r1,
                r2,
                r3,
                r4
            };

            for (int i = 0; i < robots.Length; i++)
            {
                Console.WriteLine(robots[i]);
                Console.WriteLine(); // Add empty line between robots for readability.
            }

            Console.ReadKey();
        }
    }
}
