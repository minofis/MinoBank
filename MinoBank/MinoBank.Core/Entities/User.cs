namespace MinoBank.Core.Entities
{
    public class User
    {
        public User(Guid id, string firstName, string lastName, int age, string phoneNumber, string email, string passwordHash)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            PhoneNumber = phoneNumber;
            Email = email;
            PasswordHash = passwordHash;
        }
        public Guid Id { get; set; }
        public string LastName { get; private set; }
        public string FirstName { get; private set; }
        public int Age { get; private set; }
        public string PhoneNumber { get; set; }
        public string Email { get; private set; }
        public string PasswordHash { get; private set; }

        public static User Create(Guid id, string firstName, string lastName, int age, string phoneNumber, string email, string passwordHash)
        {
            return new User(id, firstName, lastName, age, phoneNumber, email, passwordHash);
        }
    }
}