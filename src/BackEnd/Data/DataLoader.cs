using System;
using System.IO;
using System.Threading.Tasks;

namespace BackEnd.Data
{
    public abstract class DataLoader
    {
        public abstract Task LoadDataAsync(string conferenceName, Stream fileStream, ApplicationDbContext db);

        public static DataLoader GetLoader(string format)
        {
            if (string.Equals(format, "sessionize", StringComparison.OrdinalIgnoreCase))
            {
                return new SessionizeLoader();
            }
            return new DevIntersectionLoader();
        }
    }
}