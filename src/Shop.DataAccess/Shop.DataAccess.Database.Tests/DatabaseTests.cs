using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shop.DataAccess.Database.Contracts;
using Shop.Infrastructure.Factory;
using System.Data.Linq;
using System.Linq;

namespace Shop.DataAccess.Database.Tests
{
    [TestClass]
    public class DatabaseTests
    {
        IAddress address;
        IBanner banner;
        IBannersImage bannerImage;
        IBrand brand;
        ICategory category;
        ICity city;
        IFeedback feedback;
        IImage image;
        ILegalPerson legalPerson;
        ILog log;
        IOrder order;
        IOrderLine orderLine;
        IOrdersStatus ordersStatus;
        IPerson person;
        IProduct product;
        IProductsCategory productsCategory;
        IProductsImage productsImage;
        IProductsSupplier productsSupplier;
        IRegion region;
        IStorageRecord storageRecord;
        ISupplier supplier;
        IUser user;

        ShopTestDataContext context;

        [TestInitialize]
        public void InitializeTests()
        {
            context = new ShopTestDataContext();

            ClearDatabase();

            address = Factory.GetComponent<IAddress>();
            banner = Factory.GetComponent<IBanner>();
            bannerImage = Factory.GetComponent<IBannersImage>();
            brand = Factory.GetComponent<IBrand>();
            category = Factory.GetComponent<ICategory>();
            city = Factory.GetComponent<ICity>();
            feedback = Factory.GetComponent<IFeedback>();
            image = Factory.GetComponent<IImage>();
            legalPerson = Factory.GetComponent<ILegalPerson>();
            log = Factory.GetComponent<ILog>();
            order = Factory.GetComponent<IOrder>();
            orderLine = Factory.GetComponent<IOrderLine>();
            ordersStatus = Factory.GetComponent<IOrdersStatus>();
            person = Factory.GetComponent<IPerson>();
            product = Factory.GetComponent<IProduct>();
            productsCategory = Factory.GetComponent<IProductsCategory>();
            productsImage = Factory.GetComponent<IProductsImage>();
            productsSupplier = Factory.GetComponent<IProductsSupplier>();
            region = Factory.GetComponent<IRegion>();
            storageRecord = Factory.GetComponent<IStorageRecord>();
            supplier = Factory.GetComponent<ISupplier>();
            user = Factory.GetComponent<IUser>();            
        }

        [TestCleanup]
        public void CleanupTests()
        {
            ClearDatabase();
        }


        private void ClearDatabase()
        {
            context.Addresses.DeleteAllOnSubmit(context.Addresses);
            context.Banners.DeleteAllOnSubmit(context.Banners);
            context.BannersImages.DeleteAllOnSubmit(context.BannersImages);
            context.Brands.DeleteAllOnSubmit(context.Brands);
            context.Categories.DeleteAllOnSubmit(context.Categories);
            context.Cities.DeleteAllOnSubmit(context.Cities);
            context.Feedbacks.DeleteAllOnSubmit(context.Feedbacks);
            context.Images.DeleteAllOnSubmit(context.Images);
            context.LegalPersons.DeleteAllOnSubmit(context.LegalPersons);
            context.Logs.DeleteAllOnSubmit(context.Logs);
            context.OrderLines.DeleteAllOnSubmit(context.OrderLines);
            context.Orders.DeleteAllOnSubmit(context.Orders);
            context.OrdersStatus.DeleteAllOnSubmit(context.OrdersStatus);
            context.Persons.DeleteAllOnSubmit(context.Persons);
            context.Products.DeleteAllOnSubmit(context.Products);
            context.ProductsCategories.DeleteAllOnSubmit(context.ProductsCategories);
            context.ProductsImages.DeleteAllOnSubmit(context.ProductsImages);
            context.ProductsSuppliers.DeleteAllOnSubmit(context.ProductsSuppliers);
            context.Regions.DeleteAllOnSubmit(context.Regions);
            context.StorageRecords.DeleteAllOnSubmit(context.StorageRecords);
            context.Suppliers.DeleteAllOnSubmit(context.Suppliers);
            context.Users.DeleteAllOnSubmit(context.Users);
        }

