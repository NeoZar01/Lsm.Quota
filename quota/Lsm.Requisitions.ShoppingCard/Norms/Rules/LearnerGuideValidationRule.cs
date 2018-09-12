namespace DoE.Lsm.ShoppingCard.Norms.Validations.Rules
{

    using Exceptions;

    /**   The LearnerGuideValidationRule class will contains all the norms merged to ordering a learner guides.
     */
    ///<summary>
    ///    The LearnerGuideValidationRule class will contains all the norms merged to ordering a learner guides.
    ///	  <remark>  TOADD a new norm just create a method and  </remark>
    ///	  <see> Facade design patterns on how I managed to accomplish Inversion of Control(IoC)/Loosely coupled applications techniques</see>
    ///	  <seealso>Coding in c# using SOLID Principles</seealso>
    ///<summary>
    public sealed class LearnerGuideValidationRule
    {

        ///<summary>
        ///		<exception cref='ShoppingCard.Validation.Exceptions.LearnerGuideException'> If this norm is broken this exception will be thrown </exception>
        ///<summary>
        public bool IsGreaterThan(int x , int y, string z)
        {
            if( x > y )
            {
                throw new LearnerGuideException(z);
            }
            return true;
        }
    }
}
