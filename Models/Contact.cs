using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tandem.Models
{
    using Newtonsoft.Json;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Contact Schema
    /// </summary>
    public class Contact
    {
        [JsonProperty(PropertyName = "id")]
        [Required]
        public string Id { get; set; }

        [Required]
        [MaxLength(50)]
        [JsonProperty(PropertyName = "firstname")]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(50)]
        [JsonProperty(PropertyName = "middlename")]
        public string MiddleName { get; set; }

        [Required]
        [MaxLength(50)]
        [JsonProperty(PropertyName = "lastname")]
        public string LastName { get; set; }

        [Required]
        [MaxLength(10)]
        [JsonProperty(PropertyName = "phonenumber")]
        public string PhoneNumber { get; set; }

        [Required]
        [MaxLength(50)]
        [JsonProperty(PropertyName = "emailaddress")]
        public string EmailAddress { get; set; }
    }

    /// <summary>
    /// Post Contact Schema
    /// </summary>
    public class PostContact
    {
        [Required]
        [MaxLength(50)]
        [JsonProperty(PropertyName = "firstname")]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(50)]
        [JsonProperty(PropertyName = "middlename")]
        public string MiddleName { get; set; }

        [Required]
        [MaxLength(50)]
        [JsonProperty(PropertyName = "lastname")]
        public string LastName { get; set; }

        [Required]
        [MaxLength(10)]
        [JsonProperty(PropertyName = "phonenumber")]
        public string PhoneNumber { get; set; }

        [Required]
        [MaxLength(50)]
        [JsonProperty(PropertyName = "emailaddress")]
        public string EmailAddress { get; set; }
    }
}
