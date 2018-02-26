﻿using System;

namespace Lykke.Service.BitcoinCash.Sign.Core.Exceptions
{
    public class BusinessException : Exception
    {
        public ErrorCode Code { get; private set; }
        public string Text { get; private set; }

        public BusinessException(string text, ErrorCode code)
            : base(text)
        {
            Code = code;
            Text = text;
        }
    }

    public enum ErrorCode
    {
        IncompatiblePrivateKey,

        InvalidScript,
        InputNotFound

    }
}
