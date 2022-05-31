using System.Text.Json.Serialization;

namespace net6.webapi;

public class StravaEventData
{
    [JsonPropertyName("object_type")]
    public string ObjectType { get; set; }
    [JsonPropertyName("object_id")]
    public long ObjectId { get; set; }
    [JsonPropertyName("aspect_type")]
    public string AspectType { get; set; }
    [JsonPropertyName("owner_id")]
    public long OwnerId { get; set; }
    [JsonPropertyName("subscription_id")]
    public int SubscriptionId { get; set; }
    [JsonPropertyName("event_time")]
    public long EventTime { get; set; }
    [JsonPropertyName("updates")]
    public Update Updates { get; set; }

    public StravaEventData()
    {
        Updates = new Update();
    }
}

public class Update
{
    public string Title { get; set; }
    public string Type { get; set; }
    public bool Private { get; set; }
}