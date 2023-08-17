
namespace OhmsLaws.Model;

public class OhmsModel
{
    public OhmsModel(double? ohms, double? volts, double? amps, double? watts)
    {
        this.ohms = ohms;
        this.volts = volts;
        this.amps = amps;
        this.watts = watts;
    }

    public double? ohms { get; set; }
    public double? volts { get; set; }
    public double? amps { get; set; }
    public double? watts { get; set; }
}