        [TestMethod]
        public void DatabaseTests_Address()
        {
            //Initialize all necessary objects for address
            region.Name = "TestRegion";            
            city.Name = "TestCity";
            city.Region = new EntityRef<IRegion>(region);

            //Initialize address
            address.City = city;
            address.House = "TestHouse";
            address.Street = "TestStreet";
            address.Building = "TestBuilding";
            address.Floor = 4;
            address.Housing = "TestHousing";
            address.IntercomeCode = "213";
            address.IsOffice = false;
            address.Porch = "TestPorch";
            
            context.Addresses.InsertOnSubmit((Address)address);
            context.SubmitChanges();

            //Checking for correct record in Addresses table
            Assert.AreEqual("TestHouse", context.Addresses.First().House);
            Assert.AreEqual("TestStreet", context.Addresses.First().Street);
            Assert.AreEqual("TestBuilding", context.Addresses.First().Building);
            Assert.AreEqual(4, context.Addresses.First().Floor);
            Assert.AreEqual("TestHousing", context.Addresses.First().Housing);
            Assert.AreEqual("213", context.Addresses.First().IntercomeCode);
            Assert.AreEqual(false, context.Addresses.First().IsOffice);
            Assert.AreEqual("TestPorch", context.Addresses.First().Porch);

            context.Regions.DeleteOnSubmit((Region)region);
            context.Cities.DeleteOnSubmit((City)city);
            context.Addresses.DeleteOnSubmit((Address)address);
            context.SubmitChanges();
        }

        [TestMethod]
        public void DatabaseTests_Banner()
        {
            //Initialize all necessary objects for banner
            region.Name = "TestRegion";
            city.Name = "TestCity";
            city.Region = new EntityRef<IRegion>(region);
            address.City = city;
            address.House = "TestHouse";
            address.Street = "TestStreet";
            supplier.Name = "TestSupplier";
            supplier.Address = new EntityRef<IAddress>(address);

            //Initialize banner
            banner.Name = "TestBanner";
            banner.Supplier = supplier;
            
            context.Banners.InsertOnSubmit((Banner)banner);
            context.SubmitChanges();

            //Checking for correct record in Banners table
            Assert.AreEqual("TestBanner", context.Banners.First().Name);
            Assert.AreEqual(supplier.ID, context.Banners.First().SupplierID);

            context.Regions.DeleteOnSubmit((Region)region);
            context.Cities.DeleteOnSubmit((City)city);
            context.Suppliers.DeleteOnSubmit((Supplier)supplier);
            context.Addresses.DeleteOnSubmit((Address)address);
            context.Banners.DeleteOnSubmit((Banner)banner);
            context.SubmitChanges();
        }

        [TestMethod]
        public void DatabaseTests_BannersImage()
        {
            //Initialize all necessary objects for BannersImage
            region.Name = "TestRegion";
            city.Name = "TestCity";
            city.Region = new EntityRef<IRegion>(region);
            address.City = city;
            address.House = "TestHouse";
            address.Street = "TestStreet";
            supplier.Name = "TestSupplier";
            supplier.Address = new EntityRef<IAddress>(address);

            //Initialize banner
            banner.Name = "TestBanner";
            banner.Supplier = supplier;
            
            //Initialize first image
            image.Name = "TestImage";
            image.URL = "/testfolder/folder1/folder2/pict.jpg";

            //Initialize second image
            IImage picture = Factory.GetComponent<IImage>();
            picture.Name = "TestPicture";
            picture.URL = "site/folder/bigfolder/smalfolder/pict.bmp";

            banner.Images.Add(image);
            banner.Images.Add(picture);
                       
            context.Banners.InsertOnSubmit((Banner)banner);
            context.SubmitChanges();

            var imagesIDList = context.BannersImages.Select(images => images.ImageID).ToList();
            var bannerIDList = context.BannersImages.Select(banners => banners.BannerID).ToList();

            //Checking for correct records in BannersImages table
            //First record
            Assert.AreEqual(image.ID, imagesIDList[0]);
            Assert.AreEqual(picture.ID, imagesIDList[1]);

            //Second record
            Assert.AreEqual(banner.ID, bannerIDList[0]);
            Assert.AreEqual(banner.ID, bannerIDList[1]);

            context.Images.DeleteOnSubmit((Image)image);
            context.Images.DeleteOnSubmit((Image)picture);
            context.Regions.DeleteOnSubmit((Region)region);
            context.Cities.DeleteOnSubmit((City)city);
            context.Suppliers.DeleteOnSubmit((Supplier)supplier);
            context.Addresses.DeleteOnSubmit((Address)address);
            context.Banners.DeleteOnSubmit((Banner)banner);
            context.SubmitChanges();
        }

