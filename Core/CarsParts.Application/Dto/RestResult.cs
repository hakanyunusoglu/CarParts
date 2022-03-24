using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarsParts.Application.Dto
{
    public class RestResult<T> where T : class
    {
        public RestResult(bool success, T data, List<string> errors)
        {
            Errors = errors;
            Success = success;
            Data = data;
        }
        public List<string> Errors { get; set; }
        public bool Success { get; set; }
        public T Data { get; set; }
    }
}
