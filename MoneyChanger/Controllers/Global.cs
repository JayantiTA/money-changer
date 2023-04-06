using System;
namespace MoneyChanger.Controllers
{
    public static class Global
    {
        static bool _isLoading;
        static string _resultAmount, _sourceAmount, _fromCurrency, _toCurrency;

        public static bool IsLoading
        {
            get
            {
                return _isLoading;
            }
            set
            {
                _isLoading = value;
            }
        }

        public static string ResultAmount
        {
            get
            {
                return _resultAmount;
            }
            set
            {
                _resultAmount = value;
            }
        }

        public static string SourceAmount
        {
            get
            {
                return _sourceAmount;
            }
            set
            {
                _sourceAmount = value;
            }
        }

        public static string FromCurrency
        {
            get
            {
                return _fromCurrency;
            }
            set
            {
                _fromCurrency = value;
            }
        }

        public static string ToCurrency
        {
            get
            {
                return _toCurrency;
            }
            set
            {
                _toCurrency = value;
            }
        }
    }
}

