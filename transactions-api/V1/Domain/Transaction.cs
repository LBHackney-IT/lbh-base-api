using System;

namespace transactions_api.V1.Domain
{
    public class Transaction
    {
        public Decimal Balence { get; set; }
        public string Code { get; set; }
        public DateTime Date { get; set; }

        public override bool Equals(object obj)
        {
            Transaction transaction = obj as Transaction;
            if (transaction != null)
            {
                return Balence == transaction.Balence && string.Equals(Code, transaction.Code) && Date.Equals(transaction.Date);
            }
            return false;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = Balence.GetHashCode();
                hashCode = (hashCode * 397) ^ (Code != null ? Code.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ Date.GetHashCode();
                return hashCode;
            }
        }
    }
 }
