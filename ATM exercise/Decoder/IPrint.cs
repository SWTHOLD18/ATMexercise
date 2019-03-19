using System;

namespace Decoder
{
    //Simple interface for Points
    public interface IPrint
    {
        void PrintAirplaneWithSpeedAndDirection(Airplane airplane, ICalculator calculator, IAirspace Airspace);
    }
}