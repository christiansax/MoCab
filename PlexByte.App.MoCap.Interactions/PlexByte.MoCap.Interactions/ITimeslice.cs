//////////////////////////////////////////////////////////////
//                      Interface Timeslice                              
//      Author: Fabian Ochsner            Date:   2016/02/23
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public interface ITimeslice
{
    int Duration { get; }

    IUser User { get; }

    IInteraction Target { get; }

    int CalculateDuration(DateTime pStartDT, DateTime pEndDT);

}

