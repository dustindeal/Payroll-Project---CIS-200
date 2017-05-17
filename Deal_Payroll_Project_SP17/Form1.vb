Option Strict On
Public Class FrmDeal

    '***********************************************************************************

    'Name: Dustin Deal
    'Course: Programming for Information Systems CIS 200 
    'Date: 4/5/2017 
    'Project: Payroll Expense Calculator 

    'What this program does: 

    'This is a simple payroll expense calculator which will allow users to input employees by first and last name, hourly wage, and hours worked. 
    'It will then compute the: gross earnings, federal and state withholding taxes, net income, FICA, worker's compensation, as well as a running total of cash
    'needed to cover all payroll expenses. These values will then be output into two seperate listboxes, one being an employee view, and another being
    'an employer view. 

    '**************************************************************************************


    'Constants'
    '***********************************************************************************************************
    Const MIN_WAGE As Double = 9.7                  'Minimum wage in New York State 
    Const FICA_RATE As Double = 0.0765              'FICA Tax rate for both employer and employee as of 4/5/17 
    Const WORKERS_COMP As Double = 0.0175           'Workman's Compensation Rate as of 4/5/17

    'Zone Formatting'
    Dim strZones As String = "{0,-18}{1,10:C2}{2,15}{3,15:C2}{4,15:C2}{5,15:C2}{6,10:C2}{7,10:C2}"
    Dim strEmployerZones As String = "{0,-18}{1,10:C2}{2,15:C2}{3,15:C2}{4,20:C2}"

    Dim dblTotalCashNeeded As Double                    'Running total of cash needed to cover the entire payroll 




    Private Sub BtnEnter_Click(sender As Object, e As EventArgs) Handles btnEnter.Click
        'Variable Declarations'
        '***********************************************************************************************************************
        Dim strFirstName As String = String.Empty       'To store the first name of the employee
        Dim strLastName As String = String.Empty        'To store the last name of the employee
        Dim strHourlyWage As String = String.Empty      'To store the input of the hourly wage for the employee 
        Dim strHours As String = String.Empty           'To store the input of the hours worked for the employee

        Dim dblHourlyWage As Double                     'Hourly Wage of the employee  
        Dim dblGrossPay As Double                       'Gross pay of employee
        Dim dblFederalWH As Double                      'Federal withholding of the employee wage 
        Dim dblStateWH As Double                        'State withholding of the employee wage 
        Dim dblFicaEmployee As Double                   'Fica taxes payable by the employee
        Dim dblFicaEmployer As Double                   'Fica taxes for employer
        Dim dblNetPay As Double                         'Net pay for employee 
        Dim dblWorkersComp As Double                    'Workman's Compensation 
        Dim dblCashNeeded As Double                     'Cash needed for wages and taxes payable 

        Dim blnFirstName As Boolean                     'Testing if the first name is valid 
        Dim blnLastName As Boolean                      'Testing if the last name is valid 

        Dim intHours As Integer                         'To store the hours worked for the employee 
        Dim intContinue As Integer                       'Used to determine if the user wants to add another worker or not 

        dblTotalCashNeeded = 0.00                       'Reset to 0 so that the user can enter in a new payroll 

        'Setting up and clearing the listbox of any previous data'
        DisplayHeaders()

        'This loop is asking the user to input a valid first name
        '************************************************************************************************************************
        Do
            strFirstName = InputBox("Please Enter the First Name: ", "First Name")
            blnFirstName = ValidateName(strFirstName)
            If blnFirstName Then

                'This Loop is asking the user to input a valid last name
                '***************************************************************************************************************
                Do
                    strLastName = InputBox("Please Enter the Last Name: ", "Last Name")
                    blnLastName = ValidateName(strLastName)
                    If blnLastName Then

                        'This loop is asking the user to input a valid hourly wage 
                        '*******************************************************************************************************
                        Do
                            strHourlyWage = InputBox("Please Enter the Hourly Wage: ", "Hourly Wage")
                            dblHourlyWage = ValidateWage(strHourlyWage)

                            If dblHourlyWage >= MIN_WAGE Then

                                Do
                                    'This loop is asking the user to input a valid hours worked 
                                    '*******************************************************************************************
                                    strHours = InputBox("Please Enter the Hours Worked: ", "Hours Worked")
                                    intHours = ValidateHours(strHours)
                                    If intHours > 0 AndAlso intHours < 80 Then

                                        '***************************************************
                                        '*******Calculations for the listboxes************** 

                                        'Gross Pay of the Employee' 
                                        dblGrossPay = GrossPay(dblHourlyWage, intHours)

                                        'Federal Withholding of the Employee' 
                                        dblFederalWH = FederalWithholding(dblGrossPay)

                                        'State Withholding of the Employee' 
                                        dblStateWH = NYSWithholding(dblGrossPay)

                                        'FICA Employee & Employer Calculation' 
                                        dblFicaEmployee = Fica(dblGrossPay)
                                        dblFicaEmployer = Fica(dblGrossPay)

                                        'Net Pay Calculation' 

                                        dblNetPay = NetPay(dblGrossPay, dblFicaEmployee, dblStateWH, dblFederalWH)

                                        'Workers Comp Calculation'
                                        dblWorkersComp = WorkersComp(dblGrossPay)

                                        'Wages and Taxes Payable Calculation' 
                                        dblCashNeeded = CashNeeded(dblGrossPay, dblFicaEmployer, dblWorkersComp)

                                        '*************************************************************************
                                        'Outputting data to the listbox*******************************************

                                        'Passing all the values calculated from above
                                        OutputWages(strFirstName, strLastName, dblHourlyWage, intHours, dblGrossPay, dblFederalWH, dblStateWH, dblFicaEmployee, dblNetPay, dblWorkersComp, dblCashNeeded)

                                        'Asking the user if they would like to continue adding employees or to stop
                                        intContinue = MessageBox.Show("Would you like to add another employee?", "Continue?", MessageBoxButtons.YesNo)

                                        If intContinue = Windows.Forms.DialogResult.Yes Then
                                            blnFirstName = False
                                        Else
                                            'Displaying the total cash needed now that they are done inputting employees'
                                            FinalCashNeed()
                                        End If

                                    Else
                                        MessageBox.Show("Please enter in a valid number of hours worked (0-80)", "Input Error")
                                    End If
                                Loop Until intHours > 0 AndAlso intHours <= 80
                                'End of Loop requesting the hours worked 

                            Else
                                MessageBox.Show("Please enter a valid wage ($9.70+)", "Input Error")
                            End If

                        Loop Until dblHourlyWage >= MIN_WAGE
                        'End of loop requesting the hourly wage 

                    Else
                        InvalidInput()
                    End If

                Loop Until blnLastName
                'End of Loop requesting the last name
            Else
                InvalidInput()
            End If

        Loop Until blnFirstName
        'End of Loop requesting the first name 

    End Sub
    'Formatting the headers of the listboxes*************************************************************************
    Sub DisplayHeaders()

        'Clearing the listbox for new payroll data 

        lstEmployee.Items.Clear()
        lstEmployer.Items.Clear()

        'Employee Table 
        lstEmployee.Items.Add(String.Format(strZones, "Employee", "Hourly", "Hours", "Gross", " ", " ", " ", "Net"))
        lstEmployee.Items.Add(String.Format(strZones, "Name", "Rate", "Worked", "Pay", "Federal WH", "NYS WH", "FICA", "Pay"))
        lstEmployee.Items.Add(String.Format(strZones, "--------", "-------", "-------", "-------", "-------", "-------", "-------", "------"))

        'Employer Table
        lstEmployer.Items.Add(String.Format(strEmployerZones, "Employee", "Gross", "    ", "Worker's", "Cash"))
        lstEmployer.Items.Add(String.Format(strEmployerZones, "Name", "Pay", "FICA", "Comp", "Needed"))
        lstEmployer.Items.Add(String.Format(strEmployerZones, "--------", "-------", "-------", "-------", "-------"))

    End Sub

    'Outputting the information to the listboxes'*****************************************************************
    Sub OutputWages(strFirstName As String, strLastName As String, dblRate As Double, intHours As Integer, dblGross As Double, dblFwh As Double, dblNYSwh As Double, dblFica As Double, dblNet As Double, dblWorkersComp As Double, dblCashNeeded As Double)

        dblTotalCashNeeded = dblTotalCashNeeded + dblCashNeeded

        lstEmployee.Items.Add(String.Format(strZones, strLastName & ", " & strFirstName, dblRate, intHours, dblGross, dblFwh, dblNYSwh, dblFica, dblNet))
        lstEmployer.Items.Add(String.Format(strEmployerZones, strLastName & ", " & strFirstName, dblGross, dblFica, dblWorkersComp, dblCashNeeded))

    End Sub
    'Error box output*********************************************************************************************
    Sub InvalidInput()
        MessageBox.Show("Please enter a name", "Invalid Input")
    End Sub

    'Outputting final cash need after done entering employee information'
    Sub FinalCashNeed()

        lstEmployer.Items.Add(String.Empty)
        lstEmployer.Items.Add(String.Format(strEmployerZones, "Total Cash Needed: ", " ", " ", " ", dblTotalCashNeeded))

    End Sub
    'Validating name input****************************************************************************************
    Public Function ValidateName(ByRef strName As String) As Boolean
        Dim blnName As Boolean = False
        strName = strName.Trim()

        If strName <> String.Empty Then     'Checking to see if the name is blank
            blnName = True
        End If
        Return blnName

    End Function

    'Validating hourly wage input*********************************************************************************
    Public Function ValidateWage(ByVal strInput As String) As Double
        Dim dblWage As Double = 0.00
        If IsNumeric(strInput) Then
            dblWage = CDbl(strInput)
        End If
        Return dblWage
    End Function

    'Validating Hours Worked*************************************************************************************
    Public Function ValidateHours(ByVal strInput As String) As Integer
        Dim intHours As Integer = 0
        If IsNumeric(strInput) Then
            intHours = CInt(strInput)
        End If
        Return intHours
    End Function

    'Calculating the Gross Pay************************************************************************************
    Public Function GrossPay(ByVal dblWage As Double, ByVal intHours As Integer) As Double
        Dim dblGrossPay As Double = dblWage * intHours
        Return dblGrossPay
    End Function

    'Calculating the Federal Withholding**************************************************************************
    Public Function FederalWithholding(ByVal dblPay As Double) As Double
        Dim dblTaxes As Double

        'Placing the pay into the proper tax bracket '

        Select Case dblPay
            Case 0 To 44
                dblTaxes = 0.00
            Case 44 To 224
                dblTaxes = 0.00 + ((dblPay - 44) * 0.1)
            Case 224 To 774
                dblTaxes = 18.0 + ((dblPay - 224) * 0.15)
            Case 774 To 1812
                dblTaxes = 100.5 + ((dblPay - 774) * 0.25)
            Case 1812 To 3730
                dblTaxes = 360.0 + ((dblPay - 1812) * 0.28)
            Case 3730 To 8058
                dblTaxes = 897.04 + ((dblPay - 3730) * 0.33)
            Case 8058 To 8090
                dblTaxes = 2325.28 + ((dblPay - 8058) * 0.35)
            Case > 8090
                dblTaxes = 2336.48 + ((dblPay - 8090) * 0.396)
        End Select

        Return dblTaxes
    End Function

    'Calculating the State Withholding****************************************************************************
    Public Function NYSWithholding(ByVal dblPay As Double) As Double
        Dim dblTaxes As Double

        'Placing the pay into the proper tax bracket '

        Select Case dblPay
            Case 0 To 163
                dblTaxes = 0.00 + ((dblPay - 0) * 0.04)
            Case 163 To 225
                dblTaxes = 6.54 + ((dblPay - 163) * 0.045)
            Case 225 To 267
                dblTaxes = 9.31 + ((dblPay - 225) * 0.0525)
            Case 267 To 412
                dblTaxes = 11.54 + ((dblPay - 267) * 0.059)
            Case 412 To 1551
                dblTaxes = 20.04 + ((dblPay - 412) * 0.0645)
            Case 1551 To 1862
                dblTaxes = 93.54 + ((dblPay - 1551) * 0.0665)
            Case 1862 To 2070
                dblTaxes = 114.19 + ((dblPay - 1862) * 0.0758)
            Case 2070 To 3107
                dblTaxes = 130.0 + ((dblPay - 2070) * 0.0808)
            Case 3107 To 4142
                dblTaxes = 213.75 + ((dblPay - 3107) * 0.0715)
            Case 4142 To 5179
                dblTaxes = 287.79 + ((dblPay - 4142) * 0.0815)
            Case 5179 To 20722
                dblTaxes = 372.27 + ((dblPay - 5179) * 0.0735)
            Case 20722 To 21760
                dblTaxes = 1514.71 + ((dblPay - 20722) * 0.4902)
            Case > 21760
                dblTaxes = 2023.29 + ((dblPay - 21760) * 0.0962)
        End Select

        Return dblTaxes
    End Function

    'Calculating the FICA Taxes***********************************************************************************
    Public Function Fica(ByVal dblPay As Double) As Double
        Dim dblFica As Double = (dblPay * FICA_RATE)
        Return dblFica
    End Function

    'Calculating the Net Pay**************************************************************************************
    Public Function NetPay(ByVal dblPay As Double, dblFica As Double, dblStateWH As Double, dblFedWH As Double) As Double
        Dim dblNetPay As Double = dblPay - (dblFica + dblStateWH + dblFedWH)
        Return dblNetPay
    End Function

    'Calculating the Workman's Compensation **********************************************************************
    Public Function WorkersComp(ByVal dblPay As Double) As Double
        Dim dblWorkComp As Double = dblPay * WORKERS_COMP
        Return dblWorkComp
    End Function

    'Calculating the Cash Needed *********************************************************************************
    Public Function CashNeeded(ByVal dblPay As Double, dblFica As Double, dblWorkersComp As Double) As Double
        Dim dblCashNeeded As Double = dblPay + dblFica + dblWorkersComp
        Return dblCashNeeded
    End Function

    'Closing the program *********************************************************************************************
    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub
End Class

