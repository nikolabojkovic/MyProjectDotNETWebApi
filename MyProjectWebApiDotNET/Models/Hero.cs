using MyProjectWebApiDotNET.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MyProjectWebApiDotNET.Models
{
    [Table("Heroes")]
    public class Hero : IEntity
    {
        [JsonProperty(PropertyName = "id")]
        public virtual int Id { get; set; }

        [Required]
        [JsonProperty(PropertyName = "name")]
        public virtual string Name { get; set; }
    }
}