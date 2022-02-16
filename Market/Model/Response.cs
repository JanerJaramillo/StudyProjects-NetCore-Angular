using Model.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Response<T>
    {
        public HttpStatusCode StatusCode { get; set; }

        public ApiErrorCode ErrorCode { get; set; }

        public string Message { get; set; }

        public T Data { get; set; }
    }
}
