using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace BusinessLayer
{
    public static class Handler
    {
        private static string connectionString = ConfigurationManager.ConnectionStrings["VehicleHire"].ConnectionString;

        /// <summary>
        /// Search Vehicles
        /// </summary>
        /// <param name="vehicleType"></param>
        /// <param name="noOfSeats"></param>
        /// <returns></returns>
        public static List<Vehicle> SearchVehicle(int vehicleType, int noOfSeats)
        {
            var vehicle = new Vehicle();

            return vehicle.Search(connectionString, vehicleType, noOfSeats);
        }

        /// <summary>
        /// Add a new vehicle
        /// </summary>
        /// <param name="vehicleType"></param>
        /// <param name="brand"></param>
        /// <param name="model"></param>
        /// <param name="colour"></param>
        /// <param name="year"></param>
        /// <param name="numberOfSeats"></param>
        /// <param name="hasAirConditioning"></param>
        /// <param name="hasABS"></param>
        /// <param name="hasRadio"></param>
        /// <returns></returns>
        public static bool SaveVehicle(int vehicleType, string brand, string model, string colour, int year, int numberOfSeats, bool hasAirConditioning, bool hasABS, bool hasRadio)
        {
            var vehicle = new Vehicle();

            vehicle.VehicleType = vehicleType;
            vehicle.Model = model;
            vehicle.Brand = brand;
            vehicle.Year = year;
            vehicle.Colour = colour;
            vehicle.NumberOfSeats = numberOfSeats;
            vehicle.HasAirConditioning = hasAirConditioning;
            vehicle.HasABS = hasABS;
            vehicle.HasRadio = hasRadio;

            return vehicle.Save(connectionString, vehicle);
        }
    }
}
