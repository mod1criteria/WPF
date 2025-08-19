
using Dalmuti.Presentation.Enums;

namespace Dalmuti.Presentation.ViewModel
{
    /// <summary>
    /// 상태 네비게이션 인자 클래스
    /// </summary>
    /// <typeparam name="TState"></typeparam>
    public class StateNavigationArgs<TState> where TState : struct
    {
        public StateNavigationArgs(TState priviousState,
                                   NavigationDirection direction,
                                   object arguments)
        {
            PreviousState = priviousState;
            Direction = direction;
            Arguments = arguments;
        }

        /// <summary>
        /// 이전 상태
        /// </summary>
        public TState PreviousState { get; }
        /// <summary>
        /// 네비게이션 방향
        /// </summary>
        public NavigationDirection Direction { get; }
        /// <summary>
        /// 인자값
        /// </summary>
        public object Arguments { get; }
    }
}