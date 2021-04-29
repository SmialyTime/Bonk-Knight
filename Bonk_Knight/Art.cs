﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bonk_Knight
{
    class Art
    {
        public static String Background(String Type)
        {
            String back = "";
            switch (Type)
            {
                case "TEST":
                    back = @"123456789012345678901234567890%" +
                           @"123456789012345678901234567890%" +
                           @"123456789012345678901234567890%" +
                           @"123456789012345678901234567890%" +
                           @"123456789012345678901234567890%" +
                           @"123456789012345678901234567890%" +
                           @"123456789012345678901234567890%" +
                           @"123456789012345678901234567890%" +
                           @"123456789012345678901234567890%";
                    break;
                case "TES1T":
                    back = @"123456789012345678901234567890%" +
                           @"123456789012345678901234567890%" +
                           @"123456789012345678901234567890%" +
                           @"123456789012345678901234567890%" +
                           @"123456789012345678901234567890%" +
                           @"123456789012345678901234567890%" +
                           @"123456789012345678901234567890%" +
                           @"123456789012345678901234567890%" +
                           @"(¯^/^¯)'|¯)/¯\\(¯)-'/(^-´¯¯¯)'%";
                    break;
                case "Throne":
                case "t":
                    back = @"     |      ·|··|·      |     %" +
                           @"   '-'-'    ╨-╨╨-╨    '-'-'   %" +
                           @"   |╛╬╘|              |╛╬╘|   %" +
                           @"   `-.-´    o/¯¯\o    `-.-´   %" +
                           @"            |(  )|            %" +
                           @"            ||--||            %" +
                           @"            .´¯¯`.            %" +
                           @"          .´¯¯¯¯¯¯`.          %" +
                           @"(¯¯¯)(¯¯¯)(¯¯¯)(¯¯¯)(¯¯¯)(¯¯¯)%";
                    break;
                case "Mountain":
                case "m":
                    back = @"   /\    _    ,^.      /¯¯\_  %" +
                           @"  /  \  / \  /^^^\    /     \ %" +
                           @" /    \/   \/     \__/        %" +
                           @"/          /                  %" +
                           @"                              %" +
                           @"                              %" +
                           @"                              %" +
                           @"                              %" +
                           @"(¯^/^¯)'|¯)/¯\\(¯)-'/(^-´¯¯¯)'%";
                    break;
                default:
                    back = @"                              %" +
                           @"                              %" +
                           @"                              %" +
                           @"                              %" +
                           @"              ?               %" +
                           @"                              %" +
                           @"                              %" +
                           @" 	                           %" +
                           @"(¯¯¯)(¯¯¯)(¯¯¯)(¯¯¯)(¯¯¯)(¯¯¯)%";
                    break;
            }
            return back;
        }
    }
}