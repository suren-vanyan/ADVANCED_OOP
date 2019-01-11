using System;
using System.Collections.Generic;
using System.Text;

namespace Obsolete
{
    [Serializable]
    [VehicleDescription(Description = "Му rocking Harley")]
    class Motorcycle
    {
        [NonSerialized]
        float weightOfCurrentPassengers;
      
        bool hasRadioSystem;
        bool hasHeadSet;
        bool hasSissyBar;
    }
}
