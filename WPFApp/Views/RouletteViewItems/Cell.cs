using System.Windows.Media;

namespace WPFApp.Views
{
    public class Cell
    {
        public int Value { get; set; }
        public Brush Color => Value % 2 == 0 ? Brushes.Red : Brushes.Black;
        public string Text => Value.ToString();
    }
}