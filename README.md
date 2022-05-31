# Web Api Model Binding Runtime Comparison


This solution tests the default model binding behaviour between .net core 3.1 web api applications & .net 6 web api applications.

Start both web api applications.


Then make the following POST request to each:

.NET Core 3.1 Url: http://localhost:8080/api/stravatest

.NET 6 Url: http://localhost:8081/api/stravatest

Headers: [Content-Type: application/json]

Body:

    {
        "aspect_type": "update",
        "event_time": 12345,
        "object_id": 12345,
        "object_type": "activity",
        "owner_id": 12345,
        "subscription_id": 12345,
        "updates": {
            "title": "TestActivity"        
        }
    }

You will notice that the .net 3.1 web api application responds with a http status of 204 no content & the .net 6 web api application responds with a http status of 400 bad request due to the updates.type field not being populated.

Why does this behaviour differ between runtimes?

This breaks the strava web hook functionality when hosting on .net 6 with the following model definition.


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

To resolve you need to exclude the Update.Type field from your model.

The same model definiion works fine on .net core 3.1 as this solution demonstrates.