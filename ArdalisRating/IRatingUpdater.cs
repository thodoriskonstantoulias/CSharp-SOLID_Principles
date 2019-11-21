using System;
using System.Collections.Generic;
using System.Text;

namespace ArdalisRating
{
    //Removed for dependency iversion principle
    public interface IRatingUpdater
    {
        void UpdateRating(decimal rating);
    }
}
