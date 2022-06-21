using Hotel.Configuration.Interfaces.Models;

namespace Hotel.Configuration.Models.DapperModels
{
    internal class DapperUser : IUser
    {
        /// <summary>
        /// <inheritdoc/>
        /// <para>this proprety was also made set to allow access from dapper</para>
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// <inheritdoc/>
        /// <para>this proprety was also made set to allow access from dapper</para>
        /// </summary>
        public string FirstName { get; set; } = String.Empty;
        /// <summary>
        /// <inheritdoc/>
        /// <para>this proprety was also made set to allow access from dapper</para>
        /// </summary>
        public string LastName { get; set; } = String.Empty;
        /// <summary>
        /// <inheritdoc/>
        /// <para>this proprety was also made set to allow access from dapper</para>
        /// </summary>
        public string Email { get; set; } = String.Empty;
        /// <summary>
        /// <inheritdoc/>
        /// <para>this proprety was also made set to allow access from dapper</para>
        /// </summary>
        public bool IsUserAdmin { get; set; }
    }
}
