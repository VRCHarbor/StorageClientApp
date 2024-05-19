using StorageDBO.Data;
using StorageDBO.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Security.Permissions;
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
    /// Логика взаимодействия для RecordsView.xaml
    /// </summary>
    public partial class RecordsView : Window
    {
        StorageDBContext Ctx { get; set; }
        public Dictionary<string, List<RecordString>> RecordsViewModel { get; set; }

        public List<string> Types = new(){ "Приход", "Расход" };

        public RecordsView(StorageDBContext ctx)
        {
            Ctx = ctx;

            RecordsViewModel = new Dictionary<string, List<RecordString>>();

            RefreshList();

            InitializeComponent();
        }

        void RefreshList()
        {
            RecordsViewModel.Clear();

            RecordsViewModel.Add(Types[0], new(Ctx.Incomes.Select(i => new RecordString(EditRecord, DeleteRecord, i, true))));
            RecordsViewModel.Add(Types[1], new(Ctx.Expenses.Select(i => new RecordString(EditRecord, DeleteRecord, i, true))));

            RecordsViewList.ItemsSource = RecordsViewModel[RecordTypeSwitch.SelectedItem.ToString()];
        }

        void EditRecord(ChangeRecord record, bool isInRecord) 
        {
            var recordWindow = new RecordWindow(Ctx, record, isInRecord ? RecordWindow.RecordType.Income : RecordWindow.RecordType.Expence);

            while(!recordWindow.ShowDialog().Value);
            

            if (isInRecord)
            {
                Ctx.Incomes.Update((InRecord)record);
            }
            else
            {
                Ctx.Expenses.Update((OutRecord)record);
            }

            Ctx.SaveChanges();

            RefreshList();
        }

        void DeleteRecord(ChangeRecord record)
        {
            Ctx.Remove(record);

            Ctx.SaveChanges();

            RefreshList();
        }

        private void RecordTypeSwitch_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            RecordsViewList.ItemsSource = RecordsViewModel[RecordTypeSwitch.SelectedItem.ToString()];
        }
    }
}
