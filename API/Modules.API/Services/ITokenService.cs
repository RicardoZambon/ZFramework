﻿namespace ZFramework.Modules.API.Services
{
    public interface ITokenService
    {
        string GenerateToken(string username);
    }
}