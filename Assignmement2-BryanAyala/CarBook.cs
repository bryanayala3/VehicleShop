using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignmement2_BryanAyala
{
    /*
Student: Bryan Ayala

Purpose: To evaluate the abilities

Revision: 3/17/2023


*/

    internal class CarBook
    {
        private List<Car> cars=new List<Car>();

        public CarBook() { }

        public void AddCar(Car myCar)
        {
            cars.Add(myCar);
        }

        public string EraseList()
        {
            cars.Clear();

            return "StoreData was restart!";
        }


    }
}
