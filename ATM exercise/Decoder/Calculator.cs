using System;
using System.Collections.Generic;
using System.Text;

namespace Decoder
{
    public class Calculator
    {
        private List<Airplane> oldaAirplaneList;

        public Airplane Airplane { get; set; }
        
        public Calculator(List<Airplane> airplaneList)
        {
            if (oldaAirplaneList.Count == 0)
            {
                oldaAirplaneList = airplaneList;
            }            
        }

        public void newPosition(Airplane airplane)
        {
            Airplane = airplane;
        }

        //List of possible Directions, based on compass.
        public enum Direction
        {
            North = 0,
            South = 4,
            East = 2,
            West = 6,
            NortEast = 1,
            NorthWest = 7,
            SouthEast = 3,
            SouthWest = 5
        }

        public static Direction GetDirection(int x_coordinate, int y_coordinate)
        {
            //Get angle by two members tangent.
            double angle = Math.Atan2(x_coordinate, y_coordinate);

            //Fit angle to whole circle
            angle += Math.PI;
            angle /= Math.PI / 4;

            int halfQuarter = Convert.ToInt32(angle);

            //Fit to output 1 of 8 Direction from Enum
            halfQuarter %= 8;

            //Return the current direction from the 2 inputs.
            return (Direction)halfQuarter;
        }        

        public double CalculateSpeed(Airplane newAirplane)
        {
            Airplane oldAirplane = oldaAirplaneList.Find(a => a.Tag == newAirplane.Tag);
            double x_coordinate_difference = 0;
            double y_coordinate_difference = 0;



            if (newAirplane.X_coordinate > oldAirplane.X_coordinate)
            {
                x_coordinate_difference = newAirplane.X_coordinate - oldAirplane.X_coordinate;
            }
            else
            {
                x_coordinate_difference = oldAirplane.X_coordinate - newAirplane.X_coordinate;
            }

            if (newAirplane.Y_coordinate > oldAirplane.Y_coordinate)
            {
                y_coordinate_difference = newAirplane.Y_coordinate - oldAirplane.Y_coordinate;
            }
            else
            {
                y_coordinate_difference = oldAirplane.Y_coordinate - newAirplane.Y_coordinate;
            }

            DateTime timestampDifference = DateTime.Now.Subtract(oldAirplane.Timestamp - newAirplane.Timestamp);
            var timeDifference = timestampDifference.ToOADate();

            double distance = Math.Sqrt(Math.Pow(x_coordinate_difference, 2) + Math.Pow(y_coordinate_difference, 2));

            if (timeDifference < 0)
            {
                timeDifference = timeDifference * (-1);
            }

            return distance/timeDifference;
        }
    }
}
