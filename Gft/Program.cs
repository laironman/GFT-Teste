using System;
using System.Collections.Generic;

namespace Gft
{
    class Program
    {
        static void Main(string[] args)
        {
            var menu = new Menu();
            if (args.Length == 0 || HelpRequired(args[0]))
            {
                DisplayHelp();

            }
            else
            {
                var menutype = ExtractMenu(args);
                if (menutype == String.Empty)
                    DisplayHelp();
                else
                    Console.WriteLine(menu.Generate(menutype, ConvertItens(args)));
            }
        }

        private static int[] ConvertItens(string[] args)
        {
            string[] middle = args[0].Split(',');

            List<int> final = new List<int>();

            for (int x = 1; x <= (middle.Length - 1); x++)
                final.Add(Convert.ToInt32(middle[x]));

            return final.ToArray();
        }

        private static String ExtractMenu(string[] args)
        {
            try
            {
                var firstarg = args[0].Split(',')[0].ToLower();
                const string menustr = "manhã,manha,noite";
                if (!menustr.Contains(firstarg))
                    return String.Empty;
                else
                    return firstarg.Replace("ha","hã");
            }
            catch
            {
                return String.Empty;
            }
        }

        private static bool HelpRequired(string param)
        {
            const string helpstr = "-h,--help,/?,?,-?";
            return helpstr.Contains(param);
        }

        private static void DisplayHelp()
        {
            Console.WriteLine("por favor use a entrada no formato <Periodo,opcoes...>");
            Console.WriteLine("Ex: manhã,1,2,3");
        }
    }
}
