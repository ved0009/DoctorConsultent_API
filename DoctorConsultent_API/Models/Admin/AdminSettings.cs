namespace DoctorConsultent_API.Models.Admin
{
    public class GlobalDataOutput
    {
        public int ID { get; set; }
        public string GlobalVariableScope { get; set; }
        public string GlobalVariableName { get; set; }
        public string GlobalVariableValue { get; set; }
        public string GlobalVariableTitle { get; set; }
        public string GlobalVariableCategory { get; set; }
        public string GlobalValueModifiedBy { get; set; }


    }
    public class UpdateGlobalvariableValueInput
    {
        public int ID { get; set; }
        public string GlobalVariableValue { get; set; }


    }
    public class getPatientsListsOutput
    {
        public int ID { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string MobileNumber { get; set; } = string.Empty;
        public string? ProfilePicture { get; set; }  // Nullable, since it can be NULL
        public string CreatedOn { get; set; }
    }
    public class PatientHistoryInput
    {
        public int ID { get; set; }
    }
    public class PatientHistoryOutput
    {
        public int ID { get; set; }
        public int UserID { get; set; }
        public string Symptom { get; set; } = string.Empty;
        public string? RelevantSpeciality { get; set; }  
        public int? DoctorID { get; set; }  
        public DateTime? StartTime { get; set; }  
        public DateTime? EndTime { get; set; }    
        public string? Status { get; set; }
        public string? TransactionStatus { get; set; }
        public string? TransactionTime { get; set; }

    }

    public class getAllMasterOutput
    {
        public int DropDownValue { get; set; }
        public string DropDownText { get; set; }
    }

    public class UpdateConsultationStatusInput
    {
        public int  ConID { get; set; }
       
    }

    public class  InsertAppointedDoctorandTimeInput
    {
        public int ConID { get; set; }
        public int UserID { get; set; }
        public int RelevantSpeciality { get; set; }
        public int? DoctorID { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
       
    }
 

}
