using System;
using System.Collections.Generic;
using System.Globalization;
using TransponderReceiver;

namespace Decoder
{
    public class Decoder
    {
        private ITransponderReceiver receiver;

        //List of Airplanes
        public List<Airplane> airplaneList = new List<Airplane>();
        public Calculator calc = new Calculator(null);
        public Print printer = new Print();
        public Airspace space = new Airspace();

        public Decoder(ITransponderReceiver receiver)
        {
            this.receiver = receiver;
            this.receiver.TransponderDataReady += DecodeReadyData;
        }

        private void DecodeReadyData(object sender, RawTransponderDataEventArgs arg)
        {
            airplaneList.Clear();
            foreach (var data in arg.TransponderData)
            {
                string[] plane = data.Split(';');
                string tag = plane[0];
                int xCord = Int32.Parse(plane[1]);
                int yCord = Int32.Parse(plane[2]);
                int alti = Int32.Parse(plane[3]);
                string format = "yyyyMMddHHmmssfff";
                DateTime time = DateTime.ParseExact(plane[4], format, CultureInfo.InvariantCulture);

                //Create new plane from decoder.
                Airplane airplane = new Airplane(tag, xCord, yCord, alti, time);

                //Add current Airplane to list of Airplanes.
                airplaneList.Add(airplane);

                printer.PrintAirplaneWithSpeedAndDirection(airplane, calc, space);
            }
            calc.NewPositions(airplaneList);
        }
    }
}
