using System;
using System.Collections.Generic;
using System.IO;

namespace Mailbox
{
    public class DataLoader : IDisposable
    {
        private readonly Stream source;
        public DataLoader(Stream source)
        {
            if(source is null)
            {
                throw new ArgumentNullException(nameof(source));
            }
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public List<Mailbox> Load()
        {
            List<Mailbox> mailboxes = new List<Mailbox>();

            source.Position = 0;

            using(StreamReader str = new StreamReader(source))
            {
               
            }

            return mailboxes;
        }

        public void Save(List<Mailbox> mailboxes)
        {
            
        }
    }
}
