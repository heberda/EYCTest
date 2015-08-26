using System.ComponentModel.DataAnnotations;

namespace DHebert_EYCTest.Models
{
    public class Product
    {
        #region Properties
        public string Name { get; set; }

        public Category Category { get; set; }

        [Display(Name = "Unit Price"),
        DataType(DataType.Currency)]
        public double UnitPrice { get; set; }

        public Country Country { get; set; } 
        #endregion


        public Product(string name, Category category, double unitPrice, Country country)
        {
            this.Name = name;
            this.Category = category;
            this.UnitPrice = unitPrice;
            this.Country = country;
        }
    }
}