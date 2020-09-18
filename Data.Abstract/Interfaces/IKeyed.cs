namespace ZFramework.Data.Abstract.Interfaces
{
    /// <summary>
    /// Interface to represent database classes with primary key.
    /// </summary>
    /// <typeparam name="TKey">Type of the primary key.</typeparam>
    public interface IKeyed<TKey>
    {
        /// <summary>
        /// Entity primary key.
        /// </summary>
        TKey ID { get; set; }
    }
}
