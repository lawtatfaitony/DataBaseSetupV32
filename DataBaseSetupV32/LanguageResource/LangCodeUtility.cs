using Caching;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Threading;

namespace LanguageResource
{
    public enum LangParamsType { Route= 1,CultureUI= 2 }
      
    public partial class LangUtilities
    {
        public static readonly FIFOCache<string, byte[]> cache = RunTimeCache.FIFOCache();
        
        /// <summary>
        /// LanguageCode 這個方式只適合 統一系統，非用戶定制語言版。
        /// </summary>
        public static string LanguageCode
        {
            get
            {
                string _language = "en-US";

                //Method I
                bool tryGetCache = cache.TryGet("Language", out byte[] bytLanguage);
                if(tryGetCache)
                {
                    _language = System.Text.Encoding.UTF8.GetString(bytLanguage);
                    //Console.WriteLine("Language Code from cache {0}", _language);
                    return _language;
                }
                //Method II
                _language = ReadLanguageCodeFormJson();
                if(_language == string.Empty)
                {
                    try
                    { 
                        _language = Thread.CurrentThread.CurrentCulture.Name;
                    }
                    catch
                    {
                       throw;
                    }
                }
                else
                {
                    cache.AddReplace("Language", System.Text.Encoding.Default.GetBytes(_language));
                    return _language;
                }
                // Standardize LanguageCode
                _language = StandardLanguageCode(_language);

                try
                {
                    //Localize
                    Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(_language);
                    Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(_language);
                }
                catch
                {
                    throw;
                }

                return _language;  
            }
            set
            { 
                try
                {
                    string LanguageCode = StandardLanguageCode(value); 
                    cache.AddReplace("Language", System.Text.Encoding.Default.GetBytes(LanguageCode));
                    bool saveResult = SaveLanguageCodeToLocal(LanguageCode);
                }
                catch
                {
                    throw;
                }
            }
        }
        
        //把 Language 转换为 Language.Field (表格字段)
        public static string GetLanguageAbbr(string LanguageCode)
        {
            if (LanguageCode == "zh-CN" || LanguageCode == "zh-HK" || LanguageCode == "en-US")
            {
                return LanguageCode;
            }
            else
            {
                //只取前面两位语言代码, 例如 : zh:华语, en:泛英 fr:法语区
                LanguageCode = LanguageCode.Substring(0,2).ToLower();
                return LanguageCode;
            }
        }

        public static bool SaveLanguageCodeToLocal(string Language)
        {
            Language = StandardLanguageCode(Language);
             
            string appPath = System.Environment.CurrentDirectory; ; 
            string fileName = string.Format("{0}.json", "Language");
            string pathFileName = Path.Combine(appPath, fileName);

            SelectLanguageCode selectLanguageCode = new SelectLanguageCode
            {
                Language = LanguageCode,
                IsDefault = true
            };
            string FileContent = JsonConvert.SerializeObject(selectLanguageCode);
            bool saveResult = SaveDataJson(FileContent, pathFileName);
            return saveResult;
        }
        public static bool SaveDataJson(string FileContent, string PathFile)
        {
            StreamWriter writer = null;
            try
            {
                writer = new StreamWriter(PathFile, false, System.Text.Encoding.GetEncoding("UTF-8"));
                writer.Write(FileContent);
            }
            catch
            {
                return false;
            }
            finally
            {
                if (writer != null)
                    writer.Close();
            }

            return true;
        }

        public static string ReadLanguageCodeFormJson()
        { 
            string appPath = System.Environment.CurrentDirectory;
            string fileName = string.Format("{0}.json", "LanguageConfig");
            string pathFileName = Path.Combine(appPath, fileName);
             
            //if has json file and modified date is today 
            if (System.IO.File.Exists(pathFileName))
            {
                string JsonFileText = string.Empty;
                try
                {
                    using (FileStream fs = new FileStream(pathFileName, FileMode.Open, System.IO.FileAccess.Read, FileShare.Read))
                    {
                        using (StreamReader sr = new StreamReader(fs, System.Text.Encoding.GetEncoding("UTF-8")))
                        {
                            JsonFileText = sr.ReadToEnd().ToString();
                            SelectLanguageCode selectLanguageCode = JsonConvert.DeserializeObject<SelectLanguageCode>(JsonFileText);
                            return selectLanguageCode.Language;
                        }
                    }
                }
                catch
                {
                    return string.Empty;
                } 
            }
            else
            {
                return string.Empty;
            }
        }
        public static string StandardLanguageCode(string Language)
        {
            string LanguageCode = "zh-CN";

            if(Language.Length ==2)
            {
                Language = Language.ToLower();
            }
            switch (Language)
            {
                case "zh-CN":
                    LanguageCode = "zh-CN";
                    break;
                case "zh-HK":
                    LanguageCode = "zh-HK";
                    break;
                case "en-US":
                    LanguageCode = "en-US";
                    break;
                case "zh-Hant-HK":
                    LanguageCode = "zh-HK";
                    break;
                case "zh-TW":
                    LanguageCode = "zh-HK";
                    break;
                case "en-UK":
                    LanguageCode = "en-US";
                    break;
                case "zh-Hant-AO":
                    LanguageCode = "zh-HK";
                    break;
                case "zh":
                    LanguageCode = "zh-CN";
                    break;
                case "cn":
                    LanguageCode = "zh-CN";
                    break;
                case "en":
                    LanguageCode = "en-US";
                    break;
                case "hk":
                    LanguageCode = "zh-HK";
                    break;
                default:
                    LanguageCode = "zh-CN";
                    break;
            }

            return LanguageCode;
        }
    } 

    public class SelectLanguageCode
    {
        public string Language { get; set; }
        public bool IsDefault { get; set; }
    }
}
