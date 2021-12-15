using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BNIWebServiceTest.Models
{
    public class Result
    {
        public Result(bool is_Valid, string msg = "")
        {
            this.isValid = is_Valid;
            this.Message = msg;
        }

        public bool isValid { get; set; }
        public string Message { get; set; }
    }
}