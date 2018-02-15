using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessLayer
{
    public interface IVehicle
    {
        bool Save(string connectionString, Vehicle vehicle);
        List<Vehicle> Search(string connectionString, int vehicleType, int noOfSeats);
    }
}
