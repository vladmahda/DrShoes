using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DrShoes.Model
{
    public class ShoesTypes : INotifyPropertyChanged
    {
        private ObservableCollection<Type> typesCollection;
        private string filePath = @"../../Files/Data/ShoesTypes.xml";

        public ShoesTypes()
        {
            typesCollection = new ObservableCollection<Type>();
            typesCollection = XamlRepository.getShoesTypesData(typesCollection, filePath);
            //typesCollection.Add(new Type(1, "Мокасины"));
            //typesCollection.Add(new Type(2, "Босоножки"));
            //WorkWithXaml.saveData(typesCollection, filePath);
        }

        public ObservableCollection<Type> TypesCollection
        {
            get
            {
                return typesCollection;
            }
            set
            {
                typesCollection = value;
                OnPropertyChanged("TypesCollection");
            }
        }

        // Add "Shoes type" in the collection.
        public bool AddType(Type typeToList)
        {
            if (typeToList.Id != 0)
            {
                if (!checkType(typeToList))
                {
                    TypesCollection.Add(typeToList);
                    XamlRepository.saveData(TypesCollection, filePath);
                    return true;
                }
                else
                {
                    MessageBox.Show($"Клиент с Id = {typeToList.Id} уже существует.\n Введите другое Id");
                    return false;
                }
            }
            else
            {
                MessageBox.Show($"Поле Id клиента {typeToList.Title} пустое. Введите Id");
                return false;
            }
        }

        // Check for "shoes types" presence in the collection.
        public bool checkType(Type checkingType)
        {
            if (TypesCollection.Count != 0)
            {
                foreach (Type type in TypesCollection)
                {
                    if (type.Id == checkingType.Id)
                    {
                        return true;
                    }
                }
                return false;
            }
            return false;
        }



        #region INotifyPropertyChanged Members  

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion
    }
}
