﻿using CSharpFunctionalExtensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace FacilityManagement.Core
{
    [Owned]
    public class Address : ValueObject
    {

        public string Street { get; private set; }

        public int? Unit { get; private set; }

        public string City { get; private set; }

        public string Province { get; private set; }

        public string PostalCode { get; private set; }

        protected Address() { }

        private Address(string street, string city, string province, string postalCode)
        {
            Street = street;
            City = city;
            Province = province;
            PostalCode = postalCode;
        }

        private Address(string street, int? unit, string city, string province, string postalCode)
            : this(street, city, province, postalCode)
        {
            Unit = unit;
        }


        public static Result<Address> Create(string street, string city, string province, string postalCode)
        {
            return Result.Success(new Address(street, city, province, postalCode));
        }

        public static Result<Address> Create(string street, int? unit, string city, string province, string postalCode)
        {
            return Result.Success(new Address(street, unit, city, province, postalCode));
        }

        public static Address Default(IConfiguration configuration)
            => Create(
                configuration["DefaultAddress:Street"],
                configuration["DefaultAddress:City"],
                configuration["DefaultAddress:Province"],
                configuration["DefaultAddress:PostalCode"]).Value;

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Street;
            yield return Unit;
            yield return City;
            yield return Province;
            yield return PostalCode;
        }
    }
}