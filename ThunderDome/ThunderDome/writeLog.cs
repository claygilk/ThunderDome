using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace ThunderDome
{
    /// <summary>
    ///  This class updates the BattleLog.txt file with the results of each match
    /// </summary>
    public class WriteLog
    {
        public static void LogResult(string winnerName, string loserName)
        {
            string logFileName = "BattleLog.txt";
            string fullPathToLog = Path.GetFullPath(logFileName);

            try
            {
                StreamWriter sw = new StreamWriter(fullPathToLog, true);
                sw.Write($"{winnerName} beat {loserName} in the Thunderdome\n");
                sw.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            finally
            {
                // Console.WriteLine("Executin finally block.");
            }
        }
    }
}
