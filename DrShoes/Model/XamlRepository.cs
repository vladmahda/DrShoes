using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;
using System.Collections.ObjectModel;

namespace DrShoes.Model
{
    public class XamlRepository
    {
        public static void saveData(object obj, string filename)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(obj.GetType());
            using (FileStream fs = new FileStream(filename, FileMode.Create))
            {
                xmlSerializer.Serialize(fs, obj);
            }
        }

        public static ObservableCollection<Client> getClientsData(object obj, string filename)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(obj.GetType());
            using (FileStream fs = new FileStream(filename, FileMode.Open))
            {
                return (ObservableCollection<Client>)xmlSerializer.Deserialize(fs);
            }
        }

        public static ObservableCollection<Type> getShoesTypesData(object obj, string filename)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(obj.GetType());
            using (FileStream fs = new FileStream(filename, FileMode.Open))
            {
                return (ObservableCollection<Type>)xmlSerializer.Deserialize(fs);
            }
        }
    }

}
