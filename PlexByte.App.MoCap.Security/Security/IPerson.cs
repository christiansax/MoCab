//////////////////////////////////////////////////////////////////////////////
//                            IPerson                                       //
//      Author:     Christian B. Sax            Date:       04.01.2016      //
//      Project:    MoCap                       Reviewed:   <Name>          //
//      Component:  Security                    Owner:      CSAX            //
//      Description: This interface defines a person, which can be either   //
//                   a contact or user. The user is a registered person     //
//                   where a contact has no login yet                       //
//////////////////////////////////////////////////////////////////////////////

#region usings
#region Includes (Microsoft based)
//////////////////////////////////////////////
//      using includes here (Microsoft)     //
//////////////////////////////////////////////
using System;
#endregion

#region Includes (3rd parties)
//////////////////////////////////////////////
//      using includes here (3rd parties)   //
//////////////////////////////////////////////
#endregion

#region Includes (MoCap based)
//////////////////////////////////////////////
//      using includes here (MoCap)         //
//////////////////////////////////////////////
#endregion
#endregion

namespace MoCap.Security
{
    #region Delegates are declared here

    #endregion

    #region Global variables are declared here

    #endregion

    #region Enum(-s) or type(-s) declaration here

    /// <summary>
    /// The gender enumeration, which is either male or female
    /// </summary>
    public enum Gender
    {
        Male,
        Female
    };

    #endregion

    /// <summary>
    /// This interface defines a person, which can be either a user or contact. 
    /// The contact is a person that has registered with MoCap solution, where the contact has not yet
    /// </summary>
    public interface IPerson
    {
        #region Class members

        #region Events

        #endregion

        #region Properties

        /// <summary>
        /// The fist name of this person
        /// </summary>
        string FirstName{get; set;}

        /// <summary>
        /// The middle name of this person
        /// </summary>
        string MiddleName { get; set; }

        /// <summary>
        /// The last name of this person
        /// </summary>
        string LastName { get; set; }

        /// <summary>
        /// The email address of this person
        /// </summary>
        string EmailAddress { get; set; }

        /// <summary>
        /// The date of birth of this person
        /// </summary>
        DateTime DateOfBirth { get; set; }

        /// <summary>
        /// The sex / gender of this person
        /// </summary>
        Gender Sex { get; set; }

        /// <summary>
        /// The sex / gender of this person
        /// </summary>
        bool IsActive { get; set; }

        #endregion

        #endregion

        #region Methods

        #region Event handlers (methods)

        #endregion

        #region Public Methods

        #endregion

        #endregion
    }
}