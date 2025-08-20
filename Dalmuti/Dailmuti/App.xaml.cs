using System.Configuration;
using System.Data;
using System.Windows;
using Dalmuti.Presentation.Enum;
using Dalmuti.Presentation.ViewModel;

namespace Dalmuti;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);

        ScreenController.SetCurrentController(App.Current.Resources["ScreenController"] as ScreenController);
        ScreenController.Current.Initialize(DalmutiState.Starting);
    }
}