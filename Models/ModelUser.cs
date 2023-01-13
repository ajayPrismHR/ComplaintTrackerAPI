using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ComplaintTrackerAPI.Models
{
    public class ModelUser
    {
        public string LoginId { get; set; } 
        public int User_id { get; set; }
        public string User_Name { get; set; }
        public string Password { get; set; }
        public string Confirm_Password { get; set; }
        public string Name { get; set; }
        public string Role { get; set; }
        public Int64 Mobile_NO { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public bool Is_Active { get; set; }
        public bool Is_deleted { get; set; }
        public List<ModelRoles> RolesCollection { get; set; }
        public int RoleID { get; set; }

        public bool  RememberMe { get; set; }
    }
}