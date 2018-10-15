namespace DoE.Lsm
{

    /// <summary>
    ///   Creates methods that extends behavoirs of the datatype string
    /// </summary>
    public static class StringExtension
    {

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
        public static string[] ConvertStringToArray(string text, char separator)
        {
            var arry = text.Split(separator);
            return arry;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="original"></param>
        /// <param name="replacement"></param>
        /// <returns></returns>
        public static string IsNullReplaceWith(this string original, string replacement) {

            if (original == null) return replacement;

            if(string.IsNullOrEmpty(original.Trim()) || string.IsNullOrWhiteSpace(original)  || original.Trim() == "")
            {
                return replacement;
            }
            return original;
        }
    }
}
