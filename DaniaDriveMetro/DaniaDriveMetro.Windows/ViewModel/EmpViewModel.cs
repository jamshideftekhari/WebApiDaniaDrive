using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Windows.Data.Json;
using DaniaDriveMetro.Model;

namespace DaniaDriveMetro.ViewModel
{
    class EmpViewModel : INotifyPropertyChanged
    {

        private ObservableCollection<Employee> _employees;
        private HttpClient httpClient;

        public ObservableCollection<Employee> Employees
        {
            get { return _employees; }
            set { _employees = value; OnPropertyChanged(); }
        }

         public EmpViewModel()
        {
            SetHttpClient();
            GetEmployee();
          }

         private void SetHttpClient()
        {
            httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("http://localhost:52921/");
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            // Limit the max buffer size for the response so we don't get overwhelmed
            httpClient.MaxResponseContentBufferSize = 266000;

        }
        private async void GetEmployee()
        {

            var response = await httpClient.GetAsync("api/Employees");
            if (response.IsSuccessStatusCode)
            {
                var employee = await response.Content.ReadAsStringAsync();
                var emp = JsonArray.Parse(employee);

                var qry = (from m in emp
                           select new Employee()
                    {
                        EmployId =    (int)m.GetObject()["EmployeeId"].GetNumber(),
                        EmployeeName = m.GetObject()["EmployeeName"].GetString(),
                        EmployeeLastName = m.GetObject()["EmployeeLastName"].GetString(),
                        PhoneNr = m.GetObject()["PhoneNr"].GetString(),
                        EMail = m.GetObject()["EMail"].GetString(),
                        Picture = m.GetObject()["Picture"].GetString(),
                        AccountNr = m.GetObject()["AccountNr"].GetString()
                    }).ToList();
                var resualts = qry;
                Employees = new ObservableCollection<Employee>(resualts);
             }
        }


        public event PropertyChangedEventHandler PropertyChanged;
        [NotifyPropertyChangedInvocator]
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
