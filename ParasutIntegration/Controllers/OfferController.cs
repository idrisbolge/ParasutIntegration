using MediatR;
using Microsoft.AspNetCore.Mvc;
using ParasutIntegration.Enums;
using ParasutIntegration.Features.Offer.Commands;
using ParasutIntegration.Features.Offer.Queries;
using ParasutIntegration.Models.Offer;
using ParasutIntegration.Util;
using System.Reflection;

namespace ParasutIntegration.Controllers
{
    [Route("parasutApi/Offer")]
    [ApiController]

    public class OfferController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OfferController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetAllOffer")]
        public async Task<IActionResult> GetAllOfferContact()
        {
            var OfferContact = await _mediator.Send(new GetOffersQuery(0));
            return Ok(OfferContact);
        }

        [HttpGet("GetOfferById")]
        public async Task<IActionResult> GetOfferContactById(int id)
        {
            var OfferContact = await _mediator.Send(new GetOffersQuery(id));
            return Ok(OfferContact);
        }

        [HttpGet("GetOfferDetailsById")]
        public async Task<IActionResult> GetOfferDetailsById(int offerId)
        {
            var offerDetails = await _mediator.Send(new GetOfferDetailsQuery(offerId));
            return Ok(offerDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Post(ParasutOfferModel model)
        {
            var parameters = ParasutRequestFactory.CreateRequestModel("", model);
            var response = await _mediator.Send(new OfferOperationCommands(parameters, HttpMethod.Post));
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Put(ParasutOfferModel model, string id)
        {
            var parameters = ParasutRequestFactory.CreateRequestModel(id, model);
            var response = await _mediator.Send(new OfferOperationCommands(parameters, HttpMethod.Put));
            return Ok(response);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(string id)
        {
            var parameters = ParasutRequestFactory.CreateRequestModel(id, new ParasutOfferModel());
            var response = await _mediator.Send(new OfferOperationCommands(parameters, HttpMethod.Delete));
            return Ok(response);
        }

        [HttpPost("PDF")]
        public async Task<IActionResult> PDF(ParasutOfferPdfModel model)
        {
            var parameters = ParasutRequestFactory.CreateRequestModel("", model);
            var response = await _mediator.Send(new OfferPdfCommands(parameters, HttpMethod.Post));
            return Ok(response);
        }

        [HttpPatch("Archive")]
        public async Task<IActionResult> Archive(int offerId)
        {
            var response = await _mediator.Send(new OfferArchiveCommands(true, offerId));
            return Ok(response);
        }

        [HttpPatch("Unarchive")]
        public async Task<IActionResult> Unarchive(int offerId)
        {
            var response = await _mediator.Send(new OfferArchiveCommands(false, offerId));
            return Ok(response);
        }

        [HttpPatch("UpdateStatus")]
        public async Task<IActionResult> UpdateStatus(ParasutOfferStatusModel model, int offerId)
        {
            var parameters = ParasutRequestFactory.CreateRequestModel(offerId.ToString(), model);
            var response = await _mediator.Send(new ChangeOfferStatusCommands(parameters, offerId));
            return Ok(response);
        }
    }
}
