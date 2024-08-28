using System.Text.Json.Serialization;

namespace KopiusLibrary.Model.Entities
{
    public class Document
    {
        [JsonPropertyName("DocumentId")]
        public Guid Id { get; set; }
        public string Number { get; set; }
        public Discount Discount { get; set; }
        public Tax Tax { get; set; }
        public DocumentType DocumentType { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public Vendor Vendor { get; set; }
        public Client Client { get; set; }
        public DateTime DateTime { get; set; }
        public Branch Branch { get; set; }
        public Status Status { get; set; }
        public float TotalAmount { get; set; }
    
    }
}
