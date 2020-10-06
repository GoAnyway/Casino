using System.Collections.Generic;
using System.Windows.Input;
using WPFApp.Commands.RouletteViewCommands;
using WPFApp.Views;

namespace WPFApp.ViewModels
{
    public class RouletteViewModel : BaseViewModel
    {
        private Cell _selectedCell;

        public RouletteViewModel()
        {
            Rows = new List<CellRow>();
            for (var i = 3; i > 0; --i)
            {
                var row = new CellRow
                {
                    Cells = new List<Cell>()
                };
                for (var j = 0; j < 12; j++)
                {
                    var cell = new Cell
                    {
                        Value = j * 3 + i
                    };
                    row.Cells.Add(cell);
                }

                Rows.Add(row);
            }

            CellClickCommand = new CellClickCommand(_ => { SelectedCell = _ as Cell; });
        }

        public List<CellRow> Rows { get; set; }

        public Cell SelectedCell
        {
            get => _selectedCell;
            set
            {
                if (Equals(value, _selectedCell)) return;
                _selectedCell = value;
                OnPropertyChanged();
            }
        }

        public ICommand CellClickCommand { get; set; }
    }
}