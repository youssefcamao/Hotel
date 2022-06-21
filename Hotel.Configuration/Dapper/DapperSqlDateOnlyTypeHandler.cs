using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Configuration.Dapper
{
    public class DapperSqlDateOnlyTypeHandler : SqlMapper.TypeHandler<DateOnly>
    {
        /// <summary>
        /// This method converts from DateOnly to DateTime
        /// </summary>
        /// <param name="parameter"></param>
        /// <param name="date"></param>
        public override void SetValue(IDbDataParameter parameter, DateOnly date)
        => parameter.Value = date.ToDateTime(new TimeOnly(0, 0));
        /// <summary>
        /// This method converts from DateTime To DateOnly
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public override DateOnly Parse(object value)
            => DateOnly.FromDateTime((DateTime)value);
    }
}
