using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;

namespace InvoiceEvaluationAPI.Models
{
    public class InvoiceRequest
    {
        public required IFormFile InvoiceDocument { get; set; }
        public required InvoiceDetails InvoiceDetails { get; set; }
    }

    public class InvoiceDetails
    {
        public required string InvoiceId { get; set; }
        [Required]
        [RegularExpression("^S\\d{5}$", ErrorMessage = "Invoice number must start with 'S' followed by 5 digits.")]

        public required string InvoiceNumber { get; set; } // As per document Invoicenumber need to start with "S" followed by 5 digits
        public DateTime InvoiceDate { get; set; }
        public required string Comment { get; set; }

        [Required]
        [System.ComponentModel.DataAnnotations.Range(1, double.MaxValue, ErrorMessage = "Amount must be greater than zero.")]
        //[Range(1, double.MaxValue, ErrorMessage = "Amount must be greater than zero.")]
        public decimal Amount { get; set; }
    }
}