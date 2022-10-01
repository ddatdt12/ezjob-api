using AutoMapper;
using EzjobApi.DTOs;
using EzjobApi.Models;

public class UserProfile : Profile
{
  public UserProfile()
  {
    CreateMap<User, UserDto>();
    CreateMap<UserDto, User>();
  }
}