using System.Diagnostics;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc;

using MoneyChanger.Models;

namespace MoneyChanger.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    public List<string> _currencyList;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
        _currencyList = new List<string>{
            "EUR", "USD", "JPY", "IDR",
            "AUD", "CAD", "JPY", "SGD", "PHP", "MYR", "CNY" };
    }

    public IActionResult Index()
    {
        ViewBag.currencyList = _currencyList;
        ViewBag.fromCurrency = Global.FromCurrency;
        ViewBag.toCurrency = Global.ToCurrency;
        ViewBag.sourceVal = Global.SourceAmount;
        ViewBag.resVal = Global.ResultAmount;
        ViewBag.isLoading = Global.IsLoading;
        return View();
    }

    [HttpPost]
    public IActionResult Convert(string fromCurrency, string toCurrency, string sourceVal)
    {
        using (var web = new HttpClient())
        {
            web.DefaultRequestHeaders.Add("apikey", "eJMaq8jFfT0GnbG1qEECkxBWdQrayyfI");
            string url = "https://api.apilayer.com/exchangerates_data/convert?to=" + toCurrency + "&from=" + fromCurrency + "&amount=" + sourceVal;
            dynamic webRequest = new HttpRequestMessage(HttpMethod.Get, url);
            dynamic resJSON = web.Send(webRequest);
            using var reader = new StreamReader(resJSON.Content.ReadAsStream());
            ExchangeResponse resp = GetResp(reader.ReadToEnd());
            if (resp.success)
            {
                Global.FromCurrency = fromCurrency;
                Global.ToCurrency = toCurrency;
                Global.SourceAmount = sourceVal;
                Global.ResultAmount = resp.result.ToString();
                Global.IsLoading = false;
            }
            else
            {
                Global.IsLoading = true;
            }
        }
        return RedirectToAction("Index");
    }

    private static ExchangeResponse GetResp(dynamic resJSON)
    {
        return JsonConvert.DeserializeObject<ExchangeResponse>(resJSON);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

    private class ExchangeResponse
    {
        public bool success { get; set; }
        public float result { get; set; }
    }
}
