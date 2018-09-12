using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DoE.Lsm.ShoppingCard.Norms.Validations.Rules
{
    using API;
    using Exceptions;

    /**   The TeacherGuideValidationRule class will contains all the norms merged to ordering a learner guides.
     */
    ///<summary>
    ///    The TeacherGuideValidationRule class will contains all the norms merged to ordering a learner guides.
    ///	  <remark>   
    /// 			TOADD a new norm just create a method 
    ///	  <see> 
    ///			Facade design patterns on how I managed to accomplish Inversion of Control(IoC)/Loosely coupled applications techniques
    ///			<seealso>Coding in c# using SOLID Principles</seealso>
    ///	  </see>	
    ///	  </remark>
    ///<summary>
    public sealed class TeacherGuideValidationRule
    {

    /**
     *  Validate Teacher guide policy against the thrown category codes.  
     */
    ///<summary>  Validate Teacher guide policy against the thrown category codes.
    ///	   <exception cref='ShoppingCard.Validation.Exceptions.LearnerGuideException'> If this norm is broken this exception will be thrown </exception>
    ///  <param name="x">  
    ///            Category code on the item being validated.
    ///     <example>
    ///       <option value ='21'> Teacher Guide 		    </option>
    ///       <option value ='22'> Teacher Reference Book	</option>        
    ///     </example>
    ///	</param>
    ///  <param name="y"> Quota</param>
    ///  <param name="z"> Quota </param>
    ///<summary>
     public bool IsGreaterThan(int x , int y , int z, string e)
     {
          if(x == (int)NormsConstants.teacher_guide_cd_option_x01 || x == (int)NormsConstants.teacher_guide_cd_option_x02)
          {
             if( z > y )
             {
                throw  new TeacherGuideNormsException(e); //throw a custom 
             }             
          }
          return true;
     }
   }
}