        [TestMethod]
        public void DatabaseTests_Brand()
        {
            //Initialize all objects for Brand
            image.Name = "TestImage";
            image.URL = "/testfolder/folder1/folder2/pict.jpg";

            brand.Image = image;
            brand.Name = "TestBrand";

            context.Brands.InsertOnSubmit((Brand)brand);
            context.SubmitChanges();

            //Checking for correct record in Brands table
            Assert.AreEqual("TestBrand", brand.Name);
            Assert.AreEqual(image.ID, context.Brands.First().LogoID);


            context.Brands.DeleteOnSubmit((Brand)brand);
            context.Images.DeleteOnSubmit((Image)image);
            context.SubmitChanges();
        }

        [TestMethod]
        public void DatabaseTests_Category()
        {
            var category = Factory.GetComponent<ICategory>();
            var subCategory = Factory.GetComponent<ICategory>();

            category.Name = "TestCategory";
            category.Description = "TestCategoryDescription";

            subCategory.Name = "TestSubCategory";
            subCategory.Description = "";
            subCategory.ParentCategory = new EntityRef<ICategory>(category);

            context.Categories.InsertOnSubmit((Category)category);
            context.Categories.InsertOnSubmit((Category)subCategory);
            context.SubmitChanges();

            var categories = context.Categories.ToList();

            Assert.AreEqual("TestCategory", categories[0].Name);
            Assert.AreEqual("TestCategoryDescription", categories[0].Description);
            Assert.AreEqual("TestSubCategory", subCategory.Name);
            Assert.AreEqual(categories[0].ID, categories[1].ParentCategoryID);

            context.Categories.DeleteOnSubmit((Category)category);
            context.Categories.DeleteOnSubmit((Category)subCategory);
            context.SubmitChanges();
        }

        [TestMethod]
        public void DatabaseTests_City()
        {
            region.Name = "TestRegion";
            city.Region = new EntityRef<IRegion>(region);
            city.Name = "TestCity";

            context.Cities.InsertOnSubmit((City)city);
            context.SubmitChanges();

            Assert.AreEqual("TestCity", context.Cities.First().Name);
            Assert.AreEqual(region.ID, context.Regions.First().ID);

            context.Cities.DeleteOnSubmit((City)city);
            context.Regions.DeleteOnSubmit((Region)region);
            context.SubmitChanges();
        }

        [TestMethod]
        public void DatabaseTests_Feedback()
        {
            //Initialize all objects for Feedback
            region.Name = "TestRegion";
            city.Region = new EntityRef<IRegion>(region);
            city.Name = "TestCity";
            address.City = city;
            address.House = "TestHouse";
            address.Street = "TestStreet";
            person.Name = "TestName";
            person.SecondName = "TestSecondName";
            person.Address = new EntityRef<IAddress>(address);
            person.BirthDate = DateTime.Now;
            person.Email = "email@mail.com";
            user.Login = "TestLogin";
            user.Password = "TestPassword";
            user.RoleID = 2;
            user.Person = person;
            user.RegistrationDate = DateTime.Now;

            //Initialize feedback
            var date = new DateTime(2013, 4, 16);
            feedback.Date = date;
            feedback.Text = "TestText";
            feedback.Topic = "TestTopic";
            feedback.User = new EntityRef<IUser>(user);

            context.Feedbacks.InsertOnSubmit((Feedback)feedback);
            context.SubmitChanges();

            Assert.AreEqual(date.Date, context.Feedbacks.First().Date);
            Assert.AreEqual("TestText", context.Feedbacks.First().Text);
            Assert.AreEqual("TestTopic", context.Feedbacks.First().Topic);
            Assert.AreEqual(user.ID, context.Feedbacks.First().UserID);

            context.Feedbacks.DeleteOnSubmit((Feedback)feedback);
            context.Users.DeleteOnSubmit((User)user);
            context.Persons.DeleteOnSubmit((Person)person);
            context.Addresses.DeleteOnSubmit((Address)address);
            context.Cities.DeleteOnSubmit((City)city);
            context.Regions.DeleteOnSubmit((Region)region);
            context.SubmitChanges();
        }

        [TestMethod]
        public void DatabaseTests_Image()
        {
            image.Name = "TestImage";
            image.URL = "folder1/folder2/folder3/image.jpg";

            context.Images.InsertOnSubmit((Image)image);
            context.SubmitChanges();

            Assert.AreEqual("TestImage", context.Images.First().Name);
            Assert.AreEqual("folder1/folder2/folder3/image.jpg", context.Images.First().URL);

            context.Images.DeleteOnSubmit((Image)image);
            context.SubmitChanges();
        }

