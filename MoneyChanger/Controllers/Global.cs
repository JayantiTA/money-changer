using System;
namespace MoneyChanger.Controllers
{
	public static class Global
	{
        public static class CurrencyResult
        {
            public static string resultAmount { get; set; }
            public static string sourceAmount { get; set; }
            public static string fromCurrency { get; set; }
            public static string toCurrency { get; set; }
        }
        static string? _resVal, _sourceVal, _fromCurrency, _toCurrency;
        public static string ResultAmount
        {

            get
            {
                return _resVal;
            }
            set
            {
                _resVal = value;
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

