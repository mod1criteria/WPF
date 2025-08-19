using Dalmuti.Presentation.Helpers;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Windows;

namespace Dalmuti.Presentation.Logging
{
    /// <summary>
    /// 로거 정적 클래스
    /// </summary>
    public static class Logger
    {
        /// <summary>
        /// 현재 로거
        /// </summary>
        public static ILog CurrentLogger { get; set; } = new DebugLogger();
        /// <summary>
        /// 현재 저널 로거
        /// </summary>
        public static ILog CurrentJournalLogger { get; set; } = new DebugLogger();

        /// <summary>
        /// 에러를 로깅합니다.
        /// </summary>
        /// <param name="ex">예외 객체</param>
        public static void Error(Exception ex)
        {
            try
            {
                StackTrace stackTrace = new StackTrace();
                var method = stackTrace.GetFrame(1).GetMethod();
                Write(method.ReflectedType.Name, method.Name, $"exception : {ex.Message}", LogLevel.Error);
            }
            catch
            {
                Write(string.Empty, string.Empty, $"exception : {ex.Message}");
            }
        }

        /// <summary>
        /// 정보를 로깅합니다.
        /// </summary>
        /// <param name="message">메세지</param>
        public static void Info(string message = "")
        {
            try
            {
                StackTrace stackTrace = new StackTrace();
                var method = stackTrace.GetFrame(1).GetMethod();
                Write(method.ReflectedType.Name, method.Name, message);
            }
            catch
            {
                Write(string.Empty, string.Empty, message);
            }
        }

        public static void AWrite(string name, bool isSuccess, string message, string className = "", LogLevel level = LogLevel.Warn, [CallerMemberName] string callerName = "", [CallerLineNumber] int lineNumber = 0)
        {
            try
            {
                if (isSuccess)
                {
                    name = $"{name}:Success";
                    level = LogLevel.Info;
                }
                else
                {
                    name = $"{name}:Fail => message:{message}";
                    level = LogLevel.Error;
                }

                callerName = $"{callerName}({lineNumber.ToString()})";
                Write(className, callerName, name, level);
            }
            catch
            {
                Write(string.Empty, string.Empty, message);
            }
        }

        public static void AWrite(string message, string className = "", LogLevel level = LogLevel.Info, [CallerMemberName] string callerName = "", [CallerLineNumber] int lineNumber = 0)
        {
            try
            {
                callerName = $"{callerName}({lineNumber.ToString()})";
                Write(className, callerName, message, level);
            }
            catch
            {
                Write(string.Empty, string.Empty, message);
            }
        }

        public static void Write(string callerName, string message)
            => Write(string.Empty, callerName, message);

        public static void Write(string className, string callerName, string message)
            => Write(className, callerName, message, LogLevel.Info);

        public static void Write(string className, string callerName, Exception exception, LogLevel level = LogLevel.Info)
            => Write(className, callerName, $"exception : {exception.Message}");

        public static void Write(string className, string callerName, string message, LogLevel level = LogLevel.Info)
        {
            if (CurrentLogger != null)
                CurrentLogger.Write(className, callerName, message, level);
            else
                Debug.WriteLine($"[{nameof(Logger)}] No CurrentLogger : please set logging instance");
        }
        
        /// <summary>
        /// 저널을 로깅합니다.
        /// </summary>
        /// <param name="view">대상 view</param>
        /// <param name="message">메세지</param>
        public static void JournalWrite(FrameworkElement view, string message)
        {
            if (CurrentJournalLogger != null)
            {
                string name = view.GetValue(Aprop.JournalTitleProperty)?.ToString();
                if (!string.IsNullOrWhiteSpace(name))
                {
                    message = $"[{name.ToLogHeader()}] {view.GetType().Name} {message}";
                    CurrentJournalLogger.JournalWrite(message);
                }
                else
                {
                    CurrentJournalLogger.JournalWrite($"title empty  {view.GetType().Name}");
                }
            }
        }

        /// <summary>
        /// 저널을 로깅합니다.
        /// </summary>
        /// <param name="title">타이틀</param>
        /// <param name="message">메세지</param>
        public static void JournalWrite(string title, string message = "")
        {
            message = $"[{title.ToLogHeader()}] {message}";
            CurrentJournalLogger.JournalWrite(message);
        }

        /// <summary>
        /// 로그를 정리합니다.
        /// </summary>
        public static void ClearLog() => CurrentLogger?.ClearLog();
    }
}
