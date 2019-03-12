using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decoder
{
    class Program
    {
        static void Main(string[] args)
        {
            string format = "yyyyMMddHHmmssfff";

            DateTime time1 = DateTime.ParseExact("20151006213456001", format, CultureInfo.InvariantCulture);
            Airplane airplane1 = new Airplane("ATR423", 10000, 10000, 14000, time1);

            DateTime time2 = DateTime.ParseExact("20151022215556001", format, CultureInfo.InvariantCulture);
            Airplane airplane2 = new Airplane("ATR423", 40000, 40000, 14000, time2);

            List<Airplane> airplanesList = new List<Airplane>();

            airplanesList.Add(airplane1);

            airplanesList.Add(airplane2);

            Calculator testCalculator = new Calculator(airplanesList);

            Console.WriteLine(testCalculator.GetDirection(airplane2));

            //Console.WriteLine(testCalculator.GetDirection(airplane2.X_coordinate, airplane2.Y_coordinate));


            Console.WriteLine(testCalculator.CalculateSpeed(airplane2));
            

            
        }
    }
}
