using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using CrystalDecisions.CrystalReports.Engine;
using WibaReport.DataSet;
using WibaReport.Services;

namespace WibaReport.Controllers
{
    public class ReportsController : Controller
    {
        private readonly IMemberService memberService;

        public ReportsController(IMemberService memberService)
        {
            this.memberService = memberService;
        }
        public ActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> MembersReport(string documentType)
        {

            try
            {
                ReportDocument rd = new ReportDocument();

                rd.Load(Path.Combine(Server.MapPath("~/Reports"), "MembersReport.rpt"));

                var list = await memberService.GetAll();

                DataSet1 dataSet1 = new DataSet1();

                foreach (var item in list)
                {
                    dataSet1.Members.AddMembersRow(

                           item.Id,

                           item.FirstName,

                           item.MiddleName,

                           item.LastName,

                           item.PhoneNumber,

                           item.DateOfBirth,

                           item.IDNumber,

                           item.Email,

                           item.MemberNumber,

                           item.EmployeeNumber,

                           item.NhifNumber,

                           item.Relationship,

                           item.Gender,

                           item.Occupation

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

                    if (documentType == "pdf")

                    {
                        Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
                        stream.Seek(0, SeekOrigin.Begin);
                        return File(stream, "application/pdf", "Booking Report From" + ".pdf");
                    }

                    else
                    {
                        Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.ExcelRecord);
                        stream.Seek(0, SeekOrigin.Begin);
                        return File(stream, "application/pdf", "Booking Report From " + ".xls");
                    }

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