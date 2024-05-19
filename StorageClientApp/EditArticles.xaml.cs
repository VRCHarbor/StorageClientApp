using StorageDBO.Data;
using StorageDBO.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace StorageClientApp
{
    /// <summary>
    /// Логика взаимодействия для EditArticles.xaml
    /// </summary>
    public partial class EditArticles : Window
    {
        public List<string> ArticulCodeWithNames { get; set; }
        public StorageDBContext Ctx { get; set; }
        public Dictionary<string, Articul> Articles { get; set; }

        public EditArticles()
        {
            InitializeComponent();
        }

        public EditArticles(StorageDBContext ctx) : this()
        {
            Ctx = ctx;

            ResetArticles();

            if (Articles.Count > 0) { ArticulList.SelectedIndex = 0; }
        }

        private void ResetArticles()
        {
            Articles = new Dictionary<string, Articul>(Ctx.Articuls.Select(i => new KeyValuePair<string, Articul>(i.ArticulSellerCode, i)));
            ArticulList.ItemsSource = Articles.Select(i => i.Key);
        }

        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void AddNewArticleBtn_Click(object sender, RoutedEventArgs e)
        {
            var NewArticleWindow = new ArticulCreateForm(Ctx);

            while (!NewArticleWindow.ShowDialog().Value)
            {
                ResetArticles();
            }
        }
    }
}
