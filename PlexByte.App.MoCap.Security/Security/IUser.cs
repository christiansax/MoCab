using System;

namespace MoCap.Security
{
    /// <summary>
    /// This enum defines possible user titles
    /// </summary>
    public enum ETitle { Mr, Ms, Mrs, Dr, Prof };

    /// <summary>
    /// This enum defines the user's sex
    /// </summary>
    public enum ESex { Male, Female };

    /// <summary>
    /// This interface defines the user object. It specifies properties, methods and events applicable to user objects
    /// </summary>
    interface IUser
    {
        string Name { get; set; }
        string FirstName { get; set; }
        string MiddleName { get; set; }
        string EmailAddress { get; set; }
        string PhoneNumberOffice { get; set; }
        string PhoneNumberHome { get; set; }
        string PhoneNumberMobile { get; set; }
        string JobTitle { get; set; }
        string JobRole { get; set; }
        string Department { get; set; }
        string CompanyName { get; set; }
        ETitle Title { get; set; }
        ESex Sex { get; set; }
        DateTime BirthDate { get; set; }

        event EventHandler<EventArgs> OnUserCreated;
        event EventHandler<EventArgs> OnUserDeleted;
        event EventHandler<EventArgs> OnUserUpdated;

        void UpdateUser(params Object[] pParameters);
    }
}
