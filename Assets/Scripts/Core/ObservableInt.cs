using System;
using System.ComponentModel;
using UnityEngine;

public class ObservableInt : INotifyPropertyChanged
{
    private int value;

    public int Value
    {
        get { return value; }
        set
        {
           this.value = value;
           NotifyPropertyChanged(nameof(Value));
        }
    }

    public ObservableInt(int initialValue)
    {
        this.value = initialValue;
    }
    
    public event PropertyChangedEventHandler PropertyChanged;
    
    internal void NotifyPropertyChanged(string propertyName) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
}