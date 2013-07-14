using System.ComponentModel;

[InjectValidation]
public class Person : INotifyPropertyChanged
{
    public string GivenNames;
    public string FamilyName;
    public event PropertyChangedEventHandler PropertyChanged;
}