        [TestMethod]
        public void DatabaseTests_LegalPerson()
        {
            //Initialize all objects for LegalPerson
            region.Name = "TestRegion";
            city.Region = new EntityRef<IRegion>(region);
            city.Name = "TestCity";
            address.City = city;
            address.House = "TestHouse";
            address.Street = "TestStreet";
            person.Name = "TestName";
            person.SecondName = "TestSecondName";
            person.Address = new EntityRef<IAddress>(address);
            person.BirthDate = DateTime.Now;
            person.Email = "email@mail.com";

            //Initialize legalPerson
            legalPerson.Person = new EntityRef<IPerson>(person);
            legalPerson.LegalAddress = "TestLegalAddress";
            legalPerson.Account = 1234567890;
            legalPerson.BIC = "TestBIC";
            legalPerson.Fax = "+81234567890";
            legalPerson.NCEO = 1;
            legalPerson.OrganizationName = "TestOrganization";
            legalPerson.RCR = 2;
            legalPerson.TIN = 3;
            legalPerson.UCSE = 4;

            context.LegalPersons.InsertOnSubmit((LegalPerson)legalPerson);
            context.SubmitChanges();

            var lperson = context.LegalPersons.First();

            Assert.AreEqual("TestLegalAddress", lperson.LegalAddress);
            Assert.AreEqual(1234567890, lperson.Account);
            Assert.AreEqual("TestBIC", lperson.BIC);
            Assert.AreEqual("+81234567890", lperson.Fax);
            Assert.AreEqual(1, lperson.NCEO);
            Assert.AreEqual("TestOrganization", lperson.OrganizationName);
            Assert.AreEqual(2, lperson.RCR);
            Assert.AreEqual(3, lperson.TIN);
            Assert.AreEqual(4, lperson.UCSE);

            context.LegalPersons.DeleteOnSubmit((LegalPerson)legalPerson);
            context.Persons.DeleteOnSubmit((Person)person);
            context.Addresses.DeleteOnSubmit((Address)address);
            context.Cities.DeleteOnSubmit((City)city);
            context.Regions.DeleteOnSubmit((Region)region);
            context.SubmitChanges();
        }

        [TestMethod]
        public void DatabaseTests_Log()
        {
            var date = new DateTime(2013, 4, 16);
            log.Location = "TestLocation";
            log.Message = "TestMessage";
            log.Date = date;
            log.Type = "TestType";

            context.Logs.InsertOnSubmit((Log)log);
            context.SubmitChanges();

            Assert.AreEqual("TestLocation", context.Logs.First().Location);
            Assert.AreEqual("TestMessage", context.Logs.First().Message);
            Assert.AreEqual(date, context.Logs.First().Date.Date);
            Assert.AreEqual("TestType", context.Logs.First().Type);

            context.Logs.DeleteOnSubmit((Log)log);
            context.SubmitChanges();
        }

        [TestMethod]
        public void DatabaseTests_Order()
        {
            //Initialize all objects for Order
            var date = new DateTime(2013, 4, 16);
            var timeFrom = new TimeSpan(12,0,0);
            var timeTo = new TimeSpan(15,0,0);
            region.Name = "TestRegion";
            city.Name = "TestCity";
            city.Region = new EntityRef<IRegion>(region);
            address.City = city;
            address.House = "TestHouse";
            address.Street = "TestStreet";
            person.Name = "TestName";
            person.SecondName = "TestSecondName";
            person.Address = new EntityRef<IAddress>(address);
            person.BirthDate = DateTime.Now;
            person.Email = "email@mail.com";
            user.Login = "TestLogin";
            user.Password = "TestPassword";
            user.RoleID = 2;
            user.Person = person;
            user.RegistrationDate = DateTime.Now;

            //Initialize order
            order.User = new EntityRef<IUser>(user);
            order.Address = new EntityRef<IAddress>(address);

            order.CreatedDate = date;
            order.DeliveredDate = date;
            order.DeliveryTimeFrom = timeFrom;
            order.DeliveryTimeTo = timeTo;
            order.DeliveryTypeID = 2;
            order.PayTypeID = 1;

            context.Orders.InsertOnSubmit((Order)order);
            context.SubmitChanges();

            var testorder = context.Orders.First();

            Assert.AreEqual(user.ID, testorder.UserID);
            Assert.AreEqual(address.ID, testorder.AddressID);
            Assert.AreEqual(date, testorder.CreatedDate);
            Assert.AreEqual(date, testorder.DeliveredDate);
            Assert.AreEqual(timeFrom, testorder.DeliveryTimeFrom);
            Assert.AreEqual(timeTo, testorder.DeliveryTimeTo);
            Assert.AreEqual(2, testorder.DeliveryTypeID);
            Assert.AreEqual(1, testorder.PayTypeID);

            context.Orders.DeleteOnSubmit((Order)order);
            context.Users.DeleteOnSubmit((User)user);
            context.Persons.DeleteOnSubmit((Person)person);
            context.Addresses.DeleteOnSubmit((Address)address);
            context.Cities.DeleteOnSubmit((City)city);
            context.Regions.DeleteOnSubmit((Region)region);
            context.SubmitChanges();
        }        

