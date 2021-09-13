using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Tess.Server.Auth;
using Tess.Server.Services;
using Tess.Shared.Models;

namespace Tess.Server.Pages
{
    [ServiceFilter(typeof(RemoteControlFilterAttribute))]
    public class RemoteControlModel : PageModel
    {
        private readonly IDataService _dataService;
        public RemoteControlModel(IDataService dataService)
        {
            _dataService = dataService;
        }

        public TessUser TessUser { get; private set; }
        public void OnGet()
        {
            if (User.Identity.IsAuthenticated)
            {
                TessUser = _dataService.GetUserByNameWithOrg(base.User.Identity.Name);
            }
        }
    }
}
