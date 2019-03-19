using System;
using System.Collections.Generic;
using System.Text;

namespace Decoder
{
    public interface ICalculator
    {
        void NewPositions(List<Airplane> newAirplaneList);
        double GetDirection(Airplane newPosition);
        double CalculateSpeed(Airplane newPosition);
    }
}
