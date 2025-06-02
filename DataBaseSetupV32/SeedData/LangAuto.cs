using AttendanceBussiness.DbFirst;
using LanguageResource;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;
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
            if (LangUtilities.LanguageCode == "zh-CN")
            {
                try
                {
#if WINDOWS
                    source = Microsoft.VisualBasic.Strings.StrConv(source, Microsoft.VisualBasic.VbStrConv.SimplifiedChinese, 0x0009);
#endif
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
#if WINDOWS
                    source = Microsoft.VisualBasic.Strings.StrConv(source, Microsoft.VisualBasic.VbStrConv.TraditionalChinese, 0x0009);
#endif
                    return source;
                }
                catch
                {
                    return source;
                }
            }
        }
    } 
}
