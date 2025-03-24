namespace IdentityService.API.DTOs.UserDTOs;

public record LogInRequest(string Username, string Email, string Password);