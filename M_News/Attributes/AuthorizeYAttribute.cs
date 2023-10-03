﻿using Dapper;
using Mhazami.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Data.SqlClient;

namespace M_News.Attributes
{
    [AttributeUsage(AttributeTargets.All)]
    public class AuthorizeYAttribute : ActionFilterAttribute
    {
        public string? Permission { get;set; }

        public override void OnActionExecuting(ActionExecutingContext context)
        {

            var isAnonymous = context.ActionDescriptor.EndpointMetadata.Any(x => x.GetType().FullName == typeof(AllowAnonymousAttribute).FullName);
            if (isAnonymous)
                return;
            var id = context.HttpContext.User.Claims.FirstOrDefault(x => x.Type == "Id")?.Value;
            if (string.IsNullOrEmpty(id) || id.ToGuid() == Guid.Empty)
            {
               // context.Result = new StatusCodeResult(401);
                return;
            }

            string query = "select Permissions.Title from Admins " +
               "inner join UserRole on UserRole.UserId = Admins.User_Id " +
               "inner join Roles on Roles.Id = UserRole.RoleId " +
               "inner join RolePermissions on RolePermissions.RoleId = Roles.Id " +
               "inner join Permissions on Permissions.Id = RolePermissions.PermissionId " +
               "where Admins.User_Id = @GuidValue and Permissions.Title = @pTitle";

            DynamicParameters paramaters = new();
            paramaters.Add("@GuidValue", id);
            paramaters.Add("@pTitle", Permission);

            // string connections = "server=DESKTOP-RKAH2TS;database=NewsDb;integrated security=true;Encrypt=false";
            string connections = "server=LPTNET052\\SQLEXPRESS;database=NewsDb;integrated security=true;Encrypt=false";
            using (SqlConnection connection = new(connections))
            {
                var result = connection.Query<string>(query, paramaters);
                if (result != null && result.Any(x => x == Permission))
                {
                    return;
                }


                else
                {
                  //  context.Result = new ForbidResult(); // Returns a 403 Forbidden status code
                    return;
                }
            }
        }

    }
}


/*List<String> columnData = new List<String>();

using (SqlConnection connection = new SqlConnection("conn_string"))
{
    connection.Open();
    string query = "SELECT Column1 FROM Table1";
    using (SqlCommand command = new SqlCommand(query, connection))
    {
        using (SqlDataReader reader = command.ExecuteReader())
        {
            while (reader.Read())
            {
                columnData.Add(reader.GetString(0));
            }
        }
    }
}*/
/*AdminManager um = new AdminManager(new EfAdminDal());
Admin Value = um.GetAdmin(Gid);*/
/*var value = User.Identity.Name;*/
/*            var claims = ClaimsPrincipal.Current.Identity.Name;*/