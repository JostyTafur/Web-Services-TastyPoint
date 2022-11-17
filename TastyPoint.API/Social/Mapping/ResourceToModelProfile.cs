﻿using AutoMapper;
using TastyPoint.API.Social.Domain.Models;
using TastyPoint.API.Social.Resources;

namespace TastyPoint.API.Social.Mapping;

public class ResourceToModelProfile:Profile
{
    protected ResourceToModelProfile()
    {
        CreateMap<SaveFoodStoreResource, FoodStore>();
        CreateMap<SaveCommentResource, Comment>();
    }
}