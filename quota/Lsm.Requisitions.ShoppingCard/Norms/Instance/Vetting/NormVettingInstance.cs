namespace DoE.Lsm.ShoppingCard.Norms.Validations
{
    using API;
    using Rules;

    ///<summary>
    ///
    ///<summary>
    public partial class NormVettingInstance
    {

        private readonly LearnerGuideValidationRule learnerGuide = new LearnerGuideValidationRule();
        private readonly TeacherGuideValidationRule teacherGuide = new TeacherGuideValidationRule();

        ///<summary>
        ///
        ///<summary>
        public Policy HasPassed(int quantity, ref int quota, int category, int teacherCount)
        {
         ///For teacher guides
            if (category == (int)NormsConstants.teacher_guide_cd_option_x01 || category == (int)NormsConstants.teacher_guide_cd_option_x02)
            {
              return RunTeacherGuide(category, teacherCount, quantity, quota);
            }

          ///For learner guides
              return RunLeanerGuide(category, teacherCount, quantity, quota);
        }

    }

    ///<summary>
    ///
    ///<summary>
    public partial class NormVettingInstance : INormVettingInstance
    {

        ///<summary>
        ///
        ///<summary>
        public Policy RunLeanerGuide(int category, int teacherCount, int quantity, int quota)
        {
            try
            {
                bool hasPassed = learnerGuide.IsGreaterThan(quantity, quota , "You caanot order more books than the number of learners enrolled in your subject");
            }
            catch 
            {
                return Policy.Failed;
            }
            return Policy.Passed; 
        }

        ///<summary>
        ///
        ///<summary>
        public Policy RunTeacherGuide(int category , int teacherCount ,int quantity , int quota)
        {
            try
            {
                var IsTeacherComplaint = teacherGuide.IsGreaterThan(category, teacherCount, quantity, "You can only make orders based on the number of teachers assigned a subject.");

                    quota = teacherCount;
                    return Policy.Passed;
            }
            catch
            {
                return Policy.Failed;
            }
        }
    }
}