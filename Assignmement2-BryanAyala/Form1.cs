using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Net.Mail;

namespace Assignmement2_BryanAyala

/*
Student: Bryan Ayala

Purpose: To evaluate the abilities

Revision: 3/17/2023


*/

{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //Change of the date format according to the instructions
            appointmentCustomer.Format = DateTimePickerFormat.Custom;
            appointmentCustomer.CustomFormat = "dd MMM yyyy";
        }

        //Variables
        Car carMethods = new Car();
        CarBook books = new CarBook();
        string name;
        string address;
        string city;
        string province;
        string postalCode;
        string homePhone;
        string cellPhone;
        string email;
        string model;
        int year;
        string yearStr;
        DateTime appointment;
        string problem;


        //static method to capitalize strings
        public static String Capitalize(string sentence)
        {
            if (sentence == null)
            {
                sentence = "";

            }
            else
            {
                string pattern = @"^\s*(.+?)\s*$";

                if (Regex.IsMatch(sentence, pattern))
                {
                    sentence = Regex.Replace(sentence, @"^\s+", "");
                    sentence = Regex.Replace(sentence, @"\s+$", "");
                }
                sentence = sentence.ToUpper();
            }
            return sentence;
        }

        //Static method to validate the postal code
        public static Boolean IsValidPostalCode(String postalCode)
        {
            bool isValid = false;

            if (string.IsNullOrEmpty(postalCode))
            {
                isValid = false;
            }
            else
            {
                string pattern = @"^[a-zA-Z][0-9][a-zA-Z]\s?[0-9][a-zA-Z][0-9]$";

                if (Regex.IsMatch(postalCode, pattern))
                {
                    isValid = true;
                }
                else
                {
                    isValid = false;
                }
            }
            return isValid;
        }

        //Static method to validate the province
        public static Boolean IsValidProvinceCode(String provinceCode)
        {
            bool isValid = false;

            if (string.IsNullOrEmpty(provinceCode))
            {
                isValid = false;
            }
            else
            {
                provinceCode = provinceCode.ToUpper();
                switch (provinceCode)
                {
                    case "ON":
                        isValid = true;
                        break;
                    case "NL":
                        isValid = true;
                        break;
                    case "PE":
                        isValid = true;
                        break;
                    case "NS":
                        isValid = true;
                        break;
                    case "NB":
                        isValid = true;
                        break;
                    case "QC":
                        isValid = true;
                        break;
                    case "MB":
                        isValid = true;
                        break;
                    case "SK":
                        isValid = true;
                        break;
                    case "AB":
                        isValid = true;
                        break;
                    case "BC":
                        isValid = true;
                        break;
                    case "YT":
                        isValid = true;
                        break;
                    case "NT":
                        isValid = true;
                        break;
                    case "NU":
                        isValid = true;
                        break;
                    default:
                        isValid = false;
                        break;

                }
            }

            return isValid;
        }

        //Static method to validate the phone number
        public static Boolean IsValidPhoneNumber(String phoneNumber)
        {
            bool isValid = false;

            if (string.IsNullOrEmpty(phoneNumber)) { isValid = false; }
            else
            {
                string pattern = @"^([0-9]{3}-?){2}[0-9]{4}$";

                if (Regex.IsMatch(phoneNumber, pattern))
                {
                    isValid = true;
                }
                else
                {
                    isValid = false;
                }
            }

            return isValid;
        }

        //Button to book a new car and alll validations according to the instructions
        private void bookBttn_Click(object sender, EventArgs e)
        {

            notificationsLabel.Text = "";
            notificationsLabel.ForeColor = Color.DarkRed;


            int errorNumber = 0;
            bool verify = true;

            if (customerNameBox.Text != "")
            {
                name = customerNameBox.Text;
            }
            else
            {
                notificationsLabel.Text = notificationsLabel.Text + "The Customer Name is required\r\n";
                if (errorNumber == 0)
                {
                    errorNumber = 1;
                }
            }
            if (emailBox.Text != "" || emailBox != null)
            {
                email = emailBox.Text;
                city = cityBox.Text;
                address = addressBox.Text;
                province = provinceBox.Text;
                province = carMethods.ShiftProvince(province);
                postalCode = postalBox.Text;


                try
                {
                    MailAddress emailAddress = new MailAddress(email);
                }
                catch
                {
                    verify = false;
                }
                if (!verify)
                {
                    notificationsLabel.Text = notificationsLabel.Text + "Email isn't in correct format\r\n";
                    if (errorNumber == 0)
                    {
                        errorNumber = 8;
                    }
                }

                if (!IsValidProvinceCode(province))
                {
                    notificationsLabel.Text = notificationsLabel.Text + "Province isn't in correct format to Canada provinces\r\n";
                    if (errorNumber == 0)
                    {
                        errorNumber = 4;
                    }
                }
                if (!IsValidPostalCode(postalCode))
                {
                    notificationsLabel.Text = notificationsLabel.Text + "Postal Code isn't in correct format\r\n";
                    if (errorNumber == 0)
                    {
                        errorNumber = 5;
                    }
                }

            }
            else
            {
                if (addressBox.Text == "")
                {
                    notificationsLabel.Text = notificationsLabel.Text + "The Address is required if email is not provided\r\n";
                    if (errorNumber == 0)
                    {
                        errorNumber = 2;
                    }
                }
                if (cityBox.Text == "")
                {
                    notificationsLabel.Text = notificationsLabel.Text + "The City is required if email is not provided\r\n";
                    if (errorNumber == 0)
                    {
                        errorNumber = 3;
                    }
                }
                if (provinceBox.Text == "")
                {
                    notificationsLabel.Text = notificationsLabel.Text + "The Province is required if email is not provided\r\n";
                    if (errorNumber == 0)
                    {
                        errorNumber = 4;
                    }
                }
                if (postalBox.Text == "")
                {
                    notificationsLabel.Text = notificationsLabel.Text + "The Postal Code is required if email is not provided\r\n";
                    if (errorNumber == 0)
                    {
                        errorNumber = 5;
                    }
                }
                if (addressBox.Text != "" && cityBox.Text != "" && provinceBox.Text != "" && postalBox.Text != "")
                {
                    city = cityBox.Text;
                    address = addressBox.Text;
                    province = provinceBox.Text;
                    province = carMethods.ShiftProvince(province);
                    postalCode = postalBox.Text;
                    email = "";
                    if (!IsValidProvinceCode(province))
                    {
                        notificationsLabel.Text = notificationsLabel.Text + "Province isn't in correct format to Canada provinces\r\n";
                        if (errorNumber == 0)
                        {
                            errorNumber = 4;
                        }
                    }
                    if (!IsValidPostalCode(postalCode))
                    {
                        notificationsLabel.Text = notificationsLabel.Text + "Postal Code isn't in correct format\r\n";
                        if (errorNumber == 0)
                        {
                            errorNumber = 5;
                        }
                    }
                }

            }

            if (cellPhoneBox.Text != "")
            {
                cellPhone = cellPhoneBox.Text;

                if (!IsValidPhoneNumber(cellPhone))
                {
                    notificationsLabel.Text = notificationsLabel.Text + "Cell phone isn't in correct format\r\n";
                    if (errorNumber == 0)
                    {
                        errorNumber = 7;
                    }
                }


            }
            if (homePhoneBox.Text != "")
            {
                homePhone = homePhoneBox.Text;

                if (!IsValidPhoneNumber(homePhone))
                {
                    notificationsLabel.Text = notificationsLabel.Text + "Cell phone isn't in correct format\r\n";
                    if (errorNumber == 0)
                    {
                        errorNumber = 6;
                    }
                }

            }
            if (homePhoneBox.Text == "" && cellPhoneBox.Text == "")
            {
                notificationsLabel.Text = notificationsLabel.Text + "At least one of thome or cell phone numbers are required\r\n";
                if (errorNumber == 0)
                {
                    errorNumber = 6;
                }
            }

            if (modelBox.Text != "")
            {
                model = modelBox.Text;
            }
            else
            {
                notificationsLabel.Text = notificationsLabel.Text + "Make & Model is required\r\n";
                if (errorNumber == 0)
                {
                    errorNumber = 9;
                }
            }
            //Validation of the year according to the instructions
            if (yearBox.Text != "")
            {
                try
                {
                    year = Convert.ToInt32(yearBox.Text);
                    int currentYear = DateTime.Now.Year;
                    if (year > currentYear + 1 || year < 1900)
                    {
                        throw new ArgumentOutOfRangeException();
                    }
                    else
                    {
                        yearStr = Convert.ToString(year);
                    }
                }
                catch
                {
                    notificationsLabel.Text = notificationsLabel.Text + "Year isn't in correct format or between 1900 and the current year plus one\r\n";
                    if (errorNumber == 0)
                    {
                        errorNumber = 10;
                    }
                }
            }
            else
            {
                yearStr = "";
            }

            //Date Validations:

            DateTime selectedDate = appointmentCustomer.Value.Date;

            if (selectedDate >= DateTime.Now.Date)
            {
                appointment = selectedDate;
            }
            else
            {
                notificationsLabel.Text = notificationsLabel.Text + "Appointment Date isn't valid. It must be in future\r\n";
                if (errorNumber == 0)
                {
                    errorNumber = 11;
                }
            }

            problem = problemBox.Text;

            //Validation that any errors were throwing 

            if (notificationsLabel.Text == "")
            {

                name = Capitalize(customerNameBox.Text);
                address = Capitalize(addressBox.Text);
                model = Capitalize(modelBox.Text);
                city = Capitalize(cityBox.Text);

                province = Capitalize(provinceBox.Text);
                postalCode = carMethods.ShiftPostalCode(postalBox.Text);
                cellPhone = carMethods.InsertDashes(cellPhoneBox.Text);
                homePhone = carMethods.InsertDashes(homePhoneBox.Text);
                email = carMethods.ShiftEmail(emailBox.Text);

                Car myCar = new Car(name, address, city, province, postalCode, homePhone, cellPhone, email, model, yearStr, problem, appointment);

                books.AddCar(myCar);

                notificationsLabel.ForeColor = Color.Green;
                notificationsLabel.Text = "Car booked succesfully";

            }

            //to validate which is the first error and focus the input in the console
            else
            {
                switch (errorNumber)
                {
                    case 1:
                        {
                            customerNameBox.Focus();
                        }
                        break;
                    case 2:
                        {
                            addressBox.Focus();
                        }
                        break;
                    case 3:
                        {
                            cityBox.Focus();
                        }
                        break;
                    case 4:
                        {
                            provinceBox.Focus();
                        }
                        break;
                    case 5:
                        {
                            postalBox.Focus();
                        }
                        break;
                    case 6:
                        {
                            homePhoneBox.Focus();
                        }
                        break;
                    case 7:
                        {
                            cellPhoneBox.Focus();
                        }
                        break;
                    case 8:
                        {
                            emailBox.Focus();
                        }
                        break;
                    case 9:
                        {
                            modelBox.Focus();
                        }
                        break;
                    case 10:
                        {
                            yearBox.Focus();
                        }
                        break;
                    case 11:
                        {
                            appointmentCustomer.Focus();
                        }
                        break;
                }
            }
        }

        //button to reset all program at the begining state

        private void resetBttn_Click(object sender, EventArgs e)
        {
            customerNameBox.Text = "";
            addressBox.Text = "";
            cityBox.Text = "";
            provinceBox.Text = "";
            postalBox.Text = "";
            homePhoneBox.Text = "";
            cellPhoneBox.Text = "";
            emailBox.Text = "";
            modelBox.Text = "";
            yearBox.Text = "";
            appointmentCustomer.Value = DateTime.Now;
            problemBox.Text = "";


            notificationsLabel.Text = "";
            notificationsLabel.ForeColor = Color.Coral;
            notificationsLabel.Text = books.EraseList();
        }

        //button to close the form
        private void closeBttn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //Button to fill a generic information
        private void prefillBttn_Click(object sender, EventArgs e)
        {
            customerNameBox.Text = "Joe Black";
            addressBox.Text = "123 University Ave";
            cityBox.Text = "Waterloo";
            provinceBox.Text = "ON";
            postalBox.Text = "N2R 3S8";
            homePhoneBox.Text = "226-854-4846";
            cellPhoneBox.Text = "226-854-4846";
            emailBox.Text = "jblack@outlook.com";
            modelBox.Text = "Honda Civic";
            yearBox.Text = "2023";
            appointmentCustomer.Value = DateTime.Now;
            problemBox.Text = "Periodic Maintenance";
        }
    }




}