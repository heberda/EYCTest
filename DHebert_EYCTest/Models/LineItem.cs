using System;
using System.ComponentModel.DataAnnotations;

namespace DHebert_EYCTest.Models
{
    public class LineItem
    {
        public LineItem(Product product, int quantity)
        {
            this.Product = product;
            this.Units = quantity;
        }

        #region Properties

        public Product Product { get; set; }
        
        public int Units { get; set; }

        [DataType(DataType.Currency)]
        public double Total
        {
            get
            {
                return Units * Product.UnitPrice;
            }
        }

        [Display(Name = "Retailer Charge"),
        DataType(DataType.Currency)]
        public double RetailerCharge
        {
            get
            {
                var discount = CalculateAdditionalCharges();
                return Total * discount;
            }
        }

        #endregion

        #region Private Methods

        private double CalculateAdditionalCharges()
        {
            double charge = 0;

            charge += locationCharge();

            charge += freshCharge();

            charge += bulkCharge();

            return Math.Round(charge, 2);
        }
  
        private double bulkCharge()
        {
            if (Units < 1000)
            {
                return 0.06;
            }
            else if (Units < 5000)
            {
                return 0.04;
            }
            else
            {
                return 0.03;
            }
        }
  
        private double freshCharge()
        {
            return this.Product.Category.Equals(Category.Fresh) ? 0.01 : 0;
        }
    
        private double locationCharge()
        {
            return !this.Product.Country.Equals(Country.UK) ? 0.01 : 0;
        }
        
        #endregion
    }
}