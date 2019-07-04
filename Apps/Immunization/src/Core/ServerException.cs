﻿/* 
 * Copyright (c) 2014, Furore (info@furore.com) and contributors
 * See the file CONTRIBUTORS for details.
 * 
 * This file is licensed under the BSD 3-Clause license
 * available at https://raw.github.com/furore-fhir/spark/master/LICENSE
 */

using Hl7.Fhir.Model;
using System;
using System.Net;

namespace HealthGateway.Engine.Core
{
    [Serializable]
    public class ServerException : Exception
    {
        public readonly HttpStatusCode StatusCode;

        public OperationOutcome Outcome { get; set; }

        public ServerException(HttpStatusCode statuscode, string message = null) : base(message)
        {
            this.StatusCode = statuscode;
        }
        
        public ServerException(HttpStatusCode statuscode, string message, params object[] values)
            : base(string.Format(message, values))
        {
            this.StatusCode = statuscode;
        }
        
        public ServerException(string message) : base(message)
        {
            this.StatusCode = HttpStatusCode.BadRequest;
        }

        public ServerException(HttpStatusCode statuscode, string message, Exception inner) : base(message, inner)
        {
            this.StatusCode = statuscode;
        }

        public ServerException(HttpStatusCode statuscode, OperationOutcome outcome, string message = null)
            : this(statuscode, message)
        {
            this.Outcome = outcome;
        }
    }
}