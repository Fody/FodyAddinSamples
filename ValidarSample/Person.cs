using System.ComponentModel;

[InjectValidation]
public class Person : INotifyPropertyChanged
{
    public string GivenNames { get; set; }
    public string FamilyName { get; set; }
    public event PropertyChangedEventHandler PropertyChanged;
}