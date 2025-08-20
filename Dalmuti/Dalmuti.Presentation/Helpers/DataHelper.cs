using System.Text;
namespace Dalmuti.Presentation.Helpers
{
    /// <summary>
    /// 데이터 변환 관련 헬퍼클래스입니다.
    /// </summary>
    public static class DataHelper
    {
        /// <summary>
        /// 열거형 타입을 열거형 값 목록으로 변환합니다.
        /// </summary>
        /// <typeparam name="T">열거형 타입</typeparam>
        /// <returns>열거형 값 목록</returns>
        public static List<T> ToEnumValues<T>() where T : struct
            => System.Enum.GetValues(typeof(T)).Cast<T>().ToList();

        /// <summary>
        /// 로그 헤더를 정해진 크기의 문자열로 변환합니다.
        /// 최대 크기를 초과한 문자열은 제거되며, 최대 크기 미만의 문자열은 공백으로 채워집니다.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="maxBytelength">헤더 최대 크기</param>
        /// <returns>고정 크기 헤더</returns>
        public static string ToLogHeader(this string source, int maxBytelength = 20)
        {
            var sourcelength = Encoding.Default.GetByteCount(source);
            if (maxBytelength > sourcelength)
            {
                var hanCnt = Encoding.Default.GetBytes(source).Length - source.Length;
                return source.PadRight(maxBytelength - hanCnt, ' ');
            }
            else
            {
                var overCnt = Math.Ceiling((sourcelength - maxBytelength) / 2.0);
                return source.Substring(0, source.Length - (int)overCnt);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        public static string ListToString<T>(this IEnumerable<T> source)
        {
            return string.Join(",", source);
        }
    }
}
