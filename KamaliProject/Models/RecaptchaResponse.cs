﻿using Newtonsoft.Json;
using System.Collections.Generic;

namespace KamaliProject.Models
{
	public class RecaptchaResponse
	{
        [JsonProperty("success")]
        public bool Success { get; set; }

        [JsonProperty("challenge_ts")]
        public string ValidatedDateTime { get; set; }

        [JsonProperty("hostname")]
        public string HostName { get; set; }

        [JsonProperty("error-codes")]
        public List<string> ErrorCodes { get; set; }
    }
}