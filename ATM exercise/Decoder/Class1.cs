﻿using System;
using System.Globalization;
using TransponderReceiver;

namespace Decoder
{
    public class Decoder
    {
        private ITransponderReceiver receiver;

        public Decoder(ITransponderReceiver receiver)
        {
            this.receiver = receiver;
            this.receiver.TransponderDataReady += decodeReadyData;
        }

        private void decodeReadyData(object sender, RawTransponderDataEventArgs arg)
        {
            foreach (var data in arg.TransponderData)
            {
                string[] plane = data.Split(';');
                string tag = plane[0];
                int xCord = Int32.Parse(plane[1]);
                int yCord = Int32.Parse(plane[2]);
                int alti = Int32.Parse(plane[3]);
                string format = "yyyyMMddHHmmssfff";
                DateTime time = DateTime.ParseExact(plane[4], format, CultureInfo.InvariantCulture);
            }
        }
    }
}