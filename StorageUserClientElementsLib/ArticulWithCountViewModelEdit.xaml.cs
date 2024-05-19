using StorageDBO.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Логика взаимодействия для ArticulWithCountViewModelEdit.xaml
    /// </summary>
    public partial class ArticulWithCountViewModelEdit : UserControl
    {

        RecordCount RecordCount { get; set; }

        public int Count { get => RecordCount.Count; set => RecordCount.Count = value; }
        public string ArticulSellerCode { get => RecordCount.Articul.ArticulSellerCode; }

        public ArticulWithCountViewModelEdit()
        {
            InitializeComponent();
        }

        public ArticulWithCountViewModelEdit(RecordCount rc, bool RecordIn) : this()
        {
            RecordCount = rc;
        }

        private void CountLabel_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
