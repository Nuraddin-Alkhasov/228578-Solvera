using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace HMI.CO.MO
{
    public class TrackData
    {
        public string pon;
        public int id;
        public string type;
        public string modul;
        public string part;
        public string DK;
        public Thickness T;

        public TrackData(string _pon, int _id)
        {
            pon = _pon;
            id = _id;
            T = GetCoords(_id);
            setData();
        }

        private Thickness GetCoords(int id)
        {
            //switch (id)
            //{
            //    case 0:
            //        bool HVTinPosOven = (bool)ApplicationService.GetVariableValue("PLC.PLC.Blocks.5 Modul 3 Trockner.02 HVT.Fahrwagen.02 Fahrantrieb.DB HVT Fahrwagen Status.In Position.Ofen");
            //        if (HVTinPosOven) { return new Thickness(321, 225, 1494, 629); }
            //        else { return new Thickness(273, 429, 1542, 425); }
            //    case 1: return new Thickness(523, 223, 1292, 631);
            //    case 2: return new Thickness(560, 246, 1255, 608);
            //    case 3: return new Thickness(596, 249, 1219, 605);
            //    case 4: return new Thickness(633, 251, 1182, 603);
            //    case 5: return new Thickness(669, 254, 1146, 600);
            //    case 6: return new Thickness(706, 256, 1109, 598);
            //    case 7: return new Thickness(744, 258, 1071, 596);
            //    case 8: return new Thickness(780, 260, 1035, 594);
            //    case 9: return new Thickness(817, 262, 998, 592);
            //    case 10: return new Thickness(854, 265, 961, 589);
            //    case 11: return new Thickness(890, 267, 925, 587);
            //    case 12: return new Thickness(926, 269, 889, 585);
            //    case 13: return new Thickness(963, 272, 852, 582);
            //    case 14: return new Thickness(999, 275, 816, 579);
            //    case 15: return new Thickness(1036, 277, 779, 577);
            //    case 16: return new Thickness(1073, 280, 742, 574);
            //    case 17: return new Thickness(1110, 282, 705, 572);
            //    case 18: return new Thickness(1147, 284, 668, 570);
            //    case 19: return new Thickness(1184, 286, 631, 568);
            //    case 20: return new Thickness(1219, 289, 596, 565);
            //    case 21: return new Thickness(1257, 291, 558, 563);
            //    case 22: return new Thickness(1293, 293, 522, 561);
            //    case 23: return new Thickness(1330, 296, 485, 558);
            //    case 24: return new Thickness(1367, 298, 448, 556);
            //    case 25: return new Thickness(1404, 301, 411, 553);
            //    case 26: return new Thickness(1440, 303, 375, 551);
            //    case 27: return new Thickness(1478, 305, 337, 549);
            //    case 28:
            //        bool HNTinPosOven = (bool)ApplicationService.GetVariableValue("PLC.PLC.Blocks.5 Modul 3 Trockner.04 HNT.02 Fahrawagen.02 Fahrantrieb.DB HNT Fahrwagen Status.In Position.Ofen");
            //        if (HNTinPosOven) { return new Thickness(1515, 308, 300, 546); }
            //        else { return new Thickness(1453, 506, 362, 348); }
            //    case 29: return new Thickness(1415, 503, 400, 351);
            //    case 30: return new Thickness(1378, 501, 437, 353);
            //    case 31: return new Thickness(1341, 497, 474, 357);
            //    case 32: return new Thickness(1304, 496, 511, 358);
            //    case 33: return new Thickness(1267, 494, 548, 360);
            //    case 34: return new Thickness(1230, 492, 585, 362);
            //    case 35: return new Thickness(1194, 488, 621, 366);
            //    case 36: return new Thickness(1157, 487, 658, 367);
            //    case 37: return new Thickness(1121, 484, 694, 370);
            //    case 38: return new Thickness(1084, 481, 731, 373);
            //    case 39: return new Thickness(1048, 479, 767, 375);
            //    case 40: return new Thickness(1011, 477, 804, 377);
            //    case 41: return new Thickness(974, 474, 841, 380);
            //    case 42: return new Thickness(937, 472, 878, 382);
            //    case 43: return new Thickness(900, 470, 915, 384);
            //    case 44: return new Thickness(864, 467, 951, 387);
            //    case 45: return new Thickness(828, 464, 987, 390);
            //    case 46: return new Thickness(790, 463, 1025, 391);
            //    case 47: return new Thickness(754, 460, 1061, 394);
            //    case 48: return new Thickness(717, 458, 1098, 396);
            //    case 49: return new Thickness(680, 455, 1135, 399);
            //    case 50: return new Thickness(644, 452, 1171, 402);
            //    case 51: return new Thickness(607, 451, 1208, 403);
            //    case 52: return new Thickness(570, 449, 1245, 405);
            //    case 53: return new Thickness(533, 446, 1282, 408);
            //    case 54: return new Thickness(497, 444, 1318, 410);
            //    case 55: return new Thickness(460, 441, 1355, 413);
            //    case 56: return new Thickness(423, 439, 1392, 415);
            //    case 57: return new Thickness(386, 436, 1429, 418);
            //    case 58: return new Thickness(348, 435, 1467, 419);
            //    case 59: return new Thickness(311, 430, 1504, 424);
            //    case 60: return new Thickness(311, 430, 1504, 424);
            //    default: return new Thickness(0, 0, 0, 0);
            //}
            return new Thickness(0, 0, 0, 0);
        }

        private void setData()
        {
            //switch (id)
            //{
            //    case 0: type = "Tablet"; modul = "3"; part = "2"; DK = "0"; break;
            //    case 1: type = "Belt"; modul = "3"; part = "3"; DK = "0"; break;
            //    case 2: type = "Tablet"; modul = "3"; part = "8"; DK = "6"; break;
            //    case 3: type = "Tablet"; modul = "3"; part = "8"; DK = "7"; break;
            //    case 4: type = "Tablet"; modul = "3"; part = "8"; DK = "8"; break;
            //    case 5: type = "Tablet"; modul = "3"; part = "8"; DK = "9"; break;
            //    case 6: type = "Tablet"; modul = "3"; part = "8"; DK = "10"; break;
            //    case 7: type = "Tablet"; modul = "3"; part = "8"; DK = "11"; break;
            //    case 8: type = "Tablet"; modul = "3"; part = "8"; DK = "12"; break;
            //    case 9: type = "Tablet"; modul = "3"; part = "8"; DK = "13"; break;
            //    case 10: type = "Tablet"; modul = "3"; part = "8"; DK = "14"; break;
            //    case 11: type = "Tablet"; modul = "3"; part = "8"; DK = "15"; break;
            //    case 12: type = "Tablet"; modul = "3"; part = "8"; DK = "16"; break;
            //    case 13: type = "Tablet"; modul = "3"; part = "8"; DK = "17"; break;
            //    case 14: type = "Tablet"; modul = "3"; part = "8"; DK = "18"; break;
            //    case 15: type = "Tablet"; modul = "3"; part = "8"; DK = "19"; break;
            //    case 16: type = "Tablet"; modul = "3"; part = "8"; DK = "20"; break;
            //    case 17: type = "Tablet"; modul = "3"; part = "8"; DK = "21"; break;
            //    case 18: type = "Tablet"; modul = "3"; part = "8"; DK = "22"; break;
            //    case 19: type = "Tablet"; modul = "3"; part = "8"; DK = "23"; break;
            //    case 20: type = "Tablet"; modul = "3"; part = "8"; DK = "24"; break;
            //    case 21: type = "Tablet"; modul = "3"; part = "8"; DK = "25"; break;
            //    case 22: type = "Tablet"; modul = "3"; part = "8"; DK = "26"; break;
            //    case 23: type = "Tablet"; modul = "3"; part = "8"; DK = "27"; break;
            //    case 24: type = "Tablet"; modul = "3"; part = "8"; DK = "28"; break;
            //    case 25: type = "Tablet"; modul = "3"; part = "8"; DK = "29"; break;
            //    case 26: type = "Tablet"; modul = "3"; part = "8"; DK = "30"; break;
            //    case 27: type = "Tablet"; modul = "3"; part = "8"; DK = "31"; break;
            //    case 28: type = "Tablet"; modul = "3"; part = "7"; DK = "0"; break;
            //    case 29: type = "Tablet"; modul = "3"; part = "9"; DK = "1"; break;
            //    case 30: type = "Tablet"; modul = "3"; part = "9"; DK = "2"; break;
            //    case 31: type = "Tablet"; modul = "3"; part = "9"; DK = "3"; break;
            //    case 32: type = "Tablet"; modul = "3"; part = "9"; DK = "4"; break;
            //    case 33: type = "Tablet"; modul = "3"; part = "9"; DK = "5"; break;
            //    case 34: type = "Tablet"; modul = "3"; part = "9"; DK = "6"; break;
            //    case 35: type = "Tablet"; modul = "3"; part = "9"; DK = "7"; break;
            //    case 36: type = "Tablet"; modul = "3"; part = "9"; DK = "8"; break;
            //    case 37: type = "Tablet"; modul = "3"; part = "9"; DK = "9"; break;
            //    case 38: type = "Tablet"; modul = "3"; part = "9"; DK = "10"; break;
            //    case 39: type = "Tablet"; modul = "3"; part = "9"; DK = "11"; break;
            //    case 40: type = "Tablet"; modul = "3"; part = "9"; DK = "12"; break;
            //    case 41: type = "Tablet"; modul = "3"; part = "9"; DK = "13"; break;
            //    case 42: type = "Tablet"; modul = "3"; part = "9"; DK = "14"; break;
            //    case 43: type = "Tablet"; modul = "3"; part = "9"; DK = "15"; break;
            //    case 44: type = "Tablet"; modul = "3"; part = "9"; DK = "16"; break;
            //    case 45: type = "Tablet"; modul = "3"; part = "9"; DK = "17"; break;
            //    case 46: type = "Tablet"; modul = "3"; part = "9"; DK = "18"; break;
            //    case 47: type = "Tablet"; modul = "3"; part = "9"; DK = "19"; break;
            //    case 48: type = "Tablet"; modul = "3"; part = "9"; DK = "20"; break;
            //    case 49: type = "Tablet"; modul = "3"; part = "9"; DK = "21"; break;
            //    case 50: type = "Tablet"; modul = "3"; part = "9"; DK = "22"; break;
            //    case 51: type = "Tablet"; modul = "3"; part = "9"; DK = "23"; break;
            //    case 52: type = "Tablet"; modul = "3"; part = "9"; DK = "24"; break;
            //    case 53: type = "Tablet"; modul = "3"; part = "9"; DK = "25"; break;
            //    case 54: type = "Tablet"; modul = "3"; part = "9"; DK = "26"; break;
            //    case 55: type = "Tablet"; modul = "3"; part = "9"; DK = "27"; break;
            //    case 56: type = "Tablet"; modul = "3"; part = "9"; DK = "28"; break;
            //    case 57: type = "Tablet"; modul = "3"; part = "9"; DK = "29"; break;
            //    case 58: type = "Tablet"; modul = "3"; part = "9"; DK = "30"; break;
            //    case 59: type = "Tablet"; modul = "3"; part = "9"; DK = "31"; break;
            //    case 60: type = "Tablet"; modul = "3"; part = "4"; DK = "0"; break;
            //}
        }

    }
}
