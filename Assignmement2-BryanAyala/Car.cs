using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignmement2_BryanAyala

/*
Student: Bryan Ayala

Purpose: To evaluate the abilities

Revision: 3/17/2023


*/
{
    internal class Car
    {
        public string customerName;
        public string address;
        public string city;
        public string province;
        public string postalCode;
        public string homePhone;
        public string cellPhone;
        public string email;
        public string model;
        public string year;
        public DateTime appointment;
        public string problem;

        public Car()
        {
            customerName = "";
            address = string.Empty;
            city = string.Empty;
            province = string.Empty;
            postalCode = string.Empty;
            homePhone = string.Empty;
                cellPhone = string.Empty;
            email = string.Empty;
            model = string.Empty;
            year = string.Empty;
            problem = string.Empty;
            appointment= DateTime.MinValue;
        }
        public Car(string customerName, string address, string city, string province, string postalCode, string homePhone, string cellPhone, string email, string model, string year, string problem, DateTime appointment)
        {
            this.customerName = customerName;
            this.address = address;
            this.city = city;
            this.province = province;
            this.postalCode = postalCode;
            this.homePhone = homePhone;
            this.cellPhone = cellPhone;
            this.email = email;
            this.model = model;
            this.year = year;
            this.problem = problem;
            this.appointment = appointment;
            
        }

        public string ShiftProvince(string province)
        {
            this.province = province.ToUpper();

            return province;
        }

        public string ShiftPostalCode(string postalCode)
        {
            this.postalCode = postalCode.ToUpper();
            if(postalCode.Length == 6)
            {
                this.postalCode = this.postalCode.Substring(0, 3) + " " + this.postalCode.Substring(3);
            }
            return this.postalCode;
        }

        public string InsertDashes(string phone)
        {
            cellPhone = phone;

            if(phone.Length == 10)
            {
                cellPhone = phone.Substring(0, 3) + "-" + phone.Substring(3, 6) + "-" + phone.Substring(6);
            }

            return cellPhone;

        }

        public string ShiftEmail(string email)
        { 
            this.email = email.ToUpper();
            
            return email;
        
        }

    }
}
