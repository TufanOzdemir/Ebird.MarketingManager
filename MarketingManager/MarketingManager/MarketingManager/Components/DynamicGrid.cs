using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace MarketingManager.Components
{
    public class DynamicGrid : Grid
    {
        private int _rowCount;
        private int _column;
        private int _columnCount;

        public DynamicGrid(int column)
        {
            _rowCount = 0;
            _columnCount = 0;
            _column = column;
            Padding = 0;
            Margin = 0;
            ColumnSpacing = -1;
            RowSpacing = -1;
            Init();
        }

        private void Init()
        {
            int percent = 100 / _column;
            for (int i = 0; i < _column; i++)
            {
                ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(percent, GridUnitType.Star) });
            }
        }
        
        public void AddView(View view)
        {
            int countRow = _rowCount / _column;
            if (RowDefinitions.Count <= countRow)
            {
                RowDefinitions.Add(new RowDefinition() { Height = new GridLength(50, GridUnitType.Auto) });
            }
            Children.Add(view, _columnCount, countRow);
            _rowCount++;
            _columnCount++;
            _columnCount = _columnCount % _column;
        }
    }
}
