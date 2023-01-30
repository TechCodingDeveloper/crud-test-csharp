using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Shared.Interfaces
{
    /// <summary>
    /// default created date time for filters
    /// </summary>
    public interface IDateTime
    {
        /// <summary>
        /// Modification Date Time 
        /// </summary>
        DateTime ModificationDateTime { get; set; }
        /// <summary>
        /// Creation Date Time 
        /// </summary>
        DateTime CreationDateTime { get; set; }
    }

    public interface IDate
    {
        DateTime Date { get; set; }
    }
}
