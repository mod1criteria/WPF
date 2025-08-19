using Dalmuti.Presentation.Enums;
using System.Windows.Input;

namespace Dalmuti.Presentation.ViewModel.Base
{
    /// <summary>
    /// 상태 변경 처리 핸들러
    /// </summary>
    /// <typeparam name="TState">상태</typeparam>
    /// <param name="currentState">현재 상태</param>
    /// <param name="movedDirection">상태 이동 방향</param>
    /// <param name="targetState">목표 상태</param>
    /// <param name="agrs">인자값</param>
    public delegate void StateChangedHandler<TState>(TState currentState, NavigationDirection movedDirection, TState? targetState, object agrs) where TState : struct;

    /// <summary>
    /// 상태 변경 ViewModel 베이스 클래스
    /// </summary>
    /// <typeparam name="TState"></typeparam>
    public abstract class StateViewModelBase<TState> : ViewModelBase where TState : struct
    {
        /// <summary>
        /// 상태 변경 요청 이벤트
        /// </summary>
        public event StateChangedHandler<TState> StateChangeRequested;

        /// <summary>
        /// 현재 상태
        /// </summary>
        public abstract TState State { get; }
        /// <summary>
        /// 타임아웃
        /// </summary>
        public int Timeout { get; }
        /// <summary>
        /// 타임아웃 유무 여부
        /// </summary>
        public bool HasTimeout => Timeout > 0;
        /// <summary>
        /// 타임아웃 가로채기
        /// (타임아웃 발생시 Controller에서 공통 로직으로 처리하지 않고
        ///  직접 ViewModel에서 처리할 경우 사용)
        /// </summary>
        public Action TimeoutInterceptor { get; protected set; }

        /// <summary>
        /// 다음 상태로 이동 커멘드
        /// </summary>
        public ICommand GoBackCommand { get; }
        /// <summary>
        /// 이전 상태로 이동 커멘드
        /// </summary>
        public ICommand GoNextCommand { get; }

        public StateViewModelBase(int timeout = 0)
        {
            Timeout = timeout;

            GoBackCommand = new DelegateCommand(GoBack);
            GoNextCommand = new DelegateCommand(GoNext);
        }

        /// <summary>
        /// 상태가 변경되었습니다.
        /// </summary>
        /// <param name="args"></param>
        public virtual void Navigated(StateNavigationArgs<TState> args) { }

        /// <summary>
        /// 이전 상태로 이동합니다.
        /// </summary>
        protected virtual void GoBack()
        {
            ChangeState(NavigationDirection.Back);
        }

        /// <summary>
        /// 다음 상태로 이동합니다.
        /// </summary>
        protected virtual void GoNext()
        {
            ChangeState(NavigationDirection.Next);
        }

        /// <summary>
        /// 관리자 모드로 이동합니다.
        /// </summary>
        public virtual void GoAdmin()
        {

        }

        /// <summary>
        /// 페이지 변경 이벤트 호출 함수
        /// </summary>
        /// <param name="direction">이동 방향(주체 페이지 기준)</param>
        /// <param name="targetState">목표 상태</param>
        /// <param name="args">인자값</param>
        public virtual void ChangeState(NavigationDirection direction, TState? targetState = null, object args = null)
        {
            StateChangeRequested?.Invoke(State, direction, targetState, args);
        }
    }
}
