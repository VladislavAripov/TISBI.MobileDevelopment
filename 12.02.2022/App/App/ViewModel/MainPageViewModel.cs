using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Net.Http;
using System.Threading.Tasks;
using App.Dal;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace App.ViewModel
{
    public class MainPageViewModel
    {
        private const string DataUrl = "http://10.0.2.2:5142/api/usersvisits";
        private readonly HttpClient _httpClient;

        private ObservableCollection<UserVisit> _usersVisits = new ObservableCollection<UserVisit>();

        public ObservableCollection<UserVisit> UsersVisits
        {
            get => _usersVisits;
            set
            {
                _usersVisits = value;
                OnPropertyChanged();
            }
        }

        public MainPageViewModel()
        {
            _httpClient = new HttpClient(
                new HttpClientHandler()
                {
                    ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) =>
                    {
                        //bypass
                        return true;
                    },
                }
                , false
                )
            {
                BaseAddress = new Uri("http://10.0.2.2:5142/api/"),
                DefaultRequestHeaders = {{"Accept", "application/json"}},
            };
            LoadData();
        }

        private async void LoadData()
        {
            var data = await _httpClient.GetStringAsync("/Api/UsersVisits");
            var users = JsonConvert.DeserializeObject<List<UserVisit>>(data);

            foreach (var user in users)
            {
                UsersVisits.Add(user);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}