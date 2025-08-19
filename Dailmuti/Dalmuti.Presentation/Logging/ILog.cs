
using Dalmuti.Presentation.Logging;

namespace Dalmuti.Presentation.Logging
{
    /// <summary>
    /// 로그 인터페이스입니다.
    /// </summary>
    public interface ILog
    {
        /// <summary>
        /// 로그를 기록합니다.
        /// </summary>
        /// <param name="message">메세지</param>
        void Write(string message);
        /// <summary>
        /// 로그를 기록합니다.
        /// </summary>
        /// <param name="className">클래스명</param>
        /// <param name="callerName">호출자명</param>
        void Write(string callerName, string message);
        /// <summary>
        /// 로그를 기록합니다.
        /// </summary>
        /// <param name="className">클래스명</param>
        /// <param name="callerName">호출자명</param>
        /// <param name="message">메세지</param>
        /// <param name="logLevel">로그 레벨</param>
        void Write(string className, string callerName, string message, LogLevel logLevel = LogLevel.Info);
        /// <summary>
        /// 로그를 기록합니다.
        /// </summary>
        /// <param name="className">클래스명</param>
        /// <param name="callerName">호출자명</param>
        /// <param name="exception">예외 내용</param>
        /// <param name="logLevel">로그 레벨</param>
        void Write(string className, string callerName, Exception exception, LogLevel logLevel = LogLevel.Info);
        /// <summary>
        /// 저널 로그를 기록합니다.
        /// </summary>
        /// <param name="message">메세지</param>
        void JournalWrite(string message);
        /// <summary>
        /// 특정 기간 이전 로그를 삭제합니다.
        /// </summary>
        /// <param name="days">지정일(X 일 이전)</param>
        void ClearLog(int days = 90);
    }
}