        [TestMethod]
        public void DatabaseTests_OrderStatus()
        {
            //Initialize all objects for OrdersStatus
            var date = new DateTime(2013, 4, 16);
            var timeFrom = new TimeSpan(12, 0, 0);
            var timeTo = new TimeSpan(15, 0, 0);
            region.Name = "TestRegion";
            city.Name = "TestCity";
            city.Region = new EntityRef<IRegion>(region);
            address.City = city;
            address.House = "TestHouse";
            address.Street = "TestStreet";
            person.Name = "TestName";
            person.SecondName = "TestSecondName";
            person.Address = new EntityRef<IAddress>(address);
            person.BirthDate = DateTime.Now;
            person.Email = "email@mail.com";
            user.Login = "TestLogin";
            user.Password = "TestPassword";
            user.RoleID = 2;
            user.Person = person;
            user.RegistrationDate = DateTime.Now;
            order.User = new EntityRef<IUser>(user);
            order.Address = new EntityRef<IAddress>(address);
            order.CreatedDate = date;
            order.DeliveredDate = date;
            order.DeliveryTimeFrom = timeFrom;
            order.DeliveryTimeTo = timeTo;
            order.DeliveryTypeID = 2;
            order.PayTypeID = 1;

            //Initialize orderStatus
            ordersStatus.Order = new EntityRef<IOrder>(order);
            ordersStatus.Date = date;
            ordersStatus.StatusID = 1;


            context.OrdersStatus.InsertOnSubmit((OrdersStatus)ordersStatus);
            context.SubmitChanges();

            var teststatus = context.OrdersStatus.First();

            Assert.AreEqual(order.ID, teststatus.OrderID);
            Assert.AreEqual(1, teststatus.StatusID);
            Assert.AreEqual(date, teststatus.Date);

            context.OrdersStatus.DeleteOnSubmit((OrdersStatus)ordersStatus);
            context.Orders.DeleteOnSubmit((Order)order);
            context.Users.DeleteOnSubmit((User)user);
            context.Persons.DeleteOnSubmit((Person)person);
            context.Addresses.DeleteOnSubmit((Address)address);
            context.Cities.DeleteOnSubmit((City)city);
            context.Regions.DeleteOnSubmit((Region)region);
            context.SubmitChanges();
        }

        [TestMethod]
        public void DatabaseTests_Person()
        {           
            region.Name = "TestRegion";
            city.Name = "TestCity";
            city.Region = new EntityRef<IRegion>(region);
            address.City = city;
            address.House = "TestHouse";
            address.Street = "TestStreet";
            person.Name = "TestName";
            person.SecondName = "TestSecondName";
            person.Address = new EntityRef<IAddress>(address);
            person.BirthDate = DateTime.Now;
            person.Email = "email@mail.com";

            context.Persons.InsertOnSubmit((Person)person);
            context.SubmitChanges();
            
            var testperson = context.Persons.First();

            Assert.AreEqual("TestName", testperson.Name);
            Assert.AreEqual("TestSecondName", testperson.SecondName);
            Assert.AreEqual(address.ID, testperson.AddressID);
            Assert.AreEqual(DateTime.Now.Date, testperson.BirthDate.Date);
            Assert.AreEqual("email@mail.com", testperson.Email);

            context.Persons.DeleteOnSubmit((Person)person);
            context.Addresses.DeleteOnSubmit((Address)address);
            context.Cities.DeleteOnSubmit((City)city);
            context.Regions.DeleteOnSubmit((Region)region);
            context.SubmitChanges();
        }

