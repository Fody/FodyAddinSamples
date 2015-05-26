using System.ComponentModel;
using System.Runtime.CompilerServices;
using Commander;

namespace CommanderSample
{
    public class SampleViewModel : INotifyPropertyChanged
    {
        int ticks;

        public int Ticks
        {
            get { return ticks; }
            set
            {
                if (ticks == value)
                {
                    return;
                }
                ticks = value;
                OnPropertyChanged();
            }
        }

        [OnCommand("TickCommand")]
        public void OnTick()
        {
            Ticks++;
        }

        [OnCommandCanExecute("TickCommand")]
        public bool CanTick()
        {
            return Ticks < 10;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}