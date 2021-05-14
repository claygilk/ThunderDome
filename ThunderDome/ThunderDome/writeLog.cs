using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace ThunderDome
{
    class writeLog
    {
        public static void logWinner(string winnerName, string loserName)
        {
            string logFileName = "BattleLog.txt";
            string fullPathToLog = Path.GetFullPath(logFileName);
            //Console.WriteLine(fullPathToLog);

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
                //Console.WriteLine("Executin finally block.");
            }
        }
    }
}