        [TestMethod]
        public void DatabaseTests_Product()
        {
            brand.Name = "TestBrand";

            product.Brand = new EntityRef<IBrand>(brand);
            product.Name = "TestProduct";
            product.Price = 1;

            context.Products.InsertOnSubmit((Product)product);
            context.SubmitChanges();

            Assert.AreEqual("TestProduct", context.Products.First().Name);
            Assert.AreEqual(1, context.Products.First().Price);
            Assert.AreEqual(brand.ID, context.Products.First().BrandID);

            context.Products.DeleteOnSubmit((Product)product);
            context.Brands.DeleteOnSubmit((Brand)brand);
            context.SubmitChanges();
        }

        [TestMethod]
        public void DatabaseTests_ProductsCategory()
        {
            brand.Name = "TestBrand";
            product.Brand = new EntityRef<IBrand>(brand);
            product.Name = "TestProduct";
            product.Price = 1;

            var category = Factory.GetComponent<ICategory>();
            var subCategory = Factory.GetComponent<ICategory>();

            category.Name = "TestCategory";
            category.Description = "TestCategoryDescription";

            subCategory.Name = "TestSubCategory";
            subCategory.Description = "";
            subCategory.ParentCategory = new EntityRef<ICategory>(category);

            var anotherCategory = Factory.GetComponent<ICategory>();
            anotherCategory.Name = "AnotherTestCategory";

            product.Categories.Add(subCategory);
            product.Categories.Add(anotherCategory);

            context.Products.InsertOnSubmit((Product)product);
            context.SubmitChanges();

            var categories = context.ProductsCategories.Select(pc => pc.Category).ToList();
            var products = context.ProductsCategories.Select(pc => pc.Product).ToList();

            Assert.AreEqual(subCategory.ID, categories[0].ID);
            Assert.AreEqual(anotherCategory.ID, categories[1].ID);
            Assert.AreEqual(product.ID, products[0].ID);
            Assert.AreEqual(product.ID, products[1].ID);

            context.Products.DeleteOnSubmit((Product)product);
            context.Brands.DeleteOnSubmit((Brand)brand);
            context.Categories.DeleteOnSubmit((Category)subCategory);
            context.Categories.DeleteOnSubmit((Category)category);            
            context.Categories.DeleteOnSubmit((Category)anotherCategory);
            context.SubmitChanges();

            Assert.AreEqual(null, context.ProductsCategories.FirstOrDefault());
        }

        [TestMethod]
        public void DatabaseTests_ProductsImage()
        {
            brand.Name = "TestBrand";
            product.Brand = new EntityRef<IBrand>(brand);
            product.Name = "TestProduct";
            product.Price = 1;

            image.Name = "TestImage";
            image.URL = "URLURLURL";

            var picture = Factory.GetComponent<IImage>();
            picture.Name = "TestPicture";
            picture.URL = "URLURLURLURL";

            product.Images.Add(image);
            product.Images.Add(picture);

            context.Products.InsertOnSubmit((Product)product);
            context.SubmitChanges();

            var images = context.ProductsImages.Select(pc => pc.Image).ToList();
            var products = context.ProductsImages.Select(pc => pc.Product).ToList();

            Assert.AreEqual(image.ID, images[0].ID);
            Assert.AreEqual(picture.ID, images[1].ID);
            Assert.AreEqual(product.ID, products[0].ID);
            Assert.AreEqual(product.ID, products[1].ID);

            context.Products.DeleteOnSubmit((Product)product);
            context.Images.DeleteOnSubmit((Image)image);
            context.Images.DeleteOnSubmit((Image)picture);
            context.SubmitChanges();

            Assert.AreEqual(null, context.ProductsImages.FirstOrDefault());
        }

