Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Net
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Documents
Imports System.Windows.Input
Imports System.Windows.Media
Imports System.Windows.Media.Animation
Imports System.Windows.Shapes
Imports DevExpress.Xpf.Grid

Namespace InitializeNewItemRow
	Partial Public Class MainPage
		Inherits UserControl
		Public Sub New()
			InitializeComponent()
			grid.DataSource = New ProductList()
		End Sub

		Private Sub TableView_InitNewRow(ByVal sender As Object, ByVal e As DevExpress.Xpf.Grid.InitNewRowEventArgs)
			grid.SetCellValue(e.RowHandle, "UnitPrice", 10)
			grid.SetCellValue(e.RowHandle, "Quantity", 10)
			grid.SetCellValue(e.RowHandle, "Country", "USA")
			grid.SetCellValue(e.RowHandle, "City", "NY")
		End Sub

		Private Sub TableView_ValidateRow(ByVal sender As Object, ByVal e As DevExpress.Xpf.Grid.GridRowValidationEventArgs)
			If e.Row Is Nothing Then
				Return
			End If
			If e.RowHandle = GridControl.NewItemRowHandle Then
				e.IsValid = (CType(e.Row, Product)).ProductName <> String.Empty
			End If
		End Sub

		Private Sub TableView_InvalidRowException(ByVal sender As Object, ByVal e As DevExpress.Xpf.Grid.InvalidRowExceptionEventArgs)
			If e.RowHandle = GridControl.NewItemRowHandle Then
				e.ErrorText = "Please enter the Product name. "
				e.WindowCaption = "Input Error"
				grid.View.FocusedColumn = grid.Columns("ProductName")
			End If
		End Sub
	End Class
End Namespace
