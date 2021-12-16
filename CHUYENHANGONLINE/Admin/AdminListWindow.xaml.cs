﻿using System;
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

namespace CHUYENHANGONLINE.Admin
{
    /// <summary>
    /// Interaction logic for AdminListWindow.xaml
    /// </summary>
    public partial class AdminListWindow : Window
    {
        private BindingList<Staff.Staff> _adminList;
        public AdminListWindow(BindingList<Staff.Staff> adminList)
        {
            _adminList = adminList;
            InitializeComponent();
        }
        private void AdminListWindow_OnLoaded(object sender, RoutedEventArgs e)
        {
            AdminListView.Items.Clear();
            AdminListView.ItemsSource = _adminList;
        }
    }
}
