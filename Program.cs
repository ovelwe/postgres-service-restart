using System.Diagnostics;

class Program
{
    const string PG_CTL_EXE = @"C:\Program Files\PostgreSQL\16\bin\pg_ctl.exe";
    const string DATA_DIR = @"C:\Program Files\PostgreSQL\16\data";
    static void Main()
    {
        var process = new Process
        {
            StartInfo = new ProcessStartInfo
            {
                FileName = PG_CTL_EXE,
                Arguments = $"restart -N \"postgresql-x64-16\" -D \"{DATA_DIR}\" -w",
                UseShellExecute = false,
                RedirectStandardOutput = true,
                CreateNoWindow = true,
            }
        };

        try
        {
            process.Start();
            process.WaitForExit();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка {ex.Message}");
        }
        finally
        {

        process.Dispose();
        }
    }
}
