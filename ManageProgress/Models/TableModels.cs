using Newtonsoft.Json;
using System;

namespace ManageProgress.Models
{
    public class ProgressModel
    {
        [JsonProperty(PropertyName = "id")]
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
        [JsonIgnore]
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "progressId")]
        public int ProgressId { get; set; }

        [JsonProperty(PropertyName = "participantName")]
        public string ParticipantName { get; set; }

        [JsonProperty(PropertyName = "currentProgress")]
        public int CurrentProgress { get; set; }
    }

    public class UserModel
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }

}