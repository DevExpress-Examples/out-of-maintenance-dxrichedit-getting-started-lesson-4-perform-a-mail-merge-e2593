Imports Microsoft.VisualBasic
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
			Dim dataSource As List(Of Employee) = CType(Employees.DataSource, List(Of Employee))
			richEditControl1.Options.MailMerge.DataSource = dataSource
			richEditControl1.Options.MailMerge.ViewMergedData = True
		End Sub
	End Class

	Public Class Employee
		Private privateEmployeeID As Integer
		Public Property EmployeeID() As Integer
			Get
				Return privateEmployeeID
			End Get
			Set(ByVal value As Integer)
				privateEmployeeID = value
			End Set
		End Property
		Private privateLastName As String
		Public Property LastName() As String
			Get
				Return privateLastName
			End Get
			Set(ByVal value As String)
				privateLastName = value
			End Set
		End Property
		Private privateFirstName As String
		Public Property FirstName() As String
			Get
				Return privateFirstName
			End Get
			Set(ByVal value As String)
				privateFirstName = value
			End Set
		End Property
		Private privateTitleOfCourtesy As String
		Public Property TitleOfCourtesy() As String
			Get
				Return privateTitleOfCourtesy
			End Get
			Set(ByVal value As String)
				privateTitleOfCourtesy = value
			End Set
		End Property
		Private privateBirthDate As DateTime
		Public Property BirthDate() As DateTime
			Get
				Return privateBirthDate
			End Get
			Set(ByVal value As DateTime)
				privateBirthDate = value
			End Set
		End Property
		Private privateHireDate As DateTime
		Public Property HireDate() As DateTime
			Get
				Return privateHireDate
			End Get
			Set(ByVal value As DateTime)
				privateHireDate = value
			End Set
		End Property
		Private privateAddress As String
		Public Property Address() As String
			Get
				Return privateAddress
			End Get
			Set(ByVal value As String)
				privateAddress = value
			End Set
		End Property
		Private privateHomePhone As String
		Public Property HomePhone() As String
			Get
				Return privateHomePhone
			End Get
			Set(ByVal value As String)
				privateHomePhone = value
			End Set
		End Property
	End Class

	<XmlRoot("Employees")> _
	Public Class Employees
		Inherits List(Of Employee)
		Public Shared ReadOnly Property DataSource() As Object
			Get
				Dim s As New XmlSerializer(GetType(Employees))
				Return s.Deserialize(GetType(Employees).Assembly.GetManifestResourceStream("Employees.xml"))
			End Get
		End Property
	End Class
End Namespace

