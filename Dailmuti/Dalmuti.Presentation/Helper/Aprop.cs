using System.Windows.Input;
using System.Windows;
using System.ComponentModel;
using System.Windows.Controls;
using System.Collections;
using System.Windows.Media;

namespace Dalmuti.Presentation.Helpers
{
    // SCO 관련 Attached Properties
    public partial class Aprop
    {
        [Category("Dalmuti")]
        [AttachedPropertyBrowsableForType(typeof(ContentControl))]
        public static string GetLeftBodyDescription(DependencyObject obj) { return (string)obj.GetValue(LeftBodyDescriptionProperty); }
        public static void SetLeftBodyDescription(DependencyObject obj, string value) { obj.SetValue(LeftBodyDescriptionProperty, value); }
        public static readonly DependencyProperty LeftBodyDescriptionProperty
            = DependencyProperty.RegisterAttached("LeftBodyDescription", typeof(string), typeof(Aprop), new PropertyMetadata(null));

        [Category("Dalmuti")]
        [AttachedPropertyBrowsableForType(typeof(ContentControl))]
        public static string GetLeftBodyTitle(DependencyObject obj) { return (string)obj.GetValue(LeftBodyTitleProperty); }
        public static void SetLeftBodyTitle(DependencyObject obj, string value) { obj.SetValue(LeftBodyTitleProperty, value); }
        public static readonly DependencyProperty LeftBodyTitleProperty
            = DependencyProperty.RegisterAttached("LeftBodyTitle", typeof(string), typeof(Aprop), new PropertyMetadata(null));

        [Category("Dalmuti")]
        [AttachedPropertyBrowsableForType(typeof(ContentControl))]
        public static UIElement GetLeftBodyContent(DependencyObject obj) { return (UIElement)obj.GetValue(LeftBodyContentProperty); }
        public static void SetLeftBodyContent(DependencyObject obj, UIElement value) { obj.SetValue(LeftBodyContentProperty, value); }
        public static readonly DependencyProperty LeftBodyContentProperty =
            DependencyProperty.RegisterAttached("LeftBodyContent", typeof(UIElement), typeof(Aprop), new PropertyMetadata(null));

        [Category("Dalmuti")]
        [AttachedPropertyBrowsableForType(typeof(ContentControl))]
        public static UIElement GetBottomContent(DependencyObject obj) { return (UIElement)obj.GetValue(BottomContentProperty); }
        public static void SetBottomContent(DependencyObject obj, UIElement value) { obj.SetValue(BottomContentProperty, value); }
        public static readonly DependencyProperty BottomContentProperty =
            DependencyProperty.RegisterAttached("BottomContent", typeof(UIElement), typeof(Aprop), new PropertyMetadata(null));

        [Category("Dalmuti")]
        [AttachedPropertyBrowsableForType(typeof(ContentControl))]
        public static UIElement GetRightBodyContent(DependencyObject obj) { return (UIElement)obj.GetValue(RightBodyContentProperty); }
        public static void SetRightBodyContent(DependencyObject obj, UIElement value) { obj.SetValue(RightBodyContentProperty, value); }
        public static readonly DependencyProperty RightBodyContentProperty =
            DependencyProperty.RegisterAttached("RightBodyContent", typeof(UIElement), typeof(Aprop), new PropertyMetadata(null));

        [AttachedPropertyBrowsableForType(typeof(Button))]
        [AttachedPropertyBrowsableForType(typeof(ProgressBar))]
        public static CornerRadius GetCornerRadius(DependencyObject obj) { return (CornerRadius)obj.GetValue(CornerRadiusProperty); }
        public static void SetCornerRadius(DependencyObject obj, CornerRadius value) { obj.SetValue(CornerRadiusProperty, value); }
        public static readonly DependencyProperty CornerRadiusProperty =
            DependencyProperty.RegisterAttached("CornerRadius", typeof(CornerRadius), typeof(Aprop), new PropertyMetadata(new CornerRadius(0)));

        [AttachedPropertyBrowsableForType(typeof(Button))]
        public static Brush GetBorderBrush(DependencyObject obj){return (Brush)obj.GetValue(BorderBrushProperty);}
        public static void SetBorderBrush(DependencyObject obj, Brush value){obj.SetValue(BorderBrushProperty, value);}
        public static readonly DependencyProperty BorderBrushProperty =
            DependencyProperty.RegisterAttached("BorderBrush", typeof(Brush), typeof(Aprop), new PropertyMetadata(null));

        [AttachedPropertyBrowsableForType(typeof(Button))]
        public static Thickness GetBorderThickness(DependencyObject obj){return (Thickness)obj.GetValue(BorderThicknessProperty);}
        public static void SetBorderThickness(DependencyObject obj, Thickness value){obj.SetValue(BorderThicknessProperty, value);}
        public static readonly DependencyProperty BorderThicknessProperty =
            DependencyProperty.RegisterAttached("BorderThickness", typeof(Thickness), typeof(Aprop), new PropertyMetadata(default(Thickness)));

