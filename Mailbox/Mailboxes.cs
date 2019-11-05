using System;
using System.Collections.Generic;

namespace Mailbox
{
    public class Mailboxes : List<Mailbox>
    {
        public Mailboxes(IEnumerable<Mailbox> collection, int width, int height) 
            : base(collection)
        { 
            if (width < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(width));
            }
            if (height < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(height));
            }
            Width = width;
            Height = height;
        }

        public int Width { get; }
        public int Height { get; }

        public bool GetAdjacentPeople(int x, int y, out HashSet<Person> adjacentPeople)
        {
            adjacentPeople = new HashSet<Person>();
            bool isOccupied = false;

            foreach(Mailbox mailbox in this)
            {
                //current
                if (mailbox.Location == (x, y))
                {
                    isOccupied = true;
                }
                //above
                if (mailbox.Location == (x, y - 1))
                {
                    adjacentPeople.Add(mailbox.Owner);
                }
                //right
                if (mailbox.Location == (x + 1, y))
                {
                    adjacentPeople.Add(mailbox.Owner);
                }
                //bottom
                if (mailbox.Location == (x, y + 1))
                {
                    adjacentPeople.Add(mailbox.Owner);
                }
                //left
                if (mailbox.Location == (x - 1, y))
                {
                    adjacentPeople.Add(mailbox.Owner);
                }
            }

            return isOccupied;
        }
        
        public override bool Equals(object obj)
        {
            if(obj is Mailboxes boxes)
            {
                if(boxes.Count == this.Count)
                {
                    if(boxes.Height == this.Height && boxes.Width == this.Width)
                    {
                        for(int i = 0; i < this.Count; i++)
                        {
                            var box1 = boxes[i];
                            var box2 = this[i];

                            if (!box1.Owner.Equals(box2.Owner))
                                return false;

                            if (box1.Size != box2.Size)
                                return false;

                            if (box1.Location.Item1 != box2.Location.Item1 || box1.Location.Item2 != box2.Location.Item2)
                                return false;
                        }

                        return true;
                    }
                }
            }
            return false;
        }
        public static Mailbox AddNewMailbox( Mailboxes mailboxes, string firstName, string lastName, Size size)
        {
            int x = -1, y = -1;
            bool found = false;

            if (mailboxes.Count < 1)
            {
                found = true;
                x = y = 0;
            }
            else
            {

                for (int i = 0; i < mailboxes.Width && !found; i++)
                {
                    for (int j = 0; j < mailboxes.Height && !found; j++)
                    {
                        bool found2 = true;

                        foreach (var mailbox in mailboxes)
                        {
                            if (mailbox.Location.Item1 != i && mailbox.Location.Item2 != j)
                            {
                                found2 = false;
                                break;
                            }
                        }

                        if(found2)
                        {
                            x = i;
                            y = j;
                            found = true;
                        }
                    }
                }
            }

            var mbox = new Mailbox(size, (x, y), new Person(firstName, lastName));

            if (found)
                return mbox;

            return null;
        }
    }
}
