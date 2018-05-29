using System;
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
            if (typeof(T) == typeof(Component)) return (IValidator<T>)new ComponentValidator();
            if (typeof(T) == typeof(Configuration)) return (IValidator<T>)new ConfigurationValidator();
            if (typeof(T) == typeof(Product)) return (IValidator<T>)new ProductValidator();
            if (typeof(T) == typeof(ProductCategory)) return (IValidator<T>)new ProductCategoryValidator();
            if (typeof(T) == typeof(Manufacturer)) return (IValidator<T>)new ManufacturerValidator();
            if (typeof(T) == typeof(Contract)) return (IValidator<T>)new ContractValidator();
            if (typeof(T) == typeof(ContractType)) return (IValidator<T>)new ContractTypeValidator();
            if (typeof(T) == typeof(Task)) return (IValidator<T>)new TaskValidator();

            throw new ArgumentException("T does not implement IValidate<T>");
        }
    }
}