        [TestMethod]
        public void DatabaseTests_ProductsSupplier()
        {
            brand.Name = "TestBrand";
            product.Brand = new EntityRef<IBrand>(brand);
            product.Name = "TestProduct";
            product.Price = 1;

            var newProduct = Factory.GetComponent<IProduct>();
            newProduct.Brand= new EntityRef<IBrand>(brand);
            newProduct.Name="NewTestProduct";
            newProduct.Price = 2;
            
            region.Name = "TestRegion";
            city.Name = "TestCity";
            city.Region = new EntityRef<IRegion>(region);
            address.City = city;
            address.House = "TestHouse";
            address.Street = "TestStreet";

            supplier.Address = new EntityRef<IAddress>(address);
            supplier.Name = "TestSupplier";
            
            supplier.Products.Add((Product)product);
            supplier.Products.Add((Product)newProduct);

            context.Suppliers.InsertOnSubmit((Supplier)supplier);
            context.SubmitChanges();

            var suppliers = context.ProductsSuppliers.Select(pc => pc.Supplier).ToList();
            var products = context.ProductsSuppliers.Select(pc => pc.Product).ToList();


            Assert.AreEqual(supplier.ID, suppliers[0].ID);
            Assert.AreEqual(supplier.ID, suppliers[1].ID);
            Assert.AreEqual(product.ID, products[0].ID);
            Assert.AreEqual(newProduct.ID, products[1].ID);

            context.Suppliers.DeleteOnSubmit((Supplier)supplier);
            context.Products.DeleteOnSubmit((Product)product);
            context.Products.DeleteOnSubmit((Product)newProduct);
            context.Brands.DeleteOnSubmit((Brand)brand);
            context.Addresses.DeleteOnSubmit((Address)address);
            context.Cities.DeleteOnSubmit((City)city);
            context.Regions.DeleteOnSubmit((Region)region);
            context.SubmitChanges();

            Assert.AreEqual(null, context.ProductsSuppliers.FirstOrDefault());
        }

        [TestMethod]
        public void DatabaseTests_Region()
        {
            region.Name = "TestRegion";

            context.Regions.InsertOnSubmit((Region)region);
            context.SubmitChanges();

            Assert.AreEqual("TestRegion", context.Regions.First().Name);

            context.Regions.DeleteOnSubmit((Region)region);
            context.SubmitChanges();
        }

        [TestMethod]
        public void DatabaseTests_StorageRecord()
        {
            region.Name = "TestRegion";
            city.Name = "TestCity";
            city.Region = new EntityRef<IRegion>(region);
            address.City = city;
            address.House = "TestHouse";
            address.Street = "TestStreet";
            person.Name = "TestName";
            person.SecondName = "TestSecondName";
            person.Address = new EntityRef<IAddress>(address);
            person.BirthDate = DateTime.Now.Date;
            person.Email = "email@mail.com";
            user.Login = "TestLogin";
            user.Password = "TestPassword";
            user.RoleID = 2;
            user.Person = person;
            user.RegistrationDate = DateTime.Now;

            brand.Name = "TestBrand";
            product.Brand = new EntityRef<IBrand>(brand);
            product.Name = "TestProduct";
            product.Price = 1;

            storageRecord.Product = new EntityRef<IProduct>(product);
            storageRecord.User = new EntityRef<IUser>(user);

            storageRecord.Debit = 20;
            storageRecord.Credit = 0;
            storageRecord.Date = DateTime.Now;

            context.StorageRecords.InsertOnSubmit((StorageRecord)storageRecord);
            context.SubmitChanges();

            Assert.AreEqual(product.ID, context.StorageRecords.First().ProductID);
            Assert.AreEqual(user.ID, context.StorageRecords.First().UserID);
            Assert.AreEqual(20, context.StorageRecords.First().Debit);
            Assert.AreEqual(0, context.StorageRecords.First().Credit);
            Assert.AreEqual(DateTime.Now.Date, context.StorageRecords.First().Date.Date);

            context.Addresses.DeleteOnSubmit((Address)address);
            context.Cities.DeleteOnSubmit((City)city);
            context.Regions.DeleteOnSubmit((Region)region);
            context.Users.DeleteOnSubmit((User)user);
            context.Persons.DeleteOnSubmit((Person)person);
            context.StorageRecords.DeleteOnSubmit((StorageRecord)storageRecord);
            context.Products.DeleteOnSubmit((Product)product);
            context.Brands.DeleteOnSubmit((Brand)brand);
            context.SubmitChanges();
        }

        [TestMethod]
        public void DatabaseTests_Supplier()
        {
            region.Name = "TestRegion";
            city.Name = "TestCity";
            city.Region = new EntityRef<IRegion>(region);
            address.City = city;
            address.House = "TestHouse";
            address.Street = "TestStreet";

            supplier.Address = new EntityRef<IAddress>(address);
            supplier.Name = "TestSupplier";

            context.Suppliers.InsertOnSubmit((Supplier)supplier);
            context.SubmitChanges();

            Assert.AreEqual("TestSupplier", context.Suppliers.First().Name);
            Assert.AreEqual(address.ID, context.Suppliers.First().AddressID);

            context.Suppliers.DeleteOnSubmit((Supplier)supplier);
            context.Addresses.DeleteOnSubmit((Address)address);
            context.Cities.DeleteOnSubmit((City)city);
            context.Regions.DeleteOnSubmit((Region)region);
            context.SubmitChanges();
        }

