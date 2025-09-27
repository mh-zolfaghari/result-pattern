namespace ResultPattern.Tools
{
    /// <summary>
    /// Error Model for Result Pattern.
    /// </summary>
    public record Error
    {
        /// <summary>
        /// No Error and No Warning
        /// </summary>
        public static readonly Error None = new(string.Empty, string.Empty, ErrorType.None);

        public static implicit operator Result(Error error) => Result.Failure(error);

        #region Private Ctor
        private Error(string code, string message, ErrorType type, object? metaData = null)
        {
            Code = code;
            Message = message;
            Type = type;
            MetaData = metaData;
        }
        #endregion

        #region Props
        /// <summary>
        /// Error Code
        /// </summary>
        public string Code { get; private init; }

        /// <summary>
        /// Error Message
        /// </summary>
        public string Message { get; private init; }

        /// <summary>
        /// Error Type
        /// </summary>
        public ErrorType Type { get; private init; }

        /// <summary>
        /// Error Meta Data (Additional Information).
        /// </summary>
        public object? MetaData { get; private init; }
        #endregion


        #region Handing ErrorTypes
        /// <summary>
        /// Validation Error.
        /// </summary>
        /// <param name="code">Validation error code</param>
        /// <param name="message">Validation error message</param>
        /// <returns>Error Object</returns>
        public static Error Validation(string code, string message) => new(code, message, ErrorType.Validation);

        /// <summary>
        /// Validation Error.
        /// </summary>
        /// <param name="code">Validation error code</param>
        /// <param name="message">Validation error message</param>
        /// <param name="metaData">Validation error metaData (Additional Information).</param>
        /// <returns>Error Object</returns>
        public static Error Validation(string code, string message, object metaData) => new(code, message, ErrorType.Validation, metaData);

        /// <summary>
        /// Unauthorized Error.
        /// </summary>
        /// <param name="code">Unauthorized error code</param>
        /// <param name="message">Unauthorized error message</param>
        /// <returns>Error Object</returns>
        public static Error UnAuthorized(string code, string message) => new(code, message, ErrorType.Unauthorized);

        /// <summary>
        /// Unauthorized Error.
        /// </summary>
        /// <param name="code">Unauthorized error code</param>
        /// <param name="message">Unauthorized error message</param>
        /// <param name="metaData">Unauthorized error metaData (Additional Information).</param>
        /// <returns>Error Object</returns>
        public static Error UnAuthorized(string code, string message, object metaData) => new(code, message, ErrorType.Unauthorized, metaData);

        /// <summary>
        /// Forbbiden Error.
        /// </summary>
        /// <param name="code">Forbbiden error code</param>
        /// <param name="message">Forbbiden error message</param>
        /// <returns>Error Object</returns>
        public static Error Forbidden(string code, string message) => new(code, message, ErrorType.Forbidden);

        /// <summary>
        /// Forbbiden Error.
        /// </summary>
        /// <param name="code">Forbbiden error code</param>
        /// <param name="message">Forbbiden error message</param>
        /// <param name="metaData">Forbbiden error metaData (Additional Information).</param>
        /// <returns>Error Object</returns>
        public static Error Forbidden(string code, string message, object metaData) => new(code, message, ErrorType.Forbidden, metaData);

        /// <summary>
        /// NotFound Error.
        /// </summary>
        /// <param name="code">NotFound error code</param>
        /// <param name="message">NotFound error message</param>
        /// <returns>Error Object</returns>
        public static Error NotFound(string code, string message) => new(code, message, ErrorType.NotFound);

        /// <summary>
        /// NotFound Error.
        /// </summary>
        /// <param name="code">NotFound error code</param>
        /// <param name="message">NotFound error message</param>
        /// <param name="metaData">NotFound error metaData (Additional Information).</param>
        /// <returns>Error Object</returns>
        public static Error NotFound(string code, string message, object metaData) => new(code, message, ErrorType.NotFound, metaData);

        /// <summary>
        /// Conflict Error.
        /// </summary>
        /// <param name="code">Conflict error code</param>
        /// <param name="message">Conflict error message</param>
        /// <returns>Error Object</returns>
        public static Error Conflict(string code, string message) => new(code, message, ErrorType.Conflict);

        /// <summary>
        /// Conflict Error.
        /// </summary>
        /// <param name="code">Conflict error code</param>
        /// <param name="message">Conflict error message</param>
        /// <param name="metaData">Conflict error metaData (Additional Information).</param>
        /// <returns>Error Object</returns>
        public static Error Conflict(string code, string message, object metaData) => new(code, message, ErrorType.Conflict, metaData);

        /// <summary>
        /// Failure Error.
        /// </summary>
        /// <param name="code">Failure error code</param>
        /// <param name="message">Failure error message</param>
        /// <returns>Error Object</returns>
        public static Error Failure(string code, string message) => new(code, message, ErrorType.Failure);

        /// <summary>
        /// Failure Error.
        /// </summary>
        /// <param name="code">Failure error code</param>
        /// <param name="message">Failure error message</param>
        /// <param name="metaData">Failure error metaData (Additional Information).</param>
        /// <returns>Error Object</returns>
        public static Error Failure(string code, string message, object metaData) => new(code, message, ErrorType.Failure, metaData);

        /// <summary>
        /// UnprocessableEntity Error.
        /// </summary>
        /// <param name="code">UnprocessableEntity error code</param>
        /// <param name="message">UnprocessableEntity error message</param>
        /// <returns>Error Object</returns>
        public static Error UnprocessableEntity(string code, string message) => new(code, message, ErrorType.UnprocessableEntity);

        /// <summary>
        /// UnprocessableEntity Error.
        /// </summary>
        /// <param name="code">UnprocessableEntity error code</param>
        /// <param name="message">UnprocessableEntity error message</param>
        /// <param name="metaData">UnprocessableEntity error metaData (Additional Information).</param>
        /// <returns>Error Object</returns>
        public static Error UnprocessableEntity(string code, string message, object metaData) => new(code, message, ErrorType.UnprocessableEntity, metaData);

        /// <summary>
        /// TooManyRequests Error.
        /// </summary>
        /// <param name="code">TooManyRequests error code</param>
        /// <param name="message">TooManyRequests error message</param>
        /// <returns>Error Object</returns>
        public static Error TooManyRequests(string code, string message) => new(code, message, ErrorType.TooManyRequests);

        /// <summary>
        /// TooManyRequests Error.
        /// </summary>
        /// <param name="code">TooManyRequests error code</param>
        /// <param name="message">TooManyRequests error message</param>
        /// <param name="metaData">TooManyRequests error metaData (Additional Information).</param>
        /// <returns>Error Object</returns>
        public static Error TooManyRequests(string code, string message, object metaData) => new(code, message, ErrorType.TooManyRequests, metaData);

        /// <summary>
        /// ServiceUnavailable Error.
        /// </summary>
        /// <param name="code">ServiceUnavailable error code</param>
        /// <param name="message">ServiceUnavailable error message</param>
        /// <returns>Error Object</returns>
        public static Error ServiceUnavailable(string code, string message) => new(code, message, ErrorType.ServiceUnavailable);

        /// <summary>
        /// ServiceUnavailable Error.
        /// </summary>
        /// <param name="code">ServiceUnavailable error code</param>
        /// <param name="message">ServiceUnavailable error message</param>
        /// <param name="metaData">ServiceUnavailable error metaData (Additional Information).</param>
        /// <returns>Error Object</returns>
        public static Error ServiceUnavailable(string code, string message, object metaData) => new(code, message, ErrorType.ServiceUnavailable, metaData);
        #endregion
    }
}
