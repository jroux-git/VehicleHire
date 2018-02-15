using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessLayer
{
    public class Helper
    {
        public static IList<int> GetYears()
        {
            IList<int> years = new List<int>();

            for (int i = 0; i <= 100; i++)
                years.Add(DateTime.Today.Year - i);

            return years;
        }

        public static IList<int> GetNumberOfSeats()
        {
            return new List<int> { 1, 3, 5 };
        }


    }
}
