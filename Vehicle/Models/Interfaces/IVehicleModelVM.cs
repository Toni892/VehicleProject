namespace testna_instr.Models
{
    public interface IVehicleModelVM
    {
        int Id { get; set; }
        int VehicleMakeId { get; set; }
        string Name { get; set; }
        VehicleViewModel VehicleMake { get; set; }
    }
}