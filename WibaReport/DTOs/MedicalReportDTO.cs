using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WibaReport.DTOs
{
    public class MedicalReportDTO
    {
        public Guid Id { get; set; }
        public int RecordStatus { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public Guid AppointmentId { get; set; }
        public Guid MemberId { get; set; }
        public Guid ClaimId { get; set; }
        public byte TypeOfInjury { get; set; }
        public DateTime DateOfAdmission { get; set; }
        public bool IsDischarged { get; set; }
        public string InpatientNumber { get; set; }
        public string OccupationalDisease { get; set; }
        public bool IspermanentIncapacity { get; set; }
        public string PermanentIncapacityDetails { get; set; }
        public string PercentageOfpermanentIncapacity { get; set; }
        public bool IsfurtherExaminationRequired { get; set; }
        public string Examination { get; set; }
        public DateTime DateOfExamination { get; set; }
        public string medicalPractitioner { get; set; }
        public string TemporaryIncapacity { get; set; }
        public string HospitalName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string MemberNumber { get; set; }
        public string PhoneNumber { get; set; }
        public long ClaimNumber { get; set; }
        public string FullName => FirstName + " " + MiddleName + " " + LastName;
        public string Gender { get; set; }
        public string IDNumber { get; set; }
        public string Email { get; set; }
        public string NhifNumber { get; set; }
        public string Occupation { get; set; }
        public int ClinicId { get; set; }
        public string ClinicName { get; set; }
        public string CreatedByName { get; set; }
    }
}