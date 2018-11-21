using System;
using System.Text.RegularExpressions;

namespace DoE.Lsm
{

    /// <summary>
    ///   Creates methods that extends behavoirs of the datatype string
    /// </summary>
    public static class StringExtension
    {


        public enum ValidationFlavor {
            Null,
            Equal
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string AddSpacesToSentence(this string value)
        {
            char[] array = value.ToCharArray();
            // Handle the first letter in the string.
            if (array.Length >= 1)
            {
                if (char.IsLower(array[0]))
                {
                    array[0] = char.ToUpper(array[0]);
                }
            }
            // Scan through the letters, checking for spaces.
            // ... Uppercase the lowercase letters following spaces.
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i - 1] == ' ')
                {
                    if (char.IsLower(array[i]))
                    {
                        array[i] = char.ToUpper(array[i]);
                    }
                }
            }
            return new string(array);

        }

        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="stringValue"></param>
        /// <param name="initialLetter"></param>
        /// <returns></returns>
        public static bool StartsWith(this string stringValue, char initialLetter)
        {
            if (string.IsNullOrEmpty(stringValue))
            {
                char[] y = stringValue.ToCharArray();
                return y.Equals(initialLetter);
            }
            return false;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static string ToCapitilized(this string text)
        {


           var arry = text.Split(' ');

            string y = null;

           foreach(var s in arry)
           {
                y += string.Concat(s.Substring(0, 1).ToUpper(),
                                   s.Substring(1, s.Length - 1).ToLower(), " ");
            }

            return y;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public static int ToInt(this string userId)
        {
            //firstly check if this contains special Characters
            return (string.IsNullOrEmpty(userId) ? -1 : int.Parse(userId));
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="text"></param>
        /// <param name="separator"></param>
        /// <returns></returns>
        public static string[] ConvertStringToArray(this string text, char separator)
        {
            var arry = text.Split(separator);
            return arry;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="source"></param>
        /// <param name="replacement"></param>
        /// <returns></returns>
        public static string IsNullReplaceWith(this string source, string replacement) {

            if (source == null) return replacement;

            if(string.IsNullOrEmpty(source.Trim()) || string.IsNullOrWhiteSpace(source)  || source.Trim() == "")
            {
                return replacement;
            }
            return source;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="command"></param>
        /// <param name="pattern"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public static string Match(this string source, string command, string pattern, string token)
        {
            Match result = Regex.Match(command, pattern);
            if (result.Success)
            {
                return result.Value.Replace(string.Concat(token, ":"), "").Replace(';', ' ').Trim();
            }
            return "0";
        }


        public static string IsRequired(this string source , string text,  ValidationFlavor flavor)
        {
            switch (flavor)
            {
                case ValidationFlavor.Null:
                if (string.IsNullOrEmpty(source) || string.IsNullOrEmpty(source))  throw new InvalidCastException("Failed to Merge Property [" + source + "] ");
                break;
                case ValidationFlavor.Equal:
                if (!source.Equals(text)) throw new InvalidCastException("Failed to Merge Property [" + source + "] ");
                break;
                default: throw new InvalidCastException("Failed to Merge Property [" + source + "] ");
            }
            return source;
        }


    }
}
