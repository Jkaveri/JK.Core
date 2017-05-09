#region

using System;
using System.Threading;
using System.Threading.Tasks;
using JKCore.Mediator.Abstracts;
using JKCore.Mediator.Exceptions;
using JKCore.Validators;

#endregion

namespace JKCore.Mediator
{
    public class AnnotationValidatorFilter : MediatorFilter
    {
        private readonly AnnotationsValidator _validator;

        public AnnotationValidatorFilter(AnnotationsValidator validator)
        {
            _validator = validator;
        }

        public override Task<IMediatorResult<TResult>> Apply<TMessage, TResult>(TMessage message, Func<TMessage, CancellationToken, Task<IMediatorResult<TResult>>> next,
            CancellationToken cancellationToken = new CancellationToken())
        {

            var result = _validator.Validate(message);

            result.ThrowExceptionIfNotValid<MediatorFilterException>();

            return next(message, cancellationToken);
        }
    }
}