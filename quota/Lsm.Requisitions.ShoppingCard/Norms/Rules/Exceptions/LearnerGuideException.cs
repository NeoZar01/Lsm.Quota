using System;

namespace DoE.Lsm.ShoppingCard.Norms.Validations.Exceptions
{

    /**
     *  The LearnerGuideException is an exception that will be thrown when a 
     *  a rule amended to learner guides is broken
     */
    ///<summary>   
    /// 	This Exception <c>LearnerGuideException</c> will be thrown when a norm assigned to a learner guide is broken.
    /// 	<example>
    ///   <code>
    ///		throw new LearnerGuideException('You broke this rule because of certain norms configured on this rule.')	
    ///   </code>	     
    /// 	</example>
    ///<summary>

    [Serializable]
    public class LearnerGuideException : Exception
    {
            public LearnerGuideException() { }

        /// <summary>
        ///   <param name='exceptionDescription'> User friendly message that will be written out to the user when this exception is thrown </param>
        /// </summary>
        public LearnerGuideException(string exceptionDescription) : base(exceptionDescription){}
    }

}
