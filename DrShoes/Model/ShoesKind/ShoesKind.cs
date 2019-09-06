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
    public class ShoesKind : INotifyPropertyChanged
    {
        private ObservableCollection<Kind> kindCollection;
        private string filePath = @"../../Files/Data/ShoesKind.xml";

        public ShoesKind()
        {
            kindCollection = new ObservableCollection<Kind>();
            kindCollection = WorkWithXaml.getShoesKindData(kindCollection, filePath);
            //KindCollection.Add(new Kind(1, "Мокасины"));
            //KindCollection.Add(new Kind(2, "Босоножки"));
            //WorkWithXaml.saveData(kindCollection, filePath);
        }

        public ObservableCollection<Kind> KindCollection
        {
            get
            {
                return kindCollection;
            }
            set
            {
                kindCollection = value;
                OnPropertyChanged("KindCollection");
            }
        }

        // Добавление "Вида обуви" в коллекцию.
        public bool AddKind(Kind kindToList)
        {
            if (kindToList.Id != 0)
            {
                if (!checkKind(kindToList))
                {
                    KindCollection.Add(kindToList);
                    WorkWithXaml.saveData(KindCollection, filePath);
                    return true;
                }
                else
                {
                    MessageBox.Show($"Клиент с Id = {kindToList.Id} уже существует.\n Введите другое Id");
                    return false;
                }
            }
            else
            {
                MessageBox.Show($"Поле Id клиента {kindToList.Title} пустое. Введите Id");
                return false;
            }
        }

        //Проверка, есть ли "Вид обуви" в коллекции.
        public bool checkKind(Kind checkingKind)
        {
            if (KindCollection.Count != 0)
            {
                foreach (Kind kind in KindCollection)
                {
                    if (kind.Id == checkingKind.Id)
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
