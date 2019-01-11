using System;
using System.Collections.Generic;
using System.Text;

namespace Obsolete
{
    class OldClass
    {
        [Obsolete("The method is outdated")]//ObsoleteAttribute Full Name
        public void ObsoleteMessage()
        {
            Console.WriteLine("Hello Suren.I'm already old!!!");
        }

        [Obsolete("The method is not used", true)]// bool error
        public void ObsoleteError()
        {
            Console.WriteLine("Hello Suro.They don't use me at all!!!");
        }

    }
}
