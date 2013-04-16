using Shop.DataAccess.Database.Contracts;
using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.DataAccess.Database.Tests
{
    public partial class OrderLine : IOrderLine
    {
        int IOrderLine.ID
        {
            get { return ID; }
            set { ID = value; }
        }

        int IOrderLine.ProductID
        {
            get { return ProductID; }
            set { ProductID = value; }
        }

        int IOrderLine.OrderID
        {
            get { return OrderID; }
            set { OrderID = value; }
        }

        int IOrderLine.Count
        {
            get { return Count; }
            set { Count = value; }
        }

        int IOrderLine.UnitPrice
        {
            get { return UnitPrice; }
            set { UnitPrice = value; }
        }

        int IOrderLine.SupplierID
        {
            get { return SupplierID; }
            set { SupplierID = value; }
        }

        EntityRef<IOrder> IOrderLine.Order
        {
            get { return new EntityRef<IOrder>(Order); }
            set { Order = (Order)value.Entity; }
        }

        EntityRef<IProduct> IOrderLine.Product
        {
            get { return new EntityRef<IProduct>(Product); }
            set { Product = (Product)value.Entity; }
        }

        EntityRef<ISupplier> IOrderLine.Supplier
        {
            get { return new EntityRef<ISupplier>(Supplier); }
            set { Supplier = (Supplier)value.Entity; }
        }
    }
}
