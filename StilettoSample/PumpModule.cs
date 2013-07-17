using Stiletto;

namespace StilettoSample
{
    [Module(IsComplete = false)]
    public class PumpModule
    {
        [Provides]
        public IPump GetPump(Thermosiphon thermosiphon)
        {
            return thermosiphon;
        }
    }
}
