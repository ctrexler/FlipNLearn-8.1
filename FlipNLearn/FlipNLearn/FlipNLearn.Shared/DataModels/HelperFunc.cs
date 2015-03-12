using System;
using System.Collections.Generic;
using System.Text;
using Windows.UI;

namespace FlipNLearn.DataModels
{
    class HelperFunc
    {
        public static int ColorToInt(Color c)
        {
           return (c.A << 24) | (c.R << 16) | (c.G << 8) | c.B;
        }
    }
}
