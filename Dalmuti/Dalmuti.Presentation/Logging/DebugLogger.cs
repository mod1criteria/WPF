using System.Diagnostics;

namespace Dalmuti.Presentation.Logging
{
    /// <summary>
    /// 디버깅 모드 전용 로거입니다.
    /// </summary>
    public class DebugLogger : ILog
    {
        public void Write(string message)
             => Write(string.Empty, message);

        public void Write(string callerName, string message)
            => Write(string.Empty, callerName, message);

        public void Write(string className, string callerName, Exception exception, LogLevel level = LogLevel.Info)
            => Write(className, callerName, $"exception : {exception.Message}");

        public void Write(string className, string callerName, string message, LogLevel level = LogLevel.Info)
        {
#if DEBUG
            var data = $"[{DateTime.Now.ToString("yy-MM-dd HH:mm:ss.fff")}]" +
                       $"[{className}\t]" +
                       $"[{callerName}\t]" +
                       $"[{level}\t] " +
                       $"{message}";
            Debug.WriteLine(data);
#endif
        }

        public void ClearLog(int days)
        {
            
        }

        public void JournalWrite(string message)
        {

#if DEBUG
            Debug.WriteLine(message);
#endif
        }
    }
}
