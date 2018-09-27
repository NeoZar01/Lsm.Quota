namespace DoE.Lsm
{
    public static class ArrayExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="y"></param>
        /// <param name="x"></param>
        /// <returns></returns>
        public static bool IsAnyEqual(this string[] y, string x)
        {
            for (int i = 0; i < y.Length; i++)
            {
                if (y[i].Equals(x))
                {
                    return true;
                }
                    continue;
            }
            return false;
        }
    }
}