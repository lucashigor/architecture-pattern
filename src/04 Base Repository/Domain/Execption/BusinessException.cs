using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Domain
{
    public class BusinessException : Exception
    {
        public int Codigo;
        public int Level;

        public BusinessException()
            : base()
        { }

        public BusinessException(string message)
            : base(message)
        { }

        public BusinessException(string message, Exception innerException)
           : base(message, innerException)
        { }

        public BusinessException(SerializationInfo info, StreamingContext context)
          : base(info, context)
        { }

        public BusinessException(string message, int codigo, int level)
            : base(message)
        {
            Codigo = codigo;
            Level = level;
        }
    }
}
