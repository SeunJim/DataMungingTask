namespace DataMunging.Helper
{
    public static class DataHelper
    {
        public static string[] ReadFile(string path)
        {
            return File.ReadAllLines(path);
        }
        public static string[] SplitRow(string line)
        {
            return line.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        }
        public static int? ConvertToInt(string value)
        {
            if (int.TryParse(value, out int result))
            {
                return result;
            }
            return null;

        }
        public static int ConvertToInt2(int? value)
        {
            var text = value.ToString();
            return int.Parse(text);
        }
    }
}
