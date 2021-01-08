using System;
using System.Text.RegularExpressions;

/// <summary>
/// RMB
/// </summary>
namespace Miracle.Common.Utility.RMB
{
    /// <summary>
    /// 人民币工具类
    /// </summary>
    public static class RmbTools
    {
        /// <summary> 
        /// 转换人民币大小金额 
        /// </summary> 
        /// <param name="num">金额</param> 
        /// <returns>返回大写形式</returns> 
        public static string ConvertToChinese(decimal number)
        {
            try
            {
                var s = number.ToString("#L#E#D#C#K#E#D#C#J#E#D#C#I#E#D#C#H#E#D#C#G#E#D#C#F#E#D#C#.0B0A");
                var d = Regex.Replace(s, @"((?<=-|^)[^1-9]*)|((?'z'0)[0A-E]*((?=[1-9])|(?'-z'(?=[F-L\.]|$))))|((?'b'[F-L])(?'z'0)[0A-L]*((?=[1-9])|(?'-z'(?=[\.]|$))))", "${b}${z}");
                return Regex.Replace(d, ".", m => "负元空零壹贰叁肆伍陆柒捌玖空空空空空空空分角拾佰仟万亿兆京垓秭穰"[m.Value[0] - '-'].ToString());
            }
            catch (Exception ex)
            {
                throw new Exception("转化为中文汉字大写失败!", ex);
            }
        }

        /// <summary> 
        /// 转换人民币大小金额 
        /// </summary> 
        /// <param name="numstr">金额</param> 
        /// <returns>返回大写形式</returns>
        public static string ConvertToChinese(string numstr)
        {
            try
            {
                return ConvertToChinese(Convert.ToDecimal(numstr));
            }
            catch (Exception ex)
            {
                throw new Exception("数据类型异常,转化为中文汉字大写失败!", ex);
            }
        }

        /// <summary>
        /// 数字转化为中文大写,当数据过大存在溢出风险,推荐使用ConvertToChinese()
        /// </summary>
        /// <param name="Num">金额</param>
        /// <returns>返回大写形式</returns>
        [Obsolete]
        public static string NumToChineseStr(decimal Num)
        {
            try
            {
                string[] DX_SZ = { "零", "壹", "贰", "叁", "肆", "伍", "陆", "柒", "捌", "玖", "拾" };//大写数字  
                string[] DX_DW = { "元", "拾", "佰", "仟", "万", "拾", "佰", "仟", "亿", "拾", "佰", "仟", "万" };
                string[] DX_XSDS = { "角", "分" };//大些小数单位  
                if (Num == 0) return DX_SZ[0];
                bool IsXS_bool = false;//是否小数  
                string NumStr;//整个数字字符串  
                string NumStr_Zs;//整数部分  
                string NumSr_Xs = "";//小数部分  
                string NumStr_R = "";//返回的字符串
                NumStr = Num.ToString();
                NumStr_Zs = NumStr;
                if (NumStr_Zs.Contains("."))
                {
                    NumStr = Math.Round(Num, 2).ToString();
                    NumStr_Zs = NumStr.Substring(0, NumStr.IndexOf("."));
                    NumSr_Xs = NumStr.Substring(NumStr.IndexOf(".") + 1, NumStr.Length - NumStr.IndexOf(".") - 1);
                    IsXS_bool = true;
                }
                int k = 0;
                bool IsZeor = false;//整数中间连续0的情况  
                for (int i = 0; i < NumStr_Zs.Length; i++) //整数  
                {
                    int j = int.Parse(NumStr_Zs.Substring(i, 1));
                    if (j != 0)
                    {
                        NumStr_R += DX_SZ[j] + DX_DW[NumStr_Zs.Length - i - 1];
                        IsZeor = false; //没有连续0  
                    }
                    else if (j == 0)
                    {
                        k++;
                        if (!IsZeor && !(NumStr_Zs.Length == i + 1)) //等于0不是最后一位，连续0取一次  
                        {
                            //有问题  
                            if (NumStr_Zs.Length - i - 1 >= 4 && NumStr_Zs.Length - i - 1 <= 6)
                                NumStr_R += DX_DW[4] + "零";
                            else
                                if (NumStr_Zs.Length - i - 1 > 7)
                                NumStr_R += DX_DW[8] + "零";
                            else
                                NumStr_R += "零";
                            IsZeor = true;
                        }
                        if (NumStr_Zs.Length == i + 1)//  等于0且是最后一位 变成 XX元整  
                            NumStr_R += DX_DW[NumStr_Zs.Length - i - 1];
                    }
                }
                if (NumStr_Zs.Length > 2 && k == NumStr_Zs.Length - 1)
                    NumStr_R = NumStr_R.Remove(NumStr_R.IndexOf('零'), 1); //比如1000，10000元整的情况下 去0  
                if (!IsXS_bool)
                    return $"{NumStr_R}整"; //如果没有小数就返回  
                else
                {
                    for (int i = 0; i < NumSr_Xs.Length; i++)
                    {
                        int j = int.Parse(NumSr_Xs.Substring(i, 1));
                        NumStr_R += DX_SZ[j] + DX_XSDS[NumSr_Xs.Length - i - 1];
                    }
                }
                return NumStr_R;
            }
            catch (Exception ex)
            {
                throw new Exception("转化为中文汉字大写失败!", ex);
            }
        }
    }
}
