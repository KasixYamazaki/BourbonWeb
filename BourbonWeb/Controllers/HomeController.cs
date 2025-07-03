// <copyright file="HomeController.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using BourbonWeb.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BourbonWeb.Controllers
{
    /// <summary>
    /// Represents the controller for handling requests to the home page and related views.
    /// </summary>
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="HomeController"/> class.
        /// </summary>
        /// <param name="logger">The logger instance for logging information.</param>
        public HomeController(ILogger<HomeController> logger)
        {
            this._logger = logger;
        }

        /// <summary>
        /// Handles requests to the home page.
        /// </summary>
        /// <returns>The view for the home page.</returns>
        public IActionResult Index()
        {
            return this.View();
        }

        /// <summary>
        /// Handles requests to the privacy page.
        /// </summary>
        /// <returns>The view for the privacy page.</returns>
        public IActionResult Privacy()
        {
            return this.View();
        }

        /// <summary>
        /// Handles requests to the error page.
        /// </summary>
        /// <returns>The view for the error page with error details.</returns>
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return this.View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier });
        }
    }
}