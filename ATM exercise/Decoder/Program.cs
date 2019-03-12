using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decoder
{
    class Program
    {
        static void Main(string[] args)
        {
            Airplane airplane1 = new Airplane("ATR423", 39045, 12932, 14000, 20151006213456789);

            Airplane airplane2 = new Airplane("ATR423", 41452, 15006, 14000, 20151006213456999);

            List<Airplane> airplanesList = new List<Airplane>();

            airplanesList.Add(airplane1);

            airplanesList.Add(airplane2);

            Calculator testCalculator = new Calculator(airplanesList);

            Calculator.GetDirection(airplane1.X_coordinate, airplane1.Y_coordinate);

            Calculator.GetDirection(airplane2.X_coordinate, airplane2.Y_coordinate);

            Calculator.CalculateSpeed(airplane1);
        }
    }
}
