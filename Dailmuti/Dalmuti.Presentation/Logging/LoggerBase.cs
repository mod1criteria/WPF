
namespace Dalmuti.Presentation.Logging
{
    /// <summary>
    /// 로거 베이스 클래스
    /// </summary>
    public abstract class LoggerBase : ILog
    {
        public void Write(string message)
             => Write(string.Empty, message);

        public void Write(string callerName, string message)
            => Write(string.Empty, callerName, message);

        public void Write(string className, string callerName, Exception exception, LogLevel level = LogLevel.Info)
            => Write(className, callerName, $"exception : {exception.Message}");

        public abstract void Write(string className, string callerName, string message, LogLevel level = LogLevel.Info);
       
        public abstract void ClearLog(int days = 90);

        public void JournalWrite(string message)
            => JournalWrite(message, LogLevel.Info);

        public abstract void JournalWrite(string message, LogLevel level = LogLevel.Info);
    }
}
