﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DrShoes.Model
{
    public class Clients : INotifyPropertyChanged
    {
        private ObservableCollection<Client> clientsCollection;
        private string filePath = @"../../Files/Data/Clients.xml";

        public ObservableCollection<Client> ClientsCollection
        {
            get
            {
                return clientsCollection;
            }
            set
            {
                clientsCollection = value;
                OnPropertyChanged("ClientsCollection");
                ClientsCollection.CollectionChanged += Clients_CollectionChanged;
            }
        }

        public string FilePath { get => filePath; }

        public Clients()
        {
            clientsCollection = new ObservableCollection<Client>();
            clientsCollection = XamlRepository.getClientsData(clientsCollection, FilePath);
            //Client cl1 = new Client(1, "Ivanov", "Ivan", "Ivanovich", "111111", "first");
            //Client cl2 = new Client(2, "Petrov", "Petr", "Petrovich", "222222", "second");
            //clientsCollection.Add(cl1);
            //clientsCollection.Add(cl2);
            //WorkWithXaml.saveData(clientsCollection, filePath);
        }

        // Add client to the collection.
        public bool AddClient(Client client)
        {
            if (client.Id != 0)
            {
                if (!checkClient(client))
                {
                    ClientsCollection.Add(client);
                    XamlRepository.saveData(ClientsCollection, FilePath);
                    return true;
                }
                else
                {
                    MessageBox.Show($"Клиент с Id = {client.Id} уже существует.\n Введите другое Id");
                    return false;
                }
            }
            else
            {
                MessageBox.Show($"Поле Id клиента {client.Surname} пустое. Введите Id");
                return false;
            }
        }

        // Delete client from the collection.
        public bool DeleteClient(Client client)
        {
            if (checkClient(client))
            {
                ClientsCollection.Remove(client);
                return true;
            }
            else
            {
                MessageBox.Show($"Клиент с фамилией \"{client.Surname}\" не существует.\n Удаление невозможно.");
                return false;
            }
        }

        // Check for client presence in the collection.
        public bool checkClient(Client checkingClient)
        {
            if (ClientsCollection.Count != 0)
            {
                foreach (Client client in ClientsCollection)
                {
                    if (client.Id == checkingClient.Id)
                    {
                        return true;
                    }
                }
                return false;
            }
            return false;
        }

        // Collection Change Event Handler.
        private static void Clients_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add: // if Add
                    Client newClient = e.NewItems[0] as Client;
                    MessageBox.Show("Добавлен новый объект: {0}", newClient.Surname);
                    break;
                case NotifyCollectionChangedAction.Remove: // if Delete
                    Client oldClient = e.OldItems[0] as Client;
                    MessageBox.Show("Удален объект: {0}", oldClient.Surname);
                    break;
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
