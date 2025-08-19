using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Threading;
using Dalmuti.Presentation.Interface;
using Dalmuti.Presentation.Logging;
using Dalmuti.Presentation.Utils;

namespace Dalmuti.Presentation.ViewModel
{
    /// <summary>
    /// ViewModel 베이스 클래스
    /// </summary>
    public abstract class ViewModelBase : BindableObject, IClear
    {
        private bool _isVisible;
        private UserControl _PopupContent;

        /// <summary>
        /// Sco 화면 컨트롤러(싱글턴 인스턴스)
        /// </summary>
        public ScreenController Controller => ScreenController.Current;

        /// <summary>
        /// ViewModel 명
        /// </summary>
        public string Name => GetType().Name;
        /// <summary>
        /// UI 디스패쳐
        /// </summary>
        public Dispatcher UIDispatcher => Application.Current.Dispatcher;
        /// <summary>
        /// View 보여짐 여부
        /// </summary>
        public virtual bool IsVisible
        {
            get { return _isVisible; }
            set { SetProperty(ref _isVisible, value); }
        }

        /// <summary>
        /// 팝업 내용
        /// </summary>
        public UserControl PopupContent
        {
            get { return _PopupContent; }
            set { SetProperty(ref _PopupContent, value); }
        }

        /// <summary>
        /// View 로드 커멘드
        /// </summary>
        public ICommand LoadViewCommand { get; }

        public ViewModelBase()
        {
            LoadViewCommand = new DelegateCommand(LoadView);
        }

        /// <summary>
        /// 비동기 테스크를 처리합니다. 
        /// 처리시 IsWaitingTask 프로퍼티가 true가 되어 View에서 사용자 입력을 제한합니다.
        /// 처리 완료 후 IsWaitingTask 프로퍼티가 false가 되어 View에서 사용자 입력이 다시 가능합니다.
        /// </summary>
        /// <typeparam name="T">반환 결과형</typeparam>
        /// <param name="execter">실행 합수</param>
        /// <returns>반환 결과값</returns>
        public async Task<T> ProcessTask<T>(Func<Task<T>> execter)
        {
            try
            {
                if (Controller.IsWaitingTask)
                    return default(T);

                Controller.IsWaitingTask = true;
                var result = await execter?.Invoke();

                return result;
            }
            catch (Exception ex)
            {
                Logger.Info($"exception : {ex.Message}");
                return default(T);
            }
            finally
            {
                Controller.IsWaitingTask = false;
            }
        }

        /// <summary>
        /// 비동기 테스크를 처리합니다. 
        /// 처리시 IsWaitingTask 프로퍼티가 true가 되어 View에서 사용자 입력을 제한합니다.
        /// 처리 완료 후 IsWaitingTask 프로퍼티가 false가 되어 View에서 사용자 입력이 다시 가능합니다.
        /// </summary>
        /// <param name="execter">실행 합수</param>
        public async Task ProcessTask(Func<Task> execter)
        {
            try
            {
                if (Controller.IsWaitingTask)
                    return;

                Controller.IsWaitingTask = true;
                await execter?.Invoke();

                return;
            }
            catch (Exception ex)
            {
                Logger.Info($"exception : {ex.Message}");
                return;
            }
            finally
            {
                Controller.IsWaitingTask = false;
            }
        }

        /// <summary>
        /// 비동기형 다이얼로그 팝업을 보여줍니다. 팝업을 닫을시 결과값을 비동기로 반환합니다.
        /// </summary>
        /// <typeparam name="TResult">반환 결과형</typeparam>
        /// <param name="viewType">팝업 View</param>
        /// <param name="viewModel">팝업 ViewModel</param>
        /// <returns></returns>
        public Task<TResult> ShowPopupContentAsync<TResult>(
           Type viewType,
           AsyncPopupViewModelBase<TResult> viewModel)
        {
            if (viewType != null)
            {
                ClearPopup();

                var userControl = Activator.CreateInstance(viewType) as UserControl;
                userControl.DataContext = viewModel;

                PopupContent = userControl;
                Logger.JournalWrite(PopupContent, "스크린 로드");

                if (userControl != null && viewModel != null)
                {
                    var tcs = new TaskCompletionSource<TResult>();
                    viewModel.DialogClose += (sender, e) =>
                    {
                        TResult result = default(TResult);
                        try
                        {
                            result = e != null ? e : default(TResult);
                        }
                        catch (Exception ex)
                        {
                            Logger.Error(ex);
                        }
                        finally
                        {
                            ClearPopup();
                            tcs.SetResult(result);
                        }
                    };

                    return tcs.Task;
                }
            }

            return Task.FromResult(default(TResult));
        }

        /// <summary>
        /// 팝업을 정리합니다.
        /// </summary>
        private void ClearPopup()
        {
            if (PopupContent != null)
            {
                if (PopupContent.DataContext != this)
                {
                    (PopupContent.DataContext as IClear)?.Clear();
                }
                PopupContent = null;
            }
        }

        /// <summary>
        /// View를 로드합니다.
        /// </summary>
        protected virtual void LoadView() { }

        public virtual void Clear() { }
    }
}