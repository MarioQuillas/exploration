namespace Exploration.IoT.GrainClasses
{
    using System;
    using System.Threading.Tasks;

    using Exploration.IoT.GrainInterfaces;

    using Orleans;
    using Orleans.Providers;

    /// <summary>
    /// Grain implementation class DeviceGrain.
    /// </summary>
    [StorageProvider(ProviderName="store1")]
    public class DeviceGrain : Grain<DeviceGrainState>, IDeviceGrain
    {
        private double lastValue;

        public override Task OnActivateAsync()
        {
            var id = this.GetPrimaryKeyLong();
            Console.WriteLine("Activated {0}", id);
            return base.OnActivateAsync();
        }

        public Task SetTemperature(double value)
        {
            if (this.lastValue < 100 && value >= 100)
                Console.WriteLine("High temperature recorded {0}", value);

            this.lastValue = value;
            return Task.CompletedTask;
        }
    }
}
