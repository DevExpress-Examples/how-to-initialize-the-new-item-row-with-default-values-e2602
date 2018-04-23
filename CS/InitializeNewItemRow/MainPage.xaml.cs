using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using DevExpress.Xpf.Grid;

namespace InitializeNewItemRow {
    public partial class MainPage : UserControl {
        public MainPage() {
            InitializeComponent();
            grid.ItemsSource = new ProductList();
        }

        private void TableView_InitNewRow(object sender, DevExpress.Xpf.Grid.InitNewRowEventArgs e) {
            grid.SetCellValue(e.RowHandle, "UnitPrice", 10);
            grid.SetCellValue(e.RowHandle, "Quantity", 10);
            grid.SetCellValue(e.RowHandle, "Country", "USA");
            grid.SetCellValue(e.RowHandle, "City", "NY");
        }

        private void TableView_ValidateRow(object sender, DevExpress.Xpf.Grid.GridRowValidationEventArgs e) {
            if (e.Row == null) return;
            if (e.RowHandle == GridControl.NewItemRowHandle)
                e.IsValid = ((Product)e.Row).ProductName != string.Empty;
        }

        private void TableView_InvalidRowException(object sender, DevExpress.Xpf.Grid.InvalidRowExceptionEventArgs e) {
            if (e.RowHandle == GridControl.NewItemRowHandle) {
                e.ErrorText = "Please enter the Product name. ";
                e.WindowCaption = "Input Error";
                view.FocusedColumn = grid.Columns["ProductName"];
            }
        }
    }
}
