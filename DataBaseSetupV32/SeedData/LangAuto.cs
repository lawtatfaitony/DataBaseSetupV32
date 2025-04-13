using LanguageResource;
using DataBaseSetupV3.Model;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace DataBaseSetupV3.SeedData
{
    /// <summary>
    /// 第三個參數是 localeID 的部分, 分別包含了 zh-TW (0x0404), zh-CN (0x0840), ko-KR (0x0412), en (0x0009), 
    /// </summary>
    public class LangAuto
    {
        private DataBaseContext dataBaseContext;
        public LangAuto(DataBaseContext baseContext)
        {
            dataBaseContext = baseContext;
        }
        public static string Auto(string source)
        {
            if(LangUtilities.LanguageCode == "zh-CN")
            {
                try
                {
                    source = Microsoft.VisualBasic.Strings.StrConv(source, Microsoft.VisualBasic.VbStrConv.SimplifiedChinese, 0x0009);
                    return source;
                }
                catch
                {
                    return source;
                }           
            }
            else
            {
                try
                {
                    source = Microsoft.VisualBasic.Strings.StrConv(source, Microsoft.VisualBasic.VbStrConv.TraditionalChinese, 0x0009);
                    return source;
                }
                catch
                {
                    return source;
                }
            } 
        }
    }
    public static class ChineseStringUtilityXXX
    {
        internal const int LOCALE_SYSTEM_DEFAULT = 0x0800;
        internal const int LCMAP_SIMPLIFIED_CHINESE = 0x02000000;
        internal const int LCMAP_TRADITIONAL_CHINESE = 0x04000000;

        [DllImport("kernel32", CharSet = CharSet.Auto, SetLastError = true)]
        internal static extern int LCMapString(int Locale, int dwMapFlags, string lpSrcStr, int cchSrc, [Out] string lpDestStr, int cchDest);
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        private static extern int LCMapStringEx(
                   string lpLocaleName,        //  LPCWSTR      lpLocaleName
                   uint dwMapFlags,        //  DWORD        dwMapFlags
                   string lpSrcStr,        //  LPCWSTR      lpSrcStr
                   int cchSrc,             //  int          cchSrc
                   [Out] string lpDestStr,           //  LPWSTR       lpDestStr
                   int cchDest,            //  int          cchDest
                   IntPtr lpVersionInformation,    //  LPNLSVERSIONINFO lpVersionInformation
                   IntPtr lpReserved,          //  LPVOID       lpReserved
                   IntPtr sortHandle);         //  LPARAM       sortHandle

        public static string ToSimplified(string source)
        {
            String target = new String(' ', source.Length);
            int ret = LCMapString(LOCALE_SYSTEM_DEFAULT, LCMAP_SIMPLIFIED_CHINESE, source, source.Length, target, source.Length);
            return target;
        }
        public static string ToTraditional(string source)
        {
            String target = new String(' ', source.Length);
            int ret = LCMapString(LOCALE_SYSTEM_DEFAULT, LCMAP_TRADITIONAL_CHINESE, source, source.Length,target, source.Length);
            return target;
        }
        public static string ToSimplifiedEx(string argSource)
        {
            var t = new String(' ', argSource.Length);
            //var t = new StringBuilder(argSource.Length);
            LCMapStringEx("zh-CN", LCMAP_SIMPLIFIED_CHINESE, argSource, argSource.Length, t, argSource.Length, IntPtr.Zero, IntPtr.Zero, IntPtr.Zero);
            return t;
        }

        public static string ToTraditionalEx(string argSource)
        {
            var t = new String(' ', argSource.Length);
            LCMapStringEx("zh-CN", LCMAP_TRADITIONAL_CHINESE, argSource, argSource.Length, t, argSource.Length, IntPtr.Zero, IntPtr.Zero, IntPtr.Zero);
            return t.ToString();
        }
    }
}
