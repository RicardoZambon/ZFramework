namespace ZFramework.Data.Abstract.Interfaces
{
    /// <summary>
    /// Interface for objects that should have a property to set when deleted and not actually deleted from database.
    /// </summary>
    public interface ISoftDelete
    {
        /// <summary>
        /// Determines when the object is deleted and should be hidden in application.
        /// </summary>
        bool IsDeleted { get; set; }
    }
}