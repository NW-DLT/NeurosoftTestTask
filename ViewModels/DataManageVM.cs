using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OptionsListApp.Models;
using OptionsListApp.Views;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace OptionsListApp.ViewModels
{
    class DataManageVM : INotifyPropertyChanged
    {
        public static MoreOption SelectedMoreOption { get; set; }
        public static Value SelectedValue { get; set; }

        private List<MoreOption> allOpt = DataWorker.GetAllOpt();

        public List<MoreOption> AllOpt
        {
            get { return allOpt; }
            set 
            { 
                allOpt = value;
                OnPropertyChanged("AllOpt");
            }
        }

        private List<MoreOptionType> allOptType = DataWorker.GetAllOptType();

        public List<MoreOptionType> AllOptType
        {
            get { return allOptType; }
            set
            {
                allOptType = value;
                OnPropertyChanged("AllOptType");
            }
        }

        private List<Value> allOptValue = DataWorker.GetValues(ID);

        public List<Value> AllOptValue
        {
            get { return allOptValue; }
            set
            {
                allOptValue = value;
                OnPropertyChanged("AllOptType");
            }
        }

        private RelayCommand openAddNewOptWindow;
        public RelayCommand OpenAddNewOptWindow
        {
            get
            {
                return openAddNewOptWindow ?? new RelayCommand(obj =>
               {
                   OpenAddOptWindowMethod();
               }
                );
            }
        }

        private RelayCommand openEditNewOptWindow;
        public RelayCommand OpenEditNewOptWindow
        {
            get
            {
                return openEditNewOptWindow ?? new RelayCommand(obj =>
                {
                    if(SelectedMoreOption != null)
                    OpenEditOptWindowMethot(SelectedMoreOption);
                }
                );
            }
        }

        public static int ID;
        private RelayCommand openMoreOptListWindow;
        public RelayCommand OpenMoreOptListWindow
        {
            get
            {
                return openMoreOptListWindow ?? new RelayCommand(obj =>
                {
                    if (SelectedMoreOption != null && (SelectedMoreOption.MoreOptionTypeID == 3 || SelectedMoreOption.MoreOptionTypeID == 4))
                    {
                        ID = SelectedMoreOption.MoreOptionID;
                        OpenMoreOptListMethod();
                    }
                        
                }
                );
            }
        }
        private RelayCommand openAddValueWindow;
        public RelayCommand OpenAddValueWindow
        {
            get
            {
                return openAddValueWindow ?? new RelayCommand(obj =>
                {
                    OpenAddValueWindowMethod();
                }
                    );
            }
        }

        private RelayCommand openEditValueWindow;
        public RelayCommand OpenEditValueWindow
        {
            get
            {
                return openEditValueWindow ?? new RelayCommand(obj =>
                {
                    OpenEditValueMethod();
                }
                );
            }
        }


        private void OpenAddOptWindowMethod()
        {
            AddNewOptWindow addNewOptWindow = new AddNewOptWindow();
            addNewOptWindow.Owner = Application.Current.MainWindow;
            addNewOptWindow.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            addNewOptWindow.ShowDialog();
        }

        private void OpenEditOptWindowMethot(MoreOption moreOption)
        {
            EditOptWindow editOptWindow = new EditOptWindow(moreOption);
            editOptWindow.Owner = Application.Current.MainWindow;
            editOptWindow.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            editOptWindow.ShowDialog();
        }

        private void OpenMoreOptListMethod()
        {
            MoreOptListWindow moreOptListWindow = new MoreOptListWindow();
            moreOptListWindow.Owner = Application.Current.MainWindow;
            moreOptListWindow.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            moreOptListWindow.ShowDialog();
        }
        private void OpenAddValueWindowMethod()
        {
            AddValue addValueWind = new AddValue();
            addValueWind.Owner = Application.Current.MainWindow;
            addValueWind.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            addValueWind.ShowDialog();
        }
        private void OpenEditValueMethod()
        {
            EditValueWindow editValueWindow = new EditValueWindow();
            editValueWindow.Owner = Application.Current.MainWindow;
            editValueWindow.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            editValueWindow.ShowDialog();
        }

        public static string OptTitle { get; set; }
        public static MoreOptionType MoreOptionType { get; set; }
        private RelayCommand addNewOpt;
        public RelayCommand AddNewOpt
        {
            get
            {
                return addNewOpt ?? new RelayCommand(obj =>
                {
                    Window wnd = obj as Window;
                    if (OptTitle == null || OptTitle.Replace(" ", "").Length == 0)
                    {
                        SetRedBlockControll(wnd, "TitleBlock");
                    }
                    else if(MoreOptionType == null)
                    {
                        SetRedBlockControll(wnd, "MoreOptTypeBlock");
                    }
                    else
                    {
                        DataWorker.CreateOpt(OptTitle, MoreOptionType);
                        UpdateAllData();
                        SetNullValuesToProperties();
                        wnd.Close();
                    }
                }
                );
            }
        }

        public static string ValueName { get; set; }

        private RelayCommand addValue;

        public RelayCommand AddValue
        {
            get
            {
                return addValue ?? new RelayCommand(obj =>
                {
                    Window wnd = obj as Window;
                    if (ValueName == null || ValueName.Replace(" ", "").Length == 0)
                    {

                    }
                    else
                    {
                        DataWorker.CreatValue(ValueName, ID);
                        UpdateAllValueView();
                        SetNullValuesToProperties();
                        wnd.Close();
                    }
                }
                    );
            }
        }

        private RelayCommand editOpt;
        public RelayCommand EditOpt
        {
            get
            {
                return editOpt ?? new RelayCommand(obj =>
                {
                    Window wnd = obj as Window;
                    if (OptTitle == null || OptTitle.Replace(" ", "").Length == 0)
                    {
                        SetRedBlockControll(wnd, "TitleBlock");
                    }
                    else if (MoreOptionType == null)
                    {
                        SetRedBlockControll(wnd, "MoreOptTypeBlock");
                    }
                    else
                    {
                        DataWorker.EditOpt(SelectedMoreOption,OptTitle,MoreOptionType);
                        UpdateAllData();
                        SetNullValuesToProperties();
                        wnd.Close();
                    }
                }
                    );
            }
        }

        private RelayCommand editValue;
        public RelayCommand EditValue
        {
            get
            {
                return editValue ?? new RelayCommand(obj =>
                {
                    Window wnd = obj as Window;
                    if (ValueName == null || ValueName.Replace(" ", "").Length == 0)
                    {

                    }
                    else
                    {
                        DataWorker.EditValue(ValueName, SelectedValue);
                        UpdateAllValueView();
                        SetNullValuesToProperties();
                        wnd.Close();
                    }
                }
                );
            }
        }

        private RelayCommand deleteOpt;
        public RelayCommand DeleteOpt
        {
            get
            {
                return deleteOpt ?? new RelayCommand(obj =>
                {
                    if(SelectedMoreOption != null)
                    {
                        DataWorker.DeleteOpt(SelectedMoreOption);
                        UpdateAllData();
                        SetNullValuesToProperties();
                    }
                }
                    );
            }
        }

        private RelayCommand deleteValue;
        public RelayCommand DeleteValue
        {
            get
            {
                return deleteValue ?? new RelayCommand(obj =>
                {
                    if (SelectedValue != null)
                    {
                        DataWorker.DeleteValue(SelectedValue);
                        UpdateAllValueView();
                        SetNullValuesToProperties();
                    }
                }
                );
            }
        }

        private void UpdateAllData()
        {
            UpdataAllOptView();
        }
        private void UpdataAllOptView()
        {
            AllOpt = DataWorker.GetAllOpt();
            MainWindow.AllOptView.ItemsSource = null;
            MainWindow.AllOptView.Items.Clear();
            MainWindow.AllOptView.ItemsSource = AllOpt;
            MainWindow.AllOptView.Items.Refresh();
        }
        private void UpdateAllValueView()
        {
            AllOptValue = DataWorker.GetAllValues();
            MoreOptListWindow.AllValueView.ItemsSource = null;
            MoreOptListWindow.AllValueView.Items.Clear();
            MoreOptListWindow.AllValueView.ItemsSource = DataWorker.GetValues(ID);
            MoreOptListWindow.AllValueView.Items.Refresh();

        }
        private void SetNullValuesToProperties()
        {
            OptTitle = null;
            MoreOptionType = null;
            ValueName = null;
        }
        private void SetRedBlockControll(Window wnd, string blockName)
        {
            Control block = wnd.FindName(blockName) as Control;
            block.BorderBrush = Brushes.Red;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
