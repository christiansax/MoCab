namespace Backend
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class MoCap_Model : DbContext
    {
        public MoCap_Model()
            : base("name=MoCap_Model")
        {
        }

        public virtual DbSet<_Country_Language> C_Country_Language { get; set; }
        public virtual DbSet<_PhoneNumber_Object> C_PhoneNumber_Object { get; set; }
        public virtual DbSet<Address> Address { get; set; }
        public virtual DbSet<AddressAppendix> AddressAppendix { get; set; }
        public virtual DbSet<City> City { get; set; }
        public virtual DbSet<Company> Company { get; set; }
        public virtual DbSet<Country> Country { get; set; }
        public virtual DbSet<GeoLocation> GeoLocation { get; set; }
        public virtual DbSet<Job> Job { get; set; }
        public virtual DbSet<Language> Language { get; set; }
        public virtual DbSet<PhoneNumber> PhoneNumber { get; set; }
        public virtual DbSet<Property> Property { get; set; }
        public virtual DbSet<Settings> Settings { get; set; }
        public virtual DbSet<State> State { get; set; }
        public virtual DbSet<Street> Street { get; set; }
        public virtual DbSet<StreetNumber> StreetNumber { get; set; }
        public virtual DbSet<Translation> Translation { get; set; }
        public virtual DbSet<Type> Type { get; set; }
        public virtual DbSet<WorkingScheme> WorkingScheme { get; set; }
        public virtual DbSet<__RefactorLog> C__RefactorLog { get; set; }
        public virtual DbSet<_Poll_Option> C_Poll_Option { get; set; }
        public virtual DbSet<_Task_Task> C_Task_Task { get; set; }
        public virtual DbSet<BinaryObject> BinaryObject { get; set; }
        public virtual DbSet<Chat> Chat { get; set; }
        public virtual DbSet<Interaction_BinaryObject> Interaction_BinaryObject { get; set; }
        public virtual DbSet<Message> Message { get; set; }
        public virtual DbSet<Poll> Poll { get; set; }
        public virtual DbSet<PollOption> PollOption { get; set; }
        public virtual DbSet<Project> Project { get; set; }
        public virtual DbSet<Task> Task { get; set; }
        public virtual DbSet<Timeslice> Timeslice { get; set; }
        public virtual DbSet<_User_Document_Acceptance> C_User_Document_Acceptance { get; set; }
        public virtual DbSet<Document> Document { get; set; }
        public virtual DbSet<VersionDescription> VersionDescription { get; set; }
        public virtual DbSet<VersionInfo> VersionInfo { get; set; }
        public virtual DbSet<_Directory_User> C_Directory_User { get; set; }
        public virtual DbSet<_GeoLocation_User> C_GeoLocation_User { get; set; }
        public virtual DbSet<_User_Chat> C_User_Chat { get; set; }
        public virtual DbSet<_User_Contact> C_User_Contact { get; set; }
        public virtual DbSet<_User_Message> C_User_Message { get; set; }
        public virtual DbSet<_User_Poll_Option> C_User_Poll_Option { get; set; }
        public virtual DbSet<_User_Project> C_User_Project { get; set; }
        public virtual DbSet<_User_User> C_User_User { get; set; }
        public virtual DbSet<Contact> Contact { get; set; }
        public virtual DbSet<Directory> Directory { get; set; }
        public virtual DbSet<User> User { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<_Country_Language>()
                .Property(e => e.CreatedDateTime)
                .HasPrecision(3);

            modelBuilder.Entity<_Country_Language>()
                .Property(e => e.ModifiedDateTime)
                .HasPrecision(3);

            modelBuilder.Entity<_PhoneNumber_Object>()
                .Property(e => e.CreatedDateTime)
                .HasPrecision(3);

            modelBuilder.Entity<_PhoneNumber_Object>()
                .Property(e => e.ModifiedDateTime)
                .HasPrecision(3);

            modelBuilder.Entity<Address>()
                .Property(e => e.CreatedDateTime)
                .HasPrecision(3);

            modelBuilder.Entity<Address>()
                .Property(e => e.ModifiedDateTime)
                .HasPrecision(3);

            modelBuilder.Entity<Address>()
                .HasMany(e => e.User)
                .WithRequired(e => e.Address)
                .HasForeignKey(e => e.HomeAddressId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Address>()
                .HasMany(e => e.User1)
                .WithOptional(e => e.Address1)
                .HasForeignKey(e => e.OfficeAddressId);

            modelBuilder.Entity<AddressAppendix>()
                .Property(e => e.CreatedDateTime)
                .HasPrecision(3);

            modelBuilder.Entity<AddressAppendix>()
                .Property(e => e.ModifiedDateTime)
                .HasPrecision(3);

            modelBuilder.Entity<City>()
                .Property(e => e.CreatedDateTime)
                .HasPrecision(3);

            modelBuilder.Entity<City>()
                .Property(e => e.ModifiedDateTime)
                .HasPrecision(3);

            modelBuilder.Entity<City>()
                .HasMany(e => e.Address)
                .WithRequired(e => e.City)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Company>()
                .Property(e => e.CreatedDateTime)
                .HasPrecision(3);

            modelBuilder.Entity<Company>()
                .Property(e => e.ModifiedDateTime)
                .HasPrecision(3);

            modelBuilder.Entity<Country>()
                .Property(e => e.CreatedDateTime)
                .HasPrecision(3);

            modelBuilder.Entity<Country>()
                .Property(e => e.ModifiedDateTime)
                .HasPrecision(3);

            modelBuilder.Entity<Country>()
                .HasMany(e => e.C_Country_Language)
                .WithRequired(e => e.Country)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Country>()
                .HasMany(e => e.Address)
                .WithRequired(e => e.Country)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<GeoLocation>()
                .Property(e => e.CreatedDateTime)
                .HasPrecision(3);

            modelBuilder.Entity<GeoLocation>()
                .Property(e => e.ModifiedDateTime)
                .HasPrecision(3);

            modelBuilder.Entity<GeoLocation>()
                .HasMany(e => e.C_GeoLocation_User)
                .WithRequired(e => e.GeoLocation)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Job>()
                .Property(e => e.CreatedDateTime)
                .HasPrecision(3);

            modelBuilder.Entity<Job>()
                .Property(e => e.ModifiedDateTime)
                .HasPrecision(3);

            modelBuilder.Entity<Language>()
                .Property(e => e.CreatedDateTime)
                .HasPrecision(3);

            modelBuilder.Entity<Language>()
                .Property(e => e.ModifiedDateTime)
                .HasPrecision(3);

            modelBuilder.Entity<Language>()
                .HasMany(e => e.C_Country_Language)
                .WithRequired(e => e.Language)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Language>()
                .HasMany(e => e.Property)
                .WithRequired(e => e.Language)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Language>()
                .HasMany(e => e.Translation)
                .WithRequired(e => e.Language)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PhoneNumber>()
                .Property(e => e.CreatedDateTime)
                .HasPrecision(3);

            modelBuilder.Entity<PhoneNumber>()
                .Property(e => e.ModifiedDateTime)
                .HasPrecision(3);

            modelBuilder.Entity<PhoneNumber>()
                .HasMany(e => e.C_PhoneNumber_Object)
                .WithRequired(e => e.PhoneNumber)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Property>()
                .Property(e => e.ValueNum1)
                .HasPrecision(18, 4);

            modelBuilder.Entity<Property>()
                .Property(e => e.ValueNum2)
                .HasPrecision(18, 4);

            modelBuilder.Entity<Property>()
                .Property(e => e.ValueNum3)
                .HasPrecision(18, 4);

            modelBuilder.Entity<Property>()
                .Property(e => e.CreatedDateTime)
                .HasPrecision(3);

            modelBuilder.Entity<Property>()
                .Property(e => e.ModifiedDateTime)
                .HasPrecision(3);

            modelBuilder.Entity<Property>()
                .HasMany(e => e.PhoneNumber)
                .WithRequired(e => e.Property)
                .HasForeignKey(e => e.PhoneTypeId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Settings>()
                .Property(e => e.NumericValue)
                .HasPrecision(18, 3);

            modelBuilder.Entity<Settings>()
                .Property(e => e.DateTimeValue)
                .HasPrecision(3);

            modelBuilder.Entity<Settings>()
                .Property(e => e.CreatedDateTime)
                .HasPrecision(3);

            modelBuilder.Entity<Settings>()
                .Property(e => e.ModifiedDateTime)
                .HasPrecision(3);

            modelBuilder.Entity<State>()
                .Property(e => e.CreatedDateTime)
                .HasPrecision(3);

            modelBuilder.Entity<State>()
                .Property(e => e.ModifiedDateTime)
                .HasPrecision(3);

            modelBuilder.Entity<Street>()
                .Property(e => e.CreatedDateTime)
                .HasPrecision(3);

            modelBuilder.Entity<Street>()
                .Property(e => e.ModifiedDateTime)
                .HasPrecision(3);

            modelBuilder.Entity<Street>()
                .HasMany(e => e.Address)
                .WithRequired(e => e.Street)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<StreetNumber>()
                .Property(e => e.CreatedDateTime)
                .HasPrecision(3);

            modelBuilder.Entity<StreetNumber>()
                .Property(e => e.ModifiedDateTime)
                .HasPrecision(3);

            modelBuilder.Entity<StreetNumber>()
                .HasMany(e => e.Address)
                .WithRequired(e => e.StreetNumber)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Translation>()
                .Property(e => e.CreatedDateTime)
                .HasPrecision(3);

            modelBuilder.Entity<Translation>()
                .Property(e => e.ModifiedDateTime)
                .HasPrecision(3);

            modelBuilder.Entity<Type>()
                .Property(e => e.CreatedDateTime)
                .HasPrecision(3);

            modelBuilder.Entity<Type>()
                .Property(e => e.ModifiedDateTime)
                .HasPrecision(3);

            modelBuilder.Entity<Type>()
                .HasMany(e => e.Address)
                .WithRequired(e => e.Type)
                .HasForeignKey(e => e.AddressTypeId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Type>()
                .HasMany(e => e.Property)
                .WithRequired(e => e.Type)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Type>()
                .HasMany(e => e.Translation)
                .WithRequired(e => e.Type)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Type>()
                .HasMany(e => e.BinaryObject)
                .WithRequired(e => e.Type)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Type>()
                .HasMany(e => e.Document)
                .WithRequired(e => e.Type)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Type>()
                .HasMany(e => e.VersionInfo)
                .WithRequired(e => e.Type)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<WorkingScheme>()
                .Property(e => e.PaidLeaveDays)
                .HasPrecision(5, 2);

            modelBuilder.Entity<WorkingScheme>()
                .Property(e => e.CreatedDateTime)
                .HasPrecision(3);

            modelBuilder.Entity<WorkingScheme>()
                .Property(e => e.ModifiedDateTime)
                .HasPrecision(3);

            modelBuilder.Entity<_Poll_Option>()
                .Property(e => e.CreatedDateTime)
                .HasPrecision(3);

            modelBuilder.Entity<_Poll_Option>()
                .Property(e => e.ModifiedDateTime)
                .HasPrecision(3);

            modelBuilder.Entity<_Task_Task>()
                .Property(e => e.CreatedDateTime)
                .HasPrecision(3);

            modelBuilder.Entity<_Task_Task>()
                .Property(e => e.ModifiedDateTime)
                .HasPrecision(3);

            modelBuilder.Entity<BinaryObject>()
                .Property(e => e.CreatedDateTime)
                .HasPrecision(3);

            modelBuilder.Entity<BinaryObject>()
                .Property(e => e.ModifiedDateTime)
                .HasPrecision(3);

            modelBuilder.Entity<BinaryObject>()
                .HasMany(e => e.Interaction_BinaryObject)
                .WithRequired(e => e.BinaryObject)
                .HasForeignKey(e => e.BinaryId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Chat>()
                .Property(e => e.StartDateTime)
                .HasPrecision(3);

            modelBuilder.Entity<Chat>()
                .Property(e => e.EndDateTime)
                .HasPrecision(3);

            modelBuilder.Entity<Chat>()
                .Property(e => e.CreatedDateTime)
                .HasPrecision(3);

            modelBuilder.Entity<Chat>()
                .Property(e => e.ModifedDateTime)
                .HasPrecision(3);

            modelBuilder.Entity<Chat>()
                .HasMany(e => e.C_User_Chat)
                .WithRequired(e => e.Chat)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Interaction_BinaryObject>()
                .Property(e => e.CreatedDateTime)
                .HasPrecision(3);

            modelBuilder.Entity<Interaction_BinaryObject>()
                .Property(e => e.ModifiedDateTime)
                .HasPrecision(3);

            modelBuilder.Entity<Message>()
                .Property(e => e.DateTimeOfDeath)
                .HasPrecision(3);

            modelBuilder.Entity<Message>()
                .Property(e => e.SentDateTime)
                .HasPrecision(3);

            modelBuilder.Entity<Message>()
                .Property(e => e.CreatedDateTime)
                .HasPrecision(3);

            modelBuilder.Entity<Message>()
                .Property(e => e.ModifedDateTime)
                .HasPrecision(3);

            modelBuilder.Entity<Message>()
                .HasMany(e => e.C_User_Message)
                .WithRequired(e => e.Message)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Poll>()
                .Property(e => e.StartDateTime)
                .HasPrecision(3);

            modelBuilder.Entity<Poll>()
                .Property(e => e.EndDateTime)
                .HasPrecision(3);

            modelBuilder.Entity<Poll>()
                .Property(e => e.DueDateTime)
                .HasPrecision(3);

            modelBuilder.Entity<Poll>()
                .Property(e => e.CreatedDateTime)
                .HasPrecision(3);

            modelBuilder.Entity<Poll>()
                .Property(e => e.ModifiedDateTime)
                .HasPrecision(3);

            modelBuilder.Entity<Poll>()
                .HasMany(e => e.C_Poll_Option)
                .WithRequired(e => e.Poll)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Poll>()
                .HasMany(e => e.C_User_Poll_Option)
                .WithRequired(e => e.Poll)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PollOption>()
                .Property(e => e.CreatedDateTime)
                .HasPrecision(3);

            modelBuilder.Entity<PollOption>()
                .Property(e => e.ModifiedDateTime)
                .HasPrecision(3);

            modelBuilder.Entity<PollOption>()
                .HasMany(e => e.C_Poll_Option)
                .WithRequired(e => e.PollOption)
                .HasForeignKey(e => e.OptionId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PollOption>()
                .HasMany(e => e.C_User_Poll_Option)
                .WithRequired(e => e.PollOption)
                .HasForeignKey(e => e.OptionId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Project>()
                .Property(e => e.StartDateTime)
                .HasPrecision(3);

            modelBuilder.Entity<Project>()
                .Property(e => e.EndDateTime)
                .HasPrecision(3);

            modelBuilder.Entity<Project>()
                .Property(e => e.DueDateTime)
                .HasPrecision(3);

            modelBuilder.Entity<Project>()
                .Property(e => e.Progress)
                .HasPrecision(5, 2);

            modelBuilder.Entity<Project>()
                .Property(e => e.CreatedDateTime)
                .HasPrecision(3);

            modelBuilder.Entity<Project>()
                .Property(e => e.ModifiedDateTime)
                .HasPrecision(3);

            modelBuilder.Entity<Project>()
                .HasMany(e => e.C_User_Project)
                .WithRequired(e => e.Project)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Task>()
                .Property(e => e.StartDateTime)
                .HasPrecision(3);

            modelBuilder.Entity<Task>()
                .Property(e => e.EndDateTime)
                .HasPrecision(3);

            modelBuilder.Entity<Task>()
                .Property(e => e.DueDateTime)
                .HasPrecision(3);

            modelBuilder.Entity<Task>()
                .Property(e => e.Duration)
                .HasPrecision(12, 2);

            modelBuilder.Entity<Task>()
                .Property(e => e.Progress)
                .HasPrecision(5, 2);

            modelBuilder.Entity<Task>()
                .Property(e => e.CreatedDateTime)
                .HasPrecision(3);

            modelBuilder.Entity<Task>()
                .Property(e => e.ModifiedDateTime)
                .HasPrecision(3);

            modelBuilder.Entity<Task>()
                .HasMany(e => e.C_Task_Task)
                .WithRequired(e => e.Task)
                .HasForeignKey(e => e.ParentTaskId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Task>()
                .HasMany(e => e.C_Task_Task1)
                .WithRequired(e => e.Task1)
                .HasForeignKey(e => e.SubTaskId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Timeslice>()
                .Property(e => e.CreatedDateTime)
                .HasPrecision(3);

            modelBuilder.Entity<Timeslice>()
                .Property(e => e.ModifiedDateTime)
                .HasPrecision(3);

            modelBuilder.Entity<_User_Document_Acceptance>()
                .Property(e => e.AcceptanceDateTime)
                .HasPrecision(3);

            modelBuilder.Entity<_User_Document_Acceptance>()
                .Property(e => e.CreatedDateTime)
                .HasPrecision(3);

            modelBuilder.Entity<_User_Document_Acceptance>()
                .Property(e => e.ModifiedDateTime)
                .HasPrecision(3);

            modelBuilder.Entity<Document>()
                .Property(e => e.ActivationDateTime)
                .HasPrecision(3);

            modelBuilder.Entity<Document>()
                .Property(e => e.CreatedDateTime)
                .HasPrecision(3);

            modelBuilder.Entity<Document>()
                .Property(e => e.ModifiedDateTime)
                .HasPrecision(3);

            modelBuilder.Entity<Document>()
                .HasMany(e => e.C_User_Document_Acceptance)
                .WithRequired(e => e.Document)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<VersionDescription>()
                .Property(e => e.CreatedDateTime)
                .HasPrecision(3);

            modelBuilder.Entity<VersionDescription>()
                .Property(e => e.ModifiedDateTime)
                .HasPrecision(3);

            modelBuilder.Entity<VersionInfo>()
                .Property(e => e.CreatedDateTime)
                .HasPrecision(3);

            modelBuilder.Entity<VersionInfo>()
                .Property(e => e.ModifiedDateTime)
                .HasPrecision(3);

            modelBuilder.Entity<VersionInfo>()
                .HasMany(e => e.VersionDescription)
                .WithRequired(e => e.VersionInfo)
                .HasForeignKey(e => e.ObjectId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<_Directory_User>()
                .Property(e => e.CreatedDateTime)
                .HasPrecision(3);

            modelBuilder.Entity<_Directory_User>()
                .Property(e => e.ModifiedDateTime)
                .HasPrecision(3);

            modelBuilder.Entity<_GeoLocation_User>()
                .Property(e => e.CreatedDateTime)
                .HasPrecision(3);

            modelBuilder.Entity<_GeoLocation_User>()
                .Property(e => e.ModifiedDateTime)
                .HasPrecision(3);

            modelBuilder.Entity<_User_Chat>()
                .Property(e => e.CreatedDateTime)
                .HasPrecision(3);

            modelBuilder.Entity<_User_Chat>()
                .Property(e => e.ModifedDateTime)
                .HasPrecision(3);

            modelBuilder.Entity<_User_Contact>()
                .Property(e => e.CreatedDateTime)
                .HasPrecision(3);

            modelBuilder.Entity<_User_Contact>()
                .Property(e => e.ModifiedDateTime)
                .HasPrecision(3);

            modelBuilder.Entity<_User_Message>()
                .Property(e => e.ReceivedDateTime)
                .HasPrecision(3);

            modelBuilder.Entity<_User_Message>()
                .Property(e => e.ReadDateTime)
                .HasPrecision(3);

            modelBuilder.Entity<_User_Message>()
                .Property(e => e.CreatedDateTime)
                .HasPrecision(3);

            modelBuilder.Entity<_User_Message>()
                .Property(e => e.ModifiedDateTime)
                .HasPrecision(3);

            modelBuilder.Entity<_User_Poll_Option>()
                .Property(e => e.CreatedDateTime)
                .HasPrecision(3);

            modelBuilder.Entity<_User_Poll_Option>()
                .Property(e => e.ModifiedDateTime)
                .HasPrecision(3);

            modelBuilder.Entity<_User_Poll_Option>()
                .HasMany(e => e.Interaction_BinaryObject)
                .WithOptional(e => e.C_User_Poll_Option)
                .HasForeignKey(e => e.VoteId);

            modelBuilder.Entity<_User_Project>()
                .Property(e => e.CreatedDateTime)
                .HasPrecision(3);

            modelBuilder.Entity<_User_Project>()
                .Property(e => e.ModifiedDateTime)
                .HasPrecision(3);

            modelBuilder.Entity<_User_User>()
                .Property(e => e.CreatedDateTime)
                .HasPrecision(3);

            modelBuilder.Entity<_User_User>()
                .Property(e => e.ModifiedDateTime)
                .HasPrecision(3);

            modelBuilder.Entity<Contact>()
                .Property(e => e.CreatedDateTime)
                .HasPrecision(3);

            modelBuilder.Entity<Contact>()
                .Property(e => e.ModifiedDateTime)
                .HasPrecision(3);

            modelBuilder.Entity<Contact>()
                .HasMany(e => e.C_User_Contact)
                .WithRequired(e => e.Contact)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Directory>()
                .Property(e => e.CreatedDateTime)
                .HasPrecision(3);

            modelBuilder.Entity<Directory>()
                .Property(e => e.ModifiedDateTime)
                .HasPrecision(3);

            modelBuilder.Entity<Directory>()
                .HasMany(e => e.C_Directory_User)
                .WithRequired(e => e.Directory)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Birthdate)
                .HasPrecision(3);

            modelBuilder.Entity<User>()
                .Property(e => e.CreatedDateTime)
                .HasPrecision(3);

            modelBuilder.Entity<User>()
                .Property(e => e.ModifiedDateTime)
                .HasPrecision(3);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Settings)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Message)
                .WithRequired(e => e.User)
                .HasForeignKey(e => e.SenderId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Project)
                .WithRequired(e => e.User)
                .HasForeignKey(e => e.OwnerId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Project1)
                .WithRequired(e => e.User1)
                .HasForeignKey(e => e.DeputyId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Task)
                .WithRequired(e => e.User)
                .HasForeignKey(e => e.CreatorId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Task1)
                .WithRequired(e => e.User1)
                .HasForeignKey(e => e.OwnerId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Timeslice)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.C_User_Document_Acceptance)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.C_Directory_User)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.C_GeoLocation_User)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.C_User_Chat)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.C_User_Contact)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.C_User_Message)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.C_User_Poll_Option)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.C_User_Project)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.C_User_User)
                .WithRequired(e => e.User)
                .HasForeignKey(e => e.DirectoryUserId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.C_User_User1)
                .WithRequired(e => e.User1)
                .HasForeignKey(e => e.UserId)
                .WillCascadeOnDelete(false);
        }
    }
}
