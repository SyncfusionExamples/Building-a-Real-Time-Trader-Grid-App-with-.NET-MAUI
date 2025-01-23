using Microsoft.Maui.Dispatching;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Timers;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Maui;

namespace SfDataGridSample
{
    public class StockViewModel
    {
        public ObservableCollection<Stock> Stocks { get; set; }
        private readonly System.Timers.Timer _timer;
        private readonly Random _random = new();
        private static readonly long[] ranges = { 1_000_000, 1_000_000_000, 1_000_000_000_000 };

        public StockViewModel()
        {
            Stocks = new ObservableCollection<Stock>(GenerateStocks());
            _timer = new System.Timers.Timer(800);
            _timer.Elapsed += (s, e) => UpdateStockData();
            _timer.Start();
        }

        private void UpdateStockData()
        {
            foreach (var stock in Stocks)
            {
                double oldPrice = stock.Price;
                stock.Price += (_random.NextDouble() * 4 - 2);
                stock.Change = stock.Price - oldPrice;
                stock.ChangePercentage = (stock.Change / stock.Price);
                stock.MarketCap = CalculateMarketCap(stock.Price);
                stock.Volume += (int)_random.NextInt64(1000);
                stock.Bid = stock.Price - _random.NextDouble();
                stock.Ask = stock.Price + _random.NextDouble();
                stock.Time = DateTime.Now.ToString("HH:mm:ss");
            }
        }

        public static double CalculateMarketCap(double price)
        {
            var _random = new Random();
            long range = ranges[_random.Next(ranges.Length)];
            double outstandingShares = _random.NextDouble() * range;
            double marketCap = price * outstandingShares;

            return marketCap;
        }

        private static ObservableCollection<Stock> GenerateStocks()
        {
            return new ObservableCollection<Stock>
            {
                    new Stock { Symbol = "AAPL", CompanyName = "Apple", Price = 150.00, Volume = 5000000 },
                    new Stock { Symbol = "GOOGL", CompanyName = "Alphabet", Price = 200.00, Volume = 3000000 },
                    new Stock { Symbol = "MSFT", CompanyName = "Microsoft", Price = 310.00, Volume = 4000000 },
                    new Stock { Symbol = "AMZN", CompanyName = "Amazon", Price = 300.00, Volume = 1500000 },
                    new Stock { Symbol = "TSLA", CompanyName = "Tesla", Price = 200.00, Volume = 4500000 },
                    new Stock { Symbol = "META", CompanyName = "Meta", Price = 280.00, Volume = 3500000 },
                    new Stock { Symbol = "NVDA", CompanyName = "NVIDIA", Price = 250.00, Volume = 2500000 },
                    new Stock { Symbol = "NFLX", CompanyName = "Netflix", Price = 580.00, Volume = 2000000 },
                    new Stock { Symbol = "BA", CompanyName = "Boeing Co.", Price = 220.00, Volume = 5000000 },
                    new Stock { Symbol = "ORCL", CompanyName = "Oracle", Price = 110.00, Volume = 4200000 },
                    new Stock { Symbol = "INTC", CompanyName = "Intel", Price = 50.00, Volume = 5500000 },
                    new Stock { Symbol = "PYPL", CompanyName = "PayPal", Price = 180.00, Volume = 2800000 },
                    new Stock { Symbol = "CSCO", CompanyName = "Cisco", Price = 50.00, Volume = 4800000 },
                    new Stock { Symbol = "VZ", CompanyName = "Verizon", Price = 50.00, Volume = 5200000 },
                    new Stock { Symbol = "JNJ", CompanyName = "Johnson & Johnson", Price = 165.00, Volume = 2400000 },
                    new Stock { Symbol = "PFE", CompanyName = "Pfizer.", Price = 42.00, Volume = 4000000 },
                    new Stock { Symbol = "KO", CompanyName = "Coca-Cola", Price = 60.00, Volume = 3500000 },
                    new Stock { Symbol = "MCD", CompanyName = "McDonald", Price = 250.00, Volume = 3200000 }
            };
        }
    }
}
