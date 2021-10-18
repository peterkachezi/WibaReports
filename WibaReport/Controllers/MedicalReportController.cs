using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.Mvc;
using CrystalDecisions.CrystalReports.Engine;
using WibaReport.DataSet;
using WibaReport.DTOs;
using WibaReport.Services.MedicalReportModule;

namespace WibaReport.Controllers
{
    public class MedicalReportController : Controller
    {
        private readonly IMedicalReportService medicalReportService;
        public MedicalReportController(IMedicalReportService medicalReportService)
        {
            this.medicalReportService = medicalReportService;
        }

        public ActionResult GenerateMedicalReport(Guid Id)
        {
            try
            {
                var Title = "Dr -";

                ReportDocument rd = new ReportDocument();

                rd.Load(Path.Combine(Server.MapPath("~/Reports"), "MedicalReport.rpt"));

                List<MedicalReportDTO> list1 = new List<MedicalReportDTO>();

                var list = medicalReportService.GetAllMedicalReport().Where(x => x.Id == Id).ToList();

                //var all = medicalReportService.GetAllMedicalReportById(Id);

                DataSet1 dataSet1 = new DataSet1();

                foreach (var item in list)
                {
                    dataSet1.MedicalReport.AddMedicalReportRow(

                    item.FullName,

                    item.Email,

                    item.PhoneNumber,

                    item.IDNumber,

                    item.Gender,

                    item.NhifNumber,

                    item.Occupation,

                    item.OccupationalDisease,

                    item.InpatientNumber,

                    item.PermanentIncapacityDetails,

                    item.PercentageOfpermanentIncapacity,

                    item.medicalPractitioner,

                    item.HospitalName,

                    item.Examination,

                    item.TemporaryIncapacity,

                    item.DateOfExamination.ToShortDateString(),

                    Title +" "+ item.CreatedByName

                   );
                }
                bool isEmpty = !list.Any();

                if (isEmpty)
                {
                    TempData["Bliss_Error"] = "No data was found between  the selected date period!";
                    return RedirectToAction("Index", "Reports");
                }
                else
                {
                    rd.SetDataSource(dataSet1);
                    //rd.SetParameterValue("DateFrom", fromDate.Value.ToShortDateString());
                    //rd.SetParameterValue("DateTo", toDate.Value.ToShortDateString());
                    Response.Buffer = false;
                    Response.ClearContent();
                    Response.ClearHeaders();
                    //rd.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Landscape;
                    //rd.PrintOptions.ApplyPageMargins(new CrystalDecisions.Shared.PageMargins(5, 5, 5, 5));
                    //rd.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperA5;

                    Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
                    stream.Seek(0, SeekOrigin.Begin);
                    return File(stream, "application/pdf", "Medical Report" + ".pdf");

                }

            }
            catch (TypeInitializationException ex)
            {
                TempData["Booking_Error"] = "File Not Found, kindly contact your administrator!";

                return RedirectToAction("Index", "Reports");
            }
            catch (Exception ex)
            {
                TempData["Booking_Error"] = "An error occured, kindly contact your administrator!";
                return RedirectToAction("Index", "Reports");
            }

        }

    }
}