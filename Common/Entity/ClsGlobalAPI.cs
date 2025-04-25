using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Common.Entity
{
    public sealed class ClsGlobalAPIResponse
    { 

        [DataMember]
        public object data { get; set; }

        [DataMember]
        public string message { get; set; }

        [DataMember]
        public string transactionId { get; set; }

        public static ClsGlobalAPIResponse CreateResult(ClsGlobalAPIResponse retDat, bool bitSuccess, object objData, string txtMessage)
        {   
            retDat.data = objData;
            retDat.message = txtMessage;
            retDat.transactionId = Guid.NewGuid().ToString();
            return retDat;
        }
        public static ClsGlobalAPIResponse CreateError(ClsGlobalAPIResponse retDat, bool bitSuccess, object objData, string txtMessage)
        {
            retDat.data = objData;
            retDat.message = txtMessage;
            retDat.transactionId = Guid.NewGuid().ToString();
            return retDat;
        }

    }
}
