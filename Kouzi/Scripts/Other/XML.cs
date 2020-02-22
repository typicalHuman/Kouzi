using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Xml.Serialization;

namespace Kouzi.Scripts.Other
{
    class XML<T>
    {
        private XmlSerializer serializer { get; set; } = new XmlSerializer(typeof(ObservableCollection<T>));

        public void Serialize(IEnumerable<T> coll, string fileName)
        {
            ClearFileContent(fileName);
            using (FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                serializer.Serialize(fs, coll);
            }
        }

        private void ClearFileContent(string fileName)
        {
            StreamWriter sr = new StreamWriter(fileName, false);
            sr.WriteLine("");
            sr.Close();
        }


        public IEnumerable<T> Deserialize(string fileName)
        {
            IEnumerable<T> coll = null;
            try
            {
                using (FileStream fs = File.OpenRead(fileName))
                {
                    coll = (IEnumerable<T>)serializer.Deserialize(fs);
                }
            }
            catch (FileNotFoundException) { }
            return coll;
        }
    }
}
