using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Samples.WCF.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class TestService : ITestService
    {
        public AnswerDetails GetAnswerDetails(Int32 questionNumber)
        {
            AnswerDetails CurrentDetails = new AnswerDetails();
            // Method implementation
            return CurrentDetails;
        }
        public AnswerSet[] GetQuestionAnswers(Int32 questionNumber)
        {
            AnswerSet[] CurrentAnswers = null;
            // Method implementation
            return CurrentAnswers;
        }
        public String GetQuestionText(Int32 questionNumber)
        {
            if (questionNumber <= 0)
            {
                String OutOfRangeMessage = "Question Ids must be a positive value greater than 0";
                IndexOutOfRangeException InvalidQuestionId =
                new IndexOutOfRangeException(OutOfRangeMessage);
                throw new FaultException<IndexOutOfRangeException>(InvalidQuestionId,
                OutOfRangeMessage);
            }
            String AnswerText = null;
            // Method implementation
            return AnswerText;
        }

        public String[] GetExamOutline(String examName)
        {
            String[] OutlineItems = null;
            // Method implementation
            return OutlineItems;
        }
    }

    


}
