//////////////////////////////////////////////////////////////
//                      Interface Timeslice                              
//      Author: Fabian Ochsner            Date:   2016/02/23
using System;
using PlexByte.MoCap.Security;

namespace PlexByte.MoCap.Interactions
{

    public interface ITimeslice
    {
        int Duration { get; }

        IUser User { get; }

        IInteraction Target { get; }

        int CalculateDuration(DateTime pStartDT, DateTime pEndDT);

    }

}