using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WibaReport.DTOs;

namespace WibaReport.Services.MedicalReportModule
{
   public interface IMedicalReportService
    {
        MedicalReportDTO GetAllMedicalReportById(Guid Id);
        List<MedicalReportDTO> GetAllMedicalReport();
    }
}
