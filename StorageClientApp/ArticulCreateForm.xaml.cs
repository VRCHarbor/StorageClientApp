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
using StorageDBO.Entities;
using StorageUserClientElementsLib;

namespace StorageClientApp
{
    /// <summary>
    /// Логика взаимодействия для ArticulCreateForm.xaml
    /// </summary>
    public partial class ArticulCreateForm : Window
    {
        StorageDBContext Ctx { get; set; }

        Articul Articul { get; set; }

        bool isEditing {  get; set; }

        public string ArticulSellerCode { get => Articul.ArticulSellerCode; set => Articul.ArticulSellerCode = value; }
        public string ArticulName { get => Articul.ArticulName; set => Articul.ArticulName = value; }


        public ArticulCreateForm()
        {
            InitializeComponent();

            ArticulSellerCodeInput.IsEnabled = !isEditing;
            Title = isEditing ? $"Редактирование {ArticulSellerCode}" : "";
        }

        public ArticulCreateForm(StorageDBContext ctx) : this()
        {
            Articul = new Articul();
            Ctx = ctx;

            isEditing = false;
        }

        public ArticulCreateForm(Articul articul, StorageDBContext ctx) : this()
        {
            Articul = articul;
            Ctx = ctx;

            isEditing = true;
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            
            base.OnClosing(e);
        }

        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (isEditing)
            {
                Ctx.Articuls.Update(Articul);
            }
            else
            {
                Ctx.Articuls.Add(Articul);
            }

            Ctx.SaveChanges();

            Close();
        }
    }
}
