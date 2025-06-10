using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RJHWebsite.Pages.Responsibilities
{
    public class Test : PageModel
    {
        public void OnGet()
        {

        }

        public async Task<IActionResult> OnGetDownloadPdf(string file)
        {
           string filePath = "";
           switch (file)
           {
               case "credit application":
                   filePath = "https://roryjholbrook.co.uk/downloads/Credit-Application-Form.pdf";
                   break;
               case "waste carrier":
                   filePath = "https://roryjholbrook.co.uk/downloads/Waste-Carriers-License.pdf";
                   break;
               case "tassc":
                   filePath = "https://roryjholbrook.co.uk/downloads/TASCC-Certificate.pdf";
                   break;
               case "fors silver":
                   filePath = "https://roryjholbrook.co.uk/downloads/FORS-Gold-Certificate.pdf";
                   break;
               case "acclaim":
                   filePath = "https://roryjholbrook.co.uk/downloads/Acclaim-SSIP-Certificate.pdf";
                   break;
               case "construction line":
                   filePath = "https://roryjholbrook.co.uk/downloads/Construction-Line-Gold.pdf";
                   break;
                case "bsi":
                    filePath = "https://roryjholbrook.co.uk/downloads/BSI-Membership-Certificate.pdf";
                    break;
            }

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