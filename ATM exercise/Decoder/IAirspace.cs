using System;
using System.Collections.Generic;
using System.Text;

namespace Decoder
{
    public interface IAirspace
    {
        bool WithInAirspace(Airplane airplane);
    }
}
