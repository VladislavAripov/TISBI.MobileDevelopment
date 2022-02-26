using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using App.Dal;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace App.ViewModel
{
    public class MainPageViewModel
    {
        private const string BaseUrl = "http://10.0.2.2:5142/api/";
        private readonly HttpClient _httpClient;

        private readonly string[] _surenames = new []
        {
            "Aripov",
            "Simonov",
            "Minvaleev",
            "Mustafin",
            "Fedorov",
        };

        private readonly string[] _firstnames = new []
        {
            "Vladislav",
            "Igor",
            "Adel",
            "Kamil",
            "Oleg",
        };

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
                BaseAddress = new Uri(BaseUrl),
                DefaultRequestHeaders = {{"Accept", "application/json"}},
            };
            LoadData();
        }

        private async Task LoadData()
        {
            var data = await _httpClient.GetStringAsync("/Api/UsersVisits?skip=0&take=100");
            var users = JsonConvert.DeserializeObject<List<UserVisit>>(data);

            UsersVisits.Clear();
            foreach (var user in users)
            {
                UsersVisits.Add(user);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public ICommand PostRandomUserVisitCommand => new Command(PostRandomUserVisit);

        private async void PostRandomUserVisit()
        {
            var randomUserVisit = CreateRandomUserVisit();
            var randomUserVisitJson = JsonConvert.SerializeObject(randomUserVisit);
            var httpContent = new StringContent(randomUserVisitJson, Encoding.UTF8, "application/json");

            await _httpClient.PostAsync("/Api/UsersVisits", httpContent);

            await LoadData();
        }

        protected virtual void OnPropertyChanged(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        private UserVisit CreateRandomUserVisit()
        {
            return new UserVisit
            {
                UserIp = GetRandomIp(),
                UserName = GetRandomName(),
            };
        }

        private string GetRandomIp()
        {
            return $"{GetRandomIpOctet()}.{GetRandomIpOctet()}.{GetRandomIpOctet()}.{GetRandomIpOctet()}";

            int GetRandomIpOctet()
            {
                return new Random().Next(256);
            }
        }

        private string GetRandomName()
        {
            var random = new Random();
            var surname = _surenames[random.Next(_surenames.Length)];
            var firstname = _firstnames[random.Next(_firstnames.Length)];

            return $"{surname} {firstname}";
        }
    }
}