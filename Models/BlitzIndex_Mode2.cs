using System;
using System.Collections.Generic;

namespace RashakaGroupsAdmin.Models;

public partial class BlitzIndex_Mode2
{
    public int ID { get; set; }

    public string ServerName { get; set; } = null!;

    public DateTimeOffset CheckDate { get; set; }

    public string? DatabaseName { get; set; }

    public string? SchemaName { get; set; }

    public string? TableName { get; set; }

    public string? IndexName { get; set; }

    public int? IndexId { get; set; }

    public string? ObjectType { get; set; }

    public string? IndexDefinition { get; set; }

    public string? KeyColumnNamesWithSort { get; set; }

    public int? CountKeyColumns { get; set; }

    public string? IncludeColumnNames { get; set; }

    public int? CountIncludedColumns { get; set; }

    public string? SecretColumns { get; set; }

    public int? CountSecretColumns { get; set; }

    public string? PartitionKeyColumnName { get; set; }

    public string? FilterDefinition { get; set; }

    public bool? IsIndexedView { get; set; }

    public bool? IsPrimaryKey { get; set; }

    public bool? IsXML { get; set; }

    public bool? IsSpatial { get; set; }

    public bool? IsNCColumnstore { get; set; }

    public bool? IsCXColumnstore { get; set; }

    public bool? IsDisabled { get; set; }

    public bool? IsHypothetical { get; set; }

    public bool? IsPadded { get; set; }

    public int? FillFactor { get; set; }

    public bool? IsReferencedByForeignKey { get; set; }

    public DateTime? LastUserSeek { get; set; }

    public DateTime? LastUserScan { get; set; }

    public DateTime? LastUserLookup { get; set; }

    public DateTime? LastUserUpdate { get; set; }

    public long? TotalReads { get; set; }

    public long? UserUpdates { get; set; }

    public decimal? ReadsPerWrite { get; set; }

    public string? IndexUsageSummary { get; set; }

    public int? PartitionCount { get; set; }

    public long? TotalRows { get; set; }

    public decimal? TotalReservedMB { get; set; }

    public decimal? TotalReservedLOBMB { get; set; }

    public decimal? TotalReservedRowOverflowMB { get; set; }

    public string? IndexSizeSummary { get; set; }

    public long? TotalRowLockCount { get; set; }

    public long? TotalRowLockWaitCount { get; set; }

    public long? TotalRowLockWaitInMs { get; set; }

    public long? AvgRowLockWaitInMs { get; set; }

    public long? TotalPageLockCount { get; set; }

    public long? TotalPageLockWaitCount { get; set; }

    public long? TotalPageLockWaitInMs { get; set; }

    public long? AvgPageLockWaitInMs { get; set; }

    public long? TotalIndexLockPromotionAttemptCount { get; set; }

    public long? TotalIndexLockPromotionCount { get; set; }

    public string? DataCompressionDesc { get; set; }

    public long? PageLatchWaitCount { get; set; }

    public long? PageLatchWaitInMs { get; set; }

    public long? PageIoLatchWaitCount { get; set; }

    public long? PageIoLatchWaitInMs { get; set; }

    public DateTime? CreateDate { get; set; }

    public DateTime? ModifyDate { get; set; }

    public string? MoreInfo { get; set; }

    public int? DisplayOrder { get; set; }
}
