using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Line_system.CsvReading
{
    public class CsvReaderContext<T>
    {
        private ICsvReadStrategy<T> _readStrategy;

        public CsvReaderContext(ICsvReadStrategy<T> readStrategy)
        {
            _readStrategy = readStrategy;
        }

        public IEnumerable<T> ReadData(string filepath, char separator)
        {
            return File.ReadLines(filepath)
                .Skip(1)
                .Select(line => _readStrategy.ReadCsvLine(line, separator));
        }
    }
}