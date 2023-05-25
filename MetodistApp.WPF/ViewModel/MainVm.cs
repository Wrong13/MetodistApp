using Domain.Models;
using MetodistApp.WPF.ViewModel.AsyncCmd;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MetodistApp.WPF.ViewModel
{
    class MainVm : INotifyPropertyChanged
    {
        Tutor selectedTutor;
        public Tutor SelectedTutor
        {
            get { return selectedTutor; }
            set { selectedTutor = value;}
        }
        IEnumerable<Tutor> tutors;
        public IEnumerable<Tutor> Tutors
        {
            get { return tutors; }
            set { tutors = value; OnPropertyChanged(nameof(Tutors)); }
        }
        


        AsyncCommand editTutor;
        AsyncCommand deleteTuror;
        AsyncCommand addTutor;

        MyApiClient apiClient;
        public MainVm()
        {
            apiClient = new MyApiClient();
            LoadTut();
        }

        public AsyncCommand EditTutor
        {
            get
            {
                return editTutor ?? (editTutor = new AsyncCommand(async () =>
                {
                    
                    if (SelectedTutor == null)
                    {
                        LoadTut();
                        return;
                    }
                    EditTutorWindow editTutorWindow = new EditTutorWindow(SelectedTutor);
                    editTutorWindow.ShowDialog();
                    LoadTut();
                }));
            }
        }

        public AsyncCommand AddTutor
        {
            get
            {
                return addTutor ?? (addTutor = new AsyncCommand(async () =>
                {
                    EditTutorWindow editTutorWindow = new EditTutorWindow(new Tutor(),false);
                    editTutorWindow.ShowDialog();
                    LoadTut();
                }));
            }
        }

        public AsyncCommand DeleteTutor
        {
            get
            {
                return deleteTuror ?? (deleteTuror = new AsyncCommand(async () =>
                {
                    if (SelectedTutor == null)
                        return;
                    await apiClient.DeleteTutor(SelectedTutor.Id);
                    LoadTut();
                }));
            }
        }

        private async void LoadTut()
        {
            Tutors = await apiClient.GetTutors();
            OnPropertyChanged(nameof(Tutors));
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string prop = " ")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
