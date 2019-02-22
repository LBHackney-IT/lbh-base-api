using System;

namespace transactions_api.V1.Domain
{
    public class Transaction
    {
        public Decimal Balence { get; set; }
        public string Code { get; set; }
        public DateTime Date { get; set; }
    }
}