        [TestMethod]
        public void DatabaseTests_User()
        {
            region.Name = "TestRegion";
            city.Name = "TestCity";
            city.Region = new EntityRef<IRegion>(region);
            address.City = city;
            address.House = "TestHouse";
            address.Street = "TestStreet";
            person.Name = "TestName";
            person.SecondName = "TestSecondName";
            person.Address = new EntityRef<IAddress>(address);
            person.BirthDate = DateTime.Now.Date;
            person.Email = "email@mail.com";
            user.Login = "TestLogin";
            user.Password = "TestPassword";
            user.RoleID = 2;
            user.Person = person;
            user.RegistrationDate = DateTime.Now;
            

            context.Users.InsertOnSubmit((User)user);
            context.SubmitChanges();

            Assert.AreEqual("TestLogin", context.Users.First().Login);
            Assert.AreEqual("TestPassword", context.Users.First().Password);
            Assert.AreEqual(2, context.Users.First().RoleID);
            Assert.AreEqual(person.ID, context.Users.First().PersonID);


            context.Users.DeleteOnSubmit((User)user);
            context.Persons.DeleteOnSubmit((Person)person);
            context.Addresses.DeleteOnSubmit((Address)address);
            context.Cities.DeleteOnSubmit((City)city);
            context.Regions.DeleteOnSubmit((Region)region);
            context.SubmitChanges();
        }

        [TestMethod]
        public void DatabaseTests_OrderLine()
        {
            //Create supplier
            region.Name = "TestRegion";
            city.Name = "TestCity";
            city.Region = new EntityRef<IRegion>(region);
            address.City = city;
            address.House = "TestHouse";
            address.Street = "TestStreet";
            supplier.Address = new EntityRef<IAddress>(address);
            supplier.Name = "TestSupplier";

            //Create product
            brand.Name = "TestBrand";
            product.Brand = new EntityRef<IBrand>(brand);
            product.Name = "TestProduct";
            product.Price = 1;

            //Create order
            var date = new DateTime(2013, 4, 16);
            var timeFrom = new TimeSpan(12, 0, 0);
            var timeTo = new TimeSpan(15, 0, 0);
            person.Name = "TestName";
            person.SecondName = "TestSecondName";
            person.Address = new EntityRef<IAddress>(address);
            person.BirthDate = DateTime.Now;
            person.Email = "email@mail.com";
            user.Login = "TestLogin";
            user.Password = "TestPassword";
            user.RoleID = 2;
            user.Person = person;
            user.RegistrationDate = DateTime.Now;            
            order.User = new EntityRef<IUser>(user);
            order.Address = new EntityRef<IAddress>(address);
            order.CreatedDate = date;
            order.DeliveredDate = date;
            order.DeliveryTimeFrom = timeFrom;
            order.DeliveryTimeTo = timeTo;
            order.DeliveryTypeID = 2;
            order.PayTypeID = 1;

            orderLine.Supplier = new EntityRef<ISupplier>(supplier);
            orderLine.Product = new EntityRef<IProduct>(product);
            orderLine.Order = new EntityRef<IOrder>(order);
            orderLine.Count = 2;
            orderLine.UnitPrice = 40;

            context.OrderLines.InsertOnSubmit((OrderLine)orderLine);
            context.SubmitChanges();

            Assert.AreEqual(supplier.ID, context.OrderLines.First().SupplierID);
            Assert.AreEqual(product.ID, context.OrderLines.First().ProductID);
            Assert.AreEqual(order.ID, context.OrderLines.First().OrderID);
            Assert.AreEqual(2, context.OrderLines.First().Count);
            Assert.AreEqual(40, context.OrderLines.First().UnitPrice);

            context.Users.DeleteOnSubmit((User)user);
            context.Persons.DeleteOnSubmit((Person)person);
            context.Addresses.DeleteOnSubmit((Address)address);
            context.Cities.DeleteOnSubmit((City)city);
            context.Regions.DeleteOnSubmit((Region)region);
            context.Suppliers.DeleteOnSubmit((Supplier)supplier);
            context.Products.DeleteOnSubmit((Product)product);
            context.Brands.DeleteOnSubmit((Brand)brand);
            context.Orders.DeleteOnSubmit((Order)order);
            context.OrderLines.DeleteOnSubmit((OrderLine)orderLine);
            context.SubmitChanges();
        }
    }
}
