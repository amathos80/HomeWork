using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeWorkServices.Models
{
    public class BaseEntity<Tkey>
    {
        public Tkey Id { get; set; }
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            BaseEntity<Tkey> baseEntity = obj as BaseEntity<Tkey>;

            if (baseEntity == null)
                return false;

            return baseEntity.Id.Equals(Id);
        }

        public override int GetHashCode()
        {
            if (Equals(Id, default(Tkey)))
                return base.GetHashCode();
            return Id.GetHashCode();
        }
    }
}
