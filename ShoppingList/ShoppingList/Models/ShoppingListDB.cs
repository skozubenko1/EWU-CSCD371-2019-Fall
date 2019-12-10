using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace ShoppingList.Models
{
    /// <summary>
    /// Shopping List Data Storage
    /// </summary>
    public class ShoppingListDB
    {
        public List<ShoppingListItem> Items { get; set; } = new List<ShoppingListItem>();

        [XmlIgnore]
        public string FileName = "ShoppingList.xml";

        public ShoppingListDB Save(string NewFileName = null)
        {
            if (NewFileName != null)
                FileName = NewFileName;

            try
            {
                XmlSerializer xmlserializer = XmlSerializer.FromTypes(new[] { GetType() })[0]; // new XmlSerializer(this.GetType());

                // XmlSerializer xmlserializer = new XmlSerializer(this.GetType());
                StringWriter textWriter = new StringWriter();
                xmlserializer.Serialize(textWriter, this);

                File.WriteAllText(FileName, textWriter.ToString());
            }
            catch { }

            return this;
        }

        public static ShoppingListDB Load(string FileName = "ShoppingList.xml")
        {
            ShoppingListDB db = null;

            try
            {
                StringReader stream = null;

                if (File.Exists(FileName))
                {
                    stream = new StringReader(File.ReadAllText(FileName));

                    if (stream != null)
                    {
                        // Now create a binary formatter
                        XmlSerializer xmlserializer = new XmlSerializer(typeof(ShoppingListDB));

                        // Deserialize the object and use it
                        db = (ShoppingListDB)xmlserializer.Deserialize(stream);
                    }
                }
            }
            catch { }

            return db ?? new ShoppingListDB().Save(FileName);
        }

        public ObservableCollection<ShoppingListItem> ToObservable()
        {
            return new ObservableCollection<ShoppingListItem>(Items);
        }
    }
}
