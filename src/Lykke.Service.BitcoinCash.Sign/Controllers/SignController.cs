﻿using System.Net;
using System.Threading.Tasks;
using Lykke.Service.BitcoinCash.Sign.Core.Sign;
using Lykke.Service.BitcoinCash.Sign.Models;
using Lykke.Service.BitcoinCash.Sign.Models.Sign;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Lykke.Service.BitcoinCash.Sign.Controllers
{
    [Route("api/[controller]")]
    public class SignController : Controller
    {
        private readonly ITransactionSigningService _transactionSigningService;

        public SignController(ITransactionSigningService transactionSigningService)
        {
            _transactionSigningService = transactionSigningService;
        }
        
        [HttpPost]
        [SwaggerOperation(nameof(SignRawTx))]
        [ProducesResponseType(typeof(SignOkTransactionResponce), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> SignRawTx([FromBody]SignRequest sourceTx)
        {
            if (!ModelState.IsValid)
            {

                return BadRequest(ErrorResponse.Create("ValidationError", ModelState));
            }

            var signResult = await _transactionSigningService.SignAsync(sourceTx.TransactionContext, sourceTx.PrivateKeys);

            var respResult = new SignOkTransactionResponce
            {
                SignedTransaction = signResult.TransactionHex
            };

            return Ok(respResult);
        }
    }
}