using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using OhmsLaws.Model;
using System.Globalization;

namespace OhmsLaws.ViewModels;

public partial class MainViewModel : ObservableObject
{
    [ObservableProperty]
    string ohmsText;

    [ObservableProperty]
    string voltsText;

    [ObservableProperty]
    string ampsText;

    [ObservableProperty]
    string wattsText;


    [RelayCommand]
    void Clear()
    {
        OhmsText = string.Empty;
        VoltsText = string.Empty;
        AmpsText = string.Empty;
        WattsText = string.Empty;
    }

    [RelayCommand]
    void Calculate()
    {
        OhmsModel ohmsModel =  CalculateValuesFromInput(GetNumberFromString(OhmsText),
            GetNumberFromString(VoltsText),
            GetNumberFromString(AmpsText),
            GetNumberFromString(WattsText));

        SetEntryValues(ohmsModel);
    }

    /// <summary>
    /// Get the double value from the provided input string.
    /// </summary>
    /// <param name="input"></param>
    /// <returns>Double value from stirng or return 0 if not a string.</returns>
    private double? GetNumberFromString(string input)
    {
        try
        {
            NumberFormatInfo info = new NumberFormatInfo();
            info.NumberDecimalDigits = 2;
            info.NumberDecimalSeparator = ".";
            info.NumberGroupSeparator = ",";

            return Convert.ToDouble(input, info);
        } catch (FormatException)
        {
            return null;
        }
    }
    
    /// <summary>
    /// Calculate all model values based on the provided input values.
    /// </summary>
    /// <param name="ohms"></param>
    /// <param name="volts"></param>
    /// <param name="amps"></param>
    /// <param name="watts"></param>
    /// <returns>OhmsModel object.</returns>
    public OhmsModel CalculateValuesFromInput(double? ohms, double? volts, double? amps, double? watts)
    {
        OhmsModel ohmsModel = new OhmsModel(ohms, volts, amps, watts);  

        // Volts
        if (ohms.HasValue && amps.HasValue)
        {
            ohmsModel.volts = ((double)(ohms * amps));
        }
        if (amps.HasValue && watts.HasValue)
        {
            ohmsModel.volts = ((double)(amps / watts));
        }
        if (ohms.HasValue && watts.HasValue)
        {
            ohmsModel.volts = Math.Sqrt((double)(ohms * watts));
        }

        // Amps
        if (ohms.HasValue && volts.HasValue)
        {
            ohmsModel.amps = ((double)(volts / ohms));
        }
        if (volts.HasValue && watts.HasValue)
        {
            ohmsModel.amps = ((double)(watts / volts));
        }
        if (ohms.HasValue && watts.HasValue)
        {
            ohmsModel.amps = Math.Sqrt((double)(watts / ohms));
        }

        // Ohms
        if (volts.HasValue && amps.HasValue)
        {
            ohmsModel.ohms = ((double)(volts / amps));
        }
        if (volts.HasValue && watts.HasValue)
        {
            ohmsModel.ohms = ((double)(Math.Pow((double)volts, 2.0) / watts));
        }
        if (watts.HasValue && amps.HasValue)
        {
            ohmsModel.ohms = ((double)(watts / Math.Pow((double)amps, 2.0)));
        }

        // Watts
        if (volts.HasValue && amps.HasValue)
        {
            ohmsModel.watts = ((double)(volts * amps));
        }
        if (ohms.HasValue && amps.HasValue)
        {
            ohmsModel.watts = (double)(ohms * Math.Pow((double)amps, 2.0));
        }
        if (volts.HasValue && ohms.HasValue)
        {
            ohmsModel.watts = (double)(Math.Pow((double)volts, 2.0) / ohms);
        }

        return ohmsModel;
    }

    /// <summary>
    /// Set all Entry field values to the calculated values.
    /// </summary>
    /// <param name="ohmsModel"></param>
    private void SetEntryValues(OhmsModel ohmsModel)
    {
        OhmsText = ohmsModel.ohms.ToString();
        VoltsText = ohmsModel.volts.ToString();
        AmpsText = ohmsModel.amps.ToString();
        WattsText = ohmsModel.watts.ToString();
    }
}
