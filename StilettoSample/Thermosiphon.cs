using System;
using Stiletto;

namespace StilettoSample
{
    public class Thermosiphon : IPump
    {
        private readonly IHeater heater;

        [Inject]
        public Thermosiphon(IHeater heater)
        {
            this.heater = heater;
        }

        public void Pump()
        {
            if (heater.IsHot) {
                Console.WriteLine("~~~~Pumping~~~~");
            }
        }
    }
}
