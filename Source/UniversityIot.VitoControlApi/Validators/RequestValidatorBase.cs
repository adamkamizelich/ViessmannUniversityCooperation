namespace UniversityIot.VitoControlApi.Validators
{
    using FluentValidation;

    /// <summary>
    /// Base validator
    /// </summary>
    /// <typeparam name="T">Type of request</typeparam>
    public abstract class RequestValidatorBase<T> : AbstractValidator<T>
    {
        /// <summary>
        /// Determines whether the specified property value is integer.
        /// </summary>
        /// <param name="propertyValue">The property value.</param>
        /// <returns>Is integer</returns>
        protected bool IsInteger(string propertyValue)
        {
            int result;
            return int.TryParse(propertyValue, out result);
        }
    }
}