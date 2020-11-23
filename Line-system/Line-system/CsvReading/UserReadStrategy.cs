using Line_system.Users;

namespace Line_system.CsvReading
{
    public class UserReadStrategy : ICsvReadStrategy<IUser>

    {
        public IUser ReadCsvLine(string line, char separator)
        {
            string[] csvFields = line.Split(separator);
            return new User(
                int.Parse(csvFields[0]),
                csvFields[1],
                csvFields[2],
                csvFields[3],
                decimal.Parse(csvFields[4]),
                csvFields[5]);
        }
    }
}