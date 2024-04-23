using Domain.Vehicles;

namespace Domain.RentalCompanies;

public class RentalBranch
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string State { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
    public bool IsMain { get; set; }
    public IDictionary<string, decimal> Taxes { get; set; } = new Dictionary<string, decimal>();
    public IDictionary<string, decimal> Fees { get; set; } = new Dictionary<string, decimal>();
    public IEnumerable<Vehicle> Vehicles { get; set; } = [];

    public decimal TotalTaxes() => Taxes.Sum(tax => tax.Value);

    public decimal TotalFees() => Fees.Sum(fee => fee.Value);
}
