﻿using System;
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

        public List<string> ConditionDetected(List<Airplane> airplaneList)
        {
            List<string> con = new List<string>();
            for(int i=0; i < airplaneList.Count - 1; i++)
            {
                for(int j = i + 1; j < airplaneList.Count; j++)
                {
                    
                    if(airplaneList[i].X_coordinate + 5000 <= airplaneList[j].X_coordinate && airplaneList[i].Y_coordinate + 300 <= airplaneList[j].Y_coordinate)
                    {
                        con.Add(airplaneList[i].Tag);
                        con.Add(airplaneList[j].Tag);
                        con.Add(airplaneList[i].Timestamp.ToString());
                    }
                }
            }
            return con;
        }

        public void updateCondition(List<Airplane> airplaneList)
        {
            List<string> log = new List<string>();
            log.AddRange(ConditionDetected(airplaneList));
        }
    }
}
