namespace project.service.Models
{
    public interface IVehicleModel
    {
        string Abrv { get; set; }
        int Id { get; set; }
     
        string Name { get; set; }
        VehicleMake VehicleMake { get; set; }
    }
}