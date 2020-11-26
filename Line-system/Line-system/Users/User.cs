using System;
using System.Net.NetworkInformation;
using System.Text.RegularExpressions;

namespace Line_system.Users
{
    public class User : IUser, IComparable<User>
    {
        public int ID { get; set; }
        private string _firstName;
        public string FirstName
        {
            get
            {
                return _firstName;
            }
            set
            {
                if (value != null)
                {
                    _firstName = value;
                }
                else
                {
                    throw new ArgumentNullException();
                }
            }
        }
        private string _lastName;

        public string LastName
        {
            get
            {
                return _lastName;
            }
            set
            {
                if (value != null)
                {
                    _lastName = value;
                }
                else
                {
                    throw new ArgumentNullException();
                }
            }
        }

        public string Username { get; set; }
        private string _email;
        public string Email
        {
            get => _email;
            set
            {
                Regex emailValidation = new Regex(@"[\w]+[a-zA-z0-9-_.]+\@\w+[a-zA-z0-9-_.]+\.[a-zA-z0-9-_.]+\w");

                if (emailValidation.IsMatch(value))
                {
                    _email = value;
                }
                else
                {
                    throw new FormatException($"{value} is not a valid email");
                }
            }
        }
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