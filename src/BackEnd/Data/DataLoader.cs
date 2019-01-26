using System;
using System.IO;
using System.Threading.Tasks;

namespace BackEnd.Data
{
    public abstract class DataLoader
    {
        public abstract Task LoadDataAsync(string conferenceName, Stream fileStream, ApplicationDbContext db);

        public static DataLoader GetLoader(ConferenceFormat format)
        {
            if (format == ConferenceFormat.Sessionize)
            {
                return new SessionizeLoader();
            }
            return new DevIntersectionLoader();
        }
    }

    public enum ConferenceFormat
    {
        Sessionize,
        DevIntersections
    }

}