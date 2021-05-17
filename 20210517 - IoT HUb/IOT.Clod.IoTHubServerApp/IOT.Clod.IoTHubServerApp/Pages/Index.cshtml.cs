namespace IOT.Clod.IoTHubServerApp.Pages
{
    using IOT.Clod.IoTHubServerApp.Models;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using Microsoft.Azure.Devices;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.Logging;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly string _connectionString;

        [BindProperty]
        public MessageModel Input { get; set; }

        public IndexModel(ILogger<IndexModel> logger, IConfiguration configuration)
        {
            _logger = logger;
            _connectionString = configuration.GetConnectionString("Service");
        }

        public void OnGet()
        {
            Input = new MessageModel();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                var serviceClient = ServiceClient.CreateFromConnectionString(_connectionString);

                var commandMessage = 
                            new Message(Encoding.ASCII.GetBytes(Input.MessageText));
                await serviceClient.SendAsync(Input.TargetDevice, commandMessage);
                
                return RedirectToPage();
            }
            return Page();
        }
    }
}
