using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car_Rental_Application.Classes
{
    public static class IDManagement
    {
        public static bool[] availableIndexes = new bool[short.MaxValue];
        #region ID selection

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
    }
}
