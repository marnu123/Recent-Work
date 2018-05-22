﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Classes;

namespace BusinessLayer.Validators
{
    public class ValidatorFactory
    {
        public static IValidator<T> GetValidator<T>()
        {
            if (typeof(T) == typeof(Client)) return (IValidator<T>) new ClientValidator();
            if (typeof(T) == typeof(ClientID)) return (IValidator<T>)new ClientIDValidator();
            if (typeof(T) == typeof(ContractID)) return (IValidator<T>)new ContractIDValidator();
            if (typeof(T) == typeof(Employee)) return (IValidator<T>)new EmployeeValidator();
            if (typeof(T) == typeof(Person)) return (IValidator<T>)new PersonValidator();
            if (typeof(T) == typeof(EmployeeType)) return (IValidator<T>)new EmployeeTypeValidator();
            if (typeof(T) == typeof(NotificationType)) return (IValidator<T>)new NotificationTypeValidator();
            if (typeof(T) == typeof(City)) return (IValidator<T>)new CityValidator();
            if (typeof(T) == typeof(Street)) return (IValidator<T>)new StreetValidator();
            if (typeof(T) == typeof(Location)) return (IValidator<T>)new LocationValidator();

            throw new ArgumentException("T does not implement IValidate<T>");
        }
    }
}