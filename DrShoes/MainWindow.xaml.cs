using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using DrShoes.Model;
using DrShoes.ViewModel;

namespace DrShoes
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        VMClients vmClients;
        VMOrders vmOrders;
  

        public MainWindow()
        {          
            InitializeComponent();
            vmClients = new VMClients();
            vmOrders = new VMOrders();
            //grdClients.ItemsSource = cl.ClientsCollection;
            //grdClients.ItemsSource = viewmodel.viewCollection;
            
        }

        //// Грубое нарушение паттерна MVVM!
        //private void btnAddClient_Click(object sender, RoutedEventArgs e)
        //{
        //    try
        //    {
        //        Client newClient = new Client
        //        {
        //            Id =vmClients.clientsModel.ClientsCollection.Max(x => x.Id) + 1,
        //            Surname = cmbClientSurname.Text,
        //            Name = cmbClientName.Text==""? " ": cmbClientName.Text,
        //            MiddleName = cmbClientMiddleName.Text,
        //            Phone = cmbClientPhone.Text,
        //            Notes = cmbClientNotes.Text,
        //            Fullname = ""
        //        };
        //        vmClients.clientsModel.AddClient(newClient);
        //        WorkWithXaml.saveData(vmClients.clientsModel.ClientsCollection, vmClients.clientsModel.FilePath);
        //        grdClients.Items.Refresh();
        //    }
        //    catch (Exception ex)
        //    {

        //        MessageBox.Show(ex.Message);
        //    }
        //}
    }
}
