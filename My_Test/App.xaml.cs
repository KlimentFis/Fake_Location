using System;
using Xamarin.Forms;

namespace My_Test
{
    public partial class MainPage : ContentPage
    {
        public App()
        {
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();

            string[] excuses = new string[]
            {
                "Сломался автобус",
                "Бабушка задержала на пирожки",
                "Шёл по встречке в метро",
                "Поймал галлюцинацию",
                "Решал уравнение Шредингера",
                "Застрял в лифте с философом",
                "Кот съел расписание",
                "Научился телепортироваться, но не туда",
                "Выиграл спор с зеркалом",
                "Протестировал теорию относительности"
            };

            int highlightedIndex = GetHighlightIndex(excuses.Length);

            StackLayout newExcusesLayout = new StackLayout
            {
                HorizontalOptions = LayoutOptions.CenterAndExpand
            };

            for (int i = 0; i < excuses.Length; i++)
            {
                newExcusesLayout.Children.Add(new Label
                {
                    Text = excuses[i],
                    FontSize = 20,
                    TextColor = (i == highlightedIndex) ? Color.OrangeRed : Color.Gray,
                    HorizontalTextAlignment = TextAlignment.Center
                });
            }

            if (Content is StackLayout rootLayout && rootLayout.Children.Count >= 5 && rootLayout.Children[4] is StackLayout oldExcusesLayout)
            {
                rootLayout.Children[4] = newExcusesLayout;
            }
        }

        private int GetHighlightIndex(int length)
        {
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

            int daySum = SumDigits(now.Day);
            int monthSum = SumDigits(now.Month);

            return (daySum + monthSum) % length;
        }
    }
}
