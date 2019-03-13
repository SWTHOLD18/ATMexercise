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
            if (oldaAirplaneList == null)
            {
                oldaAirplaneList = airplaneList;
            }            
        }

        public void newPosition(Airplane airplane)
        {
            Airplane = airplane;
        }

       
        public double GetDirection(Airplane newAirplane)
        {
            Airplane oldAirplane = oldaAirplaneList.Find(a => a.Tag == newAirplane.Tag);

            var x = newAirplane.X_coordinate - oldAirplane.X_coordinate;
            var y = newAirplane.Y_coordinate - oldAirplane.Y_coordinate;

            double angle = Math.Atan2(x, y);
           
            //Fit angle to whole circle if x = - angle
            if(x <= 0)
            {
               angle -= Math.PI; 
            }
            
            /* 
            angle /= Math.PI / 4;
            int halfQuarter = Convert.ToInt32(angle);
            */

            //Convert angle to degrees
            var degrees = angle * 180/Math.PI;

            //Circle Clockwise North 0 -> 359 degress
            var result = (degrees - 90) * -1;

            //Return the current direction from the 2 inputs.
            return result;
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

            DateTime timestampDifference = DateTime.Now.Subtract(newAirplane.Timestamp - oldAirplane.Timestamp);
            var timeDifference = timestampDifference.ToOADate();

            double distance = Math.Sqrt(Math.Pow(x_coordinate_difference, 2) + Math.Pow(y_coordinate_difference, 2));

            return distance/timeDifference;
        }
    }
}
