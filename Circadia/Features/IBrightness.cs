using System;
using System.Collections.Generic;
using System.Text;

namespace Circadia.Features
{
    public interface IBrightness
    {
        public void SetBrightness(uint brightness);
        public uint GetBrightness();
    }
}
