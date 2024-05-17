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
    /// Логика взаимодействия для ArticulWithCountViewModel.xaml
    /// </summary>
    public partial class ArticulWithCountViewModel : UserControl
    {

        public int Count { get; set; } = 24;
        public string ArticulSellerCode { get; set; } = "ABOBA";

        public ArticulWithCountViewModel()
        {
            InitializeComponent();
        }

        public ArticulWithCountViewModel(string name, int value) : this()
        {
            ArticulSellerCode = name;
            Count = value;
        }
    }
}
