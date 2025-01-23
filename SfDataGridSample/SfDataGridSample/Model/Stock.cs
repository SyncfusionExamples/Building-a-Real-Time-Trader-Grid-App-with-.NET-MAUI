using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace SfDataGridSample
{
    public class Stock : INotifyPropertyChanged
    {
        private double _price;
        private double _change;
        private double _changePercentage;
        private int _volume;
        private double _marketCap;
        private double _bid;
        private double _ask;
        private string _time;

        public string Symbol { get; set; }
        public string CompanyName { get; set; }

        public double Price
        {
            get => _price;
            set { _price = value; OnPropertyChanged(); }
        }

        public double Change
        {
            get => _change;
            set { _change = value; OnPropertyChanged(); }
        }

        public double ChangePercentage
        {
            get => _changePercentage;
            set { _changePercentage = value; OnPropertyChanged(); }
        }

        public int Volume
        {
            get => _volume;
            set { _volume = value; OnPropertyChanged(); }
        }

        public double MarketCap
        {
            get => _marketCap;
            set { _marketCap = value; OnPropertyChanged(); }
        }

        public double Bid
        {
            get => _bid;
            set { _bid = value; OnPropertyChanged(); }
        }

        public double Ask
        {
            get => _ask;
            set { _ask = value; OnPropertyChanged(); }
        }

        public string Time
        {
            get => _time;
            set { _time = value; OnPropertyChanged(); }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
