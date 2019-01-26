using Microsoft.EntityFrameworkCore;

namespace BackEnd.Data
{
    public interface IDataLoader
    {
        string Filename { get; set; }

        Conference Conference { get; set; }

        void LoadData(ModelBuilder builder, string filename, string conferenceName);
    }
}