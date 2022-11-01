﻿using Deck_of_Cards_API_Lab_JT.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Deck_of_Cards_API_Lab_JT.Controllers
{
    public class HomeController : Controller
    {
        DeckDAL api = new DeckDAL();
        
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            CreateDeck d = api.NewDeck();
            return View(d);
        }

        public IActionResult DrawNum() //input box for user
        {
            return View();
        }

        public IActionResult HandResult(int key) //display amount of cards user defined
        {
            DrawCard dc = api.DrawCard(key);
            return View(dc);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}