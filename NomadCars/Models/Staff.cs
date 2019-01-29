using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NomadCars.Models
{
    /// <summary>
    /// William
    /// Each Member of staff is a Person working for Nomad Cars
    /// </summary>
    public enum DepartmentOptions
    {
        [Display(Name ="Sales")]
        SALES,
        [Display(Name ="Management")]
        MANAGEMENT,
        [Display(Name ="Accounts")]
        ACCOUNTS
    }

    public enum JobPositionOptions
    {
        [Display(Name ="Sales Representative")]
        SALES_REPRESENTATIVE,
        [Display(Name ="Sales Manager")]
        SALES_MANAGER,
        [Display(Name ="Location Manager")]
        LOCATION_MANAGER,
        [Display(Name ="Accountant")]
        ACCOUNTANT
    }

    public class Staff
    {
        /// <summary>
        /// A specific identification number that identifies the member 
        /// of staff within the database.
        /// </summary>
        [ForeignKey("Person")]
        public int StaffID { get; set; }
        
        /// <summary>
        /// The department that the member of staff works for. 
        /// The departments include sales, database administration and management
        /// </summary>
        public DepartmentOptions Department { get; set; }
        
        /// <summary>
        /// The specific position that the member of staff holds within 
        /// their department, e.g. sales representative or database administrator.
        /// </summary>
        [Display(Name ="Job Position")]
        public JobPositionOptions JobPosition { get; set; }

        /// <summary>
        /// The monthly payment of the employee.
        /// </summary>
        [Required,DisplayFormat(DataFormatString ="{0:c}", ApplyFormatInEditMode = false)]
        [Display(Name ="Annual Salary")]
        public decimal Salary { get; set; }

        /// <summary>
        /// The starting date of the employee's employment, 
        /// measured in a numerical value e.g. 12/09/2013
        /// </summary>
        /// 
        [Required, DataType(DataType.DateTime), Display(Name = "Start Date"), 
            DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}",ApplyFormatInEditMode = true)]
        public DateTime StartDate { get; set; }

        /// <summary>
        ///  The URL of the image of the satff memeber,
        ///  being used on the website.
        /// </summary>
        public String ImageURL { get; set; }

        public String Description { get; set; }

        public virtual Person Person { get; set; }

    }
}
