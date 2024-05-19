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
    /// Логика взаимодействия для ChooseArticulForRecord.xaml
    /// </summary>
    public partial class ChooseArticulForRecord : Window
    {
        RecordWindow.RecordType rt;

        public List<string> ArticulCodeWithNames { get; set; }

        public StorageDBContext Ctx { get; set; }
        public ChangeRecord Record {get; set;}
        public RecordCount RecordCountWithSelectedArticul {get; set; }

        public Dictionary<string, Articul> Articles { get; set; }

        public ChooseArticulForRecord()
        {
            InitializeComponent();
        }

        public ChooseArticulForRecord(StorageDBContext ctx, ChangeRecord record, RecordWindow.RecordType rt) : this()
        {
            Record = record;
            Ctx = ctx;

            ResetArticles();
            
            if(Articles.Count > 0) { ArticulList.SelectedIndex = 0; }
            this.rt = rt;
        }

        private void ResetArticles()
        {
            Articles = new Dictionary<string, Articul>(Ctx.Articuls.Select(i => new KeyValuePair<string, Articul>(i.ArticulSellerCode, i)));
            ArticulList.ItemsSource = Articles.Select(i => i.Key);
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            var art = Articles[(string)ArticulList.SelectedItem];
            RecordCountWithSelectedArticul = rt == RecordWindow.RecordType.Income? 
                new InRecordCount { Articul =  art, Record = (InRecord)Record }:
                new OutRecordCount { Articul =  art, Record = (OutRecord)Record };

            Close();
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
