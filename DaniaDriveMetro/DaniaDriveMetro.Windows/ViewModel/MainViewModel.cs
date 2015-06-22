using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using DaniaDriveMetro.Common;

namespace DaniaDriveMetro.ViewModel
{
    public sealed class MainViewModel : INotifyPropertyChanged
    {
        // The View's "Add Item" Button will bind to this property
        public RelayCommand AddItemCommand { get; set; }
        public RelayCommand RemoveItemCommand { get; set; }

         // The View's ListView will bind to this property
        private ObservableCollection<string> _listData;
        public ObservableCollection<string> ListData
        {
            get { return _listData; }
            set { _listData = value; OnPropertyChanged(); }
        }

        public MainViewModel()
        {
            // Set up the action for the command
            AddItemCommand = new RelayCommand(DoAddItem);
            RemoveItemCommand = new RelayCommand(DoRemoveItem);

            // Create default data for the list
            _listData = new ObservableCollection<string> { "Item 0", "Item 1", "Item 2" };
        }

        public void DoAddItem(object itemText)
        {
            var newItem = itemText as string;
            if (string.IsNullOrEmpty(newItem)) newItem = "Item " + _listData.Count.ToString();

            // When we add an item the ObservableCollection<T> will raise a OnPropertyChanged 
            // event which the view will consume
            _listData.Add(newItem);  
        }

        public void DoRemoveItem(object itemText)
        {
            var newItem = itemText as string;
            if (string.IsNullOrEmpty(newItem)) newItem = "Item " + _listData.Count.ToString();

            // When we add an item the ObservableCollection<T> will raise a OnPropertyChanged 
            // event which the view will consume
            _listData.Remove(newItem);
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
