﻿using System;
using System.Data;
using System.IO;
using System.IO.Compression;

namespace Lis2013HISWSTest
{
    public class ZipHelper
    {
        /// <summary>
        /// 解压
        /// </summary>
        /// <param name="Value"></param>
        /// <returns></returns>
        public static DataSet GetDatasetByString(string Value)
        {
            DataSet ds = new DataSet();
            string CC = GZipDecompressString(Value);
            System.IO.StringReader Sr = new StringReader(CC);
            ds.ReadXml(Sr);
            return ds;
        }
        /// <summary>
        /// 根据DATASET压缩字符串
        /// </summary>
        /// <param name="ds"></param>
        /// <returns></returns>
        public static string GetStringByDataset(string ds)
        {
            return GZipCompressString(ds);
        }
        /// <summary>
        /// 将传入字符串以GZip算法压缩后，返回Base64编码字符
        /// </summary>
        /// <param name="rawString">需要压缩的字符串</param>
        /// <returns>压缩后的Base64编码的字符串</returns>
        public static string GZipCompressString(string rawString)
        {
            if (string.IsNullOrEmpty(rawString) || rawString.Length == 0)
            {
                return "";
            }
            else
            {
                byte[] rawData = System.Text.Encoding.UTF8.GetBytes(rawString.ToString());
                byte[] zippedData = Compress(rawData);
                return (string)(Convert.ToBase64String(zippedData));
            }

        }
        /// <summary>
        /// GZip压缩
        /// </summary>
        /// <param name="rawData"></param>
        /// <returns></returns>
        public static byte[] Compress(byte[] rawData)
        {
            MemoryStream ms = new MemoryStream();
            GZipStream compressedzipStream = new GZipStream(ms, CompressionMode.Compress, true);
            compressedzipStream.Write(rawData, 0, rawData.Length);
            compressedzipStream.Close();
            return ms.ToArray();
        }
        /// <summary>
        /// 将传入的二进制字符串资料以GZip算法解压缩
        /// </summary>
        /// <param name="zippedString">经GZip压缩后的二进制字符串</param>
        /// <returns>原始未压缩字符串</returns>
        public static string GZipDecompressString(string zippedString)
        {
            if (string.IsNullOrEmpty(zippedString) || zippedString.Length == 0)
            {
                return "";
            }
            else
            {

                byte[] zippedData = Convert.FromBase64String(zippedString.ToString());
                return (string)(System.Text.Encoding.UTF8.GetString(Decompress(zippedData)));
            }
        }
        /// <summary>
        /// ZIP解压
        /// </summary>
        /// <param name="zippedData"></param>
        /// <returns></returns>
        public static byte[] Decompress(byte[] zippedData)
        {
            MemoryStream ms = new MemoryStream(zippedData, 2, zippedData.Length - 2);
            DeflateStream zipStream = new DeflateStream(ms, CompressionMode.Decompress, true);
            byte[] bytes = new byte[2048 * 1024];
            int bytesNum = zipStream.Read(bytes, 0, 2048 * 1024);

            byte[] outBytes = new byte[bytesNum];

            for (int i = 0; i < bytesNum; i++)
                outBytes[i] = bytes[i];

            return outBytes;
        }
    }
}