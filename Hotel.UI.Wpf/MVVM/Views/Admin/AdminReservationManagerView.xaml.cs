﻿using Hotel.UI.Wpf.MVVM.ViewModels;
using MaterialDesignThemes.Wpf;
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

namespace Hotel.UI.Wpf.MVVM.Views.Admin
{
    /// <summary>
    /// Interaction logic for AdminReservationManagerView.xaml
    /// </summary>
    public partial class AdminReservationManagerView : UserControl
    {
        public AdminReservationManagerView()
        {
            InitializeComponent();
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            //var result = DialogHost.Show(view, "RootDialog", ClosingEventHandler);
        }
    }
}