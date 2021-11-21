using System;

namespace RestApiTesting.DTO
{
    public partial class CreateUsersDto
    {
        public string Name { get; set; }
        public string Job { get; set; }
        public long Id { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
    }
}