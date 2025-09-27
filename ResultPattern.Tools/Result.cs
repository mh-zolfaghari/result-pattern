namespace ResultPattern.Tools
{
    /// <summary>
    /// Result Pattern Base Class.
    /// </summary>
    public record Result
    {
        #region Main Props
        /// <summary>
        /// Success Result.
        /// </summary>
        public bool IsSuccess { get; private init; }


        [JsonIgnore]
        public bool IsFailure => !IsSuccess;

        /// <summary>
        /// Get Error detail when Result is Failure.
        /// </summary>
        public Error Error { get; private init; }
        #endregion

        #region Protected Ctor
        protected Result(bool isSuccess, Error error)
        {
            IsSuccess = isSuccess;
            Error = error;
        }
        #endregion

        #region Functionalities
        /// <summary>
        /// Create Failure Result with Error.
        /// </summary>
        /// <param name="error">Error object</param>
        /// <returns>Get Failute result.</returns>
        public static Result Failure(Error error) => new(false, error);

        /// <summary>
        /// Create Failure Result with Error.
        /// </summary>
        /// <typeparam name="T">Result Type</typeparam>
        /// <param name="error">Error object</param>
        /// <returns>Get Failute result.</returns>
        public static Result<T> Failure<T>(Error error) => Result<T>.Failure(error);

        /// <summary>
        /// Create Success Result without Data.
        /// </summary>
        /// <returns>Get Success result</returns>
        public static Result Success() => new(true, Error.None);

        /// <summary>
        /// Create Success Result with Data.
        /// </summary>
        /// <typeparam name="T">Typeof success data</typeparam>
        /// <param name="data">Set success Data</param>
        /// <returns>Get success result.</returns>
        public static Result<T> Success<T>(T data) => Result<T>.Success(data);
        #endregion
    }

    public record Result<T> : Result
    {
        /// <summary>
        /// Get Success Data when Result is Success.
        /// </summary>
        public T Data { get; private init; }

        #region Private Ctor
        private Result(bool isSuccess, T data, Error error) : base(isSuccess, error)
        {
            Data = data;
        }
        #endregion

        #region Functionalities
        /// <summary>
        /// Create Success Result with Data.
        /// </summary>
        /// <param name="data">Set success Data</param>
        /// <returns>Get Success result</returns>
        public static Result<T> Success(T data) => new(true, data, Error.None);


        /// <summary>
        /// Create Failure Result with Error.
        /// </summary>
        /// <param name="error">Error object</param>
        /// <returns>Get Failure result</returns>
        public new static Result<T> Failure(Error error) => new(false, default!, error);
        #endregion
    }
}
