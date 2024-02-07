using System;
using System.Collections.Generic;

namespace RashakaGroupsAdmin.Models;

public partial class source
{
    public int id { get; set; }

    public string? name { get; set; }

    public string? image { get; set; }

    public byte[]? timeStamp { get; set; }

    public DateTime? Date { get; set; }

    public int? Followers { get; set; }

    public int? CountryID { get; set; }

    public int? CategoryID { get; set; }

    public int? changeType { get; set; }

    public bool? deleted { get; set; }

    public bool? allow { get; set; }

    public string? description { get; set; }

    public string? blurImage { get; set; }

    public string? webSite { get; set; }

    public DateTime? timeparsed { get; set; }

    public int? intervalTime { get; set; }

    public string? Encoding { get; set; }

    public string? urgentWord { get; set; }

    public bool? distinctCheck { get; set; }

    public bool? isRtl { get; set; }

    public bool? approved { get; set; }

    public bool? reported { get; set; }

    public string? faceUrl { get; set; }

    public bool? type { get; set; }

    public DateTime? lastPostDate { get; set; }

    public int? socialTypeID { get; set; }

    public string? lastTwitterPostID { get; set; }

    public string? containedDIV { get; set; }

    public DateTime? SocialTimeParsed { get; set; }

    public string? removeChar { get; set; }

    public string? twitterLink { get; set; }

    public bool? urgentface { get; set; }

    public int? orderVal { get; set; }

    public string? NormalFaceBookUrl { get; set; }

    public string? NormalTwitterUrl { get; set; }

    public DateTime? LastPostFaceBookTime { get; set; }

    public string? RssUrl { get; set; }

    public bool? published { get; set; }

    public string? FaceBookPageID { get; set; }

    public bool? OpenChannel { get; set; }

    public bool? ReportToServer { get; set; }

    public bool? WhiteList { get; set; }

    public string? UrgenMainSiteUrl { get; set; }

    public int? PrevCountryID { get; set; }

    public int? PrevCategoryID { get; set; }

    public int? videoCatID { get; set; }

    public int? relatedSourceID { get; set; }

    public int? rank { get; set; }

    public bool? IsJavaScript { get; set; }

    public string? ContactUs { get; set; }

    public string? TwitterWebsiteLink { get; set; }

    public int? subCategoryId { get; set; }

    public DateTime? lastCrawlingTime { get; set; }

    public bool? IsSelected { get; set; }

    public int? ramdanCategoryId { get; set; }

    public bool? isSelectedForGallary { get; set; }

    public bool? isSelectedForYou { get; set; }

    public bool? isClosed { get; set; }

    public bool? isAutoPublishArticles { get; set; }

    public bool? isNotHeadless { get; set; }

    public bool? isOldServer { get; set; }

    public bool? isbroadcast { get; set; }

    public bool? isWorldCup { get; set; }

    public bool? isCheckWorldCup { get; set; }

    public string? gender { get; set; }

    public string? language { get; set; }

    public virtual TwitterCategory? Category { get; set; }

    public virtual ICollection<SiteKey> SiteKeys { get; set; } = new List<SiteKey>();

    public virtual ICollection<TwitterVideo> TwitterVideos { get; set; } = new List<TwitterVideo>();

    public virtual subCategory? subCategory { get; set; }
}
