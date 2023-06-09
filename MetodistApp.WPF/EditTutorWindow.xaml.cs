﻿using Domain.Models;
using MetodistApp.WPF.Views;
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

namespace MetodistApp.WPF
{
    /// <summary>
    /// Логика взаимодействия для EditTutorWindow.xaml
    /// </summary>
    public partial class EditTutorWindow : Window
    {
        public Tutor EditTutor { get; set; }
        MyApiClient apiClient;
        bool IsEdit = true;
        public EditTutorWindow(Tutor editTutor,bool isEdit = true)
        {
            InitializeComponent();
            apiClient = new MyApiClient();
            if (isEdit == true)
            {
                EditTutor = editTutor;
            }
            else
            {
                IsEdit = false;
                EditTutor = new Tutor();
            }
            this.DataContext = EditTutor;
        }

        private async void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            if (IsEdit)
                await apiClient.EditTutor(EditTutor);
            else
                await apiClient.CreateTutor(EditTutor);
        }

        private async void DeleteAttesBtn_Click(object sender, RoutedEventArgs e)
        {
            var SelectedAttestations = AttestationsListBox.SelectedItem as Attestation;
            if (SelectedAttestations == null)
                return;


            await apiClient.RemoveAttestationOnTutor(EditTutor.Id, SelectedAttestations.Id);
            this.Close();
        }

        private void AddAttesBtn_Click(object sender, RoutedEventArgs e)
        {
            AddAttestation attestation = new AddAttestation(EditTutor);
            attestation.ShowDialog();
        }
    }
}
