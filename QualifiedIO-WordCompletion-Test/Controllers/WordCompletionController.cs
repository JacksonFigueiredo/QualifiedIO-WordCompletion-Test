using Microsoft.AspNetCore.Mvc;

namespace QualifiedIO_WordCompletion_Test.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        [ApiController]
        [Route("")]
        public class WordController : ControllerBase
        {
            private static readonly HttpClient _httpClient = new HttpClient();
            private static List<string> _wordList;

            public async Task<List<string>> GetWordListAsync()
            {
                if (_wordList == null)
                {
                    var response = await _httpClient.GetAsync("https://raw.githubusercontent.com/dwyl/english-words/master/words_alpha.txt");
                    var content = await response.Content.ReadAsStringAsync();
                    _wordList = content.Split('\n').Select(w => w.TrimEnd()).ToList();
                }

                return _wordList;
            }
            [HttpGet(Name = "GeWords")]
            [HttpGet]
            public async Task<IActionResult> Get(string stem = "")
            {
                var wordList = await GetWordListAsync();

                if (string.IsNullOrEmpty(stem))
                {
                    return Ok(new { data = wordList });
                }

                var matchingWords = wordList.Where(w => w.StartsWith(stem)).ToList();

                if (matchingWords.Count == 0)
                {
                    return NotFound();
                }

                return Ok(new { data = matchingWords });
            }
        }
    } 
}