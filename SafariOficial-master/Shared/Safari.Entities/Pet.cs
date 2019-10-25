using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using static Safari.Entities.Enums;

namespace Safari.Entities
{
    public class Pet : EntityBase
    {
        [DataMember]
        [DisplayName("Id")]
        public override int Id { get; set; }

        [DataMember]
        [DisplayName("Name")]
        public string Name { get; set; }

        [DataMember]
        [DisplayName("Gender")]
        public int Gender { get; set; }

        [DataMember]
        [DisplayName("OwnerName")]
        public string OwnerName { get; set; }

    }
}
