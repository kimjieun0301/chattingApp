using System.Text.Json;

namespace chattingLib
{
    public class CsChatting
    {
        //jsonString을 CsChatting으로 역직렬화하는 함수
        public static CsChatting? Parse(string json) => JsonSerializer.Deserialize<CsChatting>(json)!;
        public string MemId { get; set; }
        public int RoomId { get; set; }
        public string MemName { get; set; }
        public string Message { get; set; }

        public CsChatting()
        {
            MemId = MemName = Message = "";
            RoomId = 0;
        }

        //CsChatting 자체를 직렬화해서 jsonString으로 넘겨주는 함수
        public string ToJsonString() => JsonSerializer.Serialize(this);
    }
}
