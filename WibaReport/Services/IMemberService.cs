using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WibaReport.DTOs;

namespace WibaReport.Services
{
   public interface IMemberService
    {
        Task<List<MemberDTO>> GetAll();
    }
}
