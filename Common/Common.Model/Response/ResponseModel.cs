using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Model.Response
{
    public class ResponseModel
    {
        public string Message { get; set; }
        public ResultActionModelCode Code { get; set; }
        public static ResponseModel Exception(Exception exc)
        {
            return new ResponseModel { Code = ResultActionModelCode.InternalServerError, Message = exc.Message };
        }
        public static ResponseModel OK()
        {
            return new ResponseModel { Code = ResultActionModelCode.OK, Message = "Ok" };
        }
    }
    public class ResponseModel<T> : ResponseModel
    {
        public static new ResponseModel<T> Exception(Exception exc)
        {
            return new ResponseModel<T> { Code = ResultActionModelCode.InternalServerError, Message = exc.Message };
        }
        public static ResponseModel<T> OK(T data)
        {
            return new ResponseModel<T> { Code = ResultActionModelCode.OK, Data = data, Message = "Ok" };
        }
        public T Data { get; set; }
    }
    public enum ResultActionModelCode
    {
        Unknown = 0, 
        OK = 1,
        InternalServerError = 2,
        NoData = 3,
        NoEntityFound = 4
    }
}
