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
using OptionsListApp.ViewModels;
using OptionsListApp.Models;

namespace OptionsListApp.Views
{
    /// <summary>
    /// Логика взаимодействия для EditOptWindow.xaml
    /// </summary>
    public partial class EditOptWindow : Window
    {
        public EditOptWindow(MoreOption moreOptionToEdit)
        {
            InitializeComponent();
            DataContext = new DataManageVM();
            DataManageVM.SelectedMoreOption = moreOptionToEdit;
            DataManageVM.OptTitle = moreOptionToEdit.Title;
            DataManageVM.MoreOptionType = moreOptionToEdit.MoreOptionType;
        }
    }
}
