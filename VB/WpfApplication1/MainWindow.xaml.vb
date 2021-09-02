Imports System
Imports System.Windows
Imports System.Collections.Generic
Imports System.Xml.Serialization

Namespace WpfApplication1
	Partial Public Class MainWindow
		Inherits Window

		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub richEditControl1_Loaded(ByVal sender As Object, ByVal e As RoutedEventArgs)
			Dim dataSource As List(Of Employee) = DirectCast(Employees.DataSource, List(Of Employee))
			richEditControl1.Options.MailMerge.DataSource = dataSource
			richEditControl1.Options.MailMerge.ViewMergedData = True
		End Sub
	End Class

	Public Class Employee
		Public Property EmployeeID() As Integer
		Public Property LastName() As String
		Public Property FirstName() As String
		Public Property TitleOfCourtesy() As String
		Public Property BirthDate() As DateTime
		Public Property HireDate() As DateTime
		Public Property Address() As String
		Public Property HomePhone() As String
	End Class

	<XmlRoot("Employees")>
	Public Class Employees
		Inherits List(Of Employee)

		Public Shared ReadOnly Property DataSource() As Object
			Get
				Dim s As New XmlSerializer(GetType(Employees))
				Return s.Deserialize(GetType(Employees).Assembly.GetManifestResourceStream(GetType(Employees).Namespace & ".Data.Employees.xml"))
			End Get
		End Property
	End Class
End Namespace

