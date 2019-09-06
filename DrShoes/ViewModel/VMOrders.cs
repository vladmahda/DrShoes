using DrShoes.Model;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrShoes.ViewModel
{
    public class VMOrders : BindableBase
    {
        public ShoesKind kindModel = new ShoesKind();
        public ObservableCollection<Kind> kindCollection => kindModel.KindCollection;

        public Products productsModel = new Products();
        public ObservableCollection<string> productsCollection => productsModel.ProductsCollection;

        public VMOrders()
        {
            kindModel.PropertyChanged += (s, e) => { RaisePropertyChanged(e.PropertyName); };
        }

    }
}
