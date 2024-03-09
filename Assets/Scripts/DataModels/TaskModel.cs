using System;
using System.Collections.Generic;
using Realms;
using MongoDB.Bson;
using Realms.Schema;
using Realms.Weaving;

public partial class TaskModel : IRealmObject
{
    [MapTo("_id")]
    [PrimaryKey]
    public ObjectId Id { get; set; }

    [Required]
    public string TaskMain { get; set; }

    [Required]
    public string TaskTitle { get; set; }

    [Required]
    public string Type { get; set; }

    [Required]
    public string UserId { get; set; }

    [Required]
    [MapTo("id")]
    public string _Id { get; set; }
}
