using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MetodistApp.WPF
{
    public class MyApiClient
    {
        private readonly HttpClient httpClient;

        public MyApiClient()
        {
            httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("https://localhost:7120/");
        }

        public async Task<IEnumerable<Tutor>> GetTutors()
        {
            IEnumerable<Tutor> rezult = new List<Tutor>();
            try
            {
                rezult = await httpClient.GetFromJsonAsync<IEnumerable<Tutor>>("Metodist/GetTutors");
            }
            catch(Exception ex)
            {
                MessageBox.Show("Ошибка при выполнении запроса: " + ex.Message);
            }
            return rezult;
        }
        public async Task<bool> DeleteTutor(int id)
        {
            try
            {
                await httpClient.DeleteAsync($"Metodist/DeleteTutor?Id={id}");
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
