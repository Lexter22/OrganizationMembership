using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Membership_BusinessDataLogic;
using Microsoft.Data.SqlClient;
namespace MembershipAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MembershipController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<MembershipCommon.Members> Get()
        {
            return MembershipBusiness.ShowAllMembers();
        }
        [HttpPost]
        public void AddMember(string firstname,string lastname,string ID)
        {
            MembershipBusiness.AddMember(firstname,lastname,ID);
        }
        [HttpDelete("{id}")]
        public void DeleteMember(string id)
        {
            MembershipBusiness.RemoveMember(id);
        }
        [HttpPatch("{id},{firstname},{lastname}")]
        public void UpdateMember(string id, string firstname, string lastname)
        {
            MembershipBusiness.UpdateMember(id, firstname, lastname);
        }

    }
}
