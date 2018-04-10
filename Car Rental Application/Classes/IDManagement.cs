using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car_Rental_Application.Classes
{
    public static class IDManagement
    {
        static bool[] availableIndexes = new bool[short.MaxValue];
        static bool[] rentedIndexes = new bool[short.MaxValue];

        public static void InitializeIndexes()
        {
            for (int i = 0; i < IDManagement.availableIndexes.Length; i++)
                IDManagement.availableIndexes[i] = true;
            for (int i = 0; i < IDManagement.rentedIndexes.Length; i++)
                IDManagement.rentedIndexes[i] = true;
        }

        #region Available ID selection

        public static int GetLowestAvailableID()
        {
            for (int i = 0; i < short.MaxValue; i++)
                if (availableIndexes[i])
                    return i;     
            throw (new Exception());
        }
        public static void MarkIDAsUnavailable(short id) { availableIndexes[id] = false; }

        public static void MarkIDAsAvailable(short id) { availableIndexes[id] = true; }

        #endregion

        #region Rent ID selection

        public static int GetLowestAvailableRentedID()
        {
            for (int i = 0; i < short.MaxValue; i++)
                if (rentedIndexes[i])
                    return i;
            throw (new Exception());
        }
        public static void MarkRentIDAsUnavailable(short id) { rentedIndexes[id] = false; }

        public static void MarkRentIDAsAvailable(short id) { rentedIndexes[id] = true; }

        #endregion

    }
}
