using System;
using System.Collections.ObjectModel;
using System.Net;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Windows;
using System.Windows.Media.Imaging;

namespace Lab01
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        ObservableCollection<Person> people = new ObservableCollection<Person>
        {
            new Person { Name = "P1", Age = 1 },
            new Person { Name = "P2", Age = 2 }
        };

        public ObservableCollection<Person> Items
        {
            get => people;
        }

        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
        }

        private void AddNewPersonButton_Click(object sender, RoutedEventArgs e)
        {
            people.Add(new Person { Age = int.Parse(ageTextBox.Text), Name = nameTextBox.Text, PersonImage = image.Source as BitmapImage });
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

        private string GetRandomWord()
        {
            WebClient myClient = new WebClient();
            Random rand = new Random();
            Uri tUri = new Uri("https://raw.githubusercontent.com/first20hours/google-10000-english/master/google-10000-english-usa-no-swears-medium.txt");
            String myDiction = myClient.DownloadString(tUri);
            String[] myWords = myDiction.Split('\n');
            string word = myWords[rand.Next(0, myWords.Length)];
            return word;
        }

        private void StartRandomizingPeople_Click(object sender, RoutedEventArgs e)
        {
            Random rand = new Random();
            int foo = 0;
            bool isRun = true;
            Task.Run(async () =>
            {
                while (isRun)
                {
                    Dispatcher.Invoke(() =>
                    {
                        string myWord = GetRandomWord();
                        Uri iUri = new Uri("http://lorempixel.com/10" + foo + "/10" + foo + "/");
                        image.Source = new BitmapImage(iUri);
                        people.Add(new Person { Name = myWord, Age = rand.Next(1, 100), PersonImage = image.Source as BitmapImage });
                        foo++;
                    }
                );
                    await Task.Delay(3000);
                }
            }
            );
        }

        private void Add_via_Json(object sender, RoutedEventArgs e)
        {
            bool isRun = true;
            using (WebClient httpClient = new WebClient())
            {
                Task.Run(async () =>
                {
                    while (isRun)
                    {
                        Dispatcher.Invoke(() =>
                        {
                            Random rand = new Random();
                            string myWord = GetRandomWord();
                            var jsonData = httpClient.DownloadString("https://api.nasa.gov/planetary/earth/imagery/?lon=" + rand.Next(10, 80) + "&lat=" + rand.Next(1, 80) + "&date=2014-02-01&cloud_score=True&api_key=FFAKssQbl7T25xe2rdDlQ8MiitLwhZwXyNyfw5bK");
                            var data = JsonConvert.DeserializeObject(jsonData);
                            var o = Newtonsoft.Json.Linq.JObject.Parse(jsonData);
                            var url = (string)o["url"];
                            Uri iUri = new Uri(url);
                            image.Source = new BitmapImage(iUri);
                            people.Add(new Person { Name = myWord, Age = rand.Next(1, 100), PersonImage = image.Source as BitmapImage });
                            //Console.WriteLine(url);
                        }
                    );
                        await Task.Delay(3000);

                    }

                });
            }
        }
    }
}