using System;

namespace PBEncDec.src.core
{
  internal class Crypt
  {
    public static void decrypt(byte[] data, int shift)
    {
      byte num = data[data.Length - 1];
      for (int index = data.Length - 1; index > 0; --index)
        data[index] = (byte) ((int) data[index - 1] << 8 - shift | (int) data[index] >> shift);
      data[0] = (byte) ((int) num << 8 - shift | (int) data[0] >> shift);
    }

    public static void encrypt(byte[] data, byte shift)
    {
      byte num = data[data.Length - 1];
      for (int index = data.Length - 1; index > 0; --index)
        data[index] = (byte) ((int) data[index - 1] << 8 - (int) shift | (int) data[index] >> (int) shift);
      data[0] = (byte) ((int) num << 8 - (int) shift | (int) data[0] >> (int) shift);
      byte[] numArray = new byte[data.Length];
      for (int index = 0; index < data.Length - 1; ++index)
        numArray[index] = data[index + 1];
      numArray[data.Length - 1] = data[0];
      numArray.CopyTo((Array) data, 0);
    }

    public static void decrypt2(byte[] data, int length, int shift)
    {
      byte num1 = (byte) shift;
      int num2 = length - 1;
      int num3 = 8 - shift;
      byte num4 = data[length - 1];
      while (num2 >= 0)
      {
        byte num5 = (byte) ((num2 > 0 ? (int) data[num2 - 1] : (int) num4) << num3 | (int) data[num2--] >> (int) num1);
        data[num2 + 1] = num5;
      }
    }

    public static void encrypt2(byte[] data, int length, int shift)
    {
      int num1 = shift;
      byte[] numArray = data;
      byte num2 = data[0];
      int num3 = 8 - shift;
      int num4 = 0;
      int num5 = 8 - shift;
      if (length <= 0)
        return;
      while (true)
      {
        int num6 = num4 >= length - 1 ? (int) num2 : (int) numArray[num4 + 1];
        int num7 = (int) numArray[num4++] << num1;
        numArray[num4 - 1] = (byte) (num7 | num6 >> num3);
        if (num4 < length)
        {
          int num8 = (int) (ushort) num3 & (int) byte.MaxValue;
          int num9 = (int) (ushort) num3 >> 8;
          num3 = num5 & (int) byte.MaxValue | (num9 & (int) byte.MaxValue) << 8;
        }
        else
          break;
      }
    }
  }
}
