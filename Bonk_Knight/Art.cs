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
                case "FillerTEST":
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
                case "KingdomEntrance":
                case "KE":
                    back = @" __ __        /'\|~      __ __%" +
                           @" ][_][       /^^^\       ][_][%" +
                           @" |   |-'-'-'-|___|-'-'-'-|   |%" +
                           @" |   |                   |   |%" +
                           @" |   |       .---.       |   |%" +
                           @" |   |      /+++++\      |   |%" +
                           @" |   |      |'''''|      |   |%" +
                           @" |   |      |     |      |   |%" +
                           @"(¯¯¯)(¯¯¯)(¯¯¯)(¯¯¯)(¯¯¯)(¯¯¯)%";
                    break;
                case "Wall":
                case "W"://‘ ‛ ’ ‚  “ ” „ ′ ″ ‴
                    back = @"_ __                          %" +
                           @"[_][                          %" +
                           @" ‘ |         |~          |~   %" +
                           @" ,’|[¯]_[¯]_[¯]_[¯]_[¯]_[¯]_[¯%" +
                           @"-.‛|,‘     ″ ‛, ‘,‛ ‘ ,‛ ′   ’%" +
                           @"+| ‘,   ‴    ,‘  , ′,’      ‘,%" +
                           @"'| | ’     ′   ‘,  ‛,  ‴    ’‘%" +
                           @" | |‘ ‘‚        ″‛,,‘     ,‘  %" +
                           @"(¯¯¯)(¯¯¯)(¯¯¯)(¯¯¯)(¯¯¯)(¯¯¯)%";
                    break;
                case "Wall2":
                    back = @"                              %" +
                           @"                              %" +
                           @"        |~                  |~%" +
                           @"¯]_[¯]_[¯]_[¯]_[¯]_[¯]_[¯]_[¯]%" +
                           @"‘,        ‘, ,‘        ‘   ‴  %" +
                           @" ‛, ′       ‛,      ″ ,‘,     %" +
                           @" ,‘,    ″   , ‘      , ‘,     %" +
                           @"‛, ‛        ,  ,    ,  , ‛ ,  %" +
                           @"(¯¯¯)(¯¯¯)(¯¯¯)(¯¯¯)(¯¯¯)(¯¯¯)%";
                    break;
                case "Wall3":
                    back = @"                              %" +
                           @"                              %" +
                           @"                  |~          %" +
                           @"_[¯]_[¯]_[¯]_[¯]_[¯]_[¯]_[¯]_[%" +
                           @"‘, ,‘,        ‘,     ″   ,    %" +
                           @"  ‛, ‘,  ″   ,’  ,‛, ,‘ , ‛   %" +
                           @"′ ,  ‘,      ‘, ‛  ‛,    ‛,  ′%" +
                           @"  ,‘   ‛    ‴,   , ’     ‛ ,  %" +
                           @"(¯¯¯)(¯¯¯)(¯¯¯)(¯¯¯)(¯¯¯)(¯¯¯)%";
                    break;
                case "Courtyard":
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
                case "Caves":
                case "c":
                    back = @"\ .^´¯¯\    / /`-´| |'`^-._  /%" +
                           @" |  ′   \  /`;    (/       |´ %" +
                           @" '       \/        )    ′  |  %" +
                           @"            ′     (        '  %" +
                           @"                   )      ′   %" +
                           @"   ′              (           %" +
                           @"           ′                  %" +
                           @"                    ′         %" +
                           @"(¯¯¯)(¯¯¯)(¯¯¯)(¯¯¯)(¯¯¯)(¯¯¯)%";
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
                    back = @"   /\    _    .^.      /¯¯\_  %" +
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
                           @"                              %" +
                           @"(¯¯¯)(¯¯¯)(¯¯¯)(¯¯¯)(¯¯¯)(¯¯¯)%";
                    break;
            }
            return back;
        }
    }
}