﻿namespace TheJitu_Commerce_Orders.Models.Dtos
{
    public class StripeRequestDto
    {
        public string? StripeSessionUrl { get; set; }
        public string? StripeSessionId { get; set; }
        public string ApprovedUrl { get; set; }
        public string CancelUrl { get; set; }
        public OrderHeaderDto OrderHeader { get; set; }
    }
}
