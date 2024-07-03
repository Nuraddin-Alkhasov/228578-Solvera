using HMI.CO.General;
using HMI.Interfaces.PD;
using System.Windows;
using VisiWin.ApplicationFramework;

namespace HMI.DialogRegion.PD.Views
{
    /// <summary>
    /// Interaction logic for UserAdd.xaml
    /// </summary>
    [ExportView("EKS")]
    public partial class EKS
    {

        public EKS()
        {
            InitializeComponent();

        }
        IEKS EKSService = ApplicationService.GetService<IEKS>();
        private void Border_Loaded(object sender, RoutedEventArgs e)
        {
            new ObjectAnimator().OpenDialog(this, border);

        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            new ObjectAnimator().CloseDialog1(this, border);
        }
        private void OpenConnection_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            EKSService.OpenConnection();

        }

        private void CloseConnection_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            EKSService.CloseConnection();

        }

        private void ReadData_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            data.Value = EKSService.Read();

        }

        private void WriteData_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            EKSService.Write(data.Value.ToString());

        }

        private void UpdateStatus_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            status.Value = EKSService.GetStatus();
        }
    }
}