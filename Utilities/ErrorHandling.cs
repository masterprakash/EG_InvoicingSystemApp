using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;

namespace InvoicingSystemApp.Utilities
{
    public static class ErrorHandling
    {
        public static void LogError(Exception ex)
        {
            // Implement error logging logic here
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }
}
