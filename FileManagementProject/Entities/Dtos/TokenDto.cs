﻿namespace FileManagementProject.Entities.Dtos
{
    public record TokenDto
    {
        public String AccessToken { get; init; }
        public String RefreshToken { get; init; }
    }
}
