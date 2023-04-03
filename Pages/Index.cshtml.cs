using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using FizzBuzzWeb.Models;
using System.Xml.Linq;


namespace FizzBuzzWeb.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        [BindProperty]
        public FizzBuzz Input { get; set; }

        [TempData]
        public string Result { get; set; }

        public void OnGet()
        {
        }

        public void OnPost()
        {
            if (ModelState.IsValid)
            {
                if (Input.Year % 4 == 0 && (Input.Year % 100 != 0 || Input.Year % 400 == 0))
                {
                    Result = $"{Input.UserName} urodził(a) się w {Input.Year} roku. To był rok przestępny.";
                }
                else
                {
                    Result = $"{Input.UserName} urodził(a) się w {Input.Year} roku. To nie był rok przestępny.";
                }

                // zapisanie danych w sesji
                var fizzBuzzList = new List<FizzBuzz>();
                var data = HttpContext.Session.GetString("FizzBuzz");
                if (!string.IsNullOrEmpty(data))
                {
                    fizzBuzzList = JsonConvert.DeserializeObject<List<FizzBuzz>>(data);
                }
                fizzBuzzList.Add(Input);
                HttpContext.Session.SetString("FizzBuzz", JsonConvert.SerializeObject(fizzBuzzList));
            }
        }
    }
}

    
