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
using OptionsListApp.Models;
using OptionsListApp.ViewModels;

namespace OptionsListApp.Views
{
    /// <summary>
    /// Логика взаимодействия для MoreOptListWindow.xaml
    /// </summary>
    public partial class MoreOptListWindow : Window
    {
        public static ListView AllValueView;
        public MoreOptListWindow()
        {
            InitializeComponent();
            DataContext = new DataManageVM();
            AllValueView = ViewAllValueList;
        }
    }
}
