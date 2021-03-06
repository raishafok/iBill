﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace LyncBillingBase.DataMappers.SQLQueries
{
    public class PhoneCallsSql
    {
        //
        // Chargeable Calls Query for a User
        public string ChargableCallsBySipAccount(List<string> _dbTables, string sipAccount)
        {
            var sqlStatment = string.Empty;

            var index = 0;
            foreach (var tableName in _dbTables)
            {
                sqlStatment += String.Format
                    (
                        "SELECT *,'{0}' AS PhoneCallsTableName FROM {0} " +
                        "WHERE " + 
                            "( [ChargingParty]='{1}' OR [UI_AssignedToUser]='{1}' ) AND " + 
                            "[Marker_CallTypeID] in (1,2,3,4,5,6,21,19,22,24) AND" +
                            "[Exclude]=0 AND " +
                            "[ToGateway] IS NOT NULL AND " +
                            "([AC_DisputeStatus]='Rejected' OR [AC_DisputeStatus] IS NULL ) "
                        , tableName
                        , sipAccount
                    );

                if (index < (_dbTables.Count() - 1))
                {
                    sqlStatment += " UNION ALL ";
                    index++;
                }
            }

            return sqlStatment;
        }

        //
        // Chargeable Calls Query for a Site Department
        public string ChargeableCallsBySiteDepartment(List<string> _dbTables, string siteName)
        {
            var sqlStatment = string.Empty;

            //var index = 0;
            //foreach (var tableName in tables)
            //{
            //    sqlStatment += String.Format
            //        (
            //            "SELECT *,'{0}' AS PhoneCallsTableName FROM {0} " +
            //            "LEFT OUTER JOIN [ActiveDirectoryUsers]  ON [{0}].[ChargingParty] = [ActiveDirectoryUsers].[SipAccount] " +
            //            "WHERE " +
            //                "[Marker_CallTypeID] in (1,2,3,4,5,6,21,19,22,24) AND " +
            //                "[Exclude]=0 AND " +
            //                "([AC_DisputeStatus]='Rejected' OR [AC_DisputeStatus] IS NULL ) AND " +
            //                "[ToGateway] IS NOT NULL AND " +
            //                "[ToGateway] IN " +
            //                "(" +
            //                    "SELECT [Gateway] " +
            //                    "FROM [GatewaysDetails] " +
            //                    "LEFT JOIN [Gateways] ON [Gateways].[GatewayId] = [GatewaysDetails].[GatewayID] " +
            //                    "LEFT JOIN [Sites] ON [Sites].[SiteID] = [GatewaysDetails].[SiteID] " +
            //                    "WHERE [SiteName]='{1}' " +
            //                ")"
            //            , tableName
            //            , siteName
            //        );

            //    if (index < (tables.Count() - 1))
            //    {
            //        sqlStatment += " UNION ALL ";
            //        index++;
            //    }
            //}

            return sqlStatment;
        }

        //
        // Chargeable Calls Query for a Site
        public string ChargeableCallsBySiteName(List<string> _dbTables, string siteName)
        {
            var sqlStatment = string.Empty;

            var index = 0;
            foreach (var tableName in _dbTables)
            {
                sqlStatment += String.Format
                    (
                        "SELECT *,'{0}' AS PhoneCallsTableName FROM {0} " +
                        "LEFT OUTER JOIN [ActiveDirectoryUsers] ON [{0}].[ChargingParty] = [ActiveDirectoryUsers].[SipAccount] " +
                        "WHERE " +
                            "[Marker_CallTypeID] in (1,2,3,4,5,6,21,19,22,24) AND " +
                            "[Exclude]=0 AND " +
                            "([AC_DisputeStatus]='Rejected' OR [AC_DisputeStatus] IS NULL ) AND " +
                            "[ToGateway] IS NOT NULL AND " +
                            "[ToGateway] IN " +
                            "(" +
                                "SELECT [Gateway] " +
                                "FROM [GatewaysDetails] " +
                                "LEFT JOIN [Gateways] ON [Gateways].[GatewayId] = [GatewaysDetails].[GatewayID] " +
                                "LEFT JOIN [Sites] ON [Sites].[SiteID] = [GatewaysDetails].[SiteID] " +
                                "WHERE [SiteName]='{1}' " +
                            ")"
                        , tableName
                        , siteName
                    );

                if (index < (_dbTables.Count() - 1))
                {
                    sqlStatment += " UNION ALL ";
                    index++;
                }
            }

            return sqlStatment;
        }


        public string GetAllPhoneCalls(List<string> _dbTables)
        {
            var sqlStatment = string.Empty;

            var index = 0;
            foreach (var tableName in _dbTables)
            {
                sqlStatment += String.Format("SELECT *,'{0}' AS PhoneCallsTableName FROM {0} ", tableName);

                if (index < (_dbTables.Count() - 1))
                {
                    sqlStatment += " UNION ALL ";
                    index++;
                }
            }

            return sqlStatment;
        }


        public string PhoneCallsWithConditions(List<string> _dbTables, Dictionary<string, object> whereConditions)
        {
            var sqlStatment = string.Empty;

            //int index = 0;
            //foreach (string tableName in tables)
            //{
            //    sqlStatment += String.Format("SELECT *,'{0}' AS PhoneCallsTableName FROM {0} ", tableName);

            //    if (index < (tables.Count() - 1))
            //    {
            //        sqlStatment += " UNION ALL ";
            //        index++;
            //    }
            //}

            return sqlStatment;
        }


        public string GetDisputedCallsForSite(List<string> _dbTables, string siteName)
        {
            var sqlStatment = string.Empty;

            var index = 0;
            foreach (var tableName in _dbTables)
            {
                sqlStatment += String.Format
                    (
                        "SELECT *,'{0}' AS PhoneCallsTableName FROM {0} " +
                        "LEFT OUTER JOIN [ActiveDirectoryUsers] ON [{0}].[ChargingParty] = [ActiveDirectoryUsers].[SipAccount] " +
                        "WHERE " +
                            "[Marker_CallTypeID] in (1,2,3,4,5,6,21,19,22,24) AND " +
                            "[Exclude]=0 AND " +
                            "([AC_DisputeStatus]='Rejected' OR [AC_DisputeStatus]='Accepted' OR ([AC_DisputeStatus] IS NULL AND [UI_CallType]='Disputed')) AND " +
                            "[ToGateway] IS NOT NULL AND " +
                            "[ToGateway] IN " +
                            "(" +
                                "SELECT [Gateway] " +
                                "FROM [GatewaysDetails] " +
                                "LEFT JOIN [Gateways] ON [Gateways].[GatewayId] = [GatewaysDetails].[GatewayID] " +
                                "LEFT JOIN [Sites] ON [Sites].[SiteID] = [GatewaysDetails].[SiteID] " +
                                "WHERE [SiteName]='{1}' " +
                            ")"
                        , tableName
                        , siteName
                    );

                if (index < (_dbTables.Count() - 1))
                {
                    sqlStatment += " UNION ALL ";
                    index++;
                }
            }

            return sqlStatment;
        }


        public string SP_InvoiceAllocatedChargeableCallsForSite(List<string> _dbTables, string siteName, string startingDate, string endingDate, string invoicingDate)
        {
            string sqlStatment = string.Empty;

            //
            // BEGIN TRANSACTION
            sqlStatment += "BEGIN TRANSACTION; ";

            var index = 0;
            foreach (var tableName in _dbTables)
            {
                sqlStatment += String.Format
                    (
                        "UPDATE {0} " +
                        "SET " + 
		                    "AC_IsInvoiced='YES', " +
		                    "AC_InvoiceDate='{1}' " +
                        "WHERE " + 
                            "[AC_IsInvoiced] = 'NO' AND " + 
		                    "[UI_CallType] IS NOT NULL AND " + 
		                    "[SessionIdTime] BETWEEN '{2}' AND '{3}' AND " + 
		                    "[Marker_CallTypeID] in (1,2,3,4,5,6,21,19,22,24) AND " +
		                    "[Exclude] = 0 AND " + 
		                    "([AC_DisputeStatus] = 'Rejected' OR [AC_DisputeStatus] IS NULL) AND " + 
		                    "[ToGateway] IS NOT NULL AND " + 
                            "[ChargingParty] IN " + 
		                    "( " + 
			                    "SELECT " + 
				                    "[ADUsers].[SipAccount] " +
			                    "FROM " + 
				                    "[ActiveDirectoryUsers] as [ADUsers], " + 
				                    "Gateways as [Gw] " + 
			                    "WHERE " + 
				                    "[ADUsers].[AD_PhysicalDeliveryOfficeName] = '{4}' AND  " + 
				                    "[Gw].[GatewayId] in " + 
				                    "( " + 
					                    "SELECT " + 
						                    "[Gw].[GatewayId] " + 
					                    "FROM " + 
						                    "Gateways " + 
						                    "INNER JOIN Sites on Sites.SiteName = [ADUsers].[AD_PhysicalDeliveryOfficeName] " + 
						                    "INNER JOIN GatewaysDetails on [GatewaysDetails].[GatewayID] = [Gateways].[GatewayId] " + 
					                    "WHERE " + 
						                    "Sites.SiteName = '{4}' " + 
				                    ") " + 
		                    "); "

                        , tableName
                        , invoicingDate
                        , startingDate
                        , endingDate
                        , siteName
                    );

                if (index < (_dbTables.Count() - 1))
                {
                    index++;
                }
            }

            //
            // COMMIT TRANSACTION
            sqlStatment += "COMMIT TRANSACTION;";

            return sqlStatment;
        }


        public string SP_InvoiceUnallocatedChargeableCallsForSite(List<string> _dbTables, string siteName, string startingDate, string endingDate, string invoicingDate)
        {
            string sqlStatment = string.Empty;

            //
            // BEGIN TRANSACTION
            sqlStatment += "BEGIN TRANSACTION; ";

            var index = 0;
            foreach (var tableName in _dbTables)
            {
                sqlStatment += String.Format
                    (
                        "UPDATE {0} " +
                        "SET " +
                            "AC_IsInvoiced='YES', " +
                            "AC_InvoiceDate='{1}', " +
		                    "UI_CallType='Personal', " + 
		                    "UI_MarkedOn='{1}', " + 
		                    "UI_UpdatedByUser='LogParser@ccc.gr' " + 
                        "WHERE " +
                            "[AC_IsInvoiced] = 'N/A' AND " +
                            "[SessionIdTime] BETWEEN '{2}' AND '{3}' AND " +
                            "[Marker_CallTypeID] in (1,2,3,4,5,6,21,19,22,24) AND " +
                            "[Exclude] = 0 AND " +
                            "([AC_DisputeStatus] = 'Rejected' OR [AC_DisputeStatus] IS NULL) AND " +
                            "[ToGateway] IS NOT NULL AND " +
                            "[ChargingParty] IN " +
                            "( " +
                                "SELECT " +
                                    "[ADUsers].[SipAccount] " +
                                "FROM " +
                                    "[ActiveDirectoryUsers] as [ADUsers], " +
                                    "Gateways as [Gw] " +
                                "WHERE " +
                                    "[ADUsers].[AD_PhysicalDeliveryOfficeName] = '{4}' AND  " +
                                    "[Gw].[GatewayId] in " +
                                    "( " +
                                        "SELECT " +
                                            "[Gw].[GatewayId] " +
                                        "FROM " +
                                            "Gateways " +
                                            "INNER JOIN Sites on Sites.SiteName = [ADUsers].[AD_PhysicalDeliveryOfficeName] " +
                                            "INNER JOIN GatewaysDetails on [GatewaysDetails].[GatewayID] = [Gateways].[GatewayId] " +
                                        "WHERE " +
                                            "Sites.SiteName = '{4}' " +
                                    ") " +
                            "); "

                        , tableName
                        , invoicingDate
                        , startingDate
                        , endingDate
                        , siteName
                    );

                if (index < (_dbTables.Count() - 1))
                {
                    index++;
                }
            }

            //
            // COMMIT TRANSACTION
            sqlStatment += "COMMIT TRANSACTION;";

            return sqlStatment;
        }


        public string SP_MarkUnallocatedCallsAsPendingForSite(List<string> _dbTables, string siteName, string startingDate, string endingDate, string invoicingDate)
        {
            string sqlStatment = string.Empty;

            //
            // BEGIN TRANSACTION
            sqlStatment += "BEGIN TRANSACTION; ";

            var index = 0;
            foreach (var tableName in _dbTables)
            {
                sqlStatment += String.Format
                    (
                        "UPDATE {0} " +
                        "SET " +
                            "AC_IsInvoiced='N/A', " + 
                            "AC_InvoiceDate='{1}' " +
                        "WHERE " +
                            "[AC_IsInvoiced] = 'NO' AND " + 
		                    "[UI_CallType] IS NULL AND " +
                            "[SessionIdTime] BETWEEN '{2}' AND '{3}' AND " +
                            "[Marker_CallTypeID] in (1,2,3,4,5,6,21,19,22,24) AND " +
                            "[Exclude] = 0 AND " +
                            "([AC_DisputeStatus] = 'Rejected' OR [AC_DisputeStatus] IS NULL) AND " +
                            "[ToGateway] IS NOT NULL AND " +
                            "[ChargingParty] IN " +
                            "( " +
                                "SELECT " +
                                    "[ADUsers].[SipAccount] " +
                                "FROM " +
                                    "[ActiveDirectoryUsers] as [ADUsers], " +
                                    "Gateways as [Gw] " +
                                "WHERE " +
                                    "[ADUsers].[AD_PhysicalDeliveryOfficeName] = '{4}' AND  " +
                                    "[Gw].[GatewayId] in " +
                                    "( " +
                                        "SELECT " +
                                            "[Gw].[GatewayId] " +
                                        "FROM " +
                                            "Gateways " +
                                            "INNER JOIN Sites on Sites.SiteName = [ADUsers].[AD_PhysicalDeliveryOfficeName] " +
                                            "INNER JOIN GatewaysDetails on [GatewaysDetails].[GatewayID] = [Gateways].[GatewayId] " +
                                        "WHERE " +
                                            "Sites.SiteName = '{4}' " +
                                    ") " +
                            "); "

                        , tableName
                        , invoicingDate
                        , startingDate
                        , endingDate
                        , siteName
                    );

                if (index < (_dbTables.Count() - 1))
                {
                    index++;
                }
            }

            //
            // COMMIT TRANSACTION
            sqlStatment += "COMMIT TRANSACTION;";

            return sqlStatment;
        }

    }

}