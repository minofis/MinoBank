namespace MinoBank.Core.Entities
{
    public class UserEntity
    {
        public UserEntity(Guid id, string firstName, string lastName, string fullName, int age, string phoneNumber, string email, string passwordHash)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            FullName = fullName;
            Age = age;
            PhoneNumber = phoneNumber;
            Email = email;
            PasswordHash = passwordHash;
        }
        public Guid Id { get; set; }
        public string LastName { get; private set; }
        public string FirstName { get; private set; }
        public string FullName { get; private set; }
        public int Age { get; private set; }
        public string PasswordHash { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public static UserEntity Create(Guid id, string firstName, string lastName, int age, string phoneNumber, string email, string passwordHash)
        {
            string fullName = $"{firstName + " " + lastName}";
            return new UserEntity(id, firstName, lastName, fullName, age, phoneNumber, email, passwordHash);
        }
    }
}