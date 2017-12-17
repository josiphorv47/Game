using System;
using System.Diagnostics;
using System.IO;

namespace GameLib.Helpers
{
    public static class Error
    {
        public static string ErrorLogLocation { get; set; } = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
            "Errors.txt"
        );

        public static void Print(Exception ex)
        {
            Debug.WriteLine(ex);
        }

        public static bool Log(Exception ex, bool openAfter = false)
        {
            try
            {
                if (File.Exists(ErrorLogLocation))
                {
                    File.AppendAllText(ErrorLogLocation, ex.ToString());

                    if (openAfter)
                    {
                        Process.Start(ErrorLogLocation);
                    }
                }

                return true;
            }
            catch(Exception e)
            {
                Print(e);
            }

            return false;
        }

        public static bool LogAndPrint(Exception ex, bool openAfter = false)
        {
            Print(ex);
            return Log(ex, openAfter);
        }
    }
}
