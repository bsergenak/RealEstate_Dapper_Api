namespace RealEstate_Dapper_Api.Dtos.ServiceDtos
{
    public class GetByIdServiceDto
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public bool CategoryStatus { get; set; }
    }
}
