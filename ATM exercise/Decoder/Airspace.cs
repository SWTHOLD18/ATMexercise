using System;

namespace Decoder
{
    public class Airspace
    {
        public Airplane airplane { get; set; }

        //Limit for start of Airspace with minium Height.
        IPoint pointMin = new Point(0, 0, 500);

        //Limit for end of Airspace with maxium Height.
        IPoint pointMax = new Point(80000, 80000, 20000);

        //Create Point for Airplane.
        public IPoint CreatePointForAirplane(Airplane airplane)
        {
            IPoint pointAirplane = new Point(
                airplane.X_coordinate,
                airplane.Y_coordinate,
                airplane.Altitude);

            return pointAirplane;
        }

        //Is Point within Airspace, return true if yes else false.
        public bool WithInAirspace(Airplane airplane)
        {
            var point = CreatePointForAirplane(airplane);

            if (point >= pointMin & point <= pointMax)
            {
                return true;

            } else {

                return false;
            }
        }
    } 
}