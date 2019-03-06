

using System.ComponentModel.DataAnnotations;

namespace base_api.V1.Boundary
{
    public class ListTransactionsRequest
    {
        [Required] public string PropertyRef { get; set; }
    }
}
