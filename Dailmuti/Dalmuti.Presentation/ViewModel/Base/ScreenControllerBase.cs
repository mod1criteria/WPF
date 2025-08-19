using Dalmuti.Presentation.Enums;
using Dalmuti.Presentation.Logging;
using Dalmuti.Presentation.Utils;
using Dalmuti.Presentation.ViewModel.Base;
using System.Windows;

namespace Dalmuti.Presentation.ViewModel
{
    /// <summary>
    /// 화면 컨트롤러 베이스 클래스
    /// </summary>
    /// <typeparam name="TState">상태</typeparam>
    public abstract class ScreenControllerBase<TState> : BindableObject where TState : struct
    {
        #region Binding Property Members
        private StateViewModelBase<TState> _CurrentStateViewModel;
        private FrameworkElement _MainScreen;
        #endregion

        /// <summary>
        /// 현재 ScoState ViewModel
        /// </summary>
        public StateViewModelBase<TState> CurrentStateViewModel
        {
            get { return _CurrentStateViewModel; }
            set { SetProperty(ref _CurrentStateViewModel, value); }
        }

        /// <summary>
        /// 상태 내용 리스트
        /// </summary>
        public List<StateContent<TState>> StateList { get; private set; }

        /// <summary>
        /// 현재 상태
        /// </summary>
        public TState CurrentState => CurrentStateViewModel.State;

        /// <summary>
        /// 현재 표출될 화면
        /// </summary>
        public FrameworkElement MainScreen
        {
            get { return _MainScreen; }
            set { SetProperty(ref _MainScreen, value); }
        }

        /// <summary>
        /// 초기화합니다.
        /// </summary>
        /// <param name="beginnginState">시작 상태</param>
        public virtual void Initialize(TState beginnginState)
        {
            StateList = SetStateContents();
            StateList.ForEach(state => state.ViewModel.StateChangeRequested += OnStateChangeRequested);
            var bState = StateList.FirstOrDefault(i => i.State.Equals(beginnginState));
            MainScreen = bState.GenerateView();
            CurrentStateViewModel = bState.ViewModel;
            CurrentStateViewModel.Navigated(new StateNavigationArgs<TState>(CurrentStateViewModel.State, NavigationDirection.Next, null));
            Logger.Info();
        }

        /// <summary>
        /// 상태 내용을 설정합니다.
        /// </summary>
        /// <returns></returns>
        protected abstract List<StateContent<TState>> SetStateContents();

        /// <summary>
        /// 페이지 이동 이벤트
        /// </summary>
        /// <param name="currentState">변경 주체 페이지</param>
        /// <param name="movedDirection">이동 방향(주체 페이지 기준)</param>
        /// <param name="targetState">이동 대상 상태</param>
        /// <param name="args">전달 인자</param>
        protected void OnStateChangeRequested(TState currentState,
                                              NavigationDirection movedDirection,
                                              TState? targetState = null,
                                              object args = null)
        {
            StateContent<TState> current = StateList.First(e => e.State.Equals(currentState));
            StateContent<TState> next = targetState == null ? null : StateList.First(e => e.State.Equals(targetState));

            if (next == null)
            {
                switch (movedDirection)
                {
                    case NavigationDirection.Next:
                        {
                            next = currentState.Equals(StateList.Last().State)
                                ? StateList.First()
                                : StateList[StateList.IndexOf(current) + 1];
                        }

                        break;
                    case NavigationDirection.Back:
                        {
                            next = currentState.Equals(StateList.First().State)
                                ? current
                                : StateList[StateList.IndexOf(current) - 1];
                        }
                        break;
                }
            }

            if (next != null)
            {
                Logger.Info($"[{currentState}] =====> [{next.State}] , direction : {movedDirection}");     
                SetController(next);
                next.ViewModel.Navigated(new StateNavigationArgs<TState>(currentState, movedDirection, args));
            }
        }

        /// <summary>
        /// 컨트롤러를 요청된 상태 내용으로 설정합니다.
        /// </summary>
        /// <param name="control"></param>
        private void SetController(StateContent<TState> control)
        {
            CurrentStateViewModel.Clear();
            CurrentStateViewModel = control.ViewModel;          
            MainScreen = control.GenerateView();
            Logger.JournalWrite(MainScreen, "스크린 로드");
            OnStateChanged(CurrentState);
        }

        /// <summary>
        /// 상태가 변경되었습니다.
        /// </summary>
        /// <param name="currentState">변경된 상태</param>
        protected abstract void OnStateChanged(TState currentState);
    }
}
