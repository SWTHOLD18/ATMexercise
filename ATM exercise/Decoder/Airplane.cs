using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Airplane
    {
        public string Tag { get; set; } 

        public int X_coordinate  
        {
            get 
            {
                return X_coordinate;
            }

            set 
            {
                Pre_x_coordinate = X_coordinate;
                this.X_coordinate = value;
            }
        }

        public int Y_coordinate 
        {
            get
            {
                return Y_coordinate;
            }

            set 
            {
                Pre_y_coordinate = Y_coordinate;
                this.Y_coordinate = value;
            }
        }
        
        public int Pre_x_coordinate { get; set; }

        public int Pre_y_coordinate { get; set; }

        public int Altitude { get; set; }

        public DateTime Timestamp { get; set; }
    }
}
