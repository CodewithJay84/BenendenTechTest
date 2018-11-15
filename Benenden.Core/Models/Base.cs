namespace Benenden.Core.Models
{
    public class Base
    {
        /// <summary>
        /// Unique ID for object
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Should object be usable/displayed
        /// </summary>
        public bool IsDeleted { get; set; }
    }
}
