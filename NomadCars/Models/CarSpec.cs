using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

/// <summary>
/// Zeeshan
/// </summary>
namespace NomadCars.Models
{
    public enum CarMakes
    {
        BMW
    }

    public enum CarModels
    {
        [Display(Name = "330d")]
        BMW_330d,
        [Display(Name = "420d")]
        BMW_420d,
        [Display(Name = "116d")]
        BMW_116d,
        [Display(Name = "X1")]
        BMW_X1,
        [Display(Name = "i8")]
        BMW_i8,
    }

    public enum EngineSizes
    {
        [Display(Name = "2999 cc")]
        CC_2999,
        [Display(Name = "1999 cc")]
        CC_1999,
        [Display(Name = "1499 cc")]
        CC_1499
    }

    public enum TaxGroups
    {
        A,
        B,
        C,
        D,
        E,
        F,
        G,
        H
    }

    public enum DriveTrains
    {
        [Display(Name = "Front Wheel Drive")]
        Front_Wheel_Drive,
        [Display(Name = "Rear Wheel Drive")]
        Rear_Wheel_Drive,
        [Display(Name = "All Wheel Drive")]
        All_Wheel_Drive
    }

    public enum BodyTypes
    {
        Coupe,
        Convertible,
        Estate,
        Hatchback,
        Saloon,
        SUV
    }

    public enum FuelTypes
    {
        [Display(Name = "Petrol")]
        PETROL,
        [Display(Name = "Diesel")]
        DIESEL,
        [Display(Name = "Electric")]
        ELECTRIC,
        [Display(Name = "Hybrid")]
        HYBRID
    }

    public class CarSpec
    {
        /// <summary>
        /// An identification number assigned to each car specification for the purposes of representing a specification within the database.
        /// </summary>
        public int CarSpecID { get; set; }

        /// <summary>
        /// What make the car is, all our cars are specifically BMW's
        /// </summary>
        public CarMakes Make { get; set; }

        /// <summary>
        /// What specific model number the car has been given by BMW
        /// </summary>
        public CarModels  Model { get; set; }

        /// <summary>
        /// Measured in cc. We are limiting this to one Engine Size only for a particular make and model
        /// </summary>
        public EngineSizes EngineSize { get; set; }

        /// <summary>
        /// How many doors the car has including the trunk door
        /// </summary>
        public int Doors { get; set; }

        /// <summary>
        /// The length of the car, measured in centimeters
        /// </summary>
        public float Length { get; set; }

        /// <summary>
        /// The width of the car, measured in centimeters
        /// </summary>
        public float Width { get; set; }

        /// <summary>
        /// The amount of power the car can put out at maximum throttle
        /// </summary>
        public Nullable<int> BHP { get; set; }

        /// <summary>
        /// Measured in litres
        /// </summary>
        public Nullable<int> BootCapacity { get; set; }

        /// <summary>
        /// The types of fuel that any car could have. A car could have 
        /// one type of fuel or a hybrid of two.
        /// </summary>
        public FuelTypes FuelType { get; set;}
        
        /// <summary>
        /// Type of fuel the specific BMW takes.
        /// </summary>
        public bool Petrol { get; set; }

        /// <summary>
        /// The number of miles the car can do before a gallon of petrol is depleted.
        /// </summary>
        public int MPG { get; set; }

        /// <summary>
        /// Type of fuel the specific BMW takes.
        /// </summary>
        public bool Diesel { get; set; }

        /// <summary>
        /// This can be what the BMW is powered by
        /// </summary>
        public bool Electric { get; set; }

        /// <summary>
        /// How many seats the car has, including front and back seats
        /// </summary>
        public int Seats { get; set; }

        /// <summary>
        /// What tax band the BMW belongs in depending on emissions
        /// </summary>
        public TaxGroups TaxGroup { get; set; }

        /// <summary>
        /// What the top speed of the BMW is, measured in MPH (Miles Per Hour)
        /// </summary>
        public int TopSpeed { get; set; }

        /// <summary>
        /// Whether the car is Front Wheel Drive (FWD), Rear Wheel Drive (RWD) or All/4 Wheel Drive (AWD/4WD)
        /// </summary>
        public DriveTrains DriveTrain { get; set; }

        /// <summary>
        /// A specific style of build that alters how the cars is labeled e.g. as a hatchback or sedan.
        /// </summary>
        public BodyTypes BodyType { get; set; }

        /// <summary>
        /// The number of miles an electric car can do before the battery is depleted.
        /// </summary>
        public int Range { get; set; }

        public virtual ICollection<Car> Cars { get; set; }

    }
}
