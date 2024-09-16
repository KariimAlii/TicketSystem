using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketSystem.Domain
{
    public static class ResultExtensions
    {
        public static Result<T> Ensure<T>(this Result<T> result, Func<T,bool> predicate, Error error)
        {
            // 🚩 First :  if result is failure  ➡️  return result
            if (result.IsFailure)
                return result;

            // 🚩 Second : if result is success
            //      ➡️  if predicate evaluates to true   ➡️  return result
            //      ➡️  if predicate evaluates to false  ➡️  return Failure Result
            return predicate(result.Value)
                ? result
                : Result.Failure<T>(error);
        }

        public static Result<Tout> Map<Tin, Tout>(this Result<Tin> result, Func<Tin, Tout> fn)
        {
            return result.IsSuccess
                ? Result.Success<Tout>(fn(result.Value))
                : Result.Failure<Tout>(result.Error);
        }
    }
}
