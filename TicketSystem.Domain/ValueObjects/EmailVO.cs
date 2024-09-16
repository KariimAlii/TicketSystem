using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketSystem.Domain.ValueObjects
{
    public class EmailVO : ValueObject<EmailVO>
    {
        private readonly string _value;
        private EmailVO(string value)
        {
            _value = value;
        }

        public static Result<EmailVO> Create(string email)
        {
            return Result.Create(email.Trim())
                .Ensure(e => string.IsNullOrWhiteSpace(e), Error.Email.EmailCannotBeEmpty)
                .Ensure(e => e.Length > 250, Error.Email.EmailLengthLong)
                .Ensure(e => e.Split('@').Length == 2, Error.Email.EmailNotValid)
                .Map(e => new EmailVO(e));

            //email = email.Trim();

            //if (string.IsNullOrWhiteSpace(email))
            //    return Result.Failure<EmailVO>(Error.Email.EmailCannotBeEmpty);

            //if (email.Length > 250)
            //    return Result.Failure<EmailVO>(Error.Email.EmailLengthLong);

            //if (!email.Contains('@'))
            //    return Result.Failure<EmailVO>(Error.Email.EmailNotValid);

            //return Result.Success<EmailVO>(new EmailVO(email));
        }

        // string  ----explicit-----> Email
        public static explicit operator EmailVO(string value)
        {
            return Create(value).Value;
        }
        // Email  ----implicit------> string
        public static implicit operator string(EmailVO emailVO)
        {
            return emailVO._value;
        }
        public override bool EqualsCore(EmailVO other)
        {
            return _value == other._value;
        }

        public override int GetHashCodeCore()
        {
            return _value.GetHashCode();
        }
    }
}
