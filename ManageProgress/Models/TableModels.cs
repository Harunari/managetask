using Newtonsoft.Json;
using System;

namespace ManageProgress.Models
{
    public class ProgressModel
    {
        [JsonProperty(PropertyName ="id")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "userId")]
        public string UserId { get; set; }

        [JsonProperty(PropertyName = "title")]
        public string Title { get; set; }

        [JsonProperty(PropertyName = "dateTimeRegistered")]
        public DateTime DateTimeRegistered { get; set; }

        [JsonProperty(PropertyName = "numberOfItems")]
        public int NumberOfTask { get; set; }

        [JsonIgnore]
        [JsonProperty(PropertyName = "password")]
        public string Password { get; set; }
    }

    public class TaskModel
    {
        [JsonIgnore]
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "progressId")]
        public int ProgressId { get; set; }

        [JsonProperty(PropertyName = "task")]
        public string Task { get; set; }
    }

    public class ParticipantModel
    {
        public int Id { get; set; }
        public int ProgressId { get; set; }
        public string ParticipantName { get; set; }
        public int CurrentProgress { get; set; }
    }
}