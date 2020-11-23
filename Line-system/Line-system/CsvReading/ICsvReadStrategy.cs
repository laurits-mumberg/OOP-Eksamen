namespace Line_system.CsvReading
{
    public interface ICsvReadStrategy<out T>
    {
        public T ReadCsvLine(string line, char separator);
    }
}