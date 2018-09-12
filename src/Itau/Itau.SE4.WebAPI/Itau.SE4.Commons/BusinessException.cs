using System;

namespace Itau.SE4.Commons
{
    public class BusinessException : ApplicationException
    {
        public BusinessException(string message)
        {
            _message = message;
        }

        protected string _message { get; set; }

        public override string Message {
            get
            {
                return _message;
            }
        }
    }
}
