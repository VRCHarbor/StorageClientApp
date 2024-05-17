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

namespace StorageClientApp
{
    /// <summary>
    /// Логика взаимодействия для RecordWindow.xaml
    /// </summary>
    public partial class RecordWindow : Window
    {

        StorageDBContext Ctx;

        

        bool IsEditing { get; set; }

        public RecordWindow()
        {
            InitializeComponent();
        }

        public RecordWindow(StorageDBContext ctx)
        {
            Ctx = ctx;

            IsEditing = false;
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            if(IsEditing) 
            {

            }

            base.OnClosing(e);
        }
    }
}
