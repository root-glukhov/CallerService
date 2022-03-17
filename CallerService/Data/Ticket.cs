using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CallerService.Data
{
    public enum TicketType
    {
        Call,
        Email,
        SMS
    }

    [DataContract]
    [Table("Tickets")]
    public class Ticket
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [DataMember]
        [Required]
        public TicketType Type { get; set; }

        [DataMember]
        [Required]
        public string Message { get; set; }

        [DataMember]
        [Required]
        public string Source { get; set; }

        [DataMember]
        [Required]
        public int CallerId { get; set; }
        public Caller Caller { get; set; }

        [Required]
        public DateTime Created { get; set; }
    }
}
