using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base64EncoderDecoder
{
    public class Base64_Encoder
    {
        byte[] plaintext;
        int length, length2;
        int block;
        int padding;
        public Base64_Encoder(byte[] input)
        {
            plaintext = input;    //vendosja e plain-tekstit
            length = input.Length;  //gjatesia e plain-tekstit
            if ((length % 3) == 0)
            {
                padding = 0;
                block = length / 3;
            }
            else
            {
                padding = 3 - (length % 3);
                block = (length + padding) / 3;
            }
            length2 = length + padding;
       
            