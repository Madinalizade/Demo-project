using Core.Result.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Result.Concrete
{
    public class SuccessResult : Result
    {
        public bool Success { get ; set ; }
        public string Message { get; set; }
        public SuccessResult(string message):base(message,true)
        {

        }
        public SuccessResult():base(true)
        {

        }
    }
}
