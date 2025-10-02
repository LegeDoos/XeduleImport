using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XeduleImportHelper.Business
{
    /// <summary>
    /// Class representing a person
    /// </summary>
    public class Person
    {
        /// <summary>
        /// Unique xedule id
        /// </summary>
        public int XeduleId { get; set; }
        /// <summary>
        /// Name of the person
        /// </summary>
        public string Name { get; set; }
    }
}
