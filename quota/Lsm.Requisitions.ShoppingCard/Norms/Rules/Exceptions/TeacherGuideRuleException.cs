using System;

namespace DoE.Lsm.ShoppingCard.Norms.Validations.Exceptions
{
    /**
     *  The TeacherGuideRuleException is an exception that will be thrown when a 
     *  a rule amended to learner guides is broken
     */
    ///<summary>   
    /// 	This Exception <c>TeacherGuideRuleException</c> will be thrown when a norm assigned to a learner guide is broken.
    /// 	<example>
    ///   <code>
    ///		throw new TeacherGuideRuleException('You broke this rule because of certain norms configured on this rule.')	
    ///   </code>	     
    /// 	</example>
    ///<summary>
    [Serializable]
    public class TeacherGuideNormsException : Exception
    {
        public TeacherGuideNormsException() { }

        /// <summary>
        ///   <param name='exceptionDescription'> User friendly message that will be written out to the user when this exception is thrown </param>
        /// </summary>
        public TeacherGuideNormsException(string message) : base(message){}
    }
}
