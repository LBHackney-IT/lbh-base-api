

using System.ComponentModel.DataAnnotations;

namespace transactions_api.V1.Boundary
{
    public class ListTransactionsRequest
    {
        [Required] public string PropertyRef { get; set; }
    }
}