        [Category("Dalmuti")]
        [AttachedPropertyBrowsableForType(typeof(ContentControl))]
        public static ICommand GetCommand(DependencyObject obj) { return (ICommand)obj.GetValue(CommandProperty); }
        public static void SetCommand(DependencyObject obj, ICommand value) { obj.SetValue(CommandProperty, value); }
        public static readonly DependencyProperty CommandProperty =
            DependencyProperty.RegisterAttached("Command", typeof(ICommand), typeof(Aprop), new PropertyMetadata(null));

        [Category("Dalmuti")]
        [AttachedPropertyBrowsableForType(typeof(ContentControl))]
        public static string GetContentText(DependencyObject obj) { return (string)obj.GetValue(ContentTextProperty); }
        public static void SetContentText(DependencyObject obj, string value) { obj.SetValue(ContentTextProperty, value); }
        public static readonly DependencyProperty ContentTextProperty =
            DependencyProperty.RegisterAttached("ContentText", typeof(string), typeof(Aprop), new PropertyMetadata(null));

        [Category("Dalmuti")]
        [AttachedPropertyBrowsableForType(typeof(ContentControl))]
        public static string GetWatermarkText(DependencyObject obj) { return (string)obj.GetValue(WatermarkTextProperty); }
        public static void SetWatermarkText(DependencyObject obj, string value) { obj.SetValue(WatermarkTextProperty, value); }
        public static readonly DependencyProperty WatermarkTextProperty =
            DependencyProperty.RegisterAttached("WatermarkText", typeof(string), typeof(Aprop), new PropertyMetadata(null));

        [Category("Dalmuti")]
        [AttachedPropertyBrowsableForType(typeof(ContentControl))]
        public static string GetDescription(DependencyObject obj) { return (string)obj.GetValue(DescriptionProperty); }
        public static void SetDescription(DependencyObject obj, string value) { obj.SetValue(DescriptionProperty, value); }
        public static readonly DependencyProperty DescriptionProperty =
            DependencyProperty.RegisterAttached("Description", typeof(string), typeof(Aprop), new PropertyMetadata(null));

        [Category("Dalmuti")]
        [AttachedPropertyBrowsableForType(typeof(ContentControl))]
        public static string GetCurrencySymbol(DependencyObject obj) { return (string)obj.GetValue(CurrencySymbolProperty); }
        public static void SetCurrencySymbol(DependencyObject obj, string value) { obj.SetValue(CurrencySymbolProperty, value); }
        public static readonly DependencyProperty CurrencySymbolProperty =
            DependencyProperty.RegisterAttached("CurrencySymbol", typeof(string), typeof(Aprop), new PropertyMetadata(string.Empty));
    
        [Category("Dalmuti")]
        [AttachedPropertyBrowsableForType(typeof(Calendar))]
        public static IEnumerable GetSelectedDateList(DependencyObject obj) { return (IEnumerable)obj.GetValue(SelectedDateListProperty); }
        public static void SetSelectedDateList(DependencyObject obj, string value) { obj.SetValue(SelectedDateListProperty, value); }
        public static readonly DependencyProperty SelectedDateListProperty
            = DependencyProperty.RegisterAttached("SelectedDateList", typeof(IEnumerable), typeof(Aprop), new PropertyMetadata(new PropertyChangedCallback(OnItemsSourcePropertyChanged)));

        private static void OnItemsSourcePropertyChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            var control = sender as Calendar;
            if (control != null && e.NewValue != null)
            {
                control.SelectedDates.Clear();
                foreach (var datetime in e.NewValue as IEnumerable)
                {
                    control.SelectedDates.Add((DateTime)datetime);
                }
            }
        }

        [Category("Dalmuti")]
        public static bool GetIsCallStaffEnabled(DependencyObject obj){return (bool)obj.GetValue(IsCallStaffEnabledProperty);}
        public static void SetIsCallStaffEnabled(DependencyObject obj, bool value){obj.SetValue(IsCallStaffEnabledProperty, value);}
        public static readonly DependencyProperty IsCallStaffEnabledProperty =
            DependencyProperty.RegisterAttached("IsCallStaffEnabled", typeof(bool), typeof(Aprop), new PropertyMetadata(true));

        [Category("Dalmuti")]
        [AttachedPropertyBrowsableForType(typeof(UserControl))]
        public static string GetJournalTitle(DependencyObject obj){return (string)obj.GetValue(JournalTitleProperty);}
        public static void SetJournalTitle(DependencyObject obj, string value){obj.SetValue(JournalTitleProperty, value);}
        public static readonly DependencyProperty JournalTitleProperty =
            DependencyProperty.RegisterAttached("JournalTitle", typeof(string), typeof(Aprop), new PropertyMetadata(null));
    }
}