using System.Text.RegularExpressions;
using Line_system.Products;

namespace Line_system.CsvReading
{
    public class ProductReadStrategy : ICsvReadStrategy<IProduct>

    {
        public IProduct ReadCsvLine(string line, char separator)
        {
            string[] csvFields = line.Split(separator);
            return new Product(
                int.Parse(csvFields[0]),
                Regex.Replace(csvFields[1],"<[^>]*>",""), // Removes html-tags
                decimal.Parse(csvFields[2]),
                parseActive(int.Parse(csvFields[3])));
        }
        
        private bool parseActive(int i)
        {
            if (i == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}