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

            double angle = Math.Atan2(y,x);
           
            //to make direction go clockwise we want the second quadrant to be negatve rather than positive
            //we subtract PI to counteract Atan2's automatic +pi if x<0 and y>=0 and than subtract PI to make
            //the degrees go negative clockwise
            if(x < 0 && y>=0)
            {
               angle -= 2*Math.PI; 
            }
            
            /* 
            angle /= Math.PI / 4;
            int halfQuarter = Convert.ToInt32(angle);
            */

            //Convert angle to degrees
            var degrees = angle * 180/Math.PI;

            //subtract 90degrees to make north 0 and invert to make the clockwise negative into clockwise positive
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

            TimeSpan tdif = newAirplane.Timestamp - oldAirplane.Timestamp;
            var tdiff = (double) tdif.TotalSeconds;

            double distance = Math.Sqrt(Math.Pow(x_coordinate_difference, 2) + Math.Pow(y_coordinate_difference, 2));

            return distance/tdiff;
        }
    }
}
