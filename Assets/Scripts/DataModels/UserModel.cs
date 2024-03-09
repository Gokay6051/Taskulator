using System;
using System.Collections.Generic;
using Realms;
using MongoDB.Bson;

public partial class UserModel : IRealmObject
{
    [MapTo("_id")]
    [PrimaryKey]
    public ObjectId Id { get; set; }

    [Required]
    public string Password { get; set; }

    [Required]
    public string Type { get; set; }

    [Required]
    public string UserId { get; set; }

    [Required]
    [MapTo("id")]
    public string _Id { get; set; }
}
