using System.Collections.Generic;

public class ProviderFactory
{
    public Provider CreateProvider(List<string> arguments)
    {
        var providerType = arguments[0];
        var id = arguments[1];
        var energyOutput = double.Parse(arguments[2]);

        if (providerType == "Solar")
        {
            return new SolarProvider(id, energyOutput);
        }

        else if (providerType == "Pressure")
        {
            return new PressureProvider(id, energyOutput);
        }

        else
        {
            return null;
        }
    }
}

