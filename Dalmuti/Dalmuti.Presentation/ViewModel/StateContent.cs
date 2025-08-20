using Dalmuti.Presentation.Logging;
using Dalmuti.Presentation.ViewModel.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Dalmuti.Presentation.ViewModel
{
    public class StateContent<TState> where TState : struct
    {
        /// <summary>
        /// 상태 View 타입
        /// </summary>
        public Type ViewType { get; private set; }
        /// <summary>
        /// ScoState ViewModel
        /// </summary>
        public StateViewModelBase<TState> ViewModel { get; private set; }
        /// <summary>
        /// 상태값
        /// </summary>
        public TState State => ViewModel.State;

        /// <summary>
        /// 상태 내용을 등록합니다.
        /// </summary>
        /// <param name="viewType">상태 View 타입</param>
        /// <param name="viewModel">상태값</param>
        /// <returns>상태 내용</returns>
        public static StateContent<TState> Register(Type viewType, StateViewModelBase<TState> viewModel)
        {
            return new StateContent<TState> { ViewType = viewType, ViewModel = viewModel };
        }

        /// <summary>
        /// 현재 상태 View를 생성한 후, ViewModel을 바인딩하여 반환합니다.
        /// </summary>
        /// <returns></returns>
        public UserControl GenerateView()
        {
            var stateView = (UserControl)Activator.CreateInstance(ViewType);
            stateView.DataContext = ViewModel;
            Logger.Info($"{ViewType} - {ViewModel}");
            return stateView;
        }
    }
}
