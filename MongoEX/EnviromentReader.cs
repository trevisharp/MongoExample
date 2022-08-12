using System.IO;

public static class EnviromentReader
{
    public static string Read(string key)
    {
        StreamReader reader = new StreamReader(".env");
        while (!reader.EndOfStream)
        {
            var data = reader.ReadLine()?.Split('=');
            if (data == null)
                continue;
            
            if (data[0] == key)
            {
                var result = data[1];
                for (int i = 2; i < data.Length; i++)
                    result += "=" + data[i];
                return result;
            }
        }
        return null;
    }
}