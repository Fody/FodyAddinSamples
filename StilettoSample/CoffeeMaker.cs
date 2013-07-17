using System;
using Stiletto;

namespace StilettoSample
{
    public class CoffeeMaker
    {
        [Inject]
        public Lazy<IHeater> Heater { get; set; }

        [Inject]
        public IPump Pump { get; set; }

        public void Brew()
        {
            Heater.Value.On();
            Pump.Pump();
            Console.WriteLine("[_]P coffee is ready!");
            Heater.Value.Off();
        }
    }
}
