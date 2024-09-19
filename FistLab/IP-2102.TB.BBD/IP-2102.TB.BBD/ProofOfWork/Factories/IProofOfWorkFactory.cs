using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IP_2102.TB.BBD.ProofOfWork.Factories
{
    internal interface IProofOfWorkFactory<ArgType> where ArgType : struct
    {
        IProofOfWork CreateProofOfWork(ArgType args);
    }
}
