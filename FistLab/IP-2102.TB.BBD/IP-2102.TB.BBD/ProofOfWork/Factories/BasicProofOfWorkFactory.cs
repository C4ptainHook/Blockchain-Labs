using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IP_2102.TB.BBD.RandomWrappers;
using Microsoft.Extensions.Logging;

namespace IP_2102.TB.BBD.ProofOfWork.Factories
{
    internal class BasicProofOfWorkFactory : IProofOfWorkFactory<ProofOfWorkArgs>
    {
        private readonly IRandomNumerical<int> _random;
        private readonly ILogger<IProofOfWork> _logger;
        public BasicProofOfWorkFactory(IRandomNumerical<int> random, ILogger<IProofOfWork> logger)
        {
            _random = random;
            _logger = logger;
        }
        public IProofOfWork CreateProofOfWork(ProofOfWorkArgs args)
        {
            return new BasicProofOfWork(_random, args, _logger);
        }
    }
}
