using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Car_Rental_Application.User_Controls;

namespace Car_Rental_Application.Interfaces
{
    interface ISort
    {
        void SortListByName(List <VehicleUserControl> vehicles);
        void SortListByType(List <VehicleUserControl> vehicles);
        void SortListByDamagePercent(List <VehicleUserControl> vehicles);
        void SortListByFuelPercent(List <VehicleUserControl> vehicles);
        void SortListByOwnerName(List <VehicleUserControl> vehicles);
        void SortListByOwnerPhoneNumber(List <VehicleUserControl> vehicles);
        void SortListByReturnDate(List <VehicleUserControl> vehicles);
    }
}
