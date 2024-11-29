namespace SoftDesign.Library.Cross.Core.Results
{
    public class Result
    {
        public bool IsSuccess { get; }
        public string ErrorMessage { get; }

        protected Result(bool isSuccess, string errorMessage)
        {
            IsSuccess = isSuccess;
            ErrorMessage = errorMessage;
        }

        public static Result Success() => new Result(true, null);
        public static Result Failure(string errorMessage) => new Result(false, errorMessage);
    }
    
    public class Result<T> : Result
    {
        public T Value { get; }

        private Result(T value, bool isSuccess, string errorMessage)
            : base(isSuccess, errorMessage)
        {
            Value = value;
        }

        public static Result<T> Success(T value) => new Result<T>(value, true, null);
        public new static Result<T> Failure(string errorMessage) => new Result<T>(default, false, errorMessage);
    }
}