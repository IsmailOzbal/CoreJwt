using System;
namespace Core2_2ApiJwt.Entities.DTO
{
    public class TokenResponse
    {
        public int UserId { get; set; }
        public string token { get; set; }
        public DateTime? expireDate { get; set; }
    }
}
