﻿using IP_2102.TB.BBD.CryptoChain;

namespace IP_2102.TB.BBD.Mining
{
    internal interface IMiner
    {
        IBlockChain Mine(int numberOfBlocks);
    }
}