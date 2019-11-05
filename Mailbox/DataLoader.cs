using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace Mailbox
{
    public class DataLoader : IDisposable
    {
        private readonly Stream source;
        #region IDisposable Support
        private bool disposedValue = false;
        public DataLoader(Stream source)
        {
            if(source is null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            this.source = source;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    //dispose managed state
                    source.Dispose();
                }

                disposedValue = true;
            }
        }
        #endregion

        public List<Mailbox> Load()
        {
            List<Mailbox> mailboxes = new List<Mailbox>();

            source.Position = 0;

            using(StreamReader str = new StreamReader(source, leaveOpen: true))
            {
                var temp = str.ReadToEnd();
                mailboxes = JsonConvert.DeserializeObject<List<Mailbox>>(temp);              
            }

            return mailboxes;
        }

        public void Save(List<Mailbox> mailboxes)
        {
            string jsonData = JsonConvert.SerializeObject(mailboxes);
            using var writer = new StreamWriter(source, leaveOpen: true);
            writer.Write(jsonData);
            writer.Flush();
        }
    }

}

