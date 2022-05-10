using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Cloth : INotifyPropertyChanged
{
    private int quantity;
    private string clothType;
    private string size;
    private string gender;

    public int Quantity
    {
        get
        {
            return quantity;
        }
        set
        {
            quantity = value;
            OnPropertyChanged("Quantity");
        }
    }
    public string ClothType
    {
        get
        {
            return clothType;
        }
        set
        {
            clothType = value;
            OnPropertyChanged("ClothType");
        }
    }
    public string Size
    {
        get
        {
            return size;
        }
        set
        {
            size = value;
            OnPropertyChanged("Size");
        }
    }
    public string Gender
    {
        get
        {
            return gender;
        }
        set
        {
            gender = value;
            OnPropertyChanged("Gender");
        }
    }
   
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
}
