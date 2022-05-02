using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Text.RegularExpressions;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using WebSocketSharp;


namespace Donation
{
    public partial class Twip
    {
        private readonly HttpClient httpClient = new HttpClient();
        private string Token;
        private string Tokenutf8;
        private string Version;
        public int TwipMoney;
        WebSocket ws = null;

        public void Connect(string key)
        {
            LoadTwiptoken("https://twip.kr/widgets/alertbox/" + key).GetAwaiter().GetResult();  // Main함수에서 await Test(httpsUrl) 사용못하므로, 이를 대신함
            ws = new WebSocket("wss://io.mytwip.net/socket.io/?alertbox_key=" + key + "&version=" + Version + "&token=" + Tokenutf8 + "&transport=websocket");
            var pingTimer = new System.Timers.Timer(22000);
            pingTimer.Elapsed += (sender, args) =>
            {
                ws.Send("2");
            };
            pingTimer.Enabled = false;
            ws.OnOpen += (sender, e) =>
            {
                Console.WriteLine("Twip = " + ws.ReadyState.ToString());
                pingTimer.Enabled = true;
                twipconnectedevent(true);
            };
            ws.OnClose += (sender, e) =>
            {
                Console.WriteLine("Twip is Closed");
                Console.WriteLine(e.Reason);
                pingTimer.Enabled = false;
                twipconnectedevent(false);
            };
            ws.OnMessage += (sender, e) =>
            {
                if (Regex.IsMatch(e.Data.ToString(), @".amount.:[\d]*") && Regex.IsMatch(e.Data.ToString(), @"new donate"))
                {
                    Match match = Regex.Match(e.Data.ToString(), @".amount.:[\d]*");
                    Match match2 = Regex.Match(match.Value.ToString(), @"[0-9]{4,}");
                    TwipMoney = Int32.Parse(match2.Value.ToString());
                    twipmoneycomeevent(TwipMoney);
                }
                else
                {

                }
            };
            ws.OnError += (sender, e) =>
            {
                Console.WriteLine("Error:" + e.Message);
                pingTimer.Enabled = false;
                ws.Close();
            };

            ws.Connect();
        }

        public void Disconnect()
        {
            if(ws != null)
            {
                ws.Close();
            }
        }
        private async Task LoadTwiptoken(string url)
        {
            try
            {
                using (var response = await httpClient.GetAsync(url))
                {
                    if (HttpStatusCode.OK == response.StatusCode)
                    {
                        string body = await response.Content.ReadAsStringAsync();
                        Match match = Regex.Match(body, @"__TOKEN__ = '[\w\W]*'");
                        Match match1 = Regex.Match(match.Value, @"'[\w\W]*'");
                        Token = Regex.Replace(match1.Value.ToString(), "'", "");
                        Match match2 = Regex.Match(body, @"version: '[\d\W]*'");
                        Match match3 = Regex.Match(match2.Value, @"'[\d\W]*'");
                        Version = Regex.Replace(match3.Value.ToString(), "'", "");

                        //인코딩 방식을 지정
                        System.Text.Encoding utf8 = System.Text.Encoding.UTF8;

                        //변환하고자 하는 문자열을 UTF8 방식으로 변환하여 byte 배열로 반환
                        byte[] utf8Bytes = utf8.GetBytes(Token);

                        //UTF-8을 string으로 변한
                        string utf8String = "";
                        foreach (byte b in utf8Bytes)
                        {
                            utf8String += "%" + String.Format("{0:X}", b);

                        }
                        Tokenutf8 = utf8String;
                    }
                    else
                    {
                        Console.WriteLine($" -- response.ReasonPhrase ==> {response.ReasonPhrase}");
                    }

                }

            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"ex.Message={ex.Message}");
                Console.WriteLine($"ex.InnerException.Message = {ex.InnerException.Message}");

                Console.WriteLine($"----------- 서버에 연결할수없습니다 ---------------------");
            }
            catch (Exception ex2)
            {
                Console.WriteLine($"Exception={ex2.Message}");
            }
        }
    }
}
