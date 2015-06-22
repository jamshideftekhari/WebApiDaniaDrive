using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Windows.Data.Json;
using Windows.UI.Xaml.Navigation;
using DaniaDriveMetro.Common;
using DaniaDriveMetro.Model;

namespace DaniaDriveMetro.ViewModel
{
    class TasksViewModel : INotifyPropertyChanged
    {

        private ObservableCollection<DaniaTask> _listData;
        private ObservableCollection<int> _String_listData;
        private ObservableCollection<DaniaTask> _tasks;
        private ObservableCollection<Employee> _tasks_emp;
        private HttpClient httpClient;
       

        public ObservableCollection<int> String_ListData
        {
            get { return _String_listData; }
            set { _String_listData = value; OnPropertyChanged(); }
        }

        public ObservableCollection<DaniaTask> ListData
        {
            get { return _listData; }
            set { _listData = value; OnPropertyChanged(); }
        }

        public ObservableCollection<DaniaTask> Tasks
        {
            get { return _tasks; }
            set { _tasks = value; OnPropertyChanged(); }
        }

        public ObservableCollection<Employee> Tasks_emp
        {
            get { return _tasks_emp; }
            set { _tasks_emp = value; OnPropertyChanged(); }
        }
        public TasksViewModel()
        {
            SetHttpClient();
            GetEmployee();
            // Create default data for the list
          //  _String_listData = new ObservableCollection<int> {11, 22, 33 };
          //  _tasks = new ObservableCollection<DaniaTask>();

            _listData = new ObservableCollection<DaniaTask>
                {
                    new DaniaTask(){DaniaTaskId = 2,ElapsedTime = 50,EmployeeId = 3,Milage = 60}, 
                    new DaniaTask(){DaniaTaskId = 33,ElapsedTime = 60,EmployeeId = 55,Milage = 70}, 
                    new DaniaTask(){DaniaTaskId = 52,ElapsedTime = 80,EmployeeId = 444,Milage = 80},
                    new DaniaTask(){DaniaTaskId = 52,ElapsedTime = 80,EmployeeId = 444,Milage = 80}
                };
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

            var response = await httpClient.GetAsync("api/daniatasks");
            if (response.IsSuccessStatusCode)
            {
                var employee = await response.Content.ReadAsStringAsync();
                var emp = JsonArray.Parse(employee);

                var qry = (from m in emp
                    select new DaniaTask()
                    {
                        DaniaTaskId = (int) m.GetObject()["DaniaTaskId"].GetNumber(),
                        EmployeeId = (int) m.GetObject()["EmployeeId"].GetNumber(),
                        PaymentId = (int) m.GetObject()["PaymentId"].GetNumber(),
                        Milage = (int) m.GetObject()["Milage"].GetNumber(),
                        ElapsedTime = (int) m.GetObject()["ElapsedTime"].GetNumber(),
                        //Employee = new Employee() { EmployId = (int)m.GetObject()["Employee:{EmployeeId}"].GetNumber()}
                    Employee = new Employee()
                    {
                        EmployId = (int)m.GetObject()["Employee"].GetObject()["EmployeeId"].GetNumber(),
                        EmployeeName = m.GetObject()["Employee"].GetObject()["EmployeeName"].GetString()
                    }
                }).ToList();
                var resualts = qry;
                Tasks = new ObservableCollection<DaniaTask>(resualts);
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
