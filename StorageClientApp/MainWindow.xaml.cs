using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using StorageDBO.Data;
using StorageUserClientElementsLib;

namespace StorageClientApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        Dictionary<string, List<ArticulWithCountViewModel>> samples = new Dictionary<string, List<ArticulWithCountViewModel>>();

        StorageDBContext Ctx { get; set; }

        public MainWindow()
        {
            InitSamples();
            InitializeComponent();

            ChooseSample.ItemsSource = samples.Keys.AsEnumerable();
            ChooseSample.SelectedIndex = 0;

            ItemsView.ItemsSource = samples[(string)ChooseSample.SelectedItem];
            var opt = new Microsoft.EntityFrameworkCore.DbContextOptions<StorageDBContext>();

            Ctx = new(opt);
        }

        void InitSamples()
        {
            samples.Add("Приход", new List<ArticulWithCountViewModel>());
            samples.Add("Расход", new List<ArticulWithCountViewModel>());
            samples.Add("Остаток", new List<ArticulWithCountViewModel>());

            var rnd = new Random(222_222_222);

            foreach (string key in samples.Keys) 
            {
                for (int i = 0; i < 20; i++)
                {
                    samples[key].Add(new ArticulWithCountViewModel($"{key}/{i}:", rnd.Next(20_00)));
                }
            }

        }

        private void ChooseSample_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ItemsView.ItemsSource = samples[(string)ChooseSample.SelectedItem];
        }

        private void RecordsViewBtn_Click(object sender, RoutedEventArgs e)
        {
            while ((new RecordsView(Ctx).ShowDialog()).Value) ;
        }

        private void ArticlesViewBtn_Click(object sender, RoutedEventArgs e)
        {
            while ((new EditArticles(Ctx).ShowDialog()).Value) ;
        }
    }
}