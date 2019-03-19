using System;

namespace Decoder
{
    public class Print
    {
        public static void PrintPoint(IPoint point)
        {
            System.Console.WriteLine("Point is: x={0}, y={1}, z={2}", point.x, point.y, point.z);
        }

        public static void PrintAirplane(Airplane airplane)
        {
            System.Console.WriteLine("Airplane: Tag: {0} // X-coordinate: {1} // Y-coordinate: {2} // Altitude: {3} // Timestamp: {4}", 
                airplane.Tag, airplane.X_coordinate, airplane.Y_coordinate, airplane.Altitude, airplane.Timestamp);
        }

        public static void PrintWithinAirspace(Airplane airplane, Airspace airspace)
        {
            if(airspace.WithInAirspace(airplane))
            {
                System.Console.WriteLine("Airplane: {0} is 'IN' within airspace!", airplane.Tag);
            } else {
                System.Console.WriteLine("Airplane: {0} is 'NOT' within airspace!", airplane.Tag);
            }
        }

        public static void PrintAirplaneDirection(Airplane airplane, Calculator calculator, Airspace airspace)
        {
            if(airspace.WithInAirspace(airplane))
            {
                System.Console.WriteLine("Airplane: {0} is flying in direction: {1}", airplane.Tag, calculator.GetDirection(airplane));
            }
        }
    } 
}