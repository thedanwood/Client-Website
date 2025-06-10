using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RJHWebsite.Pages.TermsAndConditions
{
    public class TCModel : PageModel
    {
        public void OnGet()
        {

        }

        public async Task<IActionResult> OnGetDownloadPdf()
        {
           string filePath = "https://roryjholbrook.co.uk/downloads/Trade-Credit-Terms-and-Conditions.pdf";

            if (!string.IsNullOrEmpty(filePath))
            {
                using HttpClient httpClient = new HttpClient();
                using HttpResponseMessage response = await httpClient.GetAsync(filePath);
                if (response.IsSuccessStatusCode)
                {
                    MemoryStream memoryStream = new MemoryStream();
                    await response.Content.CopyToAsync(memoryStream);
                    memoryStream.Position = 0;
                    return new FileStreamResult(memoryStream, "application/pdf");
                }
            }
            return Page();
        }
    }
}