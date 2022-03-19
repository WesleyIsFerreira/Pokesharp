﻿using FluentValidation.Results;

namespace JwtLoginAPI.Domain.Queries.Response
{
    public class CreateTokenLoginResponse
    {
        public string Token { get; set; } = String.Empty;
        public bool Success { get; set; } = true;
        public List<ValidationFailure>? Errors { get; set; }
    }
}
