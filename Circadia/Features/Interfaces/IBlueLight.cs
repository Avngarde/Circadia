using System;
using System.Collections.Generic;
using System.Text;

namespace Circadia.Features
{
    public interface IBlueLight
    {
        public void TurnOn(uint intensity);
        public void TurnOff();
    }
}
