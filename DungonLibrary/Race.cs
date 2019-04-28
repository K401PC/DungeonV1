using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungonLibrary
{
    public enum Race
    {
        //There is no direct way to create an enum through the Visual Studio
        //interface, so to make one you create a class, make it public and
        //change the class keyword to enum. TGhe values contain no spaces
        //and are comma-seperated.
        Elf,
        Dwarf,
        HalfElf,
        Human,//instuctor selection fisrt 4
        HalfOrc,
        DragonBorn,
        DarkElf,
        Halfling,
        Tiefling,
        DemiHuman,
        DescendantOfHigherPlain,//not hero


    }//end class
}//end name
