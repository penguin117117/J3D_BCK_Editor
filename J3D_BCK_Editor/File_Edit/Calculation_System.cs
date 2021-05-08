using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Globalization;
using System.Windows.Forms;
using EN = System.Environment;

namespace J3D_BCK_Editor.File_Edit
{
    class Calculation_System
    {
        public static TextBox debug = Form1.Form1Instance.デバッグ;
        public static string Byte2Char(BinaryReader br,int readchers = 4) 
        {
            return new string(br.ReadChars(readchers));
        }

        public static int Byte2Int(BinaryReader br, int readbyte = 4) 
        {
            return Int32.Parse(BitConverter.ToString(br.ReadBytes(readbyte), 0).Replace("-", "").PadLeft(readbyte, '0'), NumberStyles.HexNumber);
        }

        public static float Byte2Float(BinaryReader br, int readbyte = 4)
        {
            string str = string.Format("{0:f}", BitConverter.ToString(br.ReadBytes(readbyte), 0).Replace("-", "").PadLeft(readbyte, '0'));
            //Console.WriteLine(str);
            int num = Convert.ToInt32(str,16);
            byte[] bytenum = BitConverter.GetBytes(num);
            return BitConverter.ToSingle(bytenum, 0);
        }


        public static int Byte2Int2(BinaryReader br, int readbyte = 4)
        {
            string str = BitConverter.ToString(br.ReadBytes(readbyte)).Replace("-", "").PadLeft(8, '0');
            
            var num = Convert.ToInt32(str, 16);
            
            return Convert.ToInt32(num);
        }

        public static int Byte2Int32(BinaryReader br)
        {
            string str = BitConverter.ToString(br.ReadBytes(4)).Replace("-", "").PadLeft(8, '0');
            var i = Convert.ToInt32(str, 16);
            return Convert.ToInt32(i);
        }

        public static short Byte2Short_noPI(BinaryReader br) 
        {
            string str = BitConverter.ToString(br.ReadBytes(2)).Replace("-", "").PadLeft(4, '0');
            var i = Convert.ToInt16(str, 16);
            return Convert.ToInt16(i);
        }



        public static short Byte2Short(BinaryReader br)
        {
            var i = br.ReadInt16();
            float j = i / 182;
            Console.WriteLine("float" + j);
            return Convert.ToInt16(j);
        }

        public static byte[] StringToBytes(string str)
        {
            var bs = new List<byte>();
            for (int i = 0; i < str.Length / 2; i++)
            {
                bs.Add(Convert.ToByte(str.Substring(i*2, 2), 16));
            }
            return bs.ToArray();
        }

        public static byte[] StringToShort_byte(string str)
        {
            short sh;
            string str2;
            sh = Convert.ToInt16(str,10);
            str2 = sh.ToString("X4");
            return StringToBytes(str2);
            
        }

        public static byte[] StringToByte(string str)
        {
            byte bit;
            string str2;
            bit = Convert.ToByte(str, 10);
            str2 = bit.ToString("X2");
            return StringToBytes(str2);

        }


        public static string Float_ToHexString(float f)
        {
            var bytes = BitConverter.GetBytes(f);
            var i = BitConverter.ToInt32(bytes, 0);
            return  i.ToString("X8");
        }


        public static string Float_ToHexString_2(float f)
        {
            var j = Convert.ToSingle(f);

            var bytes = BitConverter.GetBytes(j);
            var i = BitConverter.ToInt32(bytes, 0);
            return i.ToString("X8");
        }

        public static string Int16_ToHexString(Int16 sh)
        {
            var j = Convert.ToInt16(sh);
            var bytes = BitConverter.GetBytes(j);
            var i = BitConverter.ToInt16(bytes, 0);
            return i.ToString("X4");
        }


        public static float hex2float(BinaryReader br, int readbyte = 4) 
        {
            string str = string.Format("{0:f3}", BitConverter.ToString(br.ReadBytes(readbyte), 0).Replace("-", ""));
            string hexString = str;
            uint num = uint.Parse(hexString, NumberStyles.AllowHexSpecifier);
            byte[] floatVals = BitConverter.GetBytes(num);
            float f = BitConverter.ToSingle(floatVals, 0);
            return  f;
        }

        public static float hex2float_2(BinaryReader br, int readbyte = 4)
        {
            string str = BitConverter.ToString(br.ReadBytes(readbyte), 0).Replace("-", "");
            string hexString = str;
            float f;
            f = Convert.ToSingle(Int32.Parse(str, NumberStyles.HexNumber));
            return f;
        }


        public static int hex2int(BinaryReader br, int readbyte = 4)
        {
            string str = string.Format("{0:X}", BitConverter.ToString(br.ReadBytes(readbyte), 0).Replace("-", ""));
            string hexString = str;
            return Int32.Parse(hexString, NumberStyles.AllowHexSpecifier);
        }

        public static byte[] ToHexString(string str)
        {
            var f = float.Parse(str);
            var bytes = BitConverter.GetBytes(f);
            var i = BitConverter.ToInt32(bytes, 0);
            return bytes;
        }

        public static float FromHexString(BinaryReader br)
        {

            var b = br.ReadBytes(4);
            var b2 = b.Reverse().ToArray();
            float i = BitConverter.ToSingle(b2,0);
            return i;
        }
    }
}
