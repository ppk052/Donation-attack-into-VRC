using System;
using System.Text.RegularExpressions;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using WebSocketSharp;

namespace Donation
{ 
    public partial class Toonation
    {
        //투네이션 웹소켓 연결을 위한 사전 변수설정
        //투네이션을 연결하기 위해서는 Payload라는 고유 값이 필요
        string Payload;
        public int ToonationMoney;
        WebSocket ws = null;

        //투네이션 알림을 받기위한 웹소켓 연결, 설정 및 도네 발생알림 설정
        public void Conect(string key)
        {
            LoadtoonationPayload("https://toon.at/widget/alertbox/" + key).GetAwaiter().GetResult();
            ws = new WebSocket("wss://toon.at:8071/" + Payload);
            var pingTimer = new System.Timers.Timer(50000);
            pingTimer.Elapsed += (sender, args) =>
            {
                ws.Ping();
            };
            pingTimer.Enabled = false;
            ws.OnOpen += (sender, e) =>
            {
                pingTimer.Enabled = true;
                toonationconnectedevent(true);
            };
            ws.OnClose += (sender, e) =>
            {
                pingTimer.Enabled = false;
                toonationconnectedevent(false);
            };
            ws.OnMessage += (sender, e) =>
            {
                if (Regex.IsMatch(e.Data.ToString(), @".code.:101"))
                {
                    Match match = Regex.Match(e.Data.ToString(), @"[""']amount[""']:.[\d]*.");
                    string match2 = Regex.Replace(match.Value.ToString(), @"[^0-9]", "");
                    ToonationMoney = Int32.Parse(match2);
                    toonationmoneycomeevent(ToonationMoney);
                }
                else
                {
                }
            };
            ws.OnError += (sender, e) => 
            {
                ws.Close();
            };
            ws.Connect();
        }
        public void Disonnect()
        {
            if (ws != null)
            {
                ws.Close();
            }
        }

        //payload 가져오기
        private async Task LoadtoonationPayload(string url)
        {          
            try
            {
                HttpClient httpClient = new HttpClient();
                using (var response = await httpClient.GetAsync(url))
                {
                    if (HttpStatusCode.OK == response.StatusCode)
                    {
                        string body = await response.Content.ReadAsStringAsync();
                        Match match = Regex.Match(body, @".payload.:.[\w]*.");
                        Match match1 = Regex.Match(match.Value, @"[\w]{8,}");
                        Payload = match1.Value;
                    }
                    else
                    {
                    }
                }

            }
            catch (HttpRequestException ex)
            {
            }
            catch (Exception ex2)
            {
            }
        }
    }
}
