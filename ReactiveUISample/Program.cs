using System;
using System.Reactive.Linq;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
// ReSharper disable UnusedVariable

class Program
{
    /// <summary>
    /// A class to illustrate using the [Reactive] attribute.
    /// </summary>
    public class ViewModel : ReactiveObject
    {
        [Reactive]
        public int Value1 { get; set; } // Auto-generate the equivalent behavior that you see below for Value2

        // The normal way of implementing these properties follows
        int value2;

        public int Value2
        {
            get => value2;
            set => IReactiveObjectExtensions.RaiseAndSetIfChanged(this, ref value2, value);
        }

        [ObservableAsProperty]
        public int Value3 { get; }

        public ViewModel()
        {
            this.WhenAnyValue(x => x.Value2)
                .Select(x => x*10)
                .ToPropertyEx(this, x => x.Value3);
        }
    }

    /// <summary>
    /// A sample view that binds to the two properties on the model.
    /// </summary>
    public class View : ReactiveObject
    {
        ViewModel model;

        public View(ViewModel model)
        {
            this.model = model;

            this.WhenAnyValue(m => m.model.Value1).Subscribe(x => Console.WriteLine("value1 ={0}", x));
            this.WhenAnyValue(m => m.model.Value2).Subscribe(x => Console.WriteLine("value2 ={0}", x));
            this.WhenAnyValue(m => m.model.Value3).Subscribe(x => Console.WriteLine("value3 ={0}", x));
        }
    }


    /// <summary>
    /// Program should print out:
    ///
    /// value1 =0
    /// value2 =0
    /// value3 =0
    /// value1 =2
    /// value2 =2
    /// value3 =20
    /// value1 =3
    /// value2 =3
    /// value3 =30
    ///
    /// The purpose of this sample is to demonstrate parity between doing things manually vs. using the plugin.
    /// </summary>
    public static void Main()
    {
        var vm = new ViewModel();

        var v = new View(vm);

        vm.Value1 = 2;
        vm.Value2 = 2;

        vm.Value1 = 3;
        vm.Value2 = 3;

        Console.ReadLine();
    }
}