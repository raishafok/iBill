﻿using System;
using CCC.ORM;
using CCC.ORM.DataAccess;
using CCC.ORM.DataAttributes;

namespace LyncBillingBase.DataModels
{
    [DataSource(Name = "MonitoringServersInfo", Type = Globals.DataSource.Type.DbTable,
        AccessMethod = Globals.DataSource.AccessMethod.DistributedSource)]
    public class CallsSummary : DataModel
    {
        [IsIdField]
        [DbColumn("Date")]
        public DateTime Date { get; set; }

        [DbColumn("Year")]
        public int Year { get; set; }

        [DbColumn("Month")]
        public int Month { get; set; }

        // Business
        [DbColumn("BusinessCallsCount")]
        public long BusinessCallsCount { get; set; }

        [DbColumn("BusinessCallsDuration")]
        public long BusinessCallsDuration { get; set; }

        [DbColumn("BusinessCallsCost")]
        public decimal BusinessCallsCost { get; set; }

        // Personal
        [DbColumn("PersonalCallsCount")]
        public long PersonalCallsCount { get; set; }

        [DbColumn("PersonalCallsDuration")]
        public long PersonalCallsDuration { get; set; }

        [DbColumn("PersonalCallsCost")]
        public decimal PersonalCallsCost { get; set; }

        // Unmarked
        [DbColumn("UnmarkedCallsCount")]
        public long UnallocatedCallsCount { get; set; }

        [DbColumn("UnmarkedCallsDuration")]
        public long UnallocatedCallsDuration { get; set; }

        [DbColumn("UnmarkedCallsCost")]
        public decimal UnallocatedCallsCost { get; set; }

        public decimal TotalCallsCost
        {
            get { return (BusinessCallsCost + PersonalCallsCost + UnallocatedCallsCost); }
        }

        public long TotalCallsDuration
        {
            get { return (BusinessCallsDuration + PersonalCallsDuration + UnallocatedCallsDuration); }
        }

        public long TotalCallsCount
        {
            get { return (BusinessCallsCount + PersonalCallsCount + UnallocatedCallsCount); }
        }
    }

}
