using System;
using System.Collections.ObjectModel;
using System.Net;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Windows;
using System.Windows.Media.Imaging;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.Entity;
using System.Threading;
using System.Windows.Threading;
using Newtonsoft.Json.Linq;

namespace Lab01
{   
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    ///
    
    public partial class MainWindow : Window
    {
        Model1Container container = new Model1Container();
        CollectionViewSource myViewSource;

        ObservableCollection<Person> people = new ObservableCollection<Person>
        {    
        };
        public ObservableCollection<Person> Items
        {
            get => people;
            
        }

        public MainWindow()
        {
            InitializeComponent();
            myViewSource = ((CollectionViewSource)(FindResource("nasaViewSource")));
            DataContext = this;
        }

        private void AddNewPersonButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int.Parse(ageTextBox.Text);
                int.Parse(latTextBox.Text);
            }
            catch (Exception)
            { return; }
            people.Add(new Person { Age = 0, Name = nameTextBox.Text, Lon = int.Parse(latTextBox.Text), Lat = int.Parse(latTextBox.Text), PersonImage = image.Source as BitmapImage });
            var newEntry = new NasaBase()
            {
                Date = nameTextBox.Text,
                CloudScore = 0,
                Latitude = int.Parse(latTextBox.Text),
                Longitude = int.Parse(latTextBox.Text),
                Image = image.Source as BitmapImage,

            };
            container.NasaBaseSet.Add(newEntry);
            container.SaveChanges();
            myViewSource.View.Refresh();

        }

        private void AddImageButton_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog op = new Microsoft.Win32.OpenFileDialog();

            op.DefaultExt = ".jpg";

            if (op.ShowDialog() == true)
            {
                image.Source = new BitmapImage(new Uri(op.FileName));
            }
        }


        private void Add_via_Json(object sender, RoutedEventArgs e)
        {
            int Daysleft = 6;
            using (WebClient httpClient = new WebClient())
            {
                Task.Run(async () =>
                {
                    while (Daysleft>=0)
                    {
                        Dispatcher.Invoke(() =>
                        {
                            Random rand = new Random();
                            int Lon = rand.Next(0, 50);
                            int Lat = rand.Next(0, 50);
                            try
                            {
                                var jsonData = httpClient.DownloadString("https://api.nasa.gov/planetary/earth/imagery/?lon=" + Lon + "&lat=" + Lat + "&date=" + rand.Next(2015, 2017) + "-" + rand.Next(2, 10) + "-" + rand.Next(2, 20) + "&cloud_score=True&api_key=FFAKssQbl7T25xe2rdDlQ8MiitLwhZwXyNyfw5bK");
                                var data = JsonConvert.DeserializeObject(jsonData);
                                var o = Newtonsoft.Json.Linq.JObject.Parse(jsonData);

                                var url = (string)o["url"];
                                Uri iUri = new Uri(url);
                                image.Source = new BitmapImage(iUri);
                                var cloudscore = (int)o["cloud_score"];
                                var timestamp = (string)o["date"];


                                people.Add(new Person { Name = timestamp, Age = cloudscore, Lat = Lat, Lon = Lon, PersonImage = image.Source as BitmapImage });
                                var newEntry = new NasaBase()
                                {
      
                                    Date = timestamp,
                                    CloudScore = cloudscore,
                                    Latitude = Lat,
                                    Longitude = Lon,
                                    Image = image.Source as BitmapImage,

                                };
                                container.NasaBaseSet.Add(newEntry);
                                container.SaveChanges();
                                myViewSource.View.Refresh();

                                Daysleft--;
                            }
                            catch (WebException ex)
                            {
                                if (ex.Status == WebExceptionStatus.ProtocolError)
                                {
                                    var response = ex.Response as HttpWebResponse;
                                    if (response != null)
                                    {
                                        Console.WriteLine("HTTP Status Code: " + (int)response.StatusCode);
                                    }
                                }
                            }
                        }
                    );
                        await Task.Delay(3000);

                    }

                });
            }
        }

        

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int.Parse(ageTextBox.Text);
                int.Parse(latTextBox.Text);
            }
            catch (Exception)
            { return; }
            int l_Lon = int.Parse(ageTextBox.Text);
            int l_Lat = int.Parse(latTextBox.Text);
           
            string t_Data = nameTextBox.Text;
            string[] l_Data = t_Data.Split('-');
            if (l_Data.Length != 3)
            { return; }
            using (WebClient httpClient = new WebClient())
            {
                Task.Run(async () =>
                {
                        Dispatcher.Invoke(() =>
                        {
                            Random rand = new Random();
                            try
                            {
                                var jsonData = httpClient.DownloadString("https://api.nasa.gov/planetary/earth/imagery/?lon=" + l_Lon + "&lat=" + l_Lat + "&date=" + l_Data[0] + "-" + l_Data[1] + "-" + l_Data[2] + "&cloud_score=True&api_key=FFAKssQbl7T25xe2rdDlQ8MiitLwhZwXyNyfw5bK");
                                var data = JsonConvert.DeserializeObject(jsonData);
                                var o = Newtonsoft.Json.Linq.JObject.Parse(jsonData);

                                var url = (string)o["url"];
                                Uri iUri = new Uri(url);
                                image.Source = new BitmapImage(iUri);
                                var cloudscore = (int)o["cloud_score"];
                                var timestamp = (string)o["date"];


                                people.Add(new Person { Name = timestamp, Age = cloudscore, Lat = l_Lat, Lon = l_Lon, PersonImage = image.Source as BitmapImage });
                                var newEntry = new NasaBase()
                                {
     
                                    Date = timestamp,
                                    CloudScore = cloudscore,
                                    Latitude = l_Lat,
                                    Longitude = l_Lon,
                                    Image = image.Source as BitmapImage,

                                };
                                container.NasaBaseSet.Add(newEntry);
                                container.SaveChanges();
                                myViewSource.View.Refresh();
                            }
                            catch (WebException ex)
                            {
                                if (ex.Status == WebExceptionStatus.ProtocolError)
                                {
                                    var response = ex.Response as HttpWebResponse;
                                    if (response != null)
                                    {
                                        Console.WriteLine("HTTP Status Code: " + (int)response.StatusCode);
                                    }
                                }
                            }
                        }
                    );
                        await Task.Delay(3000);

                 

                });

            }

        }

    }
}