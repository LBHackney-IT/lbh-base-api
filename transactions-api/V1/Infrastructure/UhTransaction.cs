using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace transactions_api.V1.Domain
{
    [Table("rtrans")]
    public class UhTransaction
    {
        public static UhTransaction fromTransaction(Transaction transaction)
        {
            return new UhTransaction
            {
                Balence = transaction.Balence,
                Code = transaction.Code,
                Date = transaction.Date
            };
        }

        [Column("prop_ref")]
        public String PropRef { get; set; }

        [Column("full_value")]
        public Decimal Balence { get; set; }

        [Column("trans_type")]
        public string Code { get; set; }

        [Column("post_date")]
        public DateTime Date { get; set; }

        [Key, Column("rtrans_sid")]
        public int Id { get; set; }

        [Column("batchno")]
        public Decimal batchno { get; set; }

        [Column("transno")]
        public int transno { get; set; }

        [Column("line_no")]
        public int line_no { get; set; }

        [Column("adjustment")]
        public Boolean adjustment { get; set; }

        [Column("apportion")]
        public Boolean apportion { get; set; }

        [Column("prop_deb")]
        public Boolean prop_deb { get; set; }

        [Column("none_rent")]
        public Boolean none_rent { get; set; }

        [Column("receipted")]
        public Boolean receipted { get; set; }

        [Column("line_segno")]
        public Decimal line_segno { get; set; }

        public override bool Equals(object obj)
        {
            UhTransaction other = obj as UhTransaction;
            if (other == null)
            {
                return false;
            }
            return Balence == other.Balence &&
                   string.Equals(PropRef, other.PropRef) &&
                   string.Equals(Code, other.Code) &&
                   Date.Equals(other.Date) &&
                   Id == other.Id &&
                   batchno == other.batchno &&
                   transno == other.transno &&
                   line_no == other.line_no &&
                   adjustment == other.adjustment &&
                   apportion == other.apportion &&
                   prop_deb == other.prop_deb &&
                   none_rent == other.none_rent &&
                   receipted == other.receipted &&
                   line_segno == other.line_segno;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = Balence.GetHashCode();
                hashCode = (hashCode * 397) ^ (PropRef != null ? PropRef.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Code != null ? Code.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ Date.GetHashCode();
                hashCode = (hashCode * 397) ^ Id;
                hashCode = (hashCode * 397) ^ batchno.GetHashCode();
                hashCode = (hashCode * 397) ^ transno;
                hashCode = (hashCode * 397) ^ line_no;
                hashCode = (hashCode * 397) ^ adjustment.GetHashCode();
                hashCode = (hashCode * 397) ^ apportion.GetHashCode();
                hashCode = (hashCode * 397) ^ prop_deb.GetHashCode();
                hashCode = (hashCode * 397) ^ none_rent.GetHashCode();
                hashCode = (hashCode * 397) ^ receipted.GetHashCode();
                hashCode = (hashCode * 397) ^ line_segno.GetHashCode();
                return hashCode;
            }
        }
    }
 }
