using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutriBase.Logic.Entities
{
    public abstract class VersionEntity : IdentityEntity
    {
        [Timestamp]
        public byte[] RowVersion { get; internal set; } = new byte[0];
    }
}
