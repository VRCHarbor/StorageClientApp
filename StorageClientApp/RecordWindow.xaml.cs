using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using StorageDBO.Data;
using StorageDBO.Entities.Base;

namespace StorageClientApp
{
    /// <summary>
    /// Логика взаимодействия для RecordWindow.xaml
    /// </summary>
    public partial class RecordWindow : Window
    {

        public enum RecordType
        {
            Income,
            Expence
        } 

        RecordType recordType { get; set; }

        StorageDBContext Ctx { get; set; }

        ChangeRecord Record { get; set; }

        bool IsEditing { get; set; }

        public RecordWindow()
        {
            InitializeComponent();
        }

        public RecordWindow(StorageDBContext ctx, RecordType rt = RecordType.Income) : this() 
        {
            Ctx = ctx;

            switch (rt)
            {
                case RecordType.Income: Record = new InRecord(); break;
                case RecordType.Expence: Record = new OutRecord(); break;
            }

            Ctx.Add(Record);
            Ctx.SaveChanges();

            recordType = rt;
            IsEditing = false;
        }

        public RecordWindow(StorageDBContext ctx, ChangeRecord record, RecordType rt = RecordType.Income) : this()
        {
            Record = record;
            Ctx = ctx;
            recordType = rt;
            IsEditing = true;
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
        }

        private void SaveRecordBtn_Click(object sender, RoutedEventArgs e)
        {


            Record.ChangeDate = DateOnly.FromDateTime(RecordDateCalendar.SelectedDate ?? DateTime.Today);


            switch (recordType)
            {
                case RecordType.Income: 
                    {
                        if (IsEditing)
                        {
                            Ctx.Incomes.Update((InRecord)Record);
                        }
                        else
                        {
                            Ctx.Incomes.Add((InRecord)Record);
                        }
                    } break;
                case RecordType.Expence:
                    {
                        if (IsEditing)
                        {
                            Ctx.Expenses.Update((OutRecord)Record);
                        }
                        else
                        {
                            Ctx.Expenses.Add((OutRecord)Record);
                        }
                    }
                    break;
            }

            Ctx.SaveChanges();
            Close();
        }

        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void AddArticulToRecordBtn_Click(object sender, RoutedEventArgs e)
        {
            new ChooseArticulForRecord(Ctx, Record, recordType).ShowDialog();
        }
    }
}
