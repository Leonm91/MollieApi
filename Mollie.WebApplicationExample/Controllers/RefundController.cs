﻿using System.Threading.Tasks;
using System.Web.Mvc;
using Mollie.Api.Client;
using Mollie.WebApplicationExample.Infrastructure;

namespace Mollie.WebApplicationExample.Controllers {
    public class RefundController : Controller {
        private readonly IRefundClient _mollieClient;

        public RefundController() {
            this._mollieClient = new MollieClient(AppSettings.MollieApiKey);
        }

        [HttpPost]
        public async Task<ActionResult> Refund(string paymentId) {
            await this._mollieClient.CreateRefundAsync(paymentId);

            return this.RedirectToAction("Detail", "Payment", new { id = paymentId });
        }
    }
}