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
                case "Home":
                case "h":
                    back = @"---------todo-----------------%" +
                           @"123456789012345678901234567890%" +
                           @"123456789012345678901234567890%" +
                           @"123456789012345678901234567890%" +
                           @"123456789012345678901234567890%" +
                           @"123456789012345678901234567890%" +
                           @"123456789012345678901234567890%" +
                           @"123456789012345678901234567890%" +
                           @"123456789012345678901234567890%";
                    break;
                case "MountainEntrance":
                case "ME":
                    back = @"---------todo-----------------%" +
                           @"▓▓▓▓▓ ▓▓▓▓▓▓▓▓▓ ▓▓▓▓▓▓▓▓▓ ▓▓▓▓%" +
                           @"▓▓▓▓ ▓▓▓▓▓▓▓▓▓ ▓▓▓▓▓▓▓▓▓ ▓▓▓▓▓%" +
                           @"▓▓▓ ▓▓▓▓▓▓▓▓▓ ▓▓▓▓▓▓▓▓▓ ▓▓▓▓▓▓%" +
                           @"▒▒ ▒▒▒▒▒▒▒▒▒ ▒▒▒▒▒▒▒▒▒ ▒▒▒▒▒▒▒%" +
                           @"▒ ▒▒▒▒▒▒▒▒▒ ▒▒▒▒▒▒▒▒▒ ▒▒▒▒▒▒▒▒%" +
                           @" ░░░░░░░░░ ░░░░░░░░░ ░░░░░░░░░%" +
                           @"░░░░░░░░░ ░░░░░░░░░ ░░░░░░░░░ %" +
                           @"(¯¯¯)(¯¯¯)(¯¯¯)(¯¯¯)(¯¯¯)(¯¯¯)%";
                    break;
                case "Mountain1":
                case "M1":
                    back = @"   /\    _    .^.      /¯¯\_  %" +
                           @"  /  \  / \  /^^^\    /     \ %" +
                           @" /    \/   \/     \__/       `%" +
                           @"/          /                  %" +
                           @"                              %" +
                           @"                              %" +
                           @"                              %" +
                           @"                              %" +
                           @"(¯^/^¯)'|¯)/¯\\(¯)-'/(^-´¯¯¯)'%";
                    break;
                case "Mountain2":
                case "M2":
                    back = @"---------todo-----------------%" +
                           @"/`´`´\/´`\ /´`´`´`\   /\      %" +
                           @"´`´`´/`´`´\/\`´/\`´\ /´`/\    %" +
                           @"´`||/´`´`´/´`\/´`\´`\`|/´`\  /%" +
                           @"  ||`´`||/`´`/`´`´\`´ /`´`´\/´%" +
                           @"  ||(#)||´`|/`´`´`´\  ´`||´/`|%" +
                           @"*  *    *  |`´`||´σ´ (#)|| ´`|%" +
                           @"       (##)             ||(##)%" +
                           @"(¯¯¯)(¯¯¯)(¯¯¯)(¯¯¯)(¯¯¯)(¯¯¯)%";
                    break;
                case "Mountain3":
                case "M3":
                    back = @"---------todo-----------------%" +
                           @"   /\   /´`\/´`\      /´`\    %" +
                           @"  /´`\ /`´`/`´`´\ /\ /σ`´`\/\ %" +
                           @" /`´`´\´`|/`´`´`´\´`\´`|/\/´`\%" +
                           @"\´`´`´`\ |`´`||´σ´||´  /´`\`´`%" +
                           @"`\`||´σ´ ||  ||     * /´`´`\|`%" +
                           @"|´\||    |(##)|       ´`||´`| %" +
                           @"|´`*|  (###*#)     (*#) ||   *%" +
                           @"(¯¯¯)(¯¯¯)(¯¯¯)(¯¯¯)(¯¯¯)(¯¯¯)%";
                    break;
                case "MountainExit":
                case "MX":
                    back = @"---------todo-----------------%" +
                           @" /\                           %" +
                           @"/´`\  /\                      %" +
                           @"`´`´\/´`\  /\                 %" +
                           @"`´`´/`´`´\/´`\                %" +
                           @"`||/`´`´´`\´`´\            /\ %" +
                           @" ||`´`||´`´||´`           /´`\%" +
                           @" (*##*)|   ||             ^||^%" +
                           @"(¯¯¯)(¯¯¯)(¯¯¯)(¯¯¯)(¯¯¯)(¯¯¯)%";
                    break;
                case "CaveEntrance":
                case "CE":
                    back = @"---------todo-----------------% " +
                           @"                           /\ %" +
                           @"                     /\   /´`\%" +
                           @"                /\  /´`\ /`´`´%" +
                           @"               /´`\/`´`´\´`´`´%" +
                           @"    /\        /`´`/`´`´`´\`||´%" +
                           @"   /´`\       ´`||´`´||`´` || %" +
                           @"   ^||^   (##)  ||   ||(*##)| %" +
                           @"(¯¯¯)(¯¯¯)(¯¯¯)(¯¯¯)(¯¯¯)(¯¯¯)%";
                    break;
                case "Cave1":
                case "C1":
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
                case "Cave2":
                case "C2":
                    back = @"---------todo-----------------%" +
                           @"/`´`´\/´`\ /´`´`´`\   /\      %" +
                           @"´`´`´/`´`´\/\`´/\`´\ /´`/\    %" +
                           @"´`||/´`´`´/´`\/´`\´`\`|/´`\  /%" +
                           @"  ||`´`||/`´`/`´`´\`´ /`´`´\/´%" +
                           @"  ||(#)||´`|/`´`´`´\  ´`||´/`|%" +
                           @"*  *    *  |`´`||´σ´ (#)|| ´`|%" +
                           @"       (##)             ||(##)%" +
                           @"(¯¯¯)(¯¯¯)(¯¯¯)(¯¯¯)(¯¯¯)(¯¯¯)%";
                    break;
                case "Cave3":
                case "C3":
                    back = @"---------todo-----------------%" +
                           @"   /\   /´`\/´`\      /´`\    %" +
                           @"  /´`\ /`´`/`´`´\ /\ /σ`´`\/\ %" +
                           @" /`´`´\´`|/`´`´`´\´`\´`|/\/´`\%" +
                           @"\´`´`´`\ |`´`||´σ´||´  /´`\`´`%" +
                           @"`\`||´σ´ ||  ||     * /´`´`\|`%" +
                           @"|´\||    |(##)|       ´`||´`| %" +
                           @"|´`*|  (###*#)     (*#) ||   *%" +
                           @"(¯¯¯)(¯¯¯)(¯¯¯)(¯¯¯)(¯¯¯)(¯¯¯)%";
                    break;
                case "CaveExit":
                case "CX":
                    back = @"---------todo-----------------%" +
                           @" /\                           %" +
                           @"/´`\  /\                      %" +
                           @"`´`´\/´`\  /\                 %" +
                           @"`´`´/`´`´\/´`\                %" +
                           @"`||/`´`´´`\´`´\            /\ %" +
                           @" ||`´`||´`´||´`           /´`\%" +
                           @" (*##*)|   ||             ^||^%" +
                           @"(¯¯¯)(¯¯¯)(¯¯¯)(¯¯¯)(¯¯¯)(¯¯¯)%";
                    break;
                case "ForestEntrance":
                case "FE":
                    back = @"                              %" +
                           @"                           /\ %" +
                           @"                     /\   /´`\%" +
                           @"                /\  /´`\ /`´`´%" +
                           @"               /´`\/`´`´\´`´`´%" +
                           @"    /\        /`´`/`´`´`´\`||´%" +
                           @"   /´`\       ´`||´`´||`´` || %" +
                           @"   ^||^   (##)  ||   ||(*##)| %" +
                           @"(¯¯¯)(¯¯¯)(¯¯¯)(¯¯¯)(¯¯¯)(¯¯¯)%";
                    break;
                case "Forest1":
                case "F1":
                    back = @"   /\             /´`´`\      %" +
                           @"  /´`\  /\     /\/´`´/\`\ /\  %" +
                           @" /`´`´\/´`\   /´`\´`/´`\`/´`\ %" +
                           @"/´`´`´/`´`´\/\`´`´\/`´`´/`´`´\%" +
                           @"`σ`||/´`´`´/´`\||`´´`||/´σ´`´`%" +
                           @"   ||`´`||/`´`σ\|    ||`´`||´`%" +
                           @"   ||(#)||´`||´`|    ||   ||  %" +
                           @" *  *    *  ||*  (*##*)  *||  %" +
                           @"(¯¯¯)(¯¯¯)(¯¯¯)(¯¯¯)(¯¯¯)(¯¯¯)%";
                    break;
                case "Forest2":
                case "F2":
                    back = @" /´`\  /\   /´`´`\            %" +
                           @"/`´`´\/´`\ /´`´`´`\   /\      %" +
                           @"´`´`´/`´`´\/\`´/\`´\ /´`/\    %" +
                           @"´`||/´`´`´/´`\/´`\´`\`|/´`\  /%" +
                           @"  ||`´`||/`´`/`´`´\`´ /`´`´\/´%" +
                           @"  ||(#)||´`|/`´`´`´\  ´`||´/`|%" +
                           @"*  *    *  |`´`||´σ´ (#)|| ´`|%" +
                           @"       (##)             ||(##)%" +
                           @"(¯¯¯)(¯¯¯)(¯¯¯)(¯¯¯)(¯¯¯)(¯¯¯)%";
                    break;
                case "Forest3":
                case "F3":
                    back = @"         /\  /\        /\     %" +
                           @"   /\   /´`\/´`\      /´`\    %" +
                           @"  /´`\ /`´`/`´`´\ /\ /σ`´`\/\ %" +
                           @" /`´`´\´`|/`´`´`´\´`\´`|/\/´`\%" +
                           @"\´`´`´`\ |`´`||´σ´||´  /´`\`´`%" +
                           @"`\`||´σ´ ||  ||     * /´`´`\|`%" +
                           @"|´\||    |(##)|       ´`||´`| %" +
                           @"|´`*|  (###*#)     (*#) ||   *%" +
                           @"(¯¯¯)(¯¯¯)(¯¯¯)(¯¯¯)(¯¯¯)(¯¯¯)%";
                    break;
                case "ForestExit":
                case "FX":
                    back = @"                              %" +
                           @" /\                           %" +
                           @"/´`\  /\                      %" +
                           @"`´`´\/´`\  /\                 %" +
                           @"`´`´/`´`´\/´`\                %" +
                           @"`||/`´`´´`\´`´\            /\ %" +
                           @" ||`´`||´`´||´`           /´`\%" +
                           @" (*##*)|   ||             ^||^%" +
                           @"(¯¯¯)(¯¯¯)(¯¯¯)(¯¯¯)(¯¯¯)(¯¯¯)%";
                    break;
                case "VillageEntrance":
                case "VE":
                    back = @"                         ╒╡▓▓▓%" +
                           @"                   ╒=====╡▓▓▓▓%" +
                           @"                ╒==╡▒▒▒▒ ▒▒▒▒▒%" +
                           @"             ╒==╡▒▒▒▒▒▒ ▒▒▒▒▒▒%" +
                           @"       ╒=====╡▒▒▒▒▒▒▒▒ ▒▒▒▒▒▒▒%" +
                           @"     ╒=╡░░░ ░░░░░░░░░ ░░░o░░░░%" +
                           @"  ╒==╡░░░░ ░░░░░░░░░ ░░░░╫░░░░%" +
                           @" ╒╡░░░░░░ ░░░░░░░░░ ░░░░░░░░░░%" +
                           @"(¯¯¯)(¯¯¯)(¯¯¯)(¯¯¯)(¯¯¯)(¯¯¯)%";
                    break;
                case "Village1":
                case "V1":
                    back = @"▓▓▓▓▓▓ ▓▓▓▓▓▓▓▓▓ ▓▓▓▓▓▓▓▓▓ ▓▓▓%" +
                           @"▓▓▓▓▓ ▓▓▓▓▓▓▓▓▓ ▓▓▓▓▓▓▓▓▓ ▓▓▓▓%" +
                           @"▒▒ /\╥/\╥/\╥**** /\╥/\╥  /\╥/\%" +
                           @"▒▒ └┘ └┘ └┘ **** └┘ └┘   └┘ └┘%" +
                           @"▒▒ ▒▒▒▒▒▒▒▒▒ ▒▒▒▒▒▒▒▒▒ ▒▒▒▒▒▒▒%" +
                           @"░ ░░░░░░░░░ ░░░░░░░░░ ░░░░░░░░%" +
                           @" ░░░░░░░░░ ░░░░░░░░░ ░░░░░░░░░%" +
                           @"░░░░░░░░░ ░░░░░░░░░ ░░░░░░░░░ %" +
                           @"(¯¯¯)(¯¯¯)(¯¯¯)(¯¯¯)(¯¯¯)(¯¯¯)%";
                    break;
                case "Village2":
                case "V2":
                    back = @"▓▓▓▓▓▓ ▓▓▓▓▓▓▓▓▓ ▓▓▓▓▓▓▓▓▓ ▓▓▓%" +
                           @"▓▓▓▓▓ ▓▓▓▓▓▓▓▓▓ _   _ ▓▓▓ ▓▓▓▓%" +
                           @"▒▒▒▒ ▒▒▒▒▒▒▒▒▒  \:_/; ▒▒ ▒▒▒▒▒%" +
                           @"▒▒▒ ▒▒▒▒▒▒▒▒▒ ▒  (X)  ▒ ▒▒▒▒▒▒%" +
                           @"▒▒ ▒▒▒▒▒▒▒▒▒ ▒▒ ;/A:\  ▒▒▒▒▒▒▒%" +
                           @"░ ░░░░░░░░░ ░░░ ¯/_\¯ ░░░░░░░░%" +
                           @" ░░░░░░░░░ ░░░░░░░░░ ░░░░░░░░░%" +
                           @"░░░░░░░░░ ░░░░░░░░░ ░░░░░░░░░ %" +
                           @"(¯¯¯)(¯¯¯)(¯¯¯)(¯¯¯)(¯¯¯)(¯¯¯)%";
                    break;
                case "Village3":
                case "V3":
                    back = @"▓▓▓▓▓▓ ▓▓▓▓▓▓▓▓▓ ▓▓▓▓▓▓▓▓▓ ▓▓▓%" +
                           @"▓▓▓▓▓ ▓▓▓▓▓▓▓▓▓ ▓▓▓▓▓▓▓▓▓ ▓▓▓▓%" +
                           @"▒▒▒▒ ▒▒▒▒▒▒▒▒ ______.-. ▒▒▒▒▒▒%" +
                           @"▒▒▒ ▒▒▒▒▒▒▒▒ /A\ \ \| |\▒▒▒▒▒▒%" +
                           @"▒▒ ▒▒▒▒/\╥/\╥|X||___|_||▒▒▒▒▒▒%" +
                           @"░ ░░░░░└┘ └┘░░░░░░░░░ ░░░░░░░░%" +
                           @" ░░░░░░░░░ ░░░░░░░░░ ░░░░░░░░░%" +
                           @"░░░░░░░░░ ░░░░░░░░░ ░░░░░░░░░ %" +
                           @"(¯¯¯)(¯¯¯)(¯¯¯)(¯¯¯)(¯¯¯)(¯¯¯)%";
                    break;
                case "VillageExit":
                case "VX":
                    back = @"▓▓▓▓▓▓▓ ▓▓▓▓▓▓▓▓▓╞┘       ~|  %" +
                           @"▓▓▓▓▓▓ ▓▓▓▓▓▓▓▓▓╞┘         [''%" +
                           @"▒▒▒▒▒ ▒▒▒▒▒▒▒▒▒╞┘          |″ %" +
                           @"▒▒▒▒ ▒▒▒▒▒▒▒▒▒╞┘           |__%" +
                           @"▒▒▒ ▒▒▒▒▒▒▒▒▒╞┘               %" +
                           @"░░ ░░░░░░░░░╞┘                %" +
                           @"░ ░░░░░░░░░╞┘                 %" +
                           @" ░░░░░░░░░╞┘                  %" +
                           @"(¯¯¯)(¯¯¯)(¯¯¯)(¯¯¯)(¯¯¯)(¯¯¯)%";
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
                case "Wall1":
                case "W":
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
                    back = @"                     ][_____][%" +
                           @"                     |⌠δ⌠|⌠δ⌠|%" +
                           @"       |~          |~|║╬║=║╬║|%" +
                           @" /[¯]_[¯]_[¯]_[¯]_[¯\|⌡Φ⌡ ⌡Φ⌡|%" +
                           @"]/,’____‛,___╓╦╖__| ″|.--┬--.|%" +
                           @"//*********.-╢║╟-.\′ ||  |  ||%" +
                           @"/*********(`|-.-|´)\ || c|c ||%" +
                           @"           `'-.-'´  \||__|__||%" +
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

        public static String Menu(String Type)
        {
            String Menu = "";
            switch (Type) 
            {
                case "FillerTEST":
                    Menu = @"123456789012345678901234567890%" +
                           @"123456789012345678901234567890%" +
                           @"123456789012345678901234567890%" +
                           @"123456789012345678901234567890%" +
                           @"123456789012345678901234567890%" +
                           @"123456789012345678901234567890%" +
                           @"123456789012345678901234567890%" +
                           @"123456789012345678901234567890%" +
                           @"123456789012345678901234567890%";
                    break;
                case "Shop":
                    Menu = @"123456789012345678901234567890%" +
                           @"123456789012345678901234567890%" +
                           @"123456789012345678901234567890%" +
                           @"123456789012345678901234567890%" +
                           @"123456789012345678901234567890%" +
                           @"123456789012345678901234567890%" +
                           @"123456789012345678901234567890%" +
                           @"123456789012345678901234567890%" +
                           @"123456789012345678901234567890%";
                    break;
                case "Inventory":
                    Menu = @"123456789012345678901234567890%" +
                           @"123456789012345678901234567890%" +
                           @"123456789012345678901234567890%" +
                           @"123456789012345678901234567890%" +
                           @"123456789012345678901234567890%" +
                           @"123456789012345678901234567890%" +
                           @"123456789012345678901234567890%" +
                           @"123456789012345678901234567890%" +
                           @"123456789012345678901234567890%";
                    break;
                case "Pause":
                    Menu = @"123456789012345678901234567890%" +
                           @"123456789012345678901234567890%" +
                           @"123456789012345678901234567890%" +
                           @"123456789012345678901234567890%" +
                           @"123456789012345678901234567890%" +
                           @"123456789012345678901234567890%" +
                           @"123456789012345678901234567890%" +
                           @"123456789012345678901234567890%" +
                           @"123456789012345678901234567890%";
                    break;
                case "MainMenu":
                    Menu = @"123456789012345678901234567890%" +
                           @"123456789012345678901234567890%" +
                           @"123456789012345678901234567890%" +
                           @"123456789012345678901234567890%" +
                           @"123456789012345678901234567890%" +
                           @"123456789012345678901234567890%" +
                           @"123456789012345678901234567890%" +
                           @"123456789012345678901234567890%" +
                           @"123456789012345678901234567890%";
                    break;
                default:
                    Menu = @"                              %" +
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
            return Menu;
        }
    }
}