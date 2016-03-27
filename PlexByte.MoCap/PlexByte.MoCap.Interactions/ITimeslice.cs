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

        string Description { get; set; }

        IUser User { get; }

        IInteraction Target { get; }

        DateTime CreatedDateTime{ get; set; }

        DateTime ModifiedDateTime { get; set; }

        int CalculateDuration(DateTime pStartDT, DateTime pEndDT);

    }

}