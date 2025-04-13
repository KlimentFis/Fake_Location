using System;
using Xamarin.Forms;

namespace My_Test
{
    public partial class App : Application
    {
        public string FakeLocation { get; set; }

        public App()
        {
            InitializeComponent();

            FakeLocation = GenerateFakeLocation();
            MainPage = new MainPage
            {
                BindingContext = this
            };
        }

        private string GenerateFakeLocation()
        {
            string[] locations = new string[]
            {
        "Киевская, ТЦ Европейский",
        "Курская, Geek Boards",
        "Деловой центр, Афимол",
        "Библиотека имени Ленина, Библиотека",
        "Сокольники, Парк",
        "Измайловская, Измайловский парк",
        "ВДНХ, Парк",
        "Говорово, Гипер Лента",
        "Тимирязевская, Тимирязевский парк",
        "Юго-Восточная, Парк Кузьминки"
            };

            DateTime now = DateTime.Now;

            int SumDigits(int number)
            {
                int sum = 0;
                while (number > 0)
                {
                    sum += number % 10;
                    number /= 10;
                }
                return sum;
            }

            int daySumMod = SumDigits(now.Day) % 10;
            int monthSumMod = SumDigits(now.Month) % 10;

            int index = (daySumMod + monthSumMod) % locations.Length;

            return locations[index];
        }

        protected override void OnStart() { }

        protected override void OnSleep() { }

        protected override void OnResume() { }
    }
}
