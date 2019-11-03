using System;

namespace Mailbox
{
    public class Mailbox
    {
        public Size Size { get; set; } //default set to 0 in the enum cant be null

        public (int, int) Location { get; set; } //cant be null because value

        //and a Person Owner
        public Person Owner; //cant be null because struct

        public Mailbox(Size Size, (int, int) Location, Person Owner)
        {
            this.Size = Size;
            this.Location = Location;
            this.Owner = Owner;
        }

        public override string ToString()
        {
            var size = "";

            switch(this.Size)
            {
                case Size.Small:
                case Size.Medium:
                case Size.Large:
                    size = this.Size.ToString();
                    break;
            }

            if(this.Size.IsPremium())
            {
                if(size != "")
                    size += " Premium";
            }

            return "Mailbox size: " + size + " Location: " + Location + ", Owner: " + Owner;
        }
    }
}
