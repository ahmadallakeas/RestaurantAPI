using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.IServices
{
    public interface IServiceManager
    {
        public ICategoryService CategoryService { get; }
        public IAuthenticationService AuthenticationService { get; }
    }
}
