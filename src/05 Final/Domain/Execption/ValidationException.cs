using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Domain
{
    public class ValidationException : Exception
    {
        public IList<string> Erros { get; set; }

        public ValidationException()
            : base()
        { }

        public ValidationException(string message)
            : base(message)
        { }

        public ValidationException(string message, Exception innerException)
           : base(message, innerException)
        { }

        public ValidationException(SerializationInfo info, StreamingContext context)
          : base(info, context)
        { }

        public ValidationException(string message, List<String> erros)
            : base(message)
        {
            Erros = erros;
        }
    }
}
