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
    [DataContract]
    [Table("Callers")]
    public class Caller
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [DataMember]
        [Required]
        public string FullName { get; set; }

        [DataMember]
        [Required]
        [Phone]
        public string Phone { get; set; }
        [DataMember]
        public DateTime? DateOfBirth { get; set; }
        [DataMember]
        public string LocationAddress { get; set; }


        public ICollection<Ticket> Tickets { get; set; }
        public Caller()
        {
            Tickets = new List<Ticket>();
        }
    }
}
