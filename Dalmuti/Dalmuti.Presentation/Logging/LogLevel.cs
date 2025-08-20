namespace Dalmuti.Presentation.Logging
{
    /// <summary>
    /// 로그 레벨
    /// </summary>
    public enum LogLevel
    {
        /// <summary>
        /// Verbose - 모든 메세지 표시
        /// </summary>
        Verb,
        /// <summary>
        /// Information - 정보 메세지 이상 표시
        /// </summary>
        Info,
        /// <summary>
        /// Warning - 경고 이상의 메세지만 표시
        /// </summary>
        Warn,
        /// <summary>
        /// 에러 발생에대한 메세지 표시
        /// </summary>
        Error,
        /// <summary>
        /// 프로그램 동작이나 기능이 안 되는 심각한 오류 메세지
        /// </summary>
        Critical,
        /// <summary>
        /// 로그 레벨과 상관없이 항상 표시.(프로그램 시작/종료 등)
        /// </summary>
        All,
    }
}
