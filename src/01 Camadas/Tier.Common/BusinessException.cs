using System;

namespace Tier.Common
{
    public class BusinessException : ApplicationException
    {
        public BusinessException(string message, int level, int id)
        {
            _message = message;
            Level = level;
            Id = id;
        }

        public int Id { get; set; }
        public int Level { get; set; }

        private string _message { get; set; }

        public override string Message
        {
            get
            {
                return _message;
            }
        }
    }
}
