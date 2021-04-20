using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using Dapper;
using MetricsAgent.Controllers;
using System.Data;
using MetricsAgent.DAL.interfaces;

namespace MetricsAgent.DAL
{
    

    public class TimeSpanHandler : SqlMapper.TypeHandler<TimeSpan>
    {
        public override TimeSpan Parse(object value)
        => TimeSpan.FromSeconds((long)value);
        public override void SetValue(IDbDataParameter parameter, TimeSpan value)
        => parameter.Value = value;
    }



}

