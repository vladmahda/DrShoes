using DrShoes.Model;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrShoes.ViewModel
{
    public class VMClients : BindableBase/*, INotifyPropertyChanged*/
    {
        public Clients clientsModel = new Clients();
        public DelegateCommand AddClientCommand { get; }
        public DelegateCommand GridSelectionChanged { get; }
        public VMClients()
        {
            clientsModel.PropertyChanged += (s, e) => { RaisePropertyChanged(e.PropertyName); };
            // Add new client.
            AddClientCommand = new DelegateCommand(() =>
            {

                clientsModel.AddClient(new Client
                {
                    Id = clientsModel.ClientsCollection.Max(x => x.Id) + 1,
                    Surname = "Tutov",
                    Name = "Tut",
                    MiddleName = "Tutovich",
                    Phone = "999999",
                    Notes = "test addClient",
                    Fullname = ""
                });

            });
            GridSelectionChanged = new DelegateCommand(() =>
             {
                 
             });
    }
        public ObservableCollection<Client> viewCollection => clientsModel.ClientsCollection;


        //public event PropertyChangedEventHandler PropertyChanged;
        //protected virtual void OnPropertyChanged(string propertyName)
        //{
        //    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        //}
    }
}
