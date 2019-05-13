using System.Collections.Generic;

public class HarvesterFactory
{
    public Harvester CreateHarvester(List<string> arguments)
    {
        var harvesterType = arguments[0];
        var id = arguments[1];
        var oreOutput = double.Parse(arguments[2]);
        var energyRequirement = double.Parse(arguments[3]);

        if (harvesterType == "Hammer")
        {
            return new HammerHarvester(id, oreOutput, energyRequirement);
        }

        else if (harvesterType == "Sonic")
        {
            var sonicFactor = int.Parse(arguments[4]);

            return new SonicHarvester(id, oreOutput, energyRequirement, sonicFactor);
        }

        else
        {
            return null;
        }
    }
}