﻿namespace AW.Models.Mapper
{
    using AutoMapper;
    public class AWMapperProfile : Profile
    {
        public AWMapperProfile()
        {
            CreateMap<DataAccess.Entities.Person, Person>()
                .ReverseMap();

            CreateMap<DataAccess.Entities.AWBuildVersion, BuildVersion>()
                .ReverseMap();

            CreateMap<DataAccess.Entities.EmailAddress, EmailAddress>()
                .ReverseMap();

            CreateMap<DataAccess.Entities.PersonPhone, PersonPhone>()
                .ReverseMap();

            CreateMap<DataAccess.Entities.PhoneNumberType, PhoneNumberType>()
                .ReverseMap();

            CreateMap<DataAccess.Entities.Customer, Customer>()
                .ForMember(dest => dest.BusinessEntityID, opt => opt.MapFrom(src => src.Person.BusinessEntityID))
                .ForMember(dest => dest.PersonType, opt => opt.MapFrom(src => src.Person.PersonType))
                .ForMember(dest => dest.NameStyle, opt => opt.MapFrom(src => src.Person.NameStyle))
                .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Person.Title))
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.Person.FirstName))
                .ForMember(dest => dest.MiddleName, opt => opt.MapFrom(src => src.Person.MiddleName))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.Person.LastName))
                .ForMember(dest => dest.Suffix, opt => opt.MapFrom(src => src.Person.Suffix))
                .ForMember(dest => dest.EmailPromotion, opt => opt.MapFrom(src => src.Person.EmailPromotion))
                .ForMember(dest => dest.AdditionalContactInfo, opt => opt.MapFrom(src => src.Person.AdditionalContactInfo))
                .ForMember(dest => dest.Demographics, opt => opt.MapFrom(src => src.Person.Demographics))
                .ForMember(dest => dest.EmailAddresses, opt => opt.MapFrom(src => src.Person.EmailAddresses))
                .ForMember(dest => dest.PersonPhones, opt => opt.MapFrom(src => src.Person.PersonPhones))
                .ReverseMap();
        }
    }
}
