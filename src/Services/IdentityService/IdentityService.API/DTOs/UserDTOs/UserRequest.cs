namespace IdentityService.API.DTOs.UserDTOs;

public record UserRequset(string Username, string FirstName, string LastName, string Email, string Password, string Role);

public record ChangePasswordRequest(string NewPassword);