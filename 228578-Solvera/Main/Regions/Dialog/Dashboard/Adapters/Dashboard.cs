using HMI.CO.General;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Composition;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;
using VisiWin.ApplicationFramework;
using VisiWin.Commands;
using VisiWin.Controls;

namespace HMI.DialogRegion.Dashboard.Adapters
{

    [ExportAdapter("DR_Dashboard")]
    public class Dashboard : AdapterBase
    {
        public Dashboard()
        {
            Add = new ActionCommand(AddExecuted);
            Close = new ActionCommand(CloseExecuted);
        }

        #region - - - Properties - - -
        [ImportMany(typeof(IView))]
        public IEnumerable<Lazy<IView, IDashboardWidgetMetadata>> ImportedDashboardWidgetsLazy { get; set; }
        private readonly IRegionService iRS = ApplicationService.GetService<IRegionService>();

        public static readonly DependencyProperty AvailableDashboardWidgetsProperty = DependencyProperty.Register("AvailableDashboardWidgets", typeof(ICollectionView), typeof(Dashboard), new PropertyMetadata(null));

        public ICollectionView AvailableDashboardWidgets
        {
            get { return (ICollectionView)GetValue(AvailableDashboardWidgetsProperty); } 
            set
            {
                SetValue(AvailableDashboardWidgetsProperty, value);
            }
        }
        IDashboardWidgetMetadata _SelectedDashboardWidget;
        public IDashboardWidgetMetadata SelectedDashboardWidget
        {
            get
            {
                return _SelectedDashboardWidget;
            }
            set
            {
                _SelectedDashboardWidget = value;

                if (value != null)
                {
                    ApplicationService.SetView("DashboardPreviewRegion", value.ViewName);
                }

                OnPropertyChanged("SelectedDashboardWidget");
            }
        }
        private DashboardWidgetCommandParameter dwcp = null;
        #endregion

        #region - - - Commands - - -

        public ICommand Close { get; set; }
        private void CloseExecuted(object parameter)
        {
            ApplicationService.ObjectStore.Add("SelectedWidget", "");
            ApplicationService.ObjectStore.Remove("DWCP");
            Views.WidgetSelector v = (Views.WidgetSelector)iRS.GetView("WidgetSelector");
            new ObjectAnimator().CloseDialog1(v, v.border);
        }
        public ICommand Add { get; set; }
        public void AddExecuted(object parameter)
        {
            if (ApplicationService.ObjectStore["DWCP"] != null)
            {
                dwcp = ApplicationService.ObjectStore.GetValue("DWCP") as DashboardWidgetCommandParameter;
                ApplicationService.ObjectStore.Remove("DWCP");
            }

            if (VisiWin.Controls.Dashboard.CheckIsSizeSuitable(SelectedDashboardWidget, dwcp))
            {
                ApplicationService.ObjectStore.Add("SelectedWidget", SelectedDashboardWidget.ViewName);
                Views.WidgetSelector v = (Views.WidgetSelector)iRS.GetView("WidgetSelector");
                new ObjectAnimator().CloseDialog1(v, v.border);
            }

        }


        #endregion

        #region - - - Event handlers - - -
        protected override void OnViewLoaded(object sender, ViewLoadedEventArg e)
        {
            if (e.View.Name == "WS")
            {
                Views.WidgetSelector v = (Views.WidgetSelector)iRS.GetView("WidgetSelector");
                new ObjectAnimator().OpenDialog(v, v.border);
                FillWidgetList();
            }
            base.OnViewLoaded(sender, e);
        }

        #endregion


        #region - - - Methods - - -

        private void FillWidgetList()
        {
            ListCollectionView collectionView = new ListCollectionView(ImportedDashboardWidgetsLazy.Select(import => import.Metadata).ToList());
            if (collectionView.GroupDescriptions != null)
            {
                collectionView.GroupDescriptions.Add(new PropertyGroupDescription("Category"));
            }
            AvailableDashboardWidgets = collectionView;
        }

        #endregion

    }
}