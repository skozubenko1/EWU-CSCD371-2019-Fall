using System;
using System.Diagnostics.CodeAnalysis;

namespace Mailbox
{
    public struct Person : IEquatable<Person>
    {
        public string _FirstName; //{ get; set; }
        public string _LastName; //{ get; set; }

        public Person(string _FirstName, string _LastName)
        {
            this._FirstName = _FirstName ?? throw new ArgumentNullException(nameof(_FirstName));
            this._LastName = _LastName ?? throw new ArgumentNullException(nameof(_LastName));
        }

        public bool Equals([AllowNull] Person other)
        {
            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return this._FirstName == other._FirstName && this._LastName == other._LastName;
		}
         
        public override string ToString()
        {
            return $"{_FirstName}, {_LastName}";
        }
        
    }
}