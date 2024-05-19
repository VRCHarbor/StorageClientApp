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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace StorageUserClientElementsLib
{
    /// <summary>
    /// Логика взаимодействия для RecordString.xaml
    /// </summary>
    public partial class RecordString : UserControl
    {
        Action<ChangeRecord, bool> Edit { get; set; }
        Action<ChangeRecord> Delete { get; set; }

        ChangeRecord Record { get; set; }
        bool inRecord { get; set; }
        public string DateLabel { get => Record.ChangeDate.ToString("DD.MM.YYY"); }

        public RecordString(Action<ChangeRecord, bool> edit, Action<ChangeRecord> delete, ChangeRecord record, bool inRecord)
        {
            Edit = edit;
            Delete = delete;

            InitializeComponent();
        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            Edit(Record, inRecord);
        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            Delete(Record);
        }
    }
}
