using System;
using System.Collections.Generic;

namespace RashakaGroupsAdmin.Models;

public partial class FawryPayPurchase
{
    public int id { get; set; }

    public string? requestId { get; set; }

    public long? fawryRefNumber { get; set; }

    public long? merchantRefNumber { get; set; }

    public string? customerName { get; set; }

    public string? customerMobile { get; set; }

    public string? customerMail { get; set; }

    public long? customerMerchantId { get; set; }

    public decimal? paymentAmount { get; set; }

    public decimal? orderAmount { get; set; }

    public decimal? fawryFees { get; set; }

    public string? orderStatus { get; set; }

    public string? paymentMethod { get; set; }

    public long? orderExpiryDate { get; set; }
}
