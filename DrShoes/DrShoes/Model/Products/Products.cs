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
    public class Products :INotifyPropertyChanged
    {
        private ObservableCollection<string> productsCollection;

        public Products()
        {
            productsCollection = new ObservableCollection<string>
            {
                "Обувь женская", 
                "Обувь мужская",
                "Обувь детская",
                "Сумка",
                "Женская",
                "Мужская"
            };
        }

        public ObservableCollection<string> ProductsCollection { get => productsCollection;
            set
            {
                productsCollection = value;
                OnPropertyChanged("ProductsCollection");
            }
        }

        #region INotifyPropertyChanged Members  

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
                MessageBox.Show("Изменено свойство: {0}", propertyName);
            }
        }
        #endregion
    }
}
