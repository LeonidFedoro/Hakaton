﻿namespace hahahton.Services.Interfaces
{
    public interface IHashService
    {
        string HashPassword(string password);
        bool VerifyPassword(string password, string hashedPassword);
    }
}
