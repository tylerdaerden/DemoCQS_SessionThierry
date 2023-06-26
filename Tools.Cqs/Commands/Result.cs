namespace Tools.Cqs.Commands
{
    public class Result
    {
        public static Result Success()
        {
            return new Result(true, null);
        }

        public static Result Failure(string message)
        {
            return new Result(false, message);
        }

        public bool IsSuccess { get; init; }
        public bool IsFailure { get { return !IsSuccess; } }
        public string? Message { get; init; }

        private Result(bool isSuccess, string? message)
        {
            IsSuccess = isSuccess;
            Message = message;
        }        
    }
}