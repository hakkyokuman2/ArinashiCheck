using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ありなしチェック
{
    static class Program
    {
        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        [STAThread]
        static void Main()
        {
            string list1file = @"C:\111\takatsuka.txt";
            string list2file = @"C:\111\mkanri.txt";
            string resultfile = @"C:\111\MKANRI-result.txt";

            string[] lines1 = File.ReadAllLines(list1file, System.Text.Encoding.GetEncoding("Shift_JIS"));
            string[] lines2 = File.ReadAllLines(list2file, System.Text.Encoding.GetEncoding("Shift_JIS"));

            List<string> ls = new List<string>();
            ls.AddRange(lines2);

            for (int i = ls.Count - 1; 0 <= i; i--)
            {
                if (isExist(lines1, ls[i]) == true)
                {
                    ls.RemoveAt(i);
                }
            }

            File.WriteAllLines(resultfile, ls.ToArray(), System.Text.Encoding.GetEncoding("Shift_JIS"));
        }

        static bool isExist(string[] lines, string str)
        {
            foreach (string line in lines)
            {
                if (line == str) return true;
            }
            return false;
        }


    }
}
