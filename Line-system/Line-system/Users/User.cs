using System;

namespace Line_system.Users
{
    public class User : IUser, IComparable<User>
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public decimal Balance { get; set; }


        public User(int id, string firstName, string lastName, string username, decimal balance, string email)
        {
            ID = id;
            FirstName = firstName;
            LastName = lastName;
            Username = username;
            Balance = balance;
            Email = email;
        }
        
        public override string ToString()
        {
            return $"{FirstName} {LastName} {Email}";
        }

        public int CompareTo(User otherUser)
        {
            return this.ID - otherUser.ID;
        }

        public override bool Equals(object? obj)
        {
            if (obj is User)
            {
                User otherUser = (User)obj;
                // As Id is uniques for each user, this should be enough to determine if they are equal.
                return this.ID == otherUser.ID;
            }
            else
            {
                return false;
            }
        }

        public override int GetHashCode()
        {
            // TODO: Check om dette er en dårlig ide.
            return ID.GetHashCode();
        }
    }
}