using Dalmuti.Presentation.Enum;
using Dalmuti.Presentation.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace Dalmuti.Presentation.ViewModel
{
    public partial class ScreenController : ScreenControllerBase<DalmutiState>
    {
        #region Bindable members
        private bool _IsWaitingTask;
        #endregion

        public static ScreenController Current { get; private set; }

        /// <summary>
        /// 테스크 대기 여부(ProcessTask() 함수 실행중 여부)
        /// </summary>
        public bool IsWaitingTask
        {
            get { return _IsWaitingTask; }
            set { SetProperty(ref _IsWaitingTask, value); }
        }

        public ScreenController()
        {
        }

        public static void SetCurrentController(ScreenController controller)
        {
            if (controller == null)
                throw new ArgumentNullException();

            if (Current != null)
                throw new Exception($"already '{nameof(ScreenController)}' has been assigned");

            Current = controller;

            Logger.Info();
        }

        protected override List<StateContent<DalmutiState>> SetStateContents()
        {
            Logger.Info();

            return new List<StateContent<DalmutiState>>
            {
                
            };
        }

        public override void Initialize(DalmutiState beginnginState)
        {
            base.Initialize(beginnginState);

            Logger.Info();
        }

        protected override void OnStateChanged(DalmutiState currentState)
        {
        }
    }
}
