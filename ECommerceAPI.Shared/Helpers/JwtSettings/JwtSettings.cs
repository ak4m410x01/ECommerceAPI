﻿namespace ECommerceAPI.Shared.Helpers.JwtSettings
{
    public class JwtSettings
    {
        public string? Issuer { get; set; }
        public string? Audience { get; set; }
        public int AccessTokenExpiryDays { get; set; }
        public int RefreshTokenExpiryDays { get; set; }
        public string? Key { get; set; }
    }
}