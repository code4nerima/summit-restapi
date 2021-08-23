using System;

namespace CfjSummit.Domain.Services.Domain
{
    public static class MultilingualConverter
    {
        private const string Ja = "ja";
        private const string En = "en";
        private const string ZhTw = "zh_tw";
        private const string ZhCn = "zh_cn";

        public static string GetValueByLang(string lang, string ja, string en, string zhTw, string zhCn)
        {
            switch (lang)
            {
                //日本語はそのまま返す
                case Ja: return ja;
                //英語がなければ日本語
                case En: return !string.IsNullOrEmpty(en) ? en : ja;
                case ZhTw:
                case ZhCn:
                    var zh = lang == ZhTw ? zhTw : zhCn;
                    if (!string.IsNullOrEmpty(zh))
                    {
                        //それぞれの中国語を表示
                        return zh;
                    }
                    else
                    {
                        //英語がなければ日本語
                        return !string.IsNullOrEmpty(en) ? en : ja;
                    }

                default:
                    throw new Exception("指定された言語は非対応");
            }
        }
    }
}
