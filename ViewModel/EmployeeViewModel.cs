using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Module02Exercise01.Model;

using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

namespace Module02Exercise01.ViewModel
{
    public class EmployeeViewModel : INotifyPropertyChanged
    {
        private Employee _employee;

        private string _fullName;



        public EmployeeViewModel()
        {
            //Initialize sample student model. Coordination with model.
            _employee = new Employee { FirstName = "Richard", LastName = "Sy", Position="Manager", Department="Department of Accounting", IsActive=true};
            //UI thread management
            LoadEmployeeDataCommand = new Command(async () => await LoadEmployeeDataAsync());

            Employees = new ObservableCollection<Employee>
            {
                new Employee { FirstName = "John", LastName = "Cena", Position= "Employee", Department="Department of Accounting", IsActive=true},
                new Employee { FirstName = "Ellen", LastName = "Joe", Position="Employee", Department="Department of Accounting",  IsActive=true},
                new Employee { FirstName = "Ben", LastName = "Bigger", Position="Employee", Department="Department of Accounting",  IsActive=true},
                new Employee { FirstName = "Furina", LastName = "Focalor", Position="Intern", Department="Department of Accounting",  IsActive=false},
            };
        }
        public ObservableCollection<Employee> Employees { get; set; }
        //2 way data binding and data conversion
        public string FullName
        {
            get => _fullName;
            set
            {
                if (_fullName != value)
                {
                    _fullName = value;
                    OnPropertyChanged(nameof(FullName));
                }
            }
        }
        //UI Thread Management
        public ICommand LoadEmployeeDataCommand { get; }


        private async Task LoadEmployeeDataAsync()
        {
            await Task.Delay(1000); // I/O operation
            FullName = $"The Current Manager is {_employee.FirstName} {_employee.LastName}"; //Data Conversion

        }
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
