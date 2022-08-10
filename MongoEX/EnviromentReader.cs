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
                return data[1];
        }
        return null;
    }
}