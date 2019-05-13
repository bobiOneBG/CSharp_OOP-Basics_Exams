using System;
using System.Collections.Generic;
using System.Linq;

public class DraftManager
{
    private List<Harvester> harvesters;
    private List<Provider> providers;

    private double totalStoredEnergy;
    private double totalMinedOre;

    private Modes mode;

    public DraftManager()
    {
        this.harvesters = new List<Harvester>();
        this.providers = new List<Provider>();
        this.totalStoredEnergy = 0;
        this.totalMinedOre = 0;
        this.mode = Modes.Full;
    }

    public string RegisterHarvester(List<string> arguments)
    {
        var harvesterFactory = new HarvesterFactory();
        var harvester = harvesterFactory.CreateHarvester(arguments);

        this.harvesters.Add(harvester);

        return $"Successfully registered {arguments[0]} Harvester - {harvester.Id}";
    }

    public string RegisterProvider(List<string> arguments)
    {
        var providerFactory = new ProviderFactory();
        var provider = providerFactory.CreateProvider(arguments);

        this.providers.Add(provider);

        return $"Successfully registered {arguments[0]} Provider - {provider.Id}";
    }

    public string Day()
    {
        var dayEnergyProduce = this.providers.Sum(p => p.EnergyOutput);
        this.totalStoredEnergy += dayEnergyProduce;

        double dayEnergyNeed = 0;
        
        double dayMinedOre = 0;

        if (this.mode != Modes.Energy)
        {
            dayEnergyNeed = this.mode == Modes.Full ? this.harvesters.Sum(h => h.EnergyRequirement) :
             this.harvesters.Sum(h => h.EnergyRequirement) * 0.6;

            if (dayEnergyNeed <= this.totalStoredEnergy)
            {
                this.totalStoredEnergy -= dayEnergyNeed;

                dayMinedOre = this.mode == Modes.Full ? this.harvesters.Sum(h => h.OreOutput) :
                  this.harvesters.Sum(h => h.OreOutput) * 0.5;

                this.totalMinedOre += dayMinedOre;
            }
        }

        return "A day has passed." + Environment.NewLine +
            $"Energy Provided: { dayEnergyProduce}" + Environment.NewLine +
            $"Plumbus Ore Mined: { dayMinedOre}";
    }

    public string Mode(List<string> arguments)
    {
        this.mode = (Modes)Enum.Parse(typeof(Modes), arguments[0]);

        return $"Successfully changed working mode to {this.mode} Mode";
    }

    public string Check(List<string> arguments)
    {
        var id = arguments[0];

        var provider = this.providers.SingleOrDefault(p => p.Id == id);
        var harvester = this.harvesters.SingleOrDefault(h => h.Id == id);

        if (provider != null)
        {
            return $"{provider.GetType().Name.Substring(0, provider.GetType().Name.IndexOf("Provider"))} Provider - {id}" + Environment.NewLine +
                $"Energy Output: { provider.EnergyOutput}";
        }

        else if (harvester != null)
        {
            return $"{harvester.GetType().Name.Substring(0, harvester.GetType().Name.IndexOf("Harvester"))} Harvester - {id}" + Environment.NewLine +
                $"Ore Output: {harvester.OreOutput}" + Environment.NewLine +
                $"Energy Requirement: {harvester.EnergyRequirement}";
        }

        else
        {
            return $"No element found with id - {id}";
        }
    }

    public string ShutDown()
    {
        return "System Shutdown" + Environment.NewLine +
            $"Total Energy Stored: {this.totalStoredEnergy}" + Environment.NewLine +
            $"Total Mined Plumbus Ore: {this.totalMinedOre}";
    }
}

