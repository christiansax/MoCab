//////////////////////////////////////////////////////////////////////////////
//                              PhoneNumber                                 //
//      Author:     Christian B. Sax            Date:       04.01.2016      //
//      Project:    MoCap                       Reviewed:   <Name>          //
//      Component:  Config                      Owner:      SAXC            //
//      Description: Class defining the phone numbers                       //
//////////////////////////////////////////////////////////////////////////////

#region usings
#region Includes (Microsoft based)
//////////////////////////////////////////////
//      using includes here (Microsoft)     //
//////////////////////////////////////////////
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

namespace MoCap.Config
{
    #region Delegates are declared here

    #endregion

    #region Global variables are declared here

    #endregion

    #region Enum(-s) or type(-s) declaration here

    /// <summary>
    /// The phone number type enumeration specifying the different types of phone numbers
    /// </summary>
    public enum PhoneNumberType
    {
        LandLine,
        Mobile,
        HomePhone,
        OfficePhone,
        Fax,
        Pager,
        Unknown
    };

    #endregion

    /// <summary>
    /// This is the summary of the class
    /// </summary>
    public class PhoneNumber
    {
        #region Class members

        #region Events

        #endregion

        #region Properties

        /// <summary>
        /// Holds the international dialing prefix to be used. In order to comply with E.164 phone number standard the default is set to +
        /// </summary>
        public string InternationalDialingPrefix { get; set; } = "+";

        /// <summary>
        /// This property holds the international dialing code, which is defined on a per country basis
        /// Examples: 1 for USA, 41 for Switzerland etc.
        /// </summary>
        public int InternationalDialingCode{get; set;}

        /// <summary>
        /// Holds the area code use when dialing domesticly
        /// Examples: 555, 044 etc.
        /// </summary>
        public string LocalAreaCode { get; set; }

        /// <summary>
        /// Hold the local exchange / switch number. This is the number between the area code and the subscriber number. In rare cases this number starts with a 0
        /// Examples: 471, 378 etc.
        /// </summary>
        public string LocalExchangeNumber { get; set; }

        /// <summary>
        /// The subscriber number of the contact. In normalized number plans this is typically 4 digits. However, there are exceptions
        /// Example: 4115, 078885
        /// </summary>
        public string MultipleSubscriberNumber { get; set; }

        /// <summary>
        /// This is the standardized phone number format
        /// Example: +41 71 411 5135
        /// </summary>
        public string E164Number { get; set; }

        #endregion

        #region Private variables

        #endregion

        #endregion

        #region Methods

        #region Constructor(-s) & Destructor

        #endregion

        #region Private Methods

        #endregion

        #region Event handlers (methods)

        #endregion

        #region Public Methods

        /// <summary>
        /// Description of the method, what is it doing
        /// </summary>
        /// <param name="pMystring">String: Specifying the name of the object</param>
        /// <param name="pMyCount">Int: The number of objects to compare</param>
        /// <returns>object: The object which resulted from the query</returns>
        public object GetData(string pMystring, int pMyCount)
        {
            object a = new object();
            return (a);
        }

        #endregion

        #endregion

        #region Nested classes here (indentical structure here)

        #endregion
    }
}