using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WibaReport.DTOs;
using WibaReport.EDMX;

namespace WibaReport.Services.MedicalReportModule
{
    public class MedicalReportService : IMedicalReportService
    {
        private readonly WibaERPProdEntities context;

        public MedicalReportService(WibaERPProdEntities context)
        {
            this.context = context;
        }
        public MedicalReportDTO GetAllMedicalReportById(Guid Id)
        {
            try
            {
                var report = (from r in context.MedicalReports

                              join m in context.Members on r.MemberId equals m.Id

                              join a in context.Appointments on r.AppointmentId equals a.Id

                              join c in context.Clinics on a.ClinicId equals c.Pkid

                              where r.Id == Id

                              select new MedicalReportDTO
                              {
                                  Id = r.Id,

                                  FirstName = m.FirstName,

                                  LastName = m.LastName,

                                  MiddleName = m.MiddleName,

                                  PhoneNumber = m.PhoneNumber,

                                  MemberNumber = m.MemberNumber,

                                  Gender = m.Gender,

                                  IDNumber = m.IDNumber,

                                  Email = m.Email,

                                  NhifNumber = m.NhifNumber,

                                  Occupation = m.Occupation,

                                  CreatedAt = r.CreatedAt,

                                  UpdatedAt = r.UpdatedAt,

                                  AppointmentId = r.AppointmentId,

                                  MemberId = r.MemberId,

                                  ClaimId = r.ClaimId,

                                  DateOfAdmission = r.DateOfAdmission,

                                  IsDischarged = r.IsDischarged,

                                  OccupationalDisease = r.OccupationalDisease != null ? r.OccupationalDisease : "N/A",

                                  InpatientNumber = r.InpatientNumber != null ? r.InpatientNumber : "N/A",

                                  IspermanentIncapacity = r.IspermanentIncapacity,

                                  PermanentIncapacityDetails = r.PermanentIncapacityDetails != null ? r.PermanentIncapacityDetails : "N/A",

                                  PercentageOfpermanentIncapacity = r.PercentageOfpermanentIncapacity != null ? r.PercentageOfpermanentIncapacity : "N/A",

                                  IsfurtherExaminationRequired = r.IsfurtherExaminationRequired,

                                  DateOfExamination = r.DateOfExamination,

                                  Examination = r.Examination != null ? r.Examination : "N/A",

                                  medicalPractitioner = r.medicalPractitioner != null ? r.medicalPractitioner : "N/A",

                                  HospitalName = r.HospitalName != null ? r.HospitalName : "N/A",

                                  TemporaryIncapacity = r.TemporaryIncapacity,

                                  ClinicId = a.ClinicId,

                                  ClinicName = c.Name,
                              });

                return report.FirstOrDefault();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public List<MedicalReportDTO> GetAllMedicalReport()
        {
            try
            {
                var report = (from r in context.MedicalReports

                              join m in context.Members on r.MemberId equals m.Id

                              join a in context.Appointments on r.AppointmentId equals a.Id

                              join c in context.Clinics on a.ClinicId equals c.Pkid

                              join u in context.AspNetUsers on r.CreatedBy equals u.Id

                              select new MedicalReportDTO
                              {
                                  Id = r.Id,

                                  FirstName = m.FirstName,

                                  LastName = m.LastName,

                                  MiddleName = m.MiddleName,

                                  PhoneNumber = m.PhoneNumber,

                                  MemberNumber = m.MemberNumber,

                                  Gender = m.Gender,

                                  IDNumber = m.IDNumber,

                                  Email = m.Email,

                                  NhifNumber = m.NhifNumber,

                                  Occupation = m.Occupation,

                                  CreatedAt = r.CreatedAt,

                                  UpdatedAt = r.UpdatedAt,

                                  AppointmentId = r.AppointmentId,

                                  MemberId = r.MemberId,

                                  ClaimId = r.ClaimId,

                                  DateOfAdmission = r.DateOfAdmission,

                                  IsDischarged = r.IsDischarged,

                                  OccupationalDisease = r.OccupationalDisease != null ? r.OccupationalDisease : "N/A",

                                  InpatientNumber = r.InpatientNumber != null ? r.InpatientNumber : "N/A",

                                  IspermanentIncapacity = r.IspermanentIncapacity,

                                  PermanentIncapacityDetails = r.PermanentIncapacityDetails != null ? r.PermanentIncapacityDetails : "N/A",

                                  PercentageOfpermanentIncapacity = r.PercentageOfpermanentIncapacity != null ? r.PercentageOfpermanentIncapacity : "N/A",

                                  IsfurtherExaminationRequired = r.IsfurtherExaminationRequired,

                                  DateOfExamination = r.DateOfExamination,

                                  Examination = r.Examination != null ? r.Examination : "N/A",

                                  medicalPractitioner = r.medicalPractitioner != null ? r.medicalPractitioner : "N/A",

                                  HospitalName = r.HospitalName != null ? r.HospitalName : "N/A",

                                  TemporaryIncapacity = r.TemporaryIncapacity,

                                  ClinicId = a.ClinicId,

                                  ClinicName = c.Name,

                                  CreatedByName = u.FullName,
                              });

                return report.ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
    }
}