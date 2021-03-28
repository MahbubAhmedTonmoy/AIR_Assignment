using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entity
{
    public class CreditCardDetails
    {
        [ForeignKey("PassengerProfile")]
        public string PassengerId { get; set; }
        public PassengerProfile PassengerProfile { get; set; }
        public string CardNumber { get; set; }
        public string CardType { get; set; }
        public int ExpirationMonth { get; set; }
        public int ExpirationYear { get; set; }
    }
}
