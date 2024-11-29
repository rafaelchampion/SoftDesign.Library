namespace SoftDesign.Library.Cross.Core.Results
{
    public class DomainResult
    {
        public bool IsSuccess { get; }
        public string ErrorMessage { get; }

        protected DomainResult(bool isSuccess, string errorMessage)
        {
            IsSuccess = isSuccess;
            ErrorMessage = errorMessage;
        }

        public static DomainResult Success() => new DomainResult(true, null);
        public static DomainResult Failure(string errorMessage) => new DomainResult(false, errorMessage);
    }
    
    public class DomainResult<T> : DomainResult
    {
        public T Value { get; }

        private DomainResult(T value, bool isSuccess, string errorMessage)
            : base(isSuccess, errorMessage)
        {
            Value = value;
        }

        public static DomainResult<T> Success(T value) => new DomainResult<T>(value, true, null);
        public new static DomainResult<T> Failure(string errorMessage) => new DomainResult<T>(default, false, errorMessage);
    }
}