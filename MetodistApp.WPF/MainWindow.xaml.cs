﻿using Domain.Models;
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
        IEnumerable<Tutor> Tutors;
        MyApiClient apiClient;
        public MainWindow()
        {
            InitializeComponent();
            apiClient = new MyApiClient();
            LoadTut();
        }
        private async void LoadTut()
        {
            MyApiClient myApi = new MyApiClient();
            Tutors = await myApi.GetTutors();
        }
    }
}
