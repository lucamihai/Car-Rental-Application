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
        List<VehicleUserControl> SortListByID(List <VehicleUserControl> vehicles);

        List<VehicleUserControl> SortListByName(List <VehicleUserControl> vehicles);

        List<VehicleUserControl> SortListByType(List <VehicleUserControl> vehicles);

        List<VehicleUserControl> SortListByDamagePercent(List <VehicleUserControl> vehicles);

        List<VehicleUserControl> SortListByFuelPercent(List <VehicleUserControl> vehicles);

        List<VehicleUserControl> SortListByOwnerName(List <VehicleUserControl> vehicles);

        List<VehicleUserControl> SortListByOwnerPhoneNumber(List <VehicleUserControl> vehicles);

        List<VehicleUserControl> SortListByReturnDate(List <VehicleUserControl> vehicles);
    }
}
