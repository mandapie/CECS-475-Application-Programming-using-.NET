using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockApplication
{
    class StockBroker
    {
        // StockBroker attributes
        private string _sBroker;
        List<Stock> stocks = new List<Stock>();

        // .txt file path
        private const string dir = @"C:\Users\Amanda\Documents\Visual Studio 2015\Projects\StockApplication\";
        private const string file = dir + "Stock.txt";

        // for locking a thread to make sure it is not interrupted
        private static Object lockThis = new Object();

        /// <summary>
        /// constructor of StockBroker
        /// </summary>
        /// <param name="sBroker"></param>
        public StockBroker(string sBroker)
        {
            _sBroker = sBroker;
        }

        /// <summary>
        /// add a stock to the stocks list
        /// </summary>
        /// <param name="stockValue"></param>
        public void AddStock(Stock stockValue)
        {
            stocks.Add(stockValue);
            // the event is called
            stockValue.RaiseStockEvent += Notify;
        }

        /// <summary>
        /// used to ensure that a block of code runs to completion without interruption by other threads
        /// and prints to the .txt file
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        /// <param name="changeValue"></param>
        public void Notify(string name, int value, int changeValue)
        {
            lock (lockThis)
            {
            StreamWriter outText = new StreamWriter(file, true);
            outText.WriteLine(_sBroker + "\t" + name + "\t" + value + "\t" + changeValue + "\n");
            Console.WriteLine("{0} \t {1} \t {2} \t {3}", _sBroker, name, value, changeValue);
            outText.Close();
            }
        }
    }
}
