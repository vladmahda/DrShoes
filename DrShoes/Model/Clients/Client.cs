using System.ComponentModel;

namespace DrShoes.Model
{
    public class Client : INotifyPropertyChanged
    {
        private int id;
        private string surname;
        private string name;
        private string middleName;
        private string phone;
        private string notes;
        private string fullname;

        public Client() { }

        public Client(int id, string surname, string name, string middleName, string phone, string notes)
        {
            Id = id;
            Surname = surname;
            Name = name;
            MiddleName = middleName;
            Phone = phone;
            Notes = notes;
            string temp = "";
            if (name != null && name.Substring(0, 1) != " ")
            {
                temp += " " + name.Substring(0, 1) + ".";
            }
            if (middleName != null && middleName.Substring(0, 1) != " ")
            {
                temp += middleName.Substring(0, 1) + ".";
            }
            fullname = surname + temp;
        }

        #region public properties
        public int Id
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
                OnPropertyChanged("Id");
            }
        }

        public string Surname
        {
            get
            {
                return surname;
            }
            set
            {
                surname = value;
                OnPropertyChanged("Surname");
            }
        }
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
                OnPropertyChanged("Name");
            }
        }
        public string MiddleName
        {
            get
            {
                return middleName;
            }
            set
            {
                middleName = value;
                OnPropertyChanged("MiddleName");
            }
        }
        public string Phone
        {
            get
            {
                return phone;
            }
            set
            {
                phone = value;
                OnPropertyChanged("Phone");
            }
        }
        public string Notes
        {
            get
            {
                return notes;
            }
            set
            {
                notes = value;
                OnPropertyChanged("Notes");
            }
        }

        public string Fullname
        {
            get
            {
                return fullname;
            }
            set
            {
                fullname = surname;
                if (name != null && name.Substring(0, 1) != " ")
                {
                    fullname += " " + name.Substring(0, 1).ToUpper() + ".";
                }
                if (middleName != null && middleName.Substring(0, 1) != " ")
                {
                    fullname += middleName.Substring(0, 1).ToUpper() + ".";
                }
                OnPropertyChanged("Fullname");
            }
        }
        #endregion

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

        private void fullnameFilling()
        {
            string temp = "";
            if (name != null && name.Substring(0, 1) != " ")
            {
                temp += " " + name.Substring(0, 1) + ".";
            }
            if (middleName != null && middleName.Substring(0, 1) != " ")
            {
                temp += middleName.Substring(0, 1) + ".";
            }
            Fullname = Surname + temp;
        }
    }
}
