using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using WibaReport.DTOs;
using WibaReport.EDMX;

namespace WibaReport.Services
{
    public class MemberService : IMemberService
    {
        private readonly WibaERPProdEntities context;

        public MemberService(WibaERPProdEntities context)
        {
            this.context = context;
        }
        public async Task<List<MemberDTO>> GetAll()
        {
            var member = await context.Members.ToListAsync();

            var members = new List<MemberDTO>();

            foreach (var item in member)
            {
                var data = new MemberDTO
                {
                    Id = item.Id,
                               
                    CreatedBy = item.CreatedBy,

                    UpdatedBy = item.UpdatedBy,

                    CreatedAt = item.CreatedAt,

                    UpdatedAt = item.UpdatedAt,

                    FirstName = item.FirstName,

                    EmployerId = item.EmployerId,

                    MiddleName = item.MiddleName,

                    NhifNumber = item.NhifNumber,

                    LastName = item.LastName,

                    PhoneNumber = item.PhoneNumber,

                    DateOfBirth = item.DateOfBirth,

                    IDNumber = item.IDNumber,

                    Email = item.Email,

                    MemberNumber = item.MemberNumber,

                    Relationship = item.Relationship,

                    Gender = item.Gender,

                    Occupation = item.Occupation,

                    CountyOfResident = item.CountyOfResident,

                    SubCountyOfResident = item.SubCountyOfResident,

                    IsPrincipal = item.IsPrincipal,

                    Password = item.Password,

                    PIN = item.PIN,

                    RoldeId = item.RoldeId,

                    //EmployerName = item.FullName,
                };

                members.Add(data);

            }

            return members;
        }
    }
}