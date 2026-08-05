using System;
using System.Collections.Generic;
using System.Text;
using System.Management;
using Circadia.Interops;
using Circadia.Utils;

namespace Circadia.Features
{
    public class BlueLight : IBlueLight
    {
        public void TurnOff() 
            => BlueLightWinInteropFacade.SetBlueLightGamma(0);

        public void TurnOn(uint intensity) 
            => BlueLightWinInteropFacade.SetBlueLightGamma(intensity);
    }
}
