﻿using Domain.Models;
using MetodistApp.WPF.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
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

namespace MetodistApp.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainVm();
            MainFrame.NavigationUIVisibility = NavigationUIVisibility.Hidden;
            MainFrame.Navigate(new Views.TutorsView());
        }

        private void TutorsBtn_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new Views.TutorsView());
        }

        private void AttestationsBtn_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new Views.AttestationsPage());
        }
    }
}
