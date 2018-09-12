
namespace DoE.Lsm.ShoppingCard.API
{

    /**
     *      Sets-up Global Constants for the shopping card app.
     */
    public enum NormsConstants : int
    {

        /// <summary>
        ///     Determines norm vetting types.Sets keys for norms vetting type
        ///    <para>Quota validates the number of available books to order</para>
        /// </summary>
        Quota,

          //Teacher guide code id
        teacher_guide_cd_option_x01 = 21,
        teacher_guide_cd_option_x02 = 22
    }

    /**
     *  Determines whether a norm check has passed or not.     
     */
    public enum Policy : int
    {
        Passed = 1,
        Failed = 0
    }

}