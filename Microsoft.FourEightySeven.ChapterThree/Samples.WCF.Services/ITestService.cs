using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Samples.WCF.Services
{
    [ServiceContract(Namespace = "http://www.williamgryan.mobi/Books/70-487")]
    public interface ITestService
    {
        [OperationContract]
        AnswerDetails GetAnswerDetails(Int32 questionNumber);
        [OperationContract]
        AnswerSet[] GetQuestionAnswers(Int32 questionNumber);
        [FaultContract(typeof(IndexOutOfRangeException))]
        [OperationContract]
        String GetQuestionText(Int32 questionNumber);
        [OperationContract]
        String[] GetExamOutline(String examName);
    }

    [DataContract(Namespace = "http://www.williamgryan.mobi/Book/70-487")]
    public class TestQuestion
    {
        [DataMember]
        public Int32 QuestionId { get; set; }
        [DataMember]
        public Int32 QuestionText { get; set; }
        [DataMember]
        public AnswerSet[] AvailableAnswers { get; set; }
        [DataMember]
        public AnswerDetails Answers { get; set; }
    }

    [DataContract(Name = "Answers", Namespace = "http://www.williamgryan.mobi/Book/70-487")]
    public class AnswerSet
    {
        [DataMember(Name = "QuestionId", IsRequired = true)]
        public Int32 QuestionId { get; set; }
        [DataMember]
        public Guid AnswerId { get; set; }
        [DataMember]
        public String AnswerText { get; set; }
    }

    [DataContract(Namespace = "http://www.williamgryan.mobi/Book/70-487")]
    [Flags]
    public enum AnswerDetails : int
    {
        [EnumMember(Value = "1")]
        A = 0x0,
        [EnumMember(Value = "2")]
        B = 0x1,
        [EnumMember(Value = "3")]
        C = 0x2,
        [EnumMember(Value = "Bill")]
        D = 0x4,
        [EnumMember(Value = "Ryan")]
        All = 0x8
    }

    [DataContract(Name = "English", Namespace = "487Samples")]
    public class EnglishQuestion : QuestionBase
    {
        public string content;
    }

    public class QuestionBase
    {
        public string text;
        public int number;
    }

    [DataContract(Name = "Math", Namespace = "487Samples")]
    public class MathQuestion : QuestionBase
    { 
        public string formula;
    }

    [DataContract(Namespace = "487Sample")]
    public class QuestionManager
    {
        [DataMember]
        private Guid QuestionSetId;
        [DataMember]
        private QuestionBase ExamQuestion;
    }


}



