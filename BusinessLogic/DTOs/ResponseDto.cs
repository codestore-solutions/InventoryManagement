using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System.Net;

namespace BusinessLogic.DTOs
{
    public class ResponseDto
    {
        public int StatusCode { get; set; }
        public bool IsSuccess { get; set; }
        public ICollection<Error>? Errors { get; set; } = new List<Error>();

        public static ResponseDto CreateErrorResponse(int code, string message)
        {
            return new ResponseDto
            {
                StatusCode = code,
                IsSuccess = false,
                Errors = new List<Error>()
                {
                    new Error()
                    {
                        StatusCode = code,
                        Message = message
                    }
                }
            };
        }
    }

    public class ResponseDto<T> : ResponseDto where T : class
    {
        //public int StatusCode { get; set; }
        //public bool IsSuccess { get; set; }
        public T? Value { get; set; }

        public static ResponseDto<T> CreateSuccessResponse(int statusCode, bool isSuccess, T? value = null)
        {
            return new ResponseDto<T>
            {
                StatusCode = statusCode,
                IsSuccess = isSuccess,
                Value = value,
                Errors = null
            };
        }

        public static ResponseDto<T> CreateSuccessResponse(T value)
        {
            return new ResponseDto<T>
            {
                StatusCode = StatusCodes.Status200OK,
                IsSuccess = true,
                Value = value,
                Errors = null
            };
        }

    }


    public class Error
    {
        public int StatusCode { get; set; }
        public string Message { get; set; } = string.Empty;
    }
    
    public class Created
    {
        public Created(long id)
        {
            this.Id = id;
        }
        public long Id { get; set; }
    }


}