using System;
using System.Configuration;

namespace MoCap.Security
{
    public interface IPerson
    {
        [ConfigurationProperty("FirstName", DefaultValue = "", IsRequired = true)]
        [StringValidator(InvalidCharacters = "~!@#$%^&*()[]{}/;'\"|\\", MinLength = 2, MaxLength = 250)]
        string FirstName { get; set; }
        [ConfigurationProperty("MiddleName", DefaultValue = "", IsRequired = false)]
        [StringValidator(InvalidCharacters = "~!@#$%^&*()[]{}/;'\"|\\", MinLength = 2, MaxLength = 250)]
        string MiddleName { get; set; }
        [ConfigurationProperty("LastName", DefaultValue = "", IsRequired = true)]
        [StringValidator(InvalidCharacters = "~!@#$%^&*()[]{}/;'\"|\\", MinLength = 2, MaxLength = 250)]
        string LastName { get; set; }
        [ConfigurationProperty("IsActive", DefaultValue = "", IsRequired = true)]
        bool IsActive { get; set; }
        [ConfigurationProperty("EmailAddress", DefaultValue = "", IsRequired = false)]
        [StringValidator(InvalidCharacters = "~!#$%^&*()[]{}/;'\"|\\", MinLength = 2, MaxLength = 250)]
        string EmailAddress { get; set; }
        [ConfigurationProperty("Created", DefaultValue = "", IsRequired = true)]
        DateTime Created { get; set; }
        [ConfigurationProperty("Modified", DefaultValue = "", IsRequired = true)]
        DateTime Modified { get; set; }
    }
}
