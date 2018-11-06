using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoE.Lsm
{
    public static class Command
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="command"></param>
        /// <param name="pattern">([1-9][0-9]{0,2})</param>
        /// <param name="tokens"></param>
        /// <returns></returns>
        public static int[] ResolveCommandExpressions( string pattern, string command, params string[] tokens )
        {

            int[] arry = new int[tokens.Length];

            if (tokens.Length > 0)
            {
                for (int i = 0; i < tokens.Length; i++)
                {
                    arry[i] = int.Parse(string.Empty.Match(command, string.Concat(tokens[i], ":", pattern, ";"), tokens[i]));
                }
            }

            return arry;
        }
    }
}