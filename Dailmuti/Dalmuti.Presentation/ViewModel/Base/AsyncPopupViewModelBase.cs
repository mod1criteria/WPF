namespace Dalmuti.Presentation.ViewModel
{
    /// <summary>
    /// 팝업 다이얼로그 이벤드 처리기
    /// </summary>
    /// <typeparam name="T">발생 이벤트 타입</typeparam>
    /// <param name="sender"></param>
    /// <param name="e">발생 이벤트 전달값</param>
    public delegate void DialogEventHandler<T>(object sender, T e);

    /// <summary>
    /// 비동기 팝업 ViewModel 베이스 클래스
    /// </summary>
    /// <typeparam name="TResult">발생 이벤트 결과값</typeparam>
    public abstract class AsyncPopupViewModelBase<TResult> : ViewModelBase
    {
        /// <summary>
        /// 팝업 다이얼로그 닫힘 이벤트
        /// </summary>
        public event DialogEventHandler<TResult> DialogClose;

        /// <summary>
        /// 팝업을 닫습니다
        /// </summary>
        /// <param name="result">전달 결과값</param>
        public virtual void Close(TResult result)
        {
            DialogClose?.Invoke(this, result);
        }
    }
}