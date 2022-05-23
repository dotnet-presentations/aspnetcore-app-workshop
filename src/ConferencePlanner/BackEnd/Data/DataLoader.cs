namespace BackEnd.Data;
public abstract class DataLoader
{
    public abstract Task LoadDataAsync(Stream fileStream, ApplicationDbContext db);
}