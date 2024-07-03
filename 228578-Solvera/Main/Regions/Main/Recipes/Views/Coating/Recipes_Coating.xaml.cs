using HMI.Resources.UserControls;
using System.Threading.Tasks;
using System.Windows.Controls;
using VisiWin.ApplicationFramework;


namespace HMI.MainRegion.Recipes.Views
{

    [ExportView("Recipes_Coating")]
    public partial class Recipes_Coating
    {

        public Recipes_Coating()
        {
            InitializeComponent();
            DataContext = new Adapters.Recipes_Coating();
        }

        CoatingStep1 cs1;
        CoatingStep2 cs2;
        CoatingStep3 cs3;
        CoatingStep4 cs4;
        public void LoadSteps()
        {
            Task t1 = Task.Run(async () =>
            {
                await Task.Delay(0);
                await Dispatcher.InvokeAsync(delegate
                  {
                      cs1 = new CoatingStep1();
                      Grid.SetColumn(cs1, 0);
                      grid.Children.Add(cs1);
                  });
            });
            t1.ContinueWith(x1 =>
            {
                Task t2 = Task.Run(async () =>
                {
                    await Task.Delay(200);
                    await Dispatcher.InvokeAsync(delegate
                    {
                        cs2 = new CoatingStep2();
                        Grid.SetColumn(cs2, 2);
                        grid.Children.Add(cs2);
                    });
                });
                t2.ContinueWith(x2 =>
                {
                    Task t3 = Task.Run(async () =>
                    {
                        await Task.Delay(200);
                        await Dispatcher.InvokeAsync(delegate
                        {
                            cs3 = new CoatingStep3();
                            Grid.SetColumn(cs3, 4);
                            grid.Children.Add(cs3);
                        });
                    });
                    t3.ContinueWith(x3 =>
                    {
                        Task t4 = Task.Run(async () =>
                        {
                            await Task.Delay(200);
                            await Dispatcher.InvokeAsync(delegate
                            {
                                cs4 = new CoatingStep4();
                                Grid.SetColumn(cs4, 6);
                                grid.Children.Add(cs4);
                            });
                        });
                    }, TaskContinuationOptions.OnlyOnRanToCompletion);
                }, TaskContinuationOptions.OnlyOnRanToCompletion);
            }, TaskContinuationOptions.OnlyOnRanToCompletion);


        }
        public void UnloadSteps()
        {
            Task.Run(() =>
              {
                  Dispatcher.InvokeAsync(delegate
                  {
                      grid.Children.Remove(cs1);
                      grid.Children.Remove(cs2);
                      grid.Children.Remove(cs3);
                      grid.Children.Remove(cs4);
                  });
              });

        }



    }
}