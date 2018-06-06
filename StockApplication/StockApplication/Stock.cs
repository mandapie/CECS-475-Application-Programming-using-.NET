using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace StockApplication
{
    // declared a delagate under the namespace of StockApplication to reference to a function
    public delegate void StockNotification(String stockName, int currentValue, int numberChanges);

    class Stock
    {
        // Stock attributes
        private string _sName;
        private int _sValue, _mChange, _threshold;
        
        private int _cValue, _numberChange, _valueChange;
        private Random _random = new Random();
        private Thread thread;
        // delegated an event that is to be raised
        public event StockNotification RaiseStockEvent;

        /// <summary>
        /// constructor that runs a thread
        /// </summary>
        /// <param name="sName"></param>
        /// <param name="initialValue"></param>
        /// <param name="mChange"></param>
        /// <param name="tHold"></param>
        public Stock(string sName, int initialValue, int mChange, int tHold)
        {
            _sName = sName;
            _sValue = initialValue;
            _mChange = mChange;
            _threshold = tHold;
            _cValue = initialValue;
            thread = new Thread(new ThreadStart(ChangeStockValue));
            thread.Start();
        }

        /// <summary>
        /// method that controls how the method is to be run
        /// </summary>
        public void ChangeStockValue()
        {
            for(int i = 0; i < 10; i++)
            {
                Thread.Sleep(500); //0.5 seconds
                _cValue += _random.Next(1, _mChange);
                _numberChange++;
                _valueChange = _cValue - _sValue;
                // if the value change is greater than or equals to the threshold, raise the event
                if (_valueChange >= _threshold)
                {
                    RaiseStockEvent(this._sName, this._cValue, this._numberChange);
                }
            }
        }
    }
}
