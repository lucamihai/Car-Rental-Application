using System;

namespace CarRentalApplication.Classes
{
    public static class IDManagement
    {
        static bool[] vehicleIndexes = new bool[short.MaxValue];
        static bool[] rentalIndexes = new bool[short.MaxValue];

        public static void InitializeIndexes()
        {
            for (int i = 0; i < IDManagement.vehicleIndexes.Length; i++)
                IDManagement.vehicleIndexes[i] = true;

            for (int i = 0; i < IDManagement.rentalIndexes.Length; i++)
                IDManagement.rentalIndexes[i] = true;
        }

        public static short LowestAvailableVehicleID
        {
            get
            {
                for (short i = 0; i < short.MaxValue; i++)
                    if (vehicleIndexes[i])
                        return i;

                // If this is reached, there's no available vehicle ID
                throw (new Exception());
            }
        }

        public static short LowestAvailableRentalID
        {
            get
            {
                for (short i = 0; i < short.MaxValue; i++)
                    if (rentalIndexes[i])
                        return i;

                // If this is reached, there's no available rental ID
                throw (new Exception());
            }
        }

        public static void MarkVehicleIDAsUnavailable(short id)
        {
            vehicleIndexes[id] = false;
        }

        public static void MarkVehicleIDAsAvailable(short id)
        {
            vehicleIndexes[id] = true;
        }

        public static void MarkRentalIDAsUnavailable(short id)
        {
            rentalIndexes[id] = false;
        }

        public static void MarkRentalIDAsAvailable(short id)
        {
            rentalIndexes[id] = true;
        }

    }
}
