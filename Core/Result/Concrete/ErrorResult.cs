using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Result.Concrete
{
    public class ErrorResult :Result
    {
        public ErrorResult(string message):base(message,false)
        {
                
        }
        public ErrorResult():base(false)
        {

        }
    }
}
