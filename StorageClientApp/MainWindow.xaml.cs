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

using StorageUserClientElementsLib;

namespace StorageClientApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        Dictionary<string, List<ArticulWithCountViewModelEdit>> samples = new Dictionary<string, List<ArticulWithCountViewModelEdit>>();

        public MainWindow()
        {
            InitSamples();
            InitializeComponent();

            ChooseSample.ItemsSource = samples.Keys.AsEnumerable();
            ChooseSample.SelectedIndex = 0;

            ItemsView.ItemsSource = samples[(string)ChooseSample.SelectedItem];
        }

        void InitSamples()
        {
            samples.Add("Приход", new List<ArticulWithCountViewModelEdit>());
            samples.Add("Расход", new List<ArticulWithCountViewModelEdit>());
            samples.Add("Остаток", new List<ArticulWithCountViewModelEdit>());

            var rnd = new Random(222_222_222);

            foreach (string key in samples.Keys) 
            {
                for (int i = 0; i < 20; i++)
                {
                    samples[key].Add(new ArticulWithCountViewModelEdit($"{key}/{i}:", rnd.Next(20_00)));
                }
            }

        }

        private void ChooseSample_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ItemsView.ItemsSource = samples[(string)ChooseSample.SelectedItem];
        }
    }
}