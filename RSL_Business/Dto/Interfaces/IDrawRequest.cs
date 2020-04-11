namespace RSL_Business.Dto.Interfaces
{
    public interface IDrawRequest
    {
        string CompanyId { get; set; }

        string[] OptionalProductFilter { get; set; }
    }
}
