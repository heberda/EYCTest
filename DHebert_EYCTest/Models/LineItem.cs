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

        protected internal LineItem()
        {
        }

        #region Properties

        public virtual Product Product { get; set; }
        
        [Range(0, Int32.MaxValue)]
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

        public double CalculateAdditionalCharges()
        {
            double charge = 0;

            charge += LocationCharge();

            charge += FreshCharge();

            charge += BulkCharge();

            return Math.Round(charge, 2);
        }
  
        public double BulkCharge()
        {
            if (Units <= 0)
            {
                return 0;
            }
            else if (Units <= 1000)
            {
                return 0.06;
            }
            else if (Units <= 5000)
            {
                return 0.04;
            }
            else
            {
                return 0.03;
            }
        }
  
        public double FreshCharge()
        {
            return this.Product.Category.Equals(Category.Fresh) ? 0.01 : 0;
        }
    
        public double LocationCharge()
        {
            return !(this.Product.Country.Equals(Country.UK)) ? 0.01 : 0;
        }
        
        #endregion
    }
}