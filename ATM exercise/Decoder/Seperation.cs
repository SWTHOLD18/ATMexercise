using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decoder
{
    class Seperation
    {
        public Airplane Airplane { get; set; }
        public void newTrack(Airplane airplane)
        {
            Airplane = airplane;
        }

        public void checkWithOtherTracks(List<Airplane> airplaneList)
        {
            
            for(int i=0; i < airplaneList.Count; i++)
            {
                for(int j = i + 1; j < airplaneList.Count; j++)
                {
                    
                    if(airplaneList[i].X_coordinate + 5000 <= airplaneList[j].X_coordinate && airplaneList[i].Y_coordinate + 300 <= airplaneList[j].Y_coordinate)
                    {
                        var tag1 = airplaneList[i].Tag;
                        var tag2 = airplaneList[j].Tag;
                        var timestamp = airplaneList[i].Timestamp;
                    }
                }
            }
        }

        public void updateCondition()
        {

        }
    }
}
