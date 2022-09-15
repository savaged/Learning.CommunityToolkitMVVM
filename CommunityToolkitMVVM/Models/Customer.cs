using System;

namespace CommunityToolkitMVVM.Models
{
    internal class Customer : ModelBase, IEquatable<Customer>
    {
        private string _firstName = string.Empty;
        private string _surname = string.Empty;

        public string FirstName
        {
            get => _firstName;
            set => SetProperty(ref _firstName, value);
        }

        public string Surname
        {
            get => _surname;
            set => SetProperty(ref _surname, value);
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as Customer);
        }

        public bool Equals(Customer? other)
        {
            return other != null &&
                FirstName == other.FirstName &&
                Surname == other.Surname;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(FirstName, Surname);
        }
    }

}
