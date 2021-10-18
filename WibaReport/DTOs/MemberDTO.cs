using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WibaReport.DTOs
{
    public class MemberDTO
    {
        public int RecordStatus { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string OTPNumber { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string FullName => FirstName + " " + MiddleName + " " + LastName;
        public string PhoneNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string NewDateOfBirth { get { return DateOfBirth.ToString("yyyy-MM-dd"); } }
        public string IDNumber { get; set; }
        public string Email { get; set; }
        public string MemberNumber { get; set; }
        public string EmployeeNumber { get; set; }
        public string NhifNumber { get; set; }
        public string Relationship { get; set; }
        public string CountyOfResident { get; set; }
        public string SubCountyOfResident { get; set; }
        public bool IsPrincipal { get; set; }
        public string Password { get; set; }
        public string Occupation { get; set; }
        public string Gender { get; set; }
        public string PIN { get; set; }
        public Guid EmployerId { get; set; }
        public string EmployerName { get; set; }
        public int? RoldeId { get; set; }
    }
}