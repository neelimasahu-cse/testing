using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace MulitipleViews.ViewModels
{
    class ClothesViewModel: INotifyPropertyChanged 
    {
        public ObservableCollection<Cloth> _ClothsList;
        
        public string test;

        public ClothesViewModel()
        {
            //_ClothsList = new ObservableCollection<Cloth>
            //{
            //    new Cloth{ClothType="Pant", Gender="Male", Quantity=10, Size="32"},
            //    new Cloth{ClothType="Pant", Gender="Male", Quantity=10, Size="34"},
            //    new Cloth{ClothType="Pant", Gender="Male", Quantity=10, Size="36"},
            //    new Cloth{ClothType="Shirt", Gender="Female", Quantity=10, Size="S"},
            //    new Cloth{ClothType="Shirt", Gender="Female", Quantity=10, Size="XS"},
            //};
            //DataContext = this;

        }

        public List<Cloth> ListBox { get; set; }
        public List<TodoItem> ITEMLIST { get; set; } = TodoItems.GetTodoItems();

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // Get data from somewhere and fill in my local ArrayList
            myDataList = LoadListBoxData();
            // Bind ArrayList with the ListBox
            ListBox.ItemsSource = myDataList;
        }

        private ArrayList LoadListBoxData()
        {
            ArrayList itemsList = new ArrayList();
            itemsList.Add("Coffie");
            itemsList.Add("Tea");
            itemsList.Add("Orange Juice");
            itemsList.Add("Milk");
            itemsList.Add("Mango Shake");
            itemsList.Add("Iced Tea");
            itemsList.Add("Soda");
            itemsList.Add("Water");
            return itemsList;
        }

        private Cloth mSelectedRow;
        public Cloth SelectedRow
        {
            get => mSelectedRow;
            set
            {
                mSelectedRow = value;
            }
        }




        // Property to bind to ComboBox's SelectedItem
        private ComboBoxItem _SelectedItem;
        public ComboBoxItem SelectedItem
        {
            get { return _SelectedItem; }
            set
            {
                _SelectedItem = value;

                // SelectedItem's Content
                string Content = (string)value.Content;

                // SelectedItem's parent (i.e. the ComboBox)
                ComboBox SelectBox = (ComboBox)value.Parent;

                test = Content;
            }
        }

        // INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged(string PropertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(PropertyName));
        }
        public ObservableCollection<Cloth> Cloths
        {
            get { return _ClothsList; }
            set { _ClothsList = value; }
        }

      
        
        





        
        
        private ICommand _DonateICommand;
        private ICommand _AddICommand;
        private object myDataList;

        public ICommand DonateCommand
        {
            get
            {
                return _DonateICommand ?? (_DonateICommand = new CommandHandler(() => Decrement(), true));
            }
        }

        public ICommand AddCommand
        {
            get
            {
                return _AddICommand ?? (_AddICommand = new CommandHandler(() => AddArticle(), true));
            }
        }

        
        public void AddArticle()
        {
            _ClothsList.Add(new Cloth { ClothType = test, Gender = "Female", Quantity = 5, Size = "M" });
        }

        public void Decrement()
        {
            if (SelectedRow != null) {
                if (SelectedRow.Quantity > 0) {
                    SelectedRow.Quantity--;
                }
            }
        }

    } 

    public class CommandHandler : ICommand
    {
        private Action _action;
        private bool _canExecute;
        public CommandHandler(Action action, bool canExecute)
        {
            _action = action;
            _canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            return _canExecute;
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            _action();
        }
    }

    // List Box Code starts fromm here !!
    public List<TodoItem> ITEMLIST { get; set; } = TodoItems.GetTodoItems();
    public class TodoItems
    {
        public static List<TodoItem> GetTodoItems()
        {

            var list = new List<TodoItem>();
             list.Add(new TodoItem() { NAME = "Neelima", SURNAME = "Sahu" });
            list.Add(new TodoItem() { NAME = "Pilu", SURNAME = "Wadikar" });
                list.Add(new TodoItem() { NAME = "Amit", SURNAME = "Sahu" });
             list.Add(new TodoItem() { NAME = "Kitty", SURNAME = "Wadikar" });
            return list;
        }

    }

    //1. create a class
    public class TodoItem
    {
        public string NAME { get; set; }
        public string SURNAME { get; set; }

        public override string ToString()
        {
            return this.NAME + this.SURNAME;
        }
    }

}