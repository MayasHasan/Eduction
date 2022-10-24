using Core.ModelForAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EducationSysetm.AuthenticationService 
{
    public interface IAuthService
    {
        Task<Response> RegisterAsync(RegisterModel model );
        Task<Response> GetTokenAsync(TokenRequestModel model);
        Task<string> AddRoleAsync(AddRoleModel model);
        Task<string> RemoveRoleAsync(AddRoleModel model);


    }
}
