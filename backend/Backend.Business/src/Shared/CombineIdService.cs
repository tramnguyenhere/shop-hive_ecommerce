using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Business.src.Shared
{
    public class CombineIdService
    {
        public static Guid CombineIds(Guid firstId, Guid secondId)
        {
            byte[] bytes = firstId.ToByteArray().Concat(secondId.ToByteArray()).ToArray();
            return new Guid(bytes);
        }
    }
}
