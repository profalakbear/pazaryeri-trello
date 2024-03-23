using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVC.Helpers;
using MVC.Mediator;
using MVC.Models;
using System.Reflection;
using System.Security.Claims;
using System.Text;
using System.Text.Json;

namespace MVC.Controllers
{
    public class AuthController : Controller
    {
        private readonly IMediatorService _mediator;

        public AuthController(IMediatorService mediator)
        {
            _mediator = mediator;
        }

        // GET: AuthController
        public async Task<IActionResult> Login(UserDTO user)
        {
            if (ModelState.IsValid)
            {
                var json = JsonSerializer.Serialize(user);

                using var httpClient = new HttpClient();
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                try
                {
                    var response = await httpClient.PostAsync("http://localhost:13741/api/auth/login", content);
                    if (response.IsSuccessStatusCode)
                    {
                        var responseContent = await response.Content.ReadAsStringAsync();
                        var responseData = JsonSerializer.Deserialize<Dictionary<string, string>>(responseContent);
                        if (responseData.ContainsKey("token"))
                        {
                            var token = responseData["token"];
                            var kvp = JwtHelper.DecodeJwtToken(token);
                            foreach (var claim in kvp)
                            {
                                HttpContext.Session.SetString(claim.Key, claim.Value);
                            }

                            var userId = 5;
                            var apiUrl = $"http://localhost:13741/api/ListItems/ByUser/{userId}";
                            var responseLists = await httpClient.GetAsync(apiUrl);
                            var responseListRead = await responseLists.Content.ReadAsStringAsync();
                            TempData["responseListRead"] = responseListRead.ToString();

                            return RedirectToAction("Index", "Home");
                        }
                    }
                    else
                    {
                        ViewBag.Message = "Invalid username or password";
                        return View();
                    }
                }
                catch (HttpRequestException ex)
                {
                    Console.WriteLine($"Request failed: {ex.Message}");
                    ViewBag.Message = "Error occurred while processing your request";
                    return View();
                }
            }

            return View();
        }

        public async Task<IActionResult> Signup(UserDTO user)
        {
            if (ModelState.IsValid)
            {
                var json = JsonSerializer.Serialize(user);

                using var httpClient = new HttpClient();

                var content = new StringContent(json, Encoding.UTF8, "application/json");

                try
                {
                    var response = await httpClient.PostAsync("http://localhost:13741/api/auth/register", content);
                    if (response.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Login", "Auth");
                    }
                    else
                    {
                        ViewBag.Message = "Error happened";
                        View();
                    }
                }
                catch (HttpRequestException ex)
                {
                    Console.WriteLine($"Request failed: {ex.Message}");
                    ViewBag.Message = "Error occurred while processing your request";
                    return View();
                }
            }
            return View();
        }

    }
}
