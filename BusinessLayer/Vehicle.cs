
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data;

namespace BusinessLayer
{
    public class Vehicle: IVehicle
    {
        public int Id { get; set; }

        public int VehicleType { get; set; }

        public string Brand { get; set; }

        public string Model { get; set; }

        public string Colour { get; set; }

        public int Year { get; set; }

        public int NumberOfSeats { get; set; }

        public bool HasAirConditioning { get; set; }

        public bool HasABS { get; set; }

        public bool HasRadio { get; set; }

        /// <summary>
        /// Add a new vehicle to the DB
        /// </summary>
        /// <param name="connectionString"></param>
        /// <param name="vehicle"></param>
        /// <returns></returns>
        public bool Save(string connectionString, Vehicle vehicle)
		{
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("AddVehicle", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@VehicleType", vehicle.VehicleType);
                    cmd.Parameters.Add("@Model", vehicle.Model);
                    cmd.Parameters.Add("@Brand", vehicle.Brand);
                    cmd.Parameters.Add("@Colour", vehicle.Colour);
                    cmd.Parameters.Add("@Year", vehicle.Year);
                    cmd.Parameters.Add("@NumberOfSeats", vehicle.NumberOfSeats);
                    cmd.Parameters.Add("@HasAirConditioning", vehicle.HasAirConditioning);
                    cmd.Parameters.Add("@HasABS", vehicle.HasABS);
                    cmd.Parameters.Add("@HasRadio", vehicle.HasRadio);
                    con.Open();
                    var affected = cmd.ExecuteNonQuery();

                    return affected > 0;
                }
            }
		}

        /// <summary>
        /// Get vehicles from the DB
        /// </summary>
        /// <param name="connectionString"></param>
        /// <param name="vehicleType"></param>
        /// <param name="noOfSeats"></param>
        /// <returns></returns>
        public List<Vehicle> Search(string connectionString, int vehicleType, int noOfSeats)
        {
            var vehicles = new List<Vehicle>();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SearchVehicles", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@VehicleType", vehicleType);
                    cmd.Parameters.Add("@NumberOfSeats", noOfSeats);
                    con.Open();
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        var vehicle = new Vehicle();
                        vehicle.Id = (int)reader["id"];
                        vehicle.Brand = (string)reader["Brand"];
                        vehicle.Colour = (string)reader["Colour"];
                        vehicle.HasABS = (bool)reader["HasABS"];
                        vehicle.HasAirConditioning = (bool)reader["HasAirConditioning"];
                        vehicle.HasRadio = (bool)reader["HasRadio"];
                        vehicle.Model = (string)reader["Model"];
                        vehicle.NumberOfSeats = (int)reader["NumberOfSeats"];
                        vehicle.VehicleType = (int)reader["VehicleType"];
                        vehicle.Year = (int)reader["Year"];

                        vehicles.Add(vehicle);
                    }
                }
            }

            return vehicles;
        }
	}
}
