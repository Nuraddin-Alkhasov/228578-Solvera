using HMI.CO.General;
using HMI.CO.Recipe;
using HMI.Resources.UserControls;
using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using VisiWin.ApplicationFramework;
using VisiWin.UserManagement;
using WpfAnimatedGif;

namespace HMI.MainRegion.Recipes.Views
{

    [ExportView("Recipes_MR")]
    public partial class Recipes_MR
    {


        public Recipes_MR()
        {
            InitializeComponent();
            DataContext = new Adapters.Recipes_MR();

            BitmapImage image = new BitmapImage();
            image.BeginInit();
            image.UriSource = new Uri(new Resources.LocalResources().Paths.LoadingGif);
            image.EndInit();
            ImageBehavior.SetAnimatedSource(gif1, image);
            ImageBehavior.SetAnimatedSource(gif2, image);


        }


        #region - - - Event Handlers - - -


        Point _A_lastTapLocation_;
        Point _C_lastTapLocation_;

        private void AList_TouchDown(object sender, System.Windows.Input.TouchEventArgs e)
        {
            _A_lastTapLocation_ = e.GetTouchPoint(this).Position;
        }
        private void AList_PreviewTouchMove(object sender, TouchEventArgs e)
        {
            if (dgv_a.SelectedIndex != -1)
            {
                RecalculatePosition(_A_lastTapLocation_, e.GetTouchPoint(this).Position, "A");
            }
        }

        private void AList_PreviewTouchUp(object sender, TouchEventArgs e)
        {
            if (ArticleList.IsChecked == true && ((MR_Article)article.Content).A.IsChecked == true)
            {
                if (IsOverSelectedStep(DragItem.PointToScreen(new Point(0d, 0d)), "A"))
                {
                    ItemDrop((Article)dgv_a.SelectedItem, "A");
                }
            }
            DragItem.Visibility = Visibility.Hidden;
        }

        private void AList_PreviewMouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (ArticleList.IsChecked == true)
            {
                ItemDrop((Article)dgv_a.SelectedItem, "A");
            }
        }

        private void CList_TouchDown(object sender, System.Windows.Input.TouchEventArgs e)
        {
            _C_lastTapLocation_ = e.GetTouchPoint(this).Position;
        }
        private void CList_PreviewTouchMove(object sender, TouchEventArgs e)
        {
            if (dgv_c.SelectedIndex != -1)
            {
                RecalculatePosition(_C_lastTapLocation_, e.GetTouchPoint(this).Position, "C");
            }
        }

        private void CList_PreviewTouchUp(object sender, TouchEventArgs e)
        {

            if (CoatingList.IsChecked == true && IsOverSelectedStep(DragItem.PointToScreen(new Point(0d, 0d)), "C"))
                ItemDrop((Coating)dgv_c.SelectedItem, "C");

            DragItem.Visibility = Visibility.Hidden;
        }

        private void CList_PreviewMouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (CoatingList.IsChecked == true)
            {
                ItemDrop((Coating)dgv_c.SelectedItem, "C");
            }


        }

        private void dgv_c_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            if (dgv_c.SelectedItem != null)
                dgv_c.ScrollIntoView(dgv_c.SelectedItem);
        }

        private void dgv_a_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            if (dgv_a.SelectedItem != null)
                dgv_a.ScrollIntoView(dgv_a.SelectedItem);
        }

        #endregion

        #region - - - Methods - - -

        private void RecalculatePosition(Point _lastTapLocation_, Point a, string _selectedRecipeType)
        {
            DragItem.Margin = new Thickness(a.X - 30, a.Y - 70, 0, 0);

            if (Math.Abs(a.X - _lastTapLocation_.X) > 25 && DragItem.Visibility == Visibility.Hidden)
            {
                switch (_selectedRecipeType)
                {
                    case "A":
                        DragItem_Name.Text = ((Article)dgv_a.SelectedItem).Header.Name;
                        DragItem_Pic.SymbolResourceKey = "R_Article";
                        DragItem.Width = ((Article)dgv_a.SelectedItem).Header.Name.Length * 9 + 110;
                        break;
                    case "C":
                        DragItem_Name.Text = ((Coating)dgv_c.SelectedItem).Header.Name;
                        DragItem_Pic.SymbolResourceKey = "R_Coating";
                        DragItem.Width = ((Coating)dgv_c.SelectedItem).Header.Name.Length * 9 + 110;
                        break;
                    default: break;
                }
                DragItem.Visibility = Visibility.Visible;
            }
        }

        private bool IsOverSelectedStep(Point a, string _selectedRecipeType)
        {

            Point SelectedItemCoordinates;
            switch (_selectedRecipeType)
            {
                case "A":
                    SelectedItemCoordinates = article.PointToScreen(new Point(0d, 0d));
                    if (a.X >= SelectedItemCoordinates.X && a.X <= SelectedItemCoordinates.X + article.ActualWidth && a.Y >= SelectedItemCoordinates.Y && a.Y <= SelectedItemCoordinates.Y + article.ActualHeight)
                    {
                        return true;
                    }
                    break;
                case "C":
                    MR_Coating c = GetCheckedCoating();
                    if (c != null)
                    {
                        SelectedItemCoordinates = c.PointToScreen(new Point(0d, 0d));
                        if (a.X >= SelectedItemCoordinates.X && a.X <= SelectedItemCoordinates.X + c.ActualWidth && a.Y >= SelectedItemCoordinates.Y && a.Y <= SelectedItemCoordinates.Y + c.ActualHeight)
                        {
                            return true;
                        }
                    }


                    break;
            }
            return false;
        }

        private void ItemDrop(object SelectedRecipe, string _selectedRecipeType)
        {
            IUserManagementService userService = ApplicationService.GetService<IUserManagementService>();
           if( userService.CurrentUser!=null)
                if (userService.CurrentUser.RightNames.Contains("RecipeM")) 
                {
                    switch (_selectedRecipeType)
                    {
                        case "A":
                            ((MR_Article)article.Content).Article = (Article)SelectedRecipe;
                            break;
                        case "C":
                            MR_Coating c = GetCheckedCoating();
                            if (c != null)
                            {
                                c.Coating = (Coating)SelectedRecipe;

                            }

                            break;
                        default: break;
                    }

                }
            
        }


        public MR_Coating GetCheckedCoating()
        {
            foreach (object c in SV.Items)
            {
                if (c.GetType().Name == "MR_Coating") 
                {
                    if (((MR_Coating)c).A.IsChecked == true)
                    {
                        return c as MR_Coating;
                    }
                }
                
            }
            return SV.Items[0] as MR_Coating;
        }

        #endregion

        
  
    }

}
