//////////////////////////////////////////////////////////////
//                      Class Timeslice                              
//      Author: Fabian Ochsner            Date:   2016/02/23
//      Implementation of ITimeslice interface, handles the time spent on a Task or Project
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Timeslice : ITimeslice
{
    #region Properties

    /// <summary>
    /// The unique id of the timeslice
    /// </summary>
    public string Id { get; private set; }
    /// <summary>
    /// The worktime of the user
    /// </summary>
    public int Duration { get; private set; }
    /// <summary>
    /// Owner of the time in the timeslice
    /// </summary>
    public IUser User { get; private set; }
    /// <summary>
    /// The target to which a timeslice is connected
    /// </summary>
    public IInteraction Target { get; private set; }

    #endregion

    #region Ctor & Dtor

    /// <summary>
    /// Constructor of the class
    /// </summary>
    /// <param name="pId"></param>
    /// <param name="pUser"></param>
    /// <param name="pDuration"></param>
    public Timeslice(string pId, IUser pUser, int pDuration, IInteraction pTarget)
    {
        InitializeProperties(pId, pUser, pDuration, pTarget);
    }

    /// <summary>
    /// Constructor of the class
    /// </summary>
    /// <param name="pId"></param>
    /// <param name="pUser"></param>
    /// <param name="pStartDT"></param>
    /// <param name="pEndDT"></param>
    public Timeslice(string pId, IUser pUser, DateTime pStartDT, DateTime pEndDT, IInteraction pTarget)
    {
        int pDuration = CalculateDuration(pStartDT, pEndDT);
        InitializeProperties(pId, pUser, pDuration, pTarget);
    }

    #endregion

    #region Public methods

    /// <summary>
    /// Calculates the duration between the start and end of a worksession
    /// </summary>
    /// <param name="pStartDT"></param>
    /// <param name="pEndDT"></param>
    /// <returns>int duration in Minutes</returns>
	public virtual int CalculateDuration(DateTime pStartDT, DateTime pEndDT)
    {
        TimeSpan timespan = pStartDT - pEndDT;
        return int.Parse(timespan.Minutes.ToString());
    }

    #endregion

    #region Private methods

    /// <summary>
    /// Initializes all attributes
    /// </summary>
    /// <param name="pId"></param>
    /// <param name="pUser"></param>
    /// <param name="pDuration"></param>
    private void InitializeProperties(string pId, IUser pUser, int pDuration, IInteraction pTarget)
    {
        Id = pId;
        User = pUser;
        Duration = pDuration;
        Target = pTarget;
    }

    #endregion
}

