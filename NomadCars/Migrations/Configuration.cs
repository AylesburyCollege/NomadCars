namespace NomadCars.Migrations
{
    using System.Data.Entity.Migrations;
    using System.Data.Entity;
    using NomadCars.Models;
    using NomadCars.DAL;
    using System.Collections.Generic;
    using System.Linq;


    internal sealed class Configuration : DbMigrationsConfiguration<NomadDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(NomadDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            SeedPaymentCard(context);

            // William
            SeedPeople(context);

            // William
            SeedStaff(context);

            // William
            SeedAddresses(context);

            // Zeeshan
            SeedCarSpec(context);

            // Zeeshan
            SeedCars(context);

            // Daniel
            SeedAccessory(context);

            // Daniel
            //SeedImages(context);
            
            // Connor
            //SeedPurchases(context);
        }

        // William
        private void SeedPeople(NomadDbContext context)
        {
            var PeopleList = new List<Person>
            {
                new Person
                {
                    PersonID = 1,
                    FirstName = "William",
                    LastName = "Foster",
                    DateOfBirth = new System.DateTime(1994, 8, 28),
                    Email = "william.foster@nomad.com",
                    IsCustomer = false,
                    IsStaff = true,
                    MaritalStatus = MaritalSatusOptions.SINGLE,
                    PaymentCardID = 1
                }, 
                new Person
                {
                    PersonID = 2,
                    FirstName = "Connor",
                    LastName = "Patey",
                    DateOfBirth = new System.DateTime(1999, 10, 10),
                    Email = "connor.patey@nomad.com",
                    IsCustomer = false,
                    IsStaff = true,
                    MaritalStatus = MaritalSatusOptions.SINGLE
                },
                new Person
                {
                    PersonID = 3,
                    FirstName = "Daniel",
                    LastName = "Schafer-Smith",
                    DateOfBirth = new System.DateTime(1999, 10, 10),
                    Email = "daniel.schafer_smith@nomad.com",
                    IsCustomer = false,
                    IsStaff = true,
                    MaritalStatus = MaritalSatusOptions.SINGLE
                },
                new Person
                {
                    PersonID = 4,
                    FirstName = "Zeeshan",
                    LastName = "Akhlaq",
                    DateOfBirth = new System.DateTime(1999, 10, 10),
                    Email = "zeeshan.akhlaq@nomad.com",
                    IsCustomer = false,
                    IsStaff = true,
                    MaritalStatus = MaritalSatusOptions.SINGLE
                },
                new Person
                {
                    PersonID = 5,
                    FirstName = "Tomas",
                    LastName = "Green",
                    DateOfBirth = new System.DateTime(1994, 12, 2),
                    Email = "TomasGreen94@gmail.com",
                    IsCustomer = true,
                    IsStaff = false,
                    MaritalStatus = MaritalSatusOptions.SINGLE
                },
                new Person
                {
                    PersonID = 6,
                    FirstName = "Ben",
                    LastName = "Miller",
                    DateOfBirth = new System.DateTime(1992, 3, 12),
                    Email = "Miller92@gmail.com",
                    IsCustomer = true,
                    IsStaff = false,
                    MaritalStatus = MaritalSatusOptions.SINGLE
                },
                new Person
                {
                    PersonID = 7,
                    FirstName = "Lilly",
                    LastName = "Erickson",
                    DateOfBirth = new System.DateTime(1985, 7, 30),
                    Email = "Lilly1985@gmail.com",
                    IsCustomer = true,
                    IsStaff = false,
                    MaritalStatus = MaritalSatusOptions.MARRIED
                },
                new Person
                {
                    PersonID = 8,
                    FirstName = "Joshua",
                    LastName = "Knight",
                    DateOfBirth = new System.DateTime(1990, 11, 23),
                    Email = "JoshKnight90@gmail.com",
                    IsCustomer = true,
                    IsStaff = false,
                    MaritalStatus = MaritalSatusOptions.MARRIED
                },
                new Person
                {
                    PersonID = 9,
                    FirstName = "Emily",
                    LastName = "White",
                    DateOfBirth = new System.DateTime(1981, 4, 5),
                    Email = "EWhite@gmail.com",
                    IsCustomer = true,
                    IsStaff = false,
                    MaritalStatus = MaritalSatusOptions.DIVORCED
                },
                new Person
                {
                    PersonID = 10,
                    FirstName = "Eliot",
                    LastName = "Meyers",
                    DateOfBirth = new System.DateTime(1956, 9, 21),
                    Email = "EliotMey@gmail.com",
                    IsCustomer = true,
                    IsStaff = false,
                    MaritalStatus = MaritalSatusOptions.OTHER
                }

            };

            PeopleList.ForEach(p => context.People.AddOrUpdate(i => i.LastName, p));
            context.SaveChanges();
        }

        /// <summary>
        /// Connor
        /// </summary>
        private void SeedPurchases(NomadDbContext context)
        {
            var PurchaseList = new List<Purchase>
            {
                new Purchase
                {
                    PurchaseID = 1,
                    InvoiceNumber =  "Invoice No 1001",
                    IsInvoiced = true,
                    HasRegistrationDocument = true,
                    IsReturned = false,
                    Refund = 0.00m,
                    IntrestRate = 3.00m,
                    TransactionType = TransactionTypes.Card,
                    CarID = 1,
                    PersonID = 1,
                    StaffID = 1
                }
            };
            PurchaseList.ForEach(p => context.Purchases.AddOrUpdate(i => i.PurchaseID, p));
           context.SaveChanges();
        }

        // Connor
        private void SeedPaymentCard(NomadDbContext context)
        {
            var PaymentCardList = new List<PaymentCard>
            {
                new PaymentCard
                {
                    PaymentCardID = 1,
                    NameOnCard = "William Foster",
                    CardNumber = "1234 1234 1234 1234",
                    CardType = CardTypes.VISA_DEBIT,
                    ExpiryMonth = 8,
                    ExpiryYear = 2021,
                    SecurityNumber = "123"
                }
            };

            PaymentCardList.ForEach(p => context.PaymentCards.AddOrUpdate(i => i.PaymentCardID, p));
            context.SaveChanges();
        }

        // Daniel
        private void SeedImages(NomadDbContext context)
        {
            var CarImageList = new List<CarImage>
            {
                new CarImage
                {
                    CarImageID = 1,
                    Caption = "BMW330D",
                    Description = "BMW330D Description",
                    ImageFormat = ImageFormats.jpg,
                    CarID = 2,
                    ImageURL = "~/Images/BMW330D.jpg",
                    Position = ImagePositions.CAR_FRONT
                }

            };

            CarImageList.ForEach(s => context.CarImages.AddOrUpdate(p => p.CarImageID, s));
            context.SaveChanges();
        }

        private void SeedAddresses(NomadDbContext context)
        {
            var addressList = new List<Address>
            {
                new Address
                {
                    AddressID = 1,
                    House = "8",
                    StreetName = "Kestrel Way",
                    TownName = "Aylesbury",
                    Postcode = "HP190GH",
                    County = Counties.BUCKINGHAMSHIRE
                },
                new Address
                {
                    AddressID = 2,
                    House = "22",
                    StreetName = "Iron Road",
                    TownName = "Aylesbury",
                    Postcode = "HP208UG",
                    County = Counties.BUCKINGHAMSHIRE
                },
                new Address
                {
                    AddressID = 3,
                    House = "12",
                    StreetName = "Mercia Close",
                    TownName = "Aylesbury",
                    Postcode = "HP214OF",
                    County = Counties.BUCKINGHAMSHIRE
                },
                new Address
                {
                    AddressID = 4,
                    House = "43",
                    StreetName = "Potters Way",
                    TownName = "Chesham",
                    Postcode = "HP236LV",
                    County = Counties.BUCKINGHAMSHIRE
                },
                new Address
                {
                    AddressID = 5,
                    House = "18",
                    StreetName = "Victory Way",
                    TownName = "Oxford",
                    Postcode = "OX181LT",
                    County = Counties.OXFORDSHIRE
                },
                new Address
                {
                    AddressID = 6,
                    House = "Forresters Cottage",
                    StreetName = "Woodland Road",
                    TownName = "Cloverfield",
                    Postcode = "HP38UK",
                    County = Counties.HERTFORDSHIRE
                },
                new Address
                {
                    AddressID = 7,
                    House = "11",
                    StreetName = "Gediminas Road",
                    TownName = "Camden",
                    Postcode = "NW35VI",
                    County = Counties.LONDON
                },
                new Address
                {
                    AddressID = 8,
                    House = "Old Station House",
                    StreetName = "Cane Row",
                    TownName = "Smith's Hearth",
                    Postcode = "OX217ME",
                    County = Counties.OXFORDSHIRE
                },
                new Address
                {
                    AddressID = 9,
                    House = "26",
                    StreetName = "Brunel Avenue",
                    TownName = "Gospel Oak",
                    Postcode = "NW42AQ",
                    County = Counties.LONDON
                },
                new Address
                {
                    AddressID = 10,
                    House = "14",
                    StreetName = "Roses Close",
                    TownName = "Towton",
                    Postcode = "AL4 E61",
                    County = Counties.BEDFORDSHIRE
                }
            };

            addressList.ForEach(s => context.Addresses.AddOrUpdate(p => p.AddressID, s));
            context.SaveChanges();
        }

        private void SeedAccessory(NomadDbContext context)
        {
            var AccessoryList = new List<Accessory>
            {
                new Accessory
                {
                    AccessoryID = 1,
                    AccessoryType = AccessoryTypes.BlueTooth,
                    Description = "Blutooth audio capabilities"
                },
                new Accessory
                {
                    AccessoryID = 2,
                    AccessoryType = AccessoryTypes.BlindSpotMonitor,
                    Description = "Allows the driver to see blind spots via the use of a monitor"
                },
                new Accessory
                {
                    AccessoryID = 3,
                    AccessoryType = AccessoryTypes.DashCam,
                    Description = "Allows the driver to record footage of the front of the car"
                },
                new Accessory
                {
                    AccessoryID = 4,
                    AccessoryType = AccessoryTypes.FrontCamera,
                    Description = "A camera that allows the user to percieve the front of the car from alternative angles"
                },
                new Accessory
                {
                    AccessoryID = 5,
                    AccessoryType = AccessoryTypes.HeatedSeats,
                    Description = "Seat or seats with the ability to heat up and warm either the driver and/or passengers seat"
                },
                new Accessory
                {
                    AccessoryID = 6,
                    AccessoryType = AccessoryTypes.ParkingSensor,
                    Description = "A sensor which will indicate if the car is likely to collide with anything"
                },
                new Accessory
                {
                    AccessoryID = 7,
                    AccessoryType = AccessoryTypes.Radio,
                    Description = "A radio with FM and/or AM audio capabilities"
                },
                new Accessory
                {
                    AccessoryID = 8,
                    AccessoryType = AccessoryTypes.ReverseCamera,
                    Description = "A camera that allows the user to percieve the back of the car from alternative angles"
                },
                new Accessory
                {
                    AccessoryID = 9,
                    AccessoryType = AccessoryTypes.SatNav,
                    Description = "A piece of integrated hardware which provides directions to a chosen destination"
                }


            };

            AccessoryList.ForEach(s => context.Accessories.AddOrUpdate(p => p.AccessoryID, s));
            context.SaveChanges();
        }

        private void SeedStaff(NomadDbContext context)
        {
            var StaffList = new List<Staff>
            {
                new Staff
                { 
                    StaffID = 1,
                    Department = DepartmentOptions.MANAGEMENT,
                    JobPosition = JobPositionOptions.LOCATION_MANAGER,
                    Salary = 24000m,
                    StartDate = new System.DateTime(2017,10, 10)
                },
                new Staff
                {
                    StaffID = 2,
                    Department = DepartmentOptions.ACCOUNTS,
                    JobPosition = JobPositionOptions.ACCOUNTANT,
                    Salary = 28000m,
                    StartDate = new System.DateTime(2017, 10, 10)
                },
                new Staff
                {
                    StaffID = 3,
                    Department = DepartmentOptions.MANAGEMENT,
                    JobPosition = JobPositionOptions.SALES_MANAGER,
                    Salary = 30000m,
                    StartDate = new System.DateTime(2017, 10, 10)
                },
                new Staff
                {
                    StaffID = 4,
                    Department = DepartmentOptions.SALES,
                    JobPosition = JobPositionOptions.SALES_REPRESENTATIVE,
                    Salary = 21000m,
                    StartDate = new System.DateTime(2017, 10, 10)
                }

            };

            StaffList.ForEach(s => context.Staff.AddOrUpdate(p => p.StaffID, s));
            context.SaveChanges();
        }

        private void SeedCars(NomadDbContext context)
        {
            var CarList = new List<Car>
            {
                new Car
                {
                    CarID = 1,
                    CarSpecID = 1,
                    Colour ="White",
                    NumberPlate = "YD17 UVV",
                    VINNo = "2BCHV8110HB571011",
                    Mileage = 467,
                    TransmissionType = TransmissionTypes.Automatic,
                    NoPreviousOwner = 3,
                    AccelerationTo60 = 6,
                    Sold = false,
                    Delivered = false,
                    CO2Emissions = 139

                },
                new Car
                {
                    CarID = 2,
                    CarSpecID = 2,
                    Colour ="Grey",
                    NumberPlate = "VO13 LUW",
                    VINNo = "LM4AC11C331171079",
                    Mileage = 40648,
                    TransmissionType = TransmissionTypes.Manual,
                    NoPreviousOwner = 1,
                    AccelerationTo60 = 5,
                    Sold = false,
                    Delivered = false,
                    CO2Emissions = 178

                },
                new Car
                {
                    CarID = 3,
                    CarSpecID = 3,
                    Colour ="Metallic Silver",
                    NumberPlate = "YH14 DDK",
                    VINNo = "5VCACRKF6BH210126",
                    Mileage = 29180,
                    TransmissionType = TransmissionTypes.Manual,
                    NoPreviousOwner = 5,
                    AccelerationTo60 = 9,
                    Sold = false,
                    Delivered = false,
                    CO2Emissions = 103

                },
                new Car
                {
                    CarID = 4,
                    CarSpecID = 4,
                    Colour ="Graphite",
                    NumberPlate = "YJ67 YTA",
                    VINNo = "1P3BB26P0JW194241",
                    Mileage = 4927,
                    TransmissionType = TransmissionTypes.Automatic,
                    NoPreviousOwner = 2,
                    AccelerationTo60 = 6,
                    Sold = false,
                    Delivered = false,
                    CO2Emissions = 170

                },
                new Car
                {
                    CarID = 5,
                    CarSpecID = 5,
                    Colour ="Metallic Grey",
                    NumberPlate = "YA18 OPP",
                    VINNo = "JM1BK34F391147858",
                    Mileage = 259,
                    TransmissionType = TransmissionTypes.Automatic,
                    NoPreviousOwner = 1,
                    AccelerationTo60 = 4,
                    Sold = false,
                    Delivered = false,
                    CO2Emissions = 49

                }

            };

            CarList.ForEach(c => context.Cars.AddOrUpdate(p => p.CarID, c));
            context.SaveChanges();
        }

        private void SeedCarSpec(NomadDbContext context)
        {
            var SpecList = new List<CarSpec>
            {
                new CarSpec
                {
                    CarSpecID  = 1,
                    Make = CarMakes.BMW,
                    Model = CarModels.BMW_420d,
                    Petrol = true,
                    Diesel = false,
                    Electric = false,
                    TaxGroup = TaxGroups.D,
                    BodyType = BodyTypes.Coupe,
                    DriveTrain = DriveTrains.Rear_Wheel_Drive,
                    TopSpeed = 160,
                    Doors = 4,
                    Range = 300,
                    EngineSize = EngineSizes.CC_1999,
                    Length = 4638,
                    Width = 2017,
                    Seats = 5,
                    BHP = 181,
                    BootCapacity = 445,
                    MPG = 47
                },
                new CarSpec
                {
                    CarSpecID  = 2,
                    Make = CarMakes.BMW,
                    Model = CarModels.BMW_330d,
                    Petrol = false,
                    Diesel = true,
                    Electric = false,
                    TaxGroup = TaxGroups.H,
                    BodyType = BodyTypes.Coupe,
                    DriveTrain = DriveTrains.Rear_Wheel_Drive,
                    TopSpeed = 160,
                    Doors = 4,
                    Range = 250,
                    EngineSize = EngineSizes.CC_2999,
                    Length = 4633,
                    Width = 2031,
                    Seats = 5,
                    BHP = 254,
                    BootCapacity = 495,
                    MPG = 40
                },
                new CarSpec
                {
                    CarSpecID  = 3,
                    Make = CarMakes.BMW,
                    Model = CarModels.BMW_116d,
                    Petrol = false,
                    Diesel = true,
                    Electric = false,
                    TaxGroup = TaxGroups.C,
                    BodyType = BodyTypes.Coupe,
                    DriveTrain = DriveTrains.Rear_Wheel_Drive,
                    TopSpeed = 140,
                    Doors = 4,
                    Range = 310,
                    EngineSize = EngineSizes.CC_1499,
                    Length = 4324,
                    Width = 1765,
                    Seats = 5,
                    BHP = 116,
                    BootCapacity = 360,
                    MPG = 52
                },
                new CarSpec
                {
                    CarSpecID  = 4,
                    Make = CarMakes.BMW,
                    Model = CarModels.BMW_X1,
                    Petrol = false,
                    Diesel = true,
                    Electric = false,
                    TaxGroup = TaxGroups.F,
                    BodyType = BodyTypes.SUV,
                    DriveTrain = DriveTrains.All_Wheel_Drive,
                    TopSpeed = 160,
                    Doors = 4,
                    Range = 350,
                    EngineSize = EngineSizes.CC_1999,
                    Length = 4439,
                    Width = 1821,
                    Seats = 5,
                    BHP = 150,
                    BootCapacity = 505,
                    MPG = 60
                },
                new CarSpec
                {
                    CarSpecID  = 5,
                    Make = CarMakes.BMW,
                    Model = CarModels.BMW_i8,
                    Petrol = true,
                    Diesel = false,
                    Electric = true,
                    TaxGroup = TaxGroups.B,
                    BodyType = BodyTypes.Coupe,
                    DriveTrain = DriveTrains.All_Wheel_Drive,
                    TopSpeed = 160,
                    Doors = 2,
                    Range = 300,
                    EngineSize = EngineSizes.CC_1499,
                    Length = 4689,
                    Width = 1942,
                    Seats = 2,
                    BHP = 370,
                    BootCapacity = 154,
                    MPG = 30
                }
            };

            SpecList.ForEach(c => context.CarSpecs.AddOrUpdate(p => p.CarSpecID, c));
            context.SaveChanges();
        }
    }
}

