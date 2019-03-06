using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using base_api.V1.Boundary;

namespace base_api.Controllers.V1
{
    [Route("api/v1/transactions")]
    [ApiController]
    [Produces("application/json")]
    public class TransactionsController : BaseController
    {
        private readonly IListTransactions _listTransactions;
        private readonly ILogger<TransactionsController> _logger;

        public TransactionsController(IListTransactions listTransactions, ILogger<TransactionsController> logger)
        {
            _listTransactions = listTransactions;
            _logger = logger;
        }

        [HttpGet]
        public JsonResult GetTransactions([FromQuery]ListTransactionsRequest request)
        {
            _logger.LogInformation("Transactions requested for PropertyRef: " + request.PropertyRef);
            var usecaseResponce = _listTransactions.Execute(request);
            return new JsonResult(usecaseResponce) {StatusCode = 200};
        }
    }
}
