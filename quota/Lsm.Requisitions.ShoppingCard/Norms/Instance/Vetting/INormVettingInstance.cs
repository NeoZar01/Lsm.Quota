namespace DoE.Lsm.ShoppingCard.Norms.Validations
{
    using API;

    ///<summary>
    ///   This interface contains an abstract of what the Quota Validation Run 
    ///<summary>
    public interface INormVettingInstance
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="category"></param>
        /// <param name="teacherCount"></param>
        /// <param name="quantity"></param>
        /// <param name="quota"></param>
        /// <returns></returns>
        Policy RunTeacherGuide(int category, int teacherCount, int quantity, int quota);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="category"></param>
        /// <param name="teacherCount"></param>
        /// <param name="quantity"></param>
        /// <param name="quota"></param>
        /// <returns></returns>
        Policy RunLeanerGuide(int category, int teacherCount, int quantity, int quota);

    }
}
