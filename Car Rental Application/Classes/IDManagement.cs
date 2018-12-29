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

        /// <summary>
        /// Restores the indexes for available and rented vehicles
        /// </summary>
        public static void InitializeIndexes()
        {
            for (int i = 0; i < IDManagement.availableIndexes.Length; i++)
                IDManagement.availableIndexes[i] = true;

            for (int i = 0; i < IDManagement.rentedIndexes.Length; i++)
                IDManagement.rentedIndexes[i] = true;
        }

        #region Available ID selection

        /// <summary>
        /// Returns the lowest available ID for available vehicles.
        /// </summary>
        /// <returns></returns>
        public static short GetLowestAvailableID()
        {
            for (short i = 0; i < short.MaxValue; i++)
                if (availableIndexes[i])
                    return i;


            // If this is reached, there's no available ID
            throw (new Exception());
        }

        public static void MarkIDAsUnavailable(short id)
        {
            availableIndexes[id] = false;
        }

        public static void MarkIDAsAvailable(short id)
        {
            availableIndexes[id] = true;
        }

        #endregion

        #region Rent ID selection

        /// <summary>
        /// Returns the lowest available ID for rented vehicles.
        /// </summary>
        /// <returns></returns>
        public static short GetLowestAvailableRentedID()
        {
            for (short i = 0; i < short.MaxValue; i++)
                if (rentedIndexes[i])
                    return i;

            // If this is reached, there's no available ID
            throw (new Exception());
        }

        public static void MarkRentIDAsUnavailable(short id)
        {
            if (id == -1)
            {
                return;
            }

            rentedIndexes[id] = false;
        }

        public static void MarkRentIDAsAvailable(short id)
        {
            if (id == -1)
            {
                return;
            }

            rentedIndexes[id] = true;
        }

        #endregion

    }
}
