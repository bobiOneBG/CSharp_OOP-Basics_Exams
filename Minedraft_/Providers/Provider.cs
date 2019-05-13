using System;

public abstract class Provider : IId
{
    private double energyOutput;

    protected Provider(string id, double energyOutput)
    {
        this.Id = id;
        this.EnergyOutput = energyOutput;
    }

    public string Id { get; }

    public double EnergyOutput
    {
        get
        {
            return this.energyOutput;
        }

        private set
        {
            if (value <= 0 || value >= 100000)
            {
                throw new ArgumentException("Provider is not registered, because of it's EnergyOutput");
            }
            this.energyOutput = value;
        }
    }
}

