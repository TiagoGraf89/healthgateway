//-------------------------------------------------------------------------
// Copyright © 2019 Province of British Columbia
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
// http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//-------------------------------------------------------------------------
namespace HealthGateway.WebClient.Controllers
{
    using System.Diagnostics;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// HomeController for Vue WebClient app.
    /// </summary>
    public class HomeController : Controller
    {
        /// <summary>
        /// The default page for the home controller.
        /// </summary>
        /// <returns>The default view.</returns>
        public IActionResult Index() => this.View();

        /// <summary>
        /// The default page for error.
        /// </summary>
        /// <returns>The default view.</returns>
        public IActionResult Error()
        {
            this.ViewData["RequestId"] = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier;
            return this.View();
        }
    }
}
