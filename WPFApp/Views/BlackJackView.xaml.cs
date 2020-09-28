using System;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Games.BlackJack;
using WPFApp.ViewModels;

namespace WPFApp.Views
{
    /// <summary>
    ///     Interaction logic for BlackJackView.xaml
    /// </summary>
    public partial class BlackJackView
    {
        public BlackJackView()
        {
            InitializeComponent();
            DataContext = new BlackJackViewModel(this);
        }

        public void DrawCards(PlayingCard card, string cardHolder)
        {
            var logo = new BitmapImage();
            logo.BeginInit();
            logo.UriSource = new Uri(@$"C:\Users\woolf\Desktop\CardImages\{card.Rank}{card.Suit}.png");
            logo.EndInit();

            var image = new Image
            {
                Source = logo,
                Width = 60,
                Height = 84,
                Stretch = Stretch.Fill,
                LayoutTransform = new ScaleTransform(1, 1)
            };

            if (cardHolder == "Player")
                PlayerCardsPanel.Children.Add(image);
            else
                DealerCardsPanel.Children.Add(image);
        }

        public void ClearDrawnCards()
        {
            PlayerCardsPanel.Children.Clear();
            DealerCardsPanel.Children.Clear();
        }
    }
}