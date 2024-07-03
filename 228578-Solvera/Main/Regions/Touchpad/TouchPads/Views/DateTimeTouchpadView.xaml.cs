using System;
using System.Windows;
using VisiWin.Controls;
using VisiWin.ApplicationFramework;
using VisiWin.Language;
using HMI.CO.General;

namespace HMI.TouchpadRegion
{
    [ExportView("DateTimeTouchpadView")]
    public partial class DateTimeTouchpadView
    {
        private DateTimeVarIn selectedDateTimeVarIn;
        private readonly ILanguageService languageService;
        private bool twelveHourMode;
        private bool dayHalfSelctionVisible;
        private bool hourInputVisible;
        private bool minuteInputVisible;
        private bool secondInputVisible;



        public DateTimeTouchpadView()
        {
            InitializeComponent();

            if (!ApplicationService.IsInDesignMode)
            {
                languageService = ApplicationService.GetService<ILanguageService>();
            }
        }


        private void View_Loaded(object sender, RoutedEventArgs e)
        {
            string CHANNELNAME_TOUCHTARGET = "vw:TouchTarget";

            if (ApplicationService.ObjectStore.ContainsKey(CHANNELNAME_TOUCHTARGET))
            {
                var varIn = ApplicationService.ObjectStore.GetValue(CHANNELNAME_TOUCHTARGET);
                if (varIn is DateTimeVarIn)
                {
                    selectedDateTimeVarIn = varIn as DateTimeVarIn;

                    if (!String.IsNullOrEmpty(selectedDateTimeVarIn.LabelText))
                        lblPadDescription.Text = selectedDateTimeVarIn.LabelText;

                    if (selectedDateTimeVarIn.DateTimeMode == VisiWin.Language.DateTimeMode.DateOnly)
                        TimePanel.Visibility = System.Windows.Visibility.Collapsed;
                    else
                        TimePanel.Visibility = System.Windows.Visibility.Visible;

                    if (selectedDateTimeVarIn.DateTimeMode == VisiWin.Language.DateTimeMode.TimeOnly)
                        calendar.Visibility = System.Windows.Visibility.Collapsed;
                    else
                        calendar.Visibility = System.Windows.Visibility.Visible;

                    string timeFormatStringID = String.Format("@[ClientSystem].Components.Time.TimeFormats.{0}", selectedDateTimeVarIn.FormatTime.Substring(1));
                    string timeFormatString = languageService.GetText(timeFormatStringID);

                    twelveHourMode = timeFormatString.Contains("h");
                    dayHalfSelctionVisible = timeFormatString.Contains("t");
                    hourInputVisible = timeFormatString.Contains("h") || timeFormatString.Contains("H");
                    minuteInputVisible = timeFormatString.Contains("m");
                    secondInputVisible = timeFormatString.Contains("s");

                    DateTime currentValue = selectedDateTimeVarIn.Value;

                    calendar.SelectedDate = currentValue.Date;
                    calendar.DisplayDate = currentValue.Date;
                    hourInput.Value = currentValue.Hour;
                    minuteInput.Value = currentValue.Minute;
                    secondInput.Value = currentValue.Second;

                    hourInput.Visibility = hourInputVisible ? Visibility.Visible : Visibility.Collapsed;
                    minuteInput.Visibility = minuteInputVisible ? Visibility.Visible : Visibility.Collapsed;
                    secondInput.Visibility = secondInputVisible ? Visibility.Visible : Visibility.Collapsed;

                    cboDayHalfSelection.Visibility = dayHalfSelctionVisible ? Visibility.Visible : Visibility.Collapsed;

                    if (twelveHourMode)
                    {
                        if (currentValue.Hour == 0)
                        {
                            hourInput.Value = 12;
                            cboDayHalfSelection.SelectedIndex = 0;
                        }
                        else if (currentValue.TimeOfDay.CompareTo(new TimeSpan(12, 0, 0)) < 0)
                            cboDayHalfSelection.SelectedIndex = 0;
                        else
                            cboDayHalfSelection.SelectedIndex = 1;

                        hourInput.RawLimitMin = 1;
                        hourInput.RawLimitMax = 12;

                        if (hourInput.Value > 12)
                            hourInput.Value -= 12;
                    }
                    else
                    {
                        hourInput.RawLimitMin = 0;
                        hourInput.RawLimitMax = 23;
                    }
                }
            }
            new ObjectAnimator().OpenKeyboard(this, border);

        }

        private void TouchKeyboard_Close(object sender, RoutedEventArgs e)
        {
            new ObjectAnimator().CloseKeyboard(this, border);
        }

        private void BtnEnter_Click(object sender, RoutedEventArgs e)
        {
            DateTime dt = calendar.SelectedDate.Value;

            if (twelveHourMode)
            {
                if (hourInput.Value == 12)
                {
                    if (cboDayHalfSelection.SelectedIndex == 0)
                    {
                        dt = dt.AddHours(0);
                    }
                    else
                    {
                        dt = dt.AddHours(12);
                    }
                }
                else
                {
                    if (cboDayHalfSelection.SelectedIndex == 0)
                    {
                        dt = dt.AddHours(hourInput.Value);
                    }
                    else
                    {
                        dt = dt.AddHours(hourInput.Value + 12);
                    }
                }
            }
            else
            {
                dt = dt.AddHours(hourInput.Value);
            }

            dt = dt.AddMinutes(minuteInput.Value);
            dt = dt.AddSeconds(secondInput.Value);

            selectedDateTimeVarIn.StartEdit();
            selectedDateTimeVarIn.Text = dt.ToString(System.Globalization.CultureInfo.CurrentCulture);
            selectedDateTimeVarIn.StopEditAsync(true);

            new ObjectAnimator().CloseKeyboard(this, border);
        }

    }
}