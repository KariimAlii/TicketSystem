using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketSystem.Domain
{
    public class Result
    {
        public Error Error { get; private set; }
        public bool IsSuccess { get; }
        public bool IsFailure => !IsSuccess;

        protected Result(bool isSuccess, Error error)
        {
            if (IsSuccess && error != Error.None)
                throw new InvalidOperationException();

            if (!isSuccess && error == Error.None)
                throw new InvalidOperationException();

            IsSuccess = isSuccess;
            Error = error;
        }
        
        public static Result Success()
        {
            return new Result(true, Error.None);
        }
        public static Result Failure(Error error)
        {
            return new Result(false, error);
        }
        public static Result<T> Success<T>(T value)
        {
            return new Result<T>(value, true, Error.None);
        }
        public static Result<T> Failure<T>(Error error)
        {
            return new Result<T>(default(T), false, error);
        }
        public static Result<T> Create<T>(T? value)
        {
            return value is not null
                ? Success<T>(value)
                : Failure<T>(Error.NullValue);
        }
    }
    public class Result<T> : Result
    {
        private readonly T _value;
        public T Value
        {
            get
            {
                if (!IsSuccess)
                    throw new InvalidOperationException();

                return _value; 
            }
        }
        protected internal Result(T value, bool isSuccess, Error? error) : base(isSuccess, error)
        {
            _value = value;
        }
    }
    public record Error(ErrorType Type, string Description)
    {
        public static class Email
        {
            public static Error EmailCannotBeEmpty = new(ErrorType.Validation, "Email cannot be empty");
            public static Error EmailNotValid = new(ErrorType.Validation, "Email is not valid");
            public static Error EmailLengthLong = new(ErrorType.Validation, "Email Length is too long");

            public static Error FailToSendEmail = new(ErrorType.Failure, "Failed to send email");
        }

        public static class Ticket
        {
            
            public static Error TicketNotExist = new(ErrorType.Failure, "Ticket doesnot exist");
        }


        public static Error None = new(ErrorType.Validation, string.Empty);
        public static Error NullValue = new(ErrorType.Validation, "Value is null");
    }

    public enum ErrorType
    {
        Validation = 1,
        Failure = 2
    }

    //public sealed class Result<T>
    //{
    //    public T Value { get; }
    //    public Error Error { get; }
    //    public bool IsSuccess { get; private set; }

    //    private Result(T value)
    //    {
    //        Value = value;
    //        IsSuccess = true;
    //    }
    //    private Result(Error error)
    //    {
    //        Error = error;
    //        IsSuccess = false;
    //    }

    //    public static Result<T> Success(T value) => new(value);
    //    public static Result<T> Failure(Error error) => new(error);
    //}
}